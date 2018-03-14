using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADB
{
    public class AppProcess
    {
        public static ProcessOutput RunProcess(string command)
        {
            var info = new System.Diagnostics.ProcessStartInfo();
            info.FileName = Globals.CommandName;
            info.UseShellExecute = false;
            info.WorkingDirectory = Globals.Working_Directory_Dir;
            info.Verb = "runas";
            info.Arguments = "/c " + command;
            info.RedirectStandardOutput = true;
            info.RedirectStandardError = true;

            info.WindowStyle = ProcessWindowStyle.Hidden;
            info.CreateNoWindow = true;
            var process = new System.Diagnostics.Process();
            process.EnableRaisingEvents = true;
            process.StartInfo = info;
            process.Start();

            ProcessOutput output = new ProcessOutput();

            //string output = "";

            //tes git
            // hahahha

            output.Output += process.StandardOutput.ReadToEnd();
            output.Error += process.StandardError.ReadToEnd();
            process.WaitForExit();
            //process.Close();
            return output;
        }

        public static string TakeSceenshot(string name = "")
        {
            var info = new System.Diagnostics.ProcessStartInfo();
            string fileName = "";
            if (name == "")
            {
                fileName = DateTime.Now.Ticks.ToString().Replace(' ', '-') + ".jpg";
            }
            else
            {
                fileName = name;
            }

            //RunProcess(String.Format("adb shell screencap -p /sdcard/screencap.jpg && adb pull /sdcard/screencap.jpg " + Globals.Temp_Dir + "\\" + fileName));

            string anyCommand = String.Format("adb shell screencap -p /sdcard/screencap.jpg && adb pull /sdcard/screencap.jpg " + Globals.Temp_Dir + "\\" + fileName);
            info.FileName = @"C:\Windows\System32\cmd.exe";
            info.UseShellExecute = true;
            info.WorkingDirectory = Globals.Working_Directory_Dir;
            info.FileName = @"C:\Windows\System32\cmd.exe";
            info.Verb = "runas";
            info.Arguments = "/c " + anyCommand;
            info.WindowStyle = ProcessWindowStyle.Hidden;
            var process = new System.Diagnostics.Process();
            process.EnableRaisingEvents = true;
            process.StartInfo = info;
            process.Exited += (sv, ev) =>
            {
            };
            process.Start();
            process.WaitForExit();
            process.Close();
            return fileName;

        }



        public static string getFocusedActivity()
        {
            return RunProcess("adb shell dumpsys activity activities | grep mFocusedActivity").Output;
            //var info = new System.Diagnostics.ProcessStartInfo();
            //string anyCommand = String.Format("adb shell dumpsys activity activities | grep mFocusedActivity");
            //info.FileName = @"C:\Windows\System32\cmd.exe";
            //info.UseShellExecute = false;
            //info.WorkingDirectory = @"C:\TMP";
            //info.FileName = @"C:\Windows\System32\cmd.exe";
            //info.Verb = "runas";
            //info.Arguments = "/c " + anyCommand;
            //info.RedirectStandardOutput = true;
            //info.RedirectStandardError = true;

            //info.WindowStyle = ProcessWindowStyle.Hidden;
            //info.CreateNoWindow = true;
            //var process = new System.Diagnostics.Process();
            //process.EnableRaisingEvents = true;
            //process.StartInfo = info;
            //process.Start();
            //string output = "";
            //output += process.StandardOutput.ReadToEnd();
            //output += process.StandardError.ReadToEnd();
            //process.WaitForExit();
            //return output;
        }




        public static bool isAdActivity()
        {
            string output = getFocusedActivity();
            foreach (string ad in Globals.AdsActivities)
            {
                if (output.Trim().Contains(ad) == true)
                {
                    return true;
                }
            }
            return false;
        }

        public static void RunOffer()
        {
            Tap(new Point(600, 550));
        }

        public static void CloseNoOfferWindow()
        {
            Random random = new Random();
            int x = random.Next(700, 780);
            int y = random.Next(420, 500);
            Tap(new Point(x, y));
        }

        public static void CloseEndOfOfferWindow()
        {
            SendKey(AndroidKeys.KEYCODE_BACK);
        }


        public static void OpenOffersWindow()
        {
            Tap(new Point(850, 130));
        }

        public static void Wait()
        {
            SendKey(AndroidKeys.KEYCODE_BACK);
        }


        public static void CloseGame()
        {

            RunProcess(String.Format("adb shell am force-stop com.scopely.headshot"));

            //var info1 = new System.Diagnostics.ProcessStartInfo();
            //info1.FileName = @"C:\Windows\System32\cmd.exe";
            //info1.UseShellExecute = true;
            //info1.WorkingDirectory = @"C:\TMP";
            //info1.FileName = @"C:\Windows\System32\cmd.exe";
            //info1.Verb = "runas";
            //info1.Arguments = "/c " + String.Format("adb shell am force-stop com.scopely.headshot");
            //info1.WindowStyle = ProcessWindowStyle.Hidden;
            //var process1 = new System.Diagnostics.Process();
            //process1.StartInfo = info1;
            //process1.EnableRaisingEvents = true;
            //process1.Exited += (sv1, ev1) =>
            //{

            //};
            //process1.Start();
            //process1.WaitForExit();
            //process1.Close();

        }


        public static void OpenGame()
        {

            RunProcess(String.Format("adb shell monkey -p com.scopely.headshot -c android.intent.category.LAUNCHER 1"));

            //var info1 = new System.Diagnostics.ProcessStartInfo();
            //info1.FileName = @"C:\Windows\System32\cmd.exe";
            //info1.UseShellExecute = true;
            //info1.WorkingDirectory = @"C:\TMP";
            //info1.FileName = @"C:\Windows\System32\cmd.exe";
            //info1.Verb = "runas";
            //info1.Arguments = "/c " + String.Format("adb shell monkey -p com.scopely.headshot -c android.intent.category.LAUNCHER 1");
            //info1.WindowStyle = ProcessWindowStyle.Hidden;
            //var process1 = new System.Diagnostics.Process();
            //process1.StartInfo = info1;
            //process1.EnableRaisingEvents = true;
            //process1.Exited += (sv1, ev1) =>
            //{

            //};
            //process1.Start();
            //process1.WaitForExit();
            //process1.Close();

        }

        public static void OpenSettings()
        {

            RunProcess(String.Format("adb shell am start -n com.google.android.gms/.ads.settings.AdsSettingsActivity"));
            //RunProcess(String.Format("adb shell am start -a android.settings.SETTINGS"));

            //var info1 = new System.Diagnostics.ProcessStartInfo();
            //info1.FileName = @"C:\Windows\System32\cmd.exe";
            //info1.UseShellExecute = true;
            //info1.WorkingDirectory = @"C:\TMP";
            //info1.FileName = @"C:\Windows\System32\cmd.exe";
            //info1.Verb = "runas";
            //info1.Arguments = "/c " + String.Format("adb shell am start -n com.google.android.gms/.ads.settings.AdsSettingsActivity");
            //info1.WindowStyle = ProcessWindowStyle.Hidden;
            //var process1 = new System.Diagnostics.Process();
            //process1.StartInfo = info1;
            //process1.EnableRaisingEvents = true;
            //process1.Exited += (sv1, ev1) =>
            //{
            //};
            //process1.Start();
            //process1.WaitForExit();
            //process1.Close();
            System.Threading.Thread.Sleep(1000);

        }


        public static void Swipe(Point start, Point end, int time)
        {

            RunProcess(String.Format("adb shell input swipe  {0} {1} {2} {3} {4}", start.X, start.Y, end.X, end.Y, time));

            //var proc1 = new ProcessStartInfo();
            //string anyCommand = String.Format("adb shell input swipe  {0} {1} {2} {3} {4}", start.X, start.Y, end.X, end.Y, time);
            //proc1.UseShellExecute = true;
            //proc1.WorkingDirectory = @"C:\TMP";
            //proc1.FileName = @"C:\Windows\System32\cmd.exe";
            //proc1.Verb = "runas";
            //proc1.Arguments = "/c " + anyCommand;
            //proc1.WindowStyle = ProcessWindowStyle.Hidden;
            //var process = Process.Start(proc1);
            //process.EnableRaisingEvents = true;
            //process.Exited += (se, sv) =>
            //{
            //};

            //process.WaitForExit();
            //process.Close();

        }


        public static void Tap(Point point)
        {

            RunProcess(String.Format("adb shell input tap {0} {1}", point.X, point.Y));

            //var info1 = new System.Diagnostics.ProcessStartInfo();
            //info1.FileName = @"C:\Windows\System32\cmd.exe";
            //info1.UseShellExecute = true;
            //info1.WorkingDirectory = @"C:\TMP";
            //info1.FileName = @"C:\Windows\System32\cmd.exe";
            //info1.Verb = "runas";
            //info1.Arguments = "/c " + String.Format("adb shell input tap {0} {1}", point.X, point.Y);
            //info1.WindowStyle = ProcessWindowStyle.Hidden;
            //var process1 = new System.Diagnostics.Process();
            //process1.StartInfo = info1;
            //process1.EnableRaisingEvents = true;
            //process1.Exited += (sv1, ev1) =>
            //{
            //};
            //process1.Start();
            //process1.WaitForExit();
            //process1.Close();

        }

        public static void DisableRotation()
        {

            RunProcess(String.Format("adb shell settings put system accelerometer_rotation 0"));
            //var info1 = new System.Diagnostics.ProcessStartInfo();
            //info1.FileName = @"C:\Windows\System32\cmd.exe";
            //info1.UseShellExecute = true;
            //info1.WorkingDirectory = @"C:\TMP";
            //info1.FileName = @"C:\Windows\System32\cmd.exe";
            //info1.Verb = "runas";
            //info1.Arguments = "/c " + String.Format("adb shell settings put system accelerometer_rotation 0");
            //info1.WindowStyle = ProcessWindowStyle.Hidden;
            //var process1 = new System.Diagnostics.Process();
            //process1.StartInfo = info1;
            //process1.EnableRaisingEvents = true;
            //process1.Exited += (sv1, ev1) =>
            //{
            //};
            //process1.Start();
            //process1.WaitForExit();
            //process1.Close();

        }

        public static void EnableRotation()
        {

            RunProcess(String.Format("adb shell settings put system accelerometer_rotation 1"));

            //var info1 = new System.Diagnostics.ProcessStartInfo();
            //info1.FileName = @"C:\Windows\System32\cmd.exe";
            //info1.UseShellExecute = true;
            //info1.WorkingDirectory = @"C:\TMP";
            //info1.FileName = @"C:\Windows\System32\cmd.exe";
            //info1.Verb = "runas";
            //info1.Arguments = "/c " + String.Format("adb shell settings put system accelerometer_rotation 1");
            //info1.WindowStyle = ProcessWindowStyle.Hidden;
            //var process1 = new System.Diagnostics.Process();
            //process1.StartInfo = info1;
            //process1.EnableRaisingEvents = true;
            //process1.Exited += (sv1, ev1) =>
            //{
            //};
            //process1.Start();
            //process1.WaitForExit();
            //process1.Close();

        }

        public static void RotateScreen(int mode /*user_rotation: actual rotation, clockwise, 0 0°, 1 90°, 2 180°, 3 270°*/)
        {

            RunProcess(String.Format("adb shell settings put system user_rotation {0}", mode));

            //var info1 = new System.Diagnostics.ProcessStartInfo();
            //info1.FileName = @"C:\Windows\System32\cmd.exe";
            //info1.UseShellExecute = true;
            //info1.WorkingDirectory = @"C:\TMP";
            //info1.FileName = @"C:\Windows\System32\cmd.exe";
            //info1.Verb = "runas";
            //info1.Arguments = "/c " + String.Format("adb shell settings put system user_rotation {0}", mode);
            //info1.WindowStyle = ProcessWindowStyle.Hidden;
            //var process1 = new System.Diagnostics.Process();
            //process1.StartInfo = info1;
            //process1.EnableRaisingEvents = true;
            //process1.Exited += (sv1, ev1) =>
            //{
            //};
            //process1.Start();
            //process1.WaitForExit();
            //process1.Close();

        }

        public static int GetRotationSituation()
        {
            string line = AppProcess.RunProcess("adb shell settings get system accelerometer_rotation").Output;
            return Int32.Parse(line.Trim());
        }

        public static void SendKey(int code)
        {
            RunProcess(String.Format("adb shell input keyevent {0}", code));

            //var info1 = new System.Diagnostics.ProcessStartInfo();
            //info1.FileName = @"C:\Windows\System32\cmd.exe";
            //info1.UseShellExecute = true;
            //info1.WorkingDirectory = @"C:\TMP";
            //info1.FileName = @"C:\Windows\System32\cmd.exe";
            //info1.Verb = "runas";
            //info1.Arguments = "/c " + String.Format("adb shell input keyevent {0}", code);
            //info1.WindowStyle = ProcessWindowStyle.Hidden;
            //var process1 = new System.Diagnostics.Process();
            //process1.StartInfo = info1;
            //process1.EnableRaisingEvents = true;
            //process1.Exited += (sv1, ev1) =>
            //{

            //};
            //process1.Start();
            //process1.WaitForExit();
            //process1.Close();

        }

        public static string GetDeviceDetails()
        {
            ProcessOutput output = AppProcess.RunProcess("adb devices -l");
            //MessageBox.Show(output.Output.Split('\n').Length + "");
            string[] lines = output.Output.Split('\n');
            string data = "No Device Found";
            //int cnt = 0;
            foreach (string line in lines)
            {
                if (line.Trim() != string.Empty && line.Contains("device") == true)
                {
                    data = line.Trim();
                    //lbl.Text = line ;
                    //cnt++;
                }
            }

            return data;
        }

        public static string GetAndroidId()
        {
            string output = RunProcess("adb shell settings get secure android_id").Output.Trim();
            return output;
            //return output.Trim().Split('\n')[0].Trim();

        }




    }
}
