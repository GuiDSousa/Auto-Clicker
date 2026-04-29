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
            
            // Cores da paleta
            Color bgDark = Color.FromArgb(46, 0, 93);      // #2e005d
            Color bgMedium = Color.FromArgb(92, 0, 139);   // #5c008b
            Color accentOrange = Color.FromArgb(255, 131, 0);  // #ff8300
            Color accentOrangeDark = Color.FromArgb(255, 98, 0); // #ff6200
            Color textLight = Color.FromArgb(240, 240, 240);
            Color textDark = Color.FromArgb(20, 20, 20);

            this.ClientSize = new System.Drawing.Size(400, 380);
            this.Name = "MainForm";
            this.Text = "AutoClicker";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Icon = SystemIcons.Application;
            this.BackColor = bgDark;
            this.ForeColor = textLight;
            this.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Regular);
            this.FormClosing += new FormClosingEventHandler(MainForm_FormClosing);

            // Painel topo (Header)
            var panelHeader = new Panel
            {
                BackColor = bgMedium,
                Location = new System.Drawing.Point(0, 0),
                Size = new System.Drawing.Size(400, 80),
                BorderStyle = BorderStyle.None
            };

            // Label Título
            var labelTitle = new Label
            {
                Text = "AUTO CLICKER",
                Font = new System.Drawing.Font("Segoe UI", 20, System.Drawing.FontStyle.Bold),
                ForeColor = accentOrange,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new System.Drawing.Point(0, 15),
                Size = new System.Drawing.Size(400, 50)
            };

            // Subtítulo
            var labelSubtitle = new Label
            {
                Text = "for idle games",
                Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Italic),
                ForeColor = textLight,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new System.Drawing.Point(0, 55),
                Size = new System.Drawing.Size(400, 20)
            };

            panelHeader.Controls.Add(labelTitle);
            panelHeader.Controls.Add(labelSubtitle);

            // Label Status
            labelStatus = new Label
            {
                Text = "Status: PARADO",
                Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold),
                ForeColor = Color.FromArgb(200, 200, 200),
                AutoSize = true,
                Location = new System.Drawing.Point(25, 100)
            };

            // Label e TrackBar de Velocidade
            labelSpeed = new Label
            {
                Text = "Velocidade: 10 cliques/s",
                Font = new System.Drawing.Font("Segoe UI", 10),
                ForeColor = textLight,
                AutoSize = true,
                Location = new System.Drawing.Point(25, 145)
            };

            trackBarSpeed = new TrackBar
            {
                Minimum = 1,
                Maximum = 50,
                Value = 10,
                TickFrequency = 5,
                Location = new System.Drawing.Point(25, 170),
                Size = new System.Drawing.Size(350, 50),
                BackColor = bgDark,
                ForeColor = accentOrange,
                TickStyle = TickStyle.BottomRight
            };
            trackBarSpeed.ValueChanged += TrackBarSpeed_ValueChanged;

            // Painel separador
            var panelSeparator = new Panel
            {
                BackColor = accentOrange,
                Location = new System.Drawing.Point(25, 220),
                Size = new System.Drawing.Size(350, 2)
            };

            // Botão Start/Stop - Melhorado
            buttonStartStop = new Button
            {
                Text = "START (Ctrl+Alt+A)",
                Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold),
                BackColor = accentOrange,
                ForeColor = textDark,
                Location = new System.Drawing.Point(25, 240),
                Size = new System.Drawing.Size(350, 60),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            buttonStartStop.FlatAppearance.BorderSize = 0;
            buttonStartStop.FlatAppearance.MouseOverBackColor = accentOrangeDark;
            buttonStartStop.FlatAppearance.MouseDownBackColor = Color.FromArgb(200, 70, 0);
            buttonStartStop.Click += ButtonStartStop_Click;

            // Label Info 1
            var labelInfo1 = new Label
            {
                Text = "Press Ctrl + Alt + A anywhere to toggle",
                Font = new System.Drawing.Font("Segoe UI", 8, System.Drawing.FontStyle.Italic),
                ForeColor = Color.FromArgb(150, 150, 150),
                AutoSize = true,
                Location = new System.Drawing.Point(25, 315)
            };

            // Label Info 2
            var labelInfo2 = new Label
            {
                Text = "Adjust speed with the slider before starting",
                Font = new System.Drawing.Font("Segoe UI", 8, System.Drawing.FontStyle.Italic),
                ForeColor = Color.FromArgb(150, 150, 150),
                AutoSize = true,
                Location = new System.Drawing.Point(25, 335)
            };

            // Adicionar controles
            this.Controls.Add(panelHeader);
            this.Controls.Add(labelStatus);
            this.Controls.Add(labelSpeed);
            this.Controls.Add(trackBarSpeed);
            this.Controls.Add(panelSeparator);
            this.Controls.Add(buttonStartStop);
            this.Controls.Add(labelInfo1);
            this.Controls.Add(labelInfo2);
        }

        private Label labelStatus = null!;
        private Label labelSpeed = null!;
        private TrackBar trackBarSpeed = null!;
        private Button buttonStartStop = null!;
    }
}
