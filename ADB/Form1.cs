using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random random = new Random();

        private void btn_Click(object sender, EventArgs e)
        {
            tmr.Enabled = true;
        }

        private void tmr_Tick(object sender, EventArgs e)
        {

            var proc1 = new ProcessStartInfo();

            int SX = random.Next(1000 , 2000);
            int SY = random.Next(1000, 2000);
            int EX = random.Next(1000, 2000);
            int EY = random.Next(1000, 2000);

            string anyCommand = String.Format("adb shell input swipe  {0} {1} {2} {3}", SX,SY,EX,EY);
            proc1.UseShellExecute = true;

            proc1.WorkingDirectory = @"C:\Windows\System32";

            proc1.FileName = @"C:\Windows\System32\cmd.exe";
            proc1.Verb = "runas";
            proc1.Arguments = "/c " + anyCommand;
            proc1.WindowStyle = ProcessWindowStyle.Normal;
            Process.Start(proc1);

            //lst.Items.Add(DateTime.Now + " -- " + "Run : " + SX + " " + SY + " TO " + EX + " " + EY);

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            tmr.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var proc1 = new ProcessStartInfo();

            int SX = random.Next(1000, 2000);
            int SY = random.Next(1000, 2000);
            int EX = random.Next(1000, 2000);
            int EY = random.Next(1000, 2000);

            SX = SY = 1000;
            EX = EY = 2000;

            string anyCommand = String.Format("adb shell input swipe  {0} {1} {2} {3}", SX, SY, EX, EY);
            txt.Text = anyCommand;
            //MessageBox.Show(anyCommand);
            proc1.UseShellExecute = true;

            proc1.WorkingDirectory = @"C:\Windows\System32";

            proc1.FileName = @"C:\Windows\System32\cmd.exe";
            proc1.Verb = "runas";
            proc1.Arguments = "/c " + anyCommand;
            proc1.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(proc1);


        }
    }
}
