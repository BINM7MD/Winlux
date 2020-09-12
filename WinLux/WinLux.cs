using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinLux
{
    public partial class WinLux : Form
    {
        public WinLux()
        {
            InitializeComponent();
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;
        #region Install WSL
        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("cmd.exe", "/c dism.exe /online /enable-feature /featurename:Microsoft-Windows-Subsystem-Linux /all /norestart & dism.exe /online /enable-feature /featurename:VirtualMachinePlatform /all /norestart & wsl --set-default-version 2");
            Thread.Sleep(150);
            stat.Text = "Status: Installed Windows Linux SubSystem!";
            MessageBox.Show("Please Restart your PC/Laptop", "WinLux");

        }
        #endregion

        #region Download Distro
        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("https://aka.ms/wslstore");
        }
        #endregion
        #region Copy commands
        private void button4_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("sudo apt update && sudo apt upgrade -y && sudo apt install kali-desktop-xfce -y && sudo apt install xrdp -y && sudo service xrdp start && ifconfig");
            MessageBox.Show("Copied, After running those commands login with microsoft rdp (bulit in windows) with the ip & the user and pass that u used", "WinLux");
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
