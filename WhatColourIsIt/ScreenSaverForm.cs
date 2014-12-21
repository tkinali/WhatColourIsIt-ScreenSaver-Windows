using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace ScreenSaver
{
    public partial class ScreenSaverForm : Form
    {
        #region Win32 API functions

        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern bool GetClientRect(IntPtr hWnd, out Rectangle lpRect);

        #endregion


        private Point mouseLocation;
        private bool previewMode = false;
        private Random rand = new Random();

        public ScreenSaverForm()
        {
            InitializeComponent();
        }

        public ScreenSaverForm(Rectangle Bounds)
        {
            InitializeComponent();
            this.Bounds = Bounds;
        }

        public ScreenSaverForm(IntPtr PreviewWndHandle)
        {
            InitializeComponent();

            // Set the preview window as the parent of this window
            SetParent(this.Handle, PreviewWndHandle);

            // Make this a child window so it will close when the parent dialog closes
            SetWindowLong(this.Handle, -16, new IntPtr(GetWindowLong(this.Handle, -16) | 0x40000000));

            // Place our window inside the parent
            Rectangle ParentRect;
            GetClientRect(PreviewWndHandle, out ParentRect);
            Size = ParentRect.Size;
            Location = new Point(0, 0);

            string hour = DateTime.Now.ToString("hh");
            string minutes = DateTime.Now.ToString("mm");
            string seconds = DateTime.Now.ToString("ss");

            int saatFontSize = Bounds.Width / 20;
            int renkKoduFontSize = Bounds.Width / 50;

            lblSaat.Font = new Font("Segoe UI", saatFontSize);
            lblSaat.Left = (Bounds.Width / 2) - (lblSaat.Width / 2);
            lblSaat.Top = (Bounds.Height / 2) - (lblSaat.Height / 2);
            lblSaat.Text = hour + " : " + minutes + " : " + seconds;
            lblSaat.ForeColor = Color.White;

            lblRenkKodu.Font = new Font("Segoe UI", renkKoduFontSize);
            lblRenkKodu.Left = (Bounds.Width / 2) - (lblRenkKodu.Width / 2);
            lblRenkKodu.Top = Bounds.Height - lblRenkKodu.Height * 3;
            lblRenkKodu.Text = "#" + hour + minutes + seconds;
            lblRenkKodu.ForeColor = Color.White;

            previewMode = false;
        }

        private void ScreenSaverForm_Load(object sender, EventArgs e)
        {
            string hour = DateTime.Now.ToString("hh");
            string minutes = DateTime.Now.ToString("mm");
            string seconds = DateTime.Now.ToString("ss");

            int iHour = Convert.ToInt32(hour, 16);
            int iMinutes = Convert.ToInt32(minutes, 16);
            int iSeconds = Convert.ToInt32(seconds, 16);

            int saatFontSize = Bounds.Width / 20;
            int renkKoduFontSize = Bounds.Width / 50;

            lblSaat.Font = new Font("Segoe UI", saatFontSize);
            lblSaat.Left = (Bounds.Width / 2) - (lblSaat.Width / 2);
            lblSaat.Top = (Bounds.Height / 2) - (lblSaat.Height / 2);
            lblSaat.Text = hour + " : " + minutes + " : " + seconds;
            lblSaat.ForeColor = Color.White;

            lblRenkKodu.Font = new Font("Segoe UI", renkKoduFontSize);
            lblRenkKodu.Left = (Bounds.Width / 2) - (lblRenkKodu.Width / 2);
            lblRenkKodu.Top = Bounds.Height - lblRenkKodu.Height*3;
            lblRenkKodu.Text = "#" + hour + minutes + seconds;
            lblRenkKodu.ForeColor = Color.White;
            
            Cursor.Hide();
            TopMost = true;

            this.BackColor = Color.FromArgb(iHour, iMinutes,iSeconds);

            moveTimer.Interval = 1000;
            moveTimer.Tick += new EventHandler(moveTimer_Tick);
            moveTimer.Start();
        }

        private void moveTimer_Tick(object sender, System.EventArgs e)
        {
            string hour = DateTime.Now.ToString("hh");
            string minutes = DateTime.Now.ToString("mm");
            string seconds = DateTime.Now.ToString("ss");

            int iHour = Convert.ToInt32(hour, 16);
            int iMinutes = Convert.ToInt32(minutes, 16);
            int iSeconds = Convert.ToInt32(seconds, 16);

            this.BackColor = Color.FromArgb(iHour, iMinutes, iSeconds);
            lblSaat.Text = hour + " : " + minutes + " : " + seconds;
            lblRenkKodu.Text = "#" + hour + minutes + seconds;
        }

        private void ScreenSaverForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (!previewMode)
            {
                if (!mouseLocation.IsEmpty)
                {
                    // Terminate if mouse is moved a significant distance
                    if (Math.Abs(mouseLocation.X - e.X) > 5 ||
                        Math.Abs(mouseLocation.Y - e.Y) > 5)
                        Application.Exit();
                }

                // Update current mouse location
                mouseLocation = e.Location;
            }
        }

        private void ScreenSaverForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!previewMode)
                Application.Exit();
        }

        private void ScreenSaverForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (!previewMode)
                Application.Exit();
        }

        private void textLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
