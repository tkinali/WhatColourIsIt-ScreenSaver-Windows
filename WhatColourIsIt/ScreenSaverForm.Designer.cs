namespace ScreenSaver
{
    partial class ScreenSaverForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblSaat = new System.Windows.Forms.Label();
            this.moveTimer = new System.Windows.Forms.Timer(this.components);
            this.lblRenkKodu = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSaat
            // 
            this.lblSaat.AutoSize = true;
            this.lblSaat.BackColor = System.Drawing.Color.Transparent;
            this.lblSaat.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSaat.ForeColor = System.Drawing.Color.Red;
            this.lblSaat.Location = new System.Drawing.Point(126, 70);
            this.lblSaat.Name = "lblSaat";
            this.lblSaat.Size = new System.Drawing.Size(256, 65);
            this.lblSaat.TabIndex = 0;
            this.lblSaat.Text = "88 : 88 : 88";
            this.lblSaat.Click += new System.EventHandler(this.textLabel_Click);
            // 
            // lblRenkKodu
            // 
            this.lblRenkKodu.AutoSize = true;
            this.lblRenkKodu.BackColor = System.Drawing.Color.Transparent;
            this.lblRenkKodu.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblRenkKodu.ForeColor = System.Drawing.Color.Red;
            this.lblRenkKodu.Location = new System.Drawing.Point(126, 186);
            this.lblRenkKodu.Name = "lblRenkKodu";
            this.lblRenkKodu.Size = new System.Drawing.Size(256, 65);
            this.lblRenkKodu.TabIndex = 1;
            this.lblRenkKodu.Text = "88 : 88 : 88";
            // 
            // ScreenSaverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(508, 260);
            this.Controls.Add(this.lblRenkKodu);
            this.Controls.Add(this.lblSaat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ScreenSaverForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ScreenSaverForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ScreenSaverForm_KeyPress);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ScreenSaverForm_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ScreenSaverForm_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSaat;
        private System.Windows.Forms.Timer moveTimer;
        private System.Windows.Forms.Label lblRenkKodu;
    }
}

