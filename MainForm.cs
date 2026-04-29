using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;

namespace AutoClicker
{
    public partial class MainForm : Form
    {
        // P/Invoke para simular mouse clicks
        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        private const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const uint MOUSEEVENTF_LEFTUP = 0x0004;

        private bool isClicking = false;
        private int clicksPerSecond = 10;
        private System.Timers.Timer? clickTimer;
        private GlobalHotKeyListener? hotKeyListener;

        public MainForm()
        {
            InitializeComponent();
            InitializeHotKey();
        }

        private void InitializeHotKey()
        {
            hotKeyListener = new GlobalHotKeyListener();
            hotKeyListener.HotKeyPressed += (keys) =>
            {
                if (keys == (Keys.Control | Keys.Alt | Keys.A))
                {
                    ToggleClicker();
                }
            };
            hotKeyListener.RegisterHotKey(Keys.Control | Keys.Alt | Keys.A);
        }

        private void ToggleClicker()
        {
            isClicking = !isClicking;
            buttonStartStop.Text = isClicking ? "PARANDO..." : "INICIANDO...";
            buttonStartStop.BackColor = isClicking ? Color.Red : Color.LimeGreen;

            if (isClicking)
            {
                StartClicking();
            }
            else
            {
                StopClicking();
            }

            labelStatus.Text = $"Status: {(isClicking ? "ATIVO ✓" : "PARADO ✗")}";
            labelStatus.ForeColor = isClicking ? Color.Green : Color.Red;
        }

        private void StartClicking()
        {
            int intervalMs = 1000 / clicksPerSecond;
            clickTimer = new System.Timers.Timer(intervalMs);
            clickTimer.Elapsed += (sender, e) =>
            {
                PerformClick();
            };
            clickTimer.AutoReset = true;
            clickTimer.Start();
        }

        private void StopClicking()
        {
            if (clickTimer != null)
            {
                clickTimer.Stop();
                clickTimer.Dispose();
                clickTimer = null;
            }
        }

        private void PerformClick()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        private void TrackBarSpeed_ValueChanged(object sender, EventArgs e)
        {
            clicksPerSecond = trackBarSpeed.Value;
            labelSpeed.Text = $"Velocidade: {clicksPerSecond} cliques/s";

            // Se está clicando, reinicia com a nova velocidade
            if (isClicking)
            {
                StopClicking();
                StartClicking();
            }
        }

        private void ButtonStartStop_Click(object sender, EventArgs e)
        {
            ToggleClicker();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopClicking();
            hotKeyListener?.Dispose();
        }
    }
}
