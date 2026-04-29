using System;
using System.Windows.Forms;
using System.Drawing;

namespace AutoClicker
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.ClientSize = new System.Drawing.Size(350, 280);
            this.Name = "MainForm";
            this.Text = "AutoClicker - Jogos Idle";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Icon = SystemIcons.Application;
            this.FormClosing += new FormClosingEventHandler(MainForm_FormClosing);

            // Label Título
            var labelTitle = new Label
            {
                Text = "🎮 AUTO CLICKER",
                Font = new System.Drawing.Font("Arial", 16, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.DarkBlue,
                AutoSize = true,
                Location = new System.Drawing.Point(70, 15)
            };

            // Label Status
            labelStatus = new Label
            {
                Text = "Status: PARADO ✗",
                Font = new System.Drawing.Font("Arial", 11, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.Red,
                AutoSize = true,
                Location = new System.Drawing.Point(20, 50)
            };

            // Label e TrackBar de Velocidade
            labelSpeed = new Label
            {
                Text = "Velocidade: 10 cliques/s",
                Font = new System.Drawing.Font("Arial", 10),
                AutoSize = true,
                Location = new System.Drawing.Point(20, 90)
            };

            trackBarSpeed = new TrackBar
            {
                Minimum = 1,
                Maximum = 50,
                Value = 10,
                TickFrequency = 5,
                Location = new System.Drawing.Point(20, 115),
                Size = new System.Drawing.Size(310, 45)
            };
            trackBarSpeed.ValueChanged += TrackBarSpeed_ValueChanged;

            // Botão Start/Stop
            buttonStartStop = new Button
            {
                Text = "INICIAR (Ctrl+Alt+A)",
                Font = new System.Drawing.Font("Arial", 11, System.Drawing.FontStyle.Bold),
                BackColor = System.Drawing.Color.LimeGreen,
                ForeColor = System.Drawing.Color.White,
                Location = new System.Drawing.Point(20, 170),
                Size = new System.Drawing.Size(310, 50),
                FlatStyle = FlatStyle.Flat
            };
            buttonStartStop.Click += ButtonStartStop_Click;

            // Label Info
            var labelInfo = new Label
            {
                Text = "Hotkey: Ctrl + Alt + A",
                Font = new System.Drawing.Font("Arial", 9, System.Drawing.FontStyle.Italic),
                ForeColor = System.Drawing.Color.Gray,
                AutoSize = true,
                Location = new System.Drawing.Point(20, 235)
            };

            // Adicionar controles
            this.Controls.Add(labelTitle);
            this.Controls.Add(labelStatus);
            this.Controls.Add(labelSpeed);
            this.Controls.Add(trackBarSpeed);
            this.Controls.Add(buttonStartStop);
            this.Controls.Add(labelInfo);
        }

        private Label labelStatus = null!;
        private Label labelSpeed = null!;
        private TrackBar trackBarSpeed = null!;
        private Button buttonStartStop = null!;
    }
}
