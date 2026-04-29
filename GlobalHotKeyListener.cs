using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AutoClicker
{
    public class GlobalHotKeyListener : IDisposable
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private const uint MOD_CONTROL = 0x0002;
        private const uint MOD_ALT = 0x0001;
        private const uint MOD_SHIFT = 0x0004;
        private const uint MOD_WIN = 0x0008;

        private IntPtr windowHandle;
        private int nextHotKeyId = 1;
        private Dictionary<int, Keys> registeredHotKeys = new();

        public event Action<Keys>? HotKeyPressed;

        public GlobalHotKeyListener()
        {
            // Criar uma janela invisível para capturar os hotkeys
            var form = new HiddenForm(this);
            windowHandle = form.Handle;
        }

        public void RegisterHotKey(Keys keys)
        {
            uint modifiers = 0;
            uint vk = 0;

            // Extrair modificadores
            if ((keys & Keys.Control) == Keys.Control) modifiers |= MOD_CONTROL;
            if ((keys & Keys.Alt) == Keys.Alt) modifiers |= MOD_ALT;
            if ((keys & Keys.Shift) == Keys.Shift) modifiers |= MOD_SHIFT;

            // Extrair tecla principal
            Keys mainKey = keys & ~(Keys.Control | Keys.Alt | Keys.Shift);
            vk = (uint)mainKey;

            if (RegisterHotKey(windowHandle, nextHotKeyId, modifiers, vk))
            {
                registeredHotKeys[nextHotKeyId] = keys;
                nextHotKeyId++;
            }
        }

        public void OnHotKeyPressed(int hotKeyId)
        {
            if (registeredHotKeys.TryGetValue(hotKeyId, out var keys))
            {
                HotKeyPressed?.Invoke(keys);
            }
        }

        public void Dispose()
        {
            foreach (var id in registeredHotKeys.Keys.ToList())
            {
                UnregisterHotKey(windowHandle, id);
            }
            registeredHotKeys.Clear();
        }
    }

    public class HiddenForm : Form
    {
        private GlobalHotKeyListener? listener;

        public HiddenForm(GlobalHotKeyListener listener)
        {
            this.listener = listener;
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new System.Drawing.Size(0, 0);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312) // WM_HOTKEY
            {
                int hotKeyId = m.WParam.ToInt32();
                listener?.OnHotKeyPressed(hotKeyId);
            }
            base.WndProc(ref m);
        }
    }
}
