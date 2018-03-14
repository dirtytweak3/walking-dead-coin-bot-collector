using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADB
{

    public partial class frmMain : Form
    {
        Random random = new Random();
        private BackgroundWorker backgroundWorker1;

        public frmMain()
        {
            InitializeComponent();

            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            //backgroundWorker1.ProgressChanged +=new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
        }


        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (chkActive.Checked == true)
                backgroundWorker1.RunWorkerAsync();
            //btnBackgoundWorker_Click(null, null);

            if (Logger.ReadLog() != null)
            {
                string[] lines = Logger.ReadLog();
                lstLog.Items.Clear();
                if (lines != null)
                    lstLog.Items.AddRange(lines);
            }

            lblNoOfferInARow.Text = Globals.NoOffersInARow + "";
            lblWatchedAds.Text = Globals.WatchedAds + "";

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {


            int sleepTime = 0;
            string msg = "";

            //MethodInvoker myProcessStarter = new MethodInvoker(AppProcess.TakeSceenshot);
            //myProcessStarter.BeginInvoke(null, null);

            string fileName = AppProcess.TakeSceenshot();

            //string fileName = Globals.fileName;
            //System.Threading.Thread.Sleep(1000);
            System.Threading.Timer TheTimer1 = null;
            int t1 = 0;
            TheTimer1 = new System.Threading.Timer((ot) =>
            {
                try
                {
                    TheTimer1.Dispose();
                }
                catch (Exception ex)
                {
                    if (TheTimer1 != null)
                        TheTimer1.Dispose();
                }

            }, null, 1000, 100);


            //string dirpath = Globals.Temp_Dir;
            string testImageTwo = Globals.Temp_Dir + "\\" + fileName;
            //System.Threading.Thread.Sleep(1000);


            if (ImageComparer.CompareImages(Globals.OfferImage, testImageTwo, Globals.AForgeConfig.CompareLevel, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true)
            {
                //MethodInvoker myProcessStarter1 = new MethodInvoker(AppProcess.RunOffer);
                //myProcessStarter1.BeginInvoke(null, null);

                AppProcess.RunOffer();
                int time = random.Next(10000, 20000);
                sleepTime = time;
                msg = DateTime.Now + " offers " + time;
            }
            else if (ImageComparer.CompareImages(Globals.NoOfferImage, testImageTwo, Globals.AForgeConfig.CompareLevel + 0.03, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true)
            {
                Globals.NoOffersInARow++;

                //MethodInvoker myProcessStarter2 = new MethodInvoker(AppProcess.CloseNoOfferWindow);
                //myProcessStarter2.BeginInvoke(null, null);

                AppProcess.CloseNoOfferWindow();
                sleepTime = 2000;
                msg = DateTime.Now + " " + "no offer 2000";
            }
            else if (ImageComparer.CompareImages(Globals.LoadingImage, testImageTwo, Globals.AForgeConfig.CompareLevel, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true)
            {
                sleepTime = 2000;
                msg = DateTime.Now + " " + "loading 2000";
            }
            else if (ImageComparer.CompareImages(Globals.NoBackPort1Image, testImageTwo, Globals.AForgeConfig.CompareLevel + 0.03, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true
                || ImageComparer.CompareImages(Globals.NoBackPort2Image, testImageTwo, Globals.AForgeConfig.CompareLevel + 0.03, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true
                )
            {
                //if (Globals.Log)
                //    Globals.WriteLog("no back port");
                var proc1 = new ProcessStartInfo();
                string anyCommand1 = String.Format("adb shell input tap 705 15");
                proc1.UseShellExecute = true;
                proc1.WorkingDirectory = @"C:\TMP";
                proc1.FileName = @"C:\Windows\System32\cmd.exe";
                proc1.Verb = "runas";
                proc1.Arguments = "/c " + anyCommand1;
                proc1.WindowStyle = ProcessWindowStyle.Hidden;
                var process2 = new System.Diagnostics.Process();

                //var process2 = Process.Start(proc1);
                process2.EnableRaisingEvents = true;
                process2.StartInfo = proc1;
                process2.Exited += (sv2, ev2) =>
                {
                    //System.Threading.Thread.Sleep(1000);
                    sleepTime = 1000;
                    msg = DateTime.Now + " " + "no back land 1000";

                    //Delay(1000);
                };
                process2.Start();
                process2.WaitForExit();
                //process2.Close();

            }

            else if (ImageComparer.CompareImages(Globals.NoBackLand1Image, testImageTwo, Globals.AForgeConfig.CompareLevel + 0.03, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true
                || ImageComparer.CompareImages(Globals.NoBackLand2Image, testImageTwo, Globals.AForgeConfig.CompareLevel + 0.03, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true
                )
            {
                //if (Globals.Log)
                //    Globals.WriteLog("no back land");
                var proc1 = new ProcessStartInfo();
                string anyCommand1 = String.Format("adb shell input tap 1450 15");
                proc1.UseShellExecute = true;
                proc1.WorkingDirectory = @"C:\TMP";
                proc1.FileName = @"C:\Windows\System32\cmd.exe";
                proc1.Verb = "runas";
                proc1.Arguments = "/c " + anyCommand1;
                proc1.WindowStyle = ProcessWindowStyle.Hidden;
                var process2 = new System.Diagnostics.Process();

                //var process2 = Process.Start(proc1);
                process2.EnableRaisingEvents = true;
                process2.StartInfo = proc1;
                process2.Exited += (sv2, ev2) =>
                {
                    //System.Threading.Thread.Sleep(1000);
                    sleepTime = 1000;
                    msg = DateTime.Now + " " + "no back land 1000";

                    //Delay(1000);
                };
                process2.Start();
                process2.WaitForExit();
                //process2.Close();

            }




            else if (ImageComparer.CompareImages(Globals.EndOfferImage, testImageTwo, Globals.AForgeConfig.CompareLevel + 0.03, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true)
            {
                Globals.NoOffersInARow = 0;
                Globals.WatchedAds++;
                sleepTime = 1000;
                msg = DateTime.Now + " " + "end of offer 1000";
                //MethodInvoker myProcessStarter2 = new MethodInvoker(AppProcess.CloseEndOfOfferWindow);
                //myProcessStarter2.BeginInvoke(null, null);

                AppProcess.CloseEndOfOfferWindow();

            }

            else if (ImageComparer.CompareImages(Globals.PrepareImage, testImageTwo, Globals.AForgeConfig.CompareLevel - 0.10, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true)
            {
                //MethodInvoker myProcessStarter2 = new MethodInvoker(AppProcess.OpenOffersWindow);
                //myProcessStarter2.BeginInvoke(null, null);

                AppProcess.OpenOffersWindow();
                sleepTime = 1000;
                msg = DateTime.Now + " " + "prepare 1000";

            }
            else
            {
                //MethodInvoker myProcessStarter2 = new MethodInvoker(AppProcess.Wait);
                //myProcessStarter2.BeginInvoke(null, null);

                AppProcess.Wait();
                sleepTime = 5000;
                msg = DateTime.Now + " " + "else 5000";
            }




            System.Threading.Timer TheTimer = null;
            int t = 0;
            TheTimer = new System.Threading.Timer((ot) =>
            {
                try
                {
                    TheTimer.Dispose();
                }
                catch (Exception ex)
                {
                    if (TheTimer != null)
                        TheTimer.Dispose();

                }


            }, null, sleepTime, 1000);


            Logger.WriteLog(msg);
            deleteFiles();



        }



        private void btnImageComparator_Click(object sender, EventArgs e)
        {
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
        }


        private async void Delay(int time)
        {
            await Task.Delay(time);
        }


        private void Process_Exited(object sender, EventArgs e)
        {
            MessageBox.Show("hi");

        }





        private void deleteFiles()
        {
            string[] files = Directory.GetFiles(Globals.Temp_Dir, "*.*", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                if (File.Exists(file) == true)
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
        }




        private void btnTest_Click(object sender, EventArgs e)
        {
            var info = new System.Diagnostics.ProcessStartInfo();
            string fileName = DateTime.Now.Ticks.ToString().Replace(' ', '-') + ".jpg";
            string anyCommand = String.Format("adb shell screencap -p /sdcard/screencap.jpg && adb pull /sdcard/screencap.jpg " + Globals.Temp_Dir + "\\" + fileName);
            //string anyCommand = String.Format("adb shell screencap -p /sdcard/screencap.jpg && adb pull /sdcard/screencap.jpg c:\\TMP\\1.jpg");
            info.FileName = @"C:\Windows\System32\cmd.exe";
            info.UseShellExecute = true;
            info.WorkingDirectory = @"C:\TMP";
            info.FileName = @"C:\Windows\System32\cmd.exe";
            info.Verb = "runas";
            info.Arguments = "/c " + anyCommand;
            info.WindowStyle = ProcessWindowStyle.Hidden;
            var process = new System.Diagnostics.Process();
            process.EnableRaisingEvents = true;
            process.StartInfo = info;

            //process.Exited += new EventHandler(Process_Exited);
            process.Exited += (sv, ev) =>
            {

                int sleepTime = 0;
                string msg = "";
                //const float similarityThreshold = 0.50f;
                //var compareLevel = 0.95;

                //string dirpath = @"C:\Temp\";
                string dirpath = Globals.Temp_Dir;

                //const string OfferImageFilePath = @"Base\offers.png";
                //const string testImageTwo = @"C:\TMP\1.jpg";
                string testImageTwo = Globals.Temp_Dir + "\\" + fileName;
                //System.Threading.Thread.Sleep(1000);
                System.Threading.Timer TheTimer1 = null;
                int t1 = 0;
                TheTimer1 = new System.Threading.Timer((ot) =>
                {
                    //t1 += 1000;
                    //if (t1 >= 1000)
                    try
                    {
                        TheTimer1.Dispose();
                    }
                    catch (Exception ex)
                    {
                        if (TheTimer1 != null)
                            TheTimer1.Dispose();

                    }

                }, null, 1000, 100);


                if (ImageComparer.CompareImages(Globals.OfferImage, testImageTwo, Globals.AForgeConfig.CompareLevel, dirpath, Globals.AForgeConfig.SimilarityThreshold) == true)
                {
                    //lstLog.Items.Add(DateTime.Now + "--- Match");
                    //if (Globals.Log)
                    //    Globals.WriteLog("offers");
                    var info1 = new System.Diagnostics.ProcessStartInfo();
                    info1.FileName = @"C:\Windows\System32\cmd.exe";
                    info1.UseShellExecute = true;
                    info1.WorkingDirectory = @"C:\TMP";
                    info1.FileName = @"C:\Windows\System32\cmd.exe";
                    info1.Verb = "runas";
                    info1.Arguments = "/c " + String.Format("adb shell input tap 600 550"); ;
                    info1.WindowStyle = ProcessWindowStyle.Hidden;
                    var process1 = new System.Diagnostics.Process();
                    process1.StartInfo = info1;
                    process1.EnableRaisingEvents = true;
                    //process.StartInfo = info1;
                    process1.Exited += (sv1, ev1) =>
                    {
                        int time = random.Next(10000, 20000);
                        sleepTime = time;
                        msg = DateTime.Now + " offers " + time;
                        //System.Threading.Thread.Sleep(time);
                        //Delay(time);

                    };
                    process1.Start();
                    process1.WaitForExit();
                    // process1.Close();

                }
                else if (ImageComparer.CompareImages(Globals.NoOfferImage, testImageTwo, Globals.AForgeConfig.CompareLevel + 0.03, dirpath, Globals.AForgeConfig.SimilarityThreshold) == true)
                {
                    Globals.NoOffersInARow++;
                    //if (Globals.Log)
                    //    Globals.WriteLog("no offer");
                    var proc11 = new ProcessStartInfo();
                    int x = random.Next(700, 780);
                    int y = random.Next(420, 500);
                    string anyCommand11 = String.Format("adb shell input tap {0} {1}", x, y);
                    proc11.UseShellExecute = true;
                    proc11.WorkingDirectory = @"C:\TMP";
                    proc11.FileName = @"C:\Windows\System32\cmd.exe";
                    proc11.Verb = "runas";
                    proc11.Arguments = "/c " + anyCommand11;
                    proc11.WindowStyle = ProcessWindowStyle.Hidden;
                    var process21 = new System.Diagnostics.Process();
                    //var process21 = Process.Start(proc11);
                    process21.EnableRaisingEvents = true;
                    process21.StartInfo = proc11;
                    process21.Exited += (sv21, ev21) =>
                    {
                        //System.Threading.Thread.Sleep(2000);
                        //Delay(2000);
                        sleepTime = 2000;
                        msg = DateTime.Now + " " + "no offer 2000";

                    };
                    process21.Start();
                    process21.WaitForExit();
                    // process21.Close();

                }
                else if (ImageComparer.CompareImages(Globals.LoadingImage, testImageTwo, Globals.AForgeConfig.CompareLevel, dirpath, Globals.AForgeConfig.SimilarityThreshold) == true)
                {
                    //if (Globals.Log)
                    //    Globals.WriteLog("loading");
                    //System.Threading.Thread.Sleep(5000);
                    sleepTime = 5000;
                    msg = DateTime.Now + " " + "loading 5000";

                    //Delay(5000);
                }
                else if (ImageComparer.CompareImages(Globals.NoBackPort1Image, testImageTwo, Globals.AForgeConfig.CompareLevel + 0.03, dirpath, Globals.AForgeConfig.SimilarityThreshold) == true
                    || ImageComparer.CompareImages(Globals.NoBackPort2Image, testImageTwo, Globals.AForgeConfig.CompareLevel + 0.03, dirpath, Globals.AForgeConfig.SimilarityThreshold) == true
                    )
                {
                    //if (Globals.Log)
                    //    Globals.WriteLog("no back port");
                    var proc1 = new ProcessStartInfo();
                    string anyCommand1 = String.Format("adb shell input tap 705 15");
                    proc1.UseShellExecute = true;
                    proc1.WorkingDirectory = @"C:\TMP";
                    proc1.FileName = @"C:\Windows\System32\cmd.exe";
                    proc1.Verb = "runas";
                    proc1.Arguments = "/c " + anyCommand1;
                    proc1.WindowStyle = ProcessWindowStyle.Hidden;
                    var process2 = new System.Diagnostics.Process();

                    //var process2 = Process.Start(proc1);
                    process2.EnableRaisingEvents = true;
                    process2.StartInfo = proc1;
                    process2.Exited += (sv2, ev2) =>
                    {
                        //System.Threading.Thread.Sleep(1000);
                        sleepTime = 1000;
                        msg = DateTime.Now + " " + "no back land 1000";

                        //Delay(1000);
                    };
                    process2.Start();
                    process2.WaitForExit();
                    //process2.Close();

                }

                else if (ImageComparer.CompareImages(Globals.NoBackLand1Image, testImageTwo, Globals.AForgeConfig.CompareLevel + 0.03, dirpath, Globals.AForgeConfig.SimilarityThreshold) == true
                    || ImageComparer.CompareImages(Globals.NoBackLand2Image, testImageTwo, Globals.AForgeConfig.CompareLevel + 0.03, dirpath, Globals.AForgeConfig.SimilarityThreshold) == true
                    )
                {
                    //if (Globals.Log)
                    //    Globals.WriteLog("no back land");
                    var proc1 = new ProcessStartInfo();
                    string anyCommand1 = String.Format("adb shell input tap 1450 15");
                    proc1.UseShellExecute = true;
                    proc1.WorkingDirectory = @"C:\TMP";
                    proc1.FileName = @"C:\Windows\System32\cmd.exe";
                    proc1.Verb = "runas";
                    proc1.Arguments = "/c " + anyCommand1;
                    proc1.WindowStyle = ProcessWindowStyle.Hidden;
                    var process2 = new System.Diagnostics.Process();

                    //var process2 = Process.Start(proc1);
                    process2.EnableRaisingEvents = true;
                    process2.StartInfo = proc1;
                    process2.Exited += (sv2, ev2) =>
                    {
                        //System.Threading.Thread.Sleep(1000);
                        sleepTime = 1000;
                        msg = DateTime.Now + " " + "no back land 1000";

                        //Delay(1000);
                    };
                    process2.Start();
                    process2.WaitForExit();
                    //process2.Close();

                }
                else if (ImageComparer.CompareImages(Globals.EndOfferImage, testImageTwo, Globals.AForgeConfig.CompareLevel + 0.02, dirpath, Globals.AForgeConfig.SimilarityThreshold) == true)
                {
                    Globals.NoOffersInARow = 0;
                    Globals.WatchedAds++;
                    //if (Globals.Log)
                    //    Globals.WriteLog("end of offer");
                    var proc1 = new ProcessStartInfo();
                    string anyCommand1 = String.Format("adb shell input keyevent 4");
                    proc1.UseShellExecute = true;
                    proc1.WorkingDirectory = @"C:\TMP";
                    proc1.FileName = @"C:\Windows\System32\cmd.exe";
                    proc1.Verb = "runas";
                    proc1.Arguments = "/c " + anyCommand1;
                    proc1.WindowStyle = ProcessWindowStyle.Hidden;
                    var process2 = new System.Diagnostics.Process();

                    //var process2 = Process.Start(proc1);
                    process2.EnableRaisingEvents = true;
                    process2.StartInfo = proc1;
                    process2.Exited += (sv2, ev2) =>
                    {
                        //System.Threading.Thread.Sleep(1000);
                        sleepTime = 1000;
                        msg = DateTime.Now + " " + "end of offer 1000";

                        //Delay(1000);
                    };
                    process2.Start();
                    process2.WaitForExit();
                    // process2.Close();

                }

                else if (ImageComparer.CompareImages(Globals.PrepareImage, testImageTwo, Globals.AForgeConfig.CompareLevel - 0.10, dirpath, Globals.AForgeConfig.SimilarityThreshold) == true)
                {
                    //if (Globals.Log)
                    //    Globals.WriteLog("prepare");
                    //Delay(500);
                    var proc11 = new ProcessStartInfo();
                    string anyCommand1 = String.Format("adb shell input tap 850 130");
                    proc11.UseShellExecute = true;
                    proc11.WorkingDirectory = @"C:\TMP";
                    proc11.FileName = @"C:\Windows\System32\cmd.exe";
                    proc11.Verb = "runas";
                    proc11.Arguments = "/c " + anyCommand1;
                    proc11.WindowStyle = ProcessWindowStyle.Hidden;
                    var process1 = Process.Start(proc11);
                    process1.EnableRaisingEvents = true;
                    process1.Exited += (se1, sv1) =>
                    {
                        //System.Threading.Thread.Sleep(1000);
                        sleepTime = 1000;
                        msg = DateTime.Now + " " + "prepare 1000";

                        //Delay(1000);
                    };
                    process1.WaitForExit();

                    //var proc1 = new ProcessStartInfo();
                    //int SX = random.Next(1000, 2000);
                    //int SY = random.Next(1000, 2000);
                    //int EX = random.Next(1000, 2000);
                    //int EY = random.Next(1000, 2000);

                    //SX = 1200;
                    //SY = 700;
                    //EX = 100;
                    //EY = 0;
                    //int T = 500;

                    //string anyCommand2 = String.Format("adb shell input swipe  {0} {1} {2} {3} {4}", SX, SY, EX, EY, T);
                    //proc1.UseShellExecute = true;
                    //proc1.WorkingDirectory = @"C:\TMP";
                    //proc1.FileName = @"C:\Windows\System32\cmd.exe";
                    //proc1.Verb = "runas";
                    //proc1.Arguments = "/c " + anyCommand2;
                    //proc1.WindowStyle = ProcessWindowStyle.Hidden;
                    //var process2 = Process.Start(proc1);
                    //process2.EnableRaisingEvents = true;
                    //process2.Exited += (se21, sv21) =>
                    //{
                    //    //System.Threading.Thread.Sleep(500);
                    //    sleepTime = 500;
                    //    msg = DateTime.Now + " " + "prepare";

                    //    //Delay(500);
                    //    var proc11 = new ProcessStartInfo();
                    //    string anyCommand1 = String.Format("adb shell input tap 850 130");
                    //    proc11.UseShellExecute = true;
                    //    proc11.WorkingDirectory = @"C:\TMP";
                    //    proc11.FileName = @"C:\Windows\System32\cmd.exe";
                    //    proc11.Verb = "runas";
                    //    proc11.Arguments = "/c " + anyCommand1;
                    //    proc11.WindowStyle = ProcessWindowStyle.Hidden;
                    //    var process1 = Process.Start(proc11);
                    //    process1.EnableRaisingEvents = true;
                    //    process1.Exited += (se1, sv1) =>
                    //    {
                    //        System.Threading.Thread.Sleep(1000);
                    //        //Delay(1000);
                    //    };
                    //    process1.WaitForExit();
                    //   // process1.Close();

                    //};
                    //process2.WaitForExit();
                    ////process2.Close();
                }
                else
                {
                    //if (Globals.Log)
                    //    Globals.WriteLog("else");
                    var proc1 = new ProcessStartInfo();
                    string anyCommand1 = String.Format("adb shell input keyevent 4");
                    proc1.UseShellExecute = true;
                    proc1.WorkingDirectory = @"C:\TMP";
                    proc1.FileName = @"C:\Windows\System32\cmd.exe";
                    proc1.Verb = "runas";
                    proc1.Arguments = "/c " + anyCommand1;
                    proc1.WindowStyle = ProcessWindowStyle.Hidden;
                    var process2 = new System.Diagnostics.Process();
                    //var process2 = Process.Start(proc1);
                    process2.EnableRaisingEvents = true;
                    process2.StartInfo = proc1;
                    process2.Exited += (sv2, ev2) =>
                    {
                        //System.Threading.Thread.Sleep(5000);
                        sleepTime = 5000;
                        msg = DateTime.Now + " " + "else 5000";

                        //Delay(5000);
                    };
                    process2.Start();
                    process2.WaitForExit();
                    //process2.Close();

                }

                //if (File.Exists(testImageTwo))
                //    File.Delete(testImageTwo);
                Logger.WriteLog(msg);


                System.Threading.Timer TheTimer = null;
                int t = 0;
                TheTimer = new System.Threading.Timer((ot) =>
                {
                    //t += 1000;
                    //if (t >= sleepTime)
                    //    TheTimer.Dispose();
                    try
                    {
                        TheTimer.Dispose();
                    }
                    catch (Exception ex)
                    {
                        if (TheTimer != null)
                            TheTimer.Dispose();

                    }


                }, null, sleepTime, 1000);

                // The timer ticked.
                //System.Threading.Thread.Sleep(sleepTime);

                //lstLog.Items.Add(msg);

                deleteFiles();

                //lblNoOfferInARow.Text = Globals.NoOffersInARow + "";

                //if (Globals.NoOffersInARow > 3)
                //    System.Media.SystemSounds.Beep.Play();

                //lblWatchedAds.Text = Globals.WatchedAds + "";



                if (chkActive.Checked == true)
                    btnTest_Click(null, null);




            };

            process.Start();
            process.WaitForExit();
            //if (process.HasExited == true)
            //{
            //    btnTest_Click(null, null);
            //}
            // process.Close();
            //btnTest_Click(null, null);



        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var proc1 = new ProcessStartInfo();
            string anyCommand = String.Format("adb shell input keyevent 4");
            proc1.UseShellExecute = true;
            proc1.WorkingDirectory = @"C:\TMP";
            proc1.FileName = @"C:\Windows\System32\cmd.exe";
            proc1.Verb = "runas";
            proc1.Arguments = "/c " + anyCommand;
            proc1.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(proc1);

        }

        private void btnCloseAfterAdWindow_Click(object sender, EventArgs e)
        {

            var proc1 = new ProcessStartInfo();
            string anyCommand = String.Format("adb shell input tap 740 450");
            proc1.UseShellExecute = true;
            proc1.WorkingDirectory = @"C:\TMP";
            proc1.FileName = @"C:\Windows\System32\cmd.exe";
            proc1.Verb = "runas";
            proc1.Arguments = "/c " + anyCommand;
            proc1.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(proc1);

        }

        private void btnPrepare_Click(object sender, EventArgs e)
        {

            var proc1 = new ProcessStartInfo();
            int SX = random.Next(1000, 2000);
            int SY = random.Next(1000, 2000);
            int EX = random.Next(1000, 2000);
            int EY = random.Next(1000, 2000);

            SX = 1200;
            SY = 700;
            EX = 100;
            EY = 0;
            int T = 500;

            //adb shell input swipe 1200 600 100 0 400
            string anyCommand = String.Format("adb shell input swipe  {0} {1} {2} {3} {4}", SX, SY, EX, EY, T);
            proc1.UseShellExecute = true;
            proc1.WorkingDirectory = @"C:\TMP";
            proc1.FileName = @"C:\Windows\System32\cmd.exe";
            proc1.Verb = "runas";
            proc1.Arguments = "/c " + anyCommand;
            proc1.WindowStyle = ProcessWindowStyle.Hidden;
            var process = Process.Start(proc1);
            process.EnableRaisingEvents = true;
            process.Exited += (se, sv) =>
            {
                System.Threading.Thread.Sleep(500);
                var proc11 = new ProcessStartInfo();
                string anyCommand1 = String.Format("adb shell input tap 850 130");
                proc11.UseShellExecute = true;
                proc11.WorkingDirectory = @"C:\TMP";
                proc11.FileName = @"C:\Windows\System32\cmd.exe";
                proc11.Verb = "runas";
                proc11.Arguments = "/c " + anyCommand1;
                proc11.WindowStyle = ProcessWindowStyle.Hidden;
                var process1 = Process.Start(proc11);
                process1.EnableRaisingEvents = true;
                process1.Exited += (se1, sv1) =>
                {


                };
            };
        }

        private void tmrLog_Tick(object sender, EventArgs e)
        {
            if (Logger.ReadLog() != null)
            {
                string[] lines = Logger.ReadLog();
                lstLog.Items.Clear();
                if (lines != null)
                    lstLog.Items.AddRange(lines);
            }

            lblNoOfferInARow.Text = Globals.NoOffersInARow + "";

            lblWatchedAds.Text = Globals.WatchedAds + "";

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Logger.ClearLog();
            //tmrLog.Enabled = Globals.Log;

            Globals.Base_Dir = Application.StartupPath + "\\Base";
            Globals.Temp_Dir = Application.StartupPath + "\\Temp";

            if (Directory.Exists(Application.StartupPath + "\\Temp") == false)
                Directory.CreateDirectory(Application.StartupPath + "\\Temp");


        }

        private void button1_Click(object sender, EventArgs e)
        {

            string s = String.Format("");
            //MessageBox.Show(s);
            var info = new System.Diagnostics.ProcessStartInfo();
            string anyCommand = s;
            info.FileName = @"C:\Windows\System32\cmd.exe";
            info.UseShellExecute = true;
            info.WorkingDirectory = @"C:\TMP";
            info.FileName = @"C:\Windows\System32\cmd.exe";
            info.Verb = "runas";
            info.Arguments = "/c " + anyCommand;
            info.WindowStyle = ProcessWindowStyle.Hidden;
            var process = new System.Diagnostics.Process();
            process.EnableRaisingEvents = true;
            process.StartInfo = info;

            process.Start();

            process.Exited += (se, sv) =>
            {

                System.Threading.Thread.Sleep(2000);
                lstLog.Items.Add("F " + DateTime.Now + "");

                button1_Click(null, null);

            };
            process.WaitForExit();

            //if (process.HasExited == false)
            //    process.Kill();

            process.Close();




        }

        private void btnRun_Click(object sender, EventArgs e)
        {

            int sleepTime = 0;
            string msg = "";

            //MethodInvoker myProcessStarter = new MethodInvoker(AppProcess.TakeSceenshot);
            //myProcessStarter.BeginInvoke(null, null);

            string fileName = AppProcess.TakeSceenshot();

            //string fileName = Globals.fileName;
            //System.Threading.Thread.Sleep(1000);
            System.Threading.Timer TheTimer1 = null;
            int t1 = 0;
            TheTimer1 = new System.Threading.Timer((ot) =>
            {
                try
                {
                    TheTimer1.Dispose();
                }
                catch (Exception ex)
                {
                    if (TheTimer1 != null)
                        TheTimer1.Dispose();
                }

            }, null, 1000, 100);


            //string dirpath = Globals.Temp_Dir;
            string testImageTwo = Globals.Temp_Dir + "\\" + fileName;
            //System.Threading.Thread.Sleep(1000);


            if (ImageComparer.CompareImages(Globals.OfferImage, testImageTwo, Globals.AForgeConfig.CompareLevel, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true)
            {
                //MethodInvoker myProcessStarter1 = new MethodInvoker(AppProcess.RunOffer);
                //myProcessStarter1.BeginInvoke(null, null);

                AppProcess.RunOffer();
                int time = random.Next(10000, 20000);
                sleepTime = time;
                msg = DateTime.Now + " offers " + time;
            }
            else if (ImageComparer.CompareImages(Globals.NoOfferImage, testImageTwo, Globals.AForgeConfig.CompareLevel + 0.03, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true)
            {
                Globals.NoOffersInARow++;

                //MethodInvoker myProcessStarter2 = new MethodInvoker(AppProcess.CloseNoOfferWindow);
                //myProcessStarter2.BeginInvoke(null, null);

                AppProcess.CloseNoOfferWindow();
                sleepTime = 2000;
                msg = DateTime.Now + " " + "no offer 2000";
            }
            else if (ImageComparer.CompareImages(Globals.LoadingImage, testImageTwo, Globals.AForgeConfig.CompareLevel, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true)
            {
                sleepTime = 2000;
                msg = DateTime.Now + " " + "loading 2000";
            }
            else if (ImageComparer.CompareImages(Globals.NoBackPort1Image, testImageTwo, Globals.AForgeConfig.CompareLevel + 0.03, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true
                || ImageComparer.CompareImages(Globals.NoBackPort2Image, testImageTwo, Globals.AForgeConfig.CompareLevel + 0.03, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true
                )
            {
                //if (Globals.Log)
                //    Globals.WriteLog("no back port");
                var proc1 = new ProcessStartInfo();
                string anyCommand1 = String.Format("adb shell input tap 705 15");
                proc1.UseShellExecute = true;
                proc1.WorkingDirectory = @"C:\TMP";
                proc1.FileName = @"C:\Windows\System32\cmd.exe";
                proc1.Verb = "runas";
                proc1.Arguments = "/c " + anyCommand1;
                proc1.WindowStyle = ProcessWindowStyle.Hidden;
                var process2 = new System.Diagnostics.Process();

                //var process2 = Process.Start(proc1);
                process2.EnableRaisingEvents = true;
                process2.StartInfo = proc1;
                process2.Exited += (sv2, ev2) =>
                {
                    //System.Threading.Thread.Sleep(1000);
                    sleepTime = 1000;
                    msg = DateTime.Now + " " + "no back land 1000";

                    //Delay(1000);
                };
                process2.Start();
                process2.WaitForExit();
                //process2.Close();

            }

            else if (ImageComparer.CompareImages(Globals.NoBackLand1Image, testImageTwo, Globals.AForgeConfig.CompareLevel + 0.03, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true
                || ImageComparer.CompareImages(Globals.NoBackLand2Image, testImageTwo, Globals.AForgeConfig.CompareLevel + 0.03, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true
                )
            {
                //if (Globals.Log)
                //    Globals.WriteLog("no back land");
                var proc1 = new ProcessStartInfo();
                string anyCommand1 = String.Format("adb shell input tap 1450 15");
                proc1.UseShellExecute = true;
                proc1.WorkingDirectory = @"C:\TMP";
                proc1.FileName = @"C:\Windows\System32\cmd.exe";
                proc1.Verb = "runas";
                proc1.Arguments = "/c " + anyCommand1;
                proc1.WindowStyle = ProcessWindowStyle.Hidden;
                var process2 = new System.Diagnostics.Process();

                //var process2 = Process.Start(proc1);
                process2.EnableRaisingEvents = true;
                process2.StartInfo = proc1;
                process2.Exited += (sv2, ev2) =>
                {
                    //System.Threading.Thread.Sleep(1000);
                    sleepTime = 1000;
                    msg = DateTime.Now + " " + "no back land 1000";

                    //Delay(1000);
                };
                process2.Start();
                process2.WaitForExit();
                //process2.Close();

            }




            else if (ImageComparer.CompareImages(Globals.EndOfferImage, testImageTwo, Globals.AForgeConfig.CompareLevel + 0.03, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true)
            {
                Globals.NoOffersInARow = 0;
                Globals.WatchedAds++;
                sleepTime = 1000;
                msg = DateTime.Now + " " + "end of offer 1000";
                //MethodInvoker myProcessStarter2 = new MethodInvoker(AppProcess.CloseEndOfOfferWindow);
                //myProcessStarter2.BeginInvoke(null, null);

                AppProcess.CloseEndOfOfferWindow();

            }

            else if (ImageComparer.CompareImages(Globals.PrepareImage, testImageTwo, Globals.AForgeConfig.CompareLevel - 0.10, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true)
            {
                //MethodInvoker myProcessStarter2 = new MethodInvoker(AppProcess.OpenOffersWindow);
                //myProcessStarter2.BeginInvoke(null, null);

                AppProcess.OpenOffersWindow();
                sleepTime = 1000;
                msg = DateTime.Now + " " + "prepare 1000";

            }
            else
            {
                //MethodInvoker myProcessStarter2 = new MethodInvoker(AppProcess.Wait);
                //myProcessStarter2.BeginInvoke(null, null);

                AppProcess.Wait();
                sleepTime = 5000;
                msg = DateTime.Now + " " + "else 5000";
            }




            System.Threading.Timer TheTimer = null;
            int t = 0;
            TheTimer = new System.Threading.Timer((ot) =>
            {
                try
                {
                    TheTimer.Dispose();
                }
                catch (Exception ex)
                {
                    if (TheTimer != null)
                        TheTimer.Dispose();

                }


            }, null, sleepTime, 1000);


            Logger.WriteLog(msg);
            deleteFiles();



            if (chkActive.Checked == true)
                btnRun_Click(null, null);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //adb shell monkey -p com.scopely.headshot -c android.intent.category.LAUNCHER 1   START
            //adb shell am force-stop com.scopely.headshot STOP
            //adb shell am kill com.scopely.headshot KILL
            //adb shell am start -a android.settings.SETTINGS



            // adb shell am start -a  android.settings.SETTINGS\com.google.android.gms\com.google.android.gms.ads.settings.AdsSettingsActivity


            //adb shell am start -n com.android.settings/.Settings -e :android:show_fragment com.google.android.gms.app.settings.GoogleSettingsLink

            //com.google.android.gms/com.google.android.gms.app.settings.GoogleSettingsLink
            //adb shell am start -n com.android.settings/com.google.android.gms.app.settings.GoogleSettingsLink

            //adb shell am start -a  com.google.android.gms.ui/u0a26
        }

        private void btnClearLogs_Click(object sender, EventArgs e)
        {
            Logger.ClearLog();
        }

        private void btnKillProcesses_Click(object sender, EventArgs e)
        {
            //Process self = Process.GetCurrentProcess();
            //foreach (Process p in Process.GetProcesses().Where(p => p.Id != self.Id))
            //{
            //    p.Kill();
            //}

            //Process[] objArrProcesses = Process.GetProcesses();

            //MessageBox.Show(objArrProcesses.Length + "");

            //foreach (Process objProcess in objArrProcesses)
            //{
            //    MessageBox.Show(objProcess.ProcessName);
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {

            var info1 = new System.Diagnostics.ProcessStartInfo();
            info1.FileName = @"C:\Windows\System32\cmd.exe";
            info1.UseShellExecute = true;
            info1.WorkingDirectory = @"C:\TMP";
            info1.FileName = @"C:\Windows\System32\cmd.exe";
            info1.Verb = "runas";
            info1.Arguments = "/c " + String.Format("adb shell am force-stop com.scopely.headshot"); ;
            info1.WindowStyle = ProcessWindowStyle.Hidden;
            var process1 = new System.Diagnostics.Process();
            process1.StartInfo = info1;
            process1.EnableRaisingEvents = true;
            process1.Exited += (sv1, ev1) =>
            {
                int time = random.Next(10000, 20000);
                //sleepTime = time;
                //msg = DateTime.Now + " offers " + time;
                //System.Threading.Thread.Sleep(time);
                //Delay(time);

            };
            process1.Start();
            process1.WaitForExit();
            process1.Close();
            System.Threading.Thread.Sleep(1000);

            //var info1 = new System.Diagnostics.ProcessStartInfo();
            info1.FileName = @"C:\Windows\System32\cmd.exe";
            info1.UseShellExecute = true;
            info1.WorkingDirectory = @"C:\TMP";
            info1.FileName = @"C:\Windows\System32\cmd.exe";
            info1.Verb = "runas";
            info1.Arguments = "/c " + String.Format("adb shell am start -a android.settings.SETTINGS"); ;
            info1.WindowStyle = ProcessWindowStyle.Hidden;
            //var process1 = new System.Diagnostics.Process();
            process1.StartInfo = info1;
            process1.EnableRaisingEvents = true;
            process1.Exited += (sv1, ev1) =>
            {
                int time = random.Next(10000, 20000);
                //sleepTime = time;
                //msg = DateTime.Now + " offers " + time;
                //System.Threading.Thread.Sleep(time);
                //Delay(time);

            };
            process1.Start();
            process1.WaitForExit();
            process1.Close();
            System.Threading.Thread.Sleep(1000);



            //var info1 = new System.Diagnostics.ProcessStartInfo();
            info1.FileName = @"C:\Windows\System32\cmd.exe";
            info1.UseShellExecute = true;
            info1.WorkingDirectory = @"C:\TMP";
            info1.FileName = @"C:\Windows\System32\cmd.exe";
            info1.Verb = "runas";
            info1.Arguments = "/c " + String.Format("adb shell input swipe  100 800 100 100 500");
            info1.WindowStyle = ProcessWindowStyle.Hidden;
            //var process1 = new System.Diagnostics.Process();
            process1.StartInfo = info1;
            process1.EnableRaisingEvents = true;
            process1.Exited += (sv1, ev1) =>
            {
                int time = random.Next(10000, 20000);
                //sleepTime = time;
                //msg = DateTime.Now + " offers " + time;
                //System.Threading.Thread.Sleep(time);
                //Delay(time);

            };
            process1.Start();
            process1.WaitForExit();
            process1.Close();
            System.Threading.Thread.Sleep(1000);




            //var info1 = new System.Diagnostics.ProcessStartInfo();
            info1.FileName = @"C:\Windows\System32\cmd.exe";
            info1.UseShellExecute = true;
            info1.WorkingDirectory = @"C:\TMP";
            info1.FileName = @"C:\Windows\System32\cmd.exe";
            info1.Verb = "runas";
            info1.Arguments = "/c " + String.Format("adb shell input tap 400 600"); ;
            info1.WindowStyle = ProcessWindowStyle.Hidden;
            //var process1 = new System.Diagnostics.Process();
            process1.StartInfo = info1;
            process1.EnableRaisingEvents = true;
            process1.Exited += (sv1, ev1) =>
            {
                int time = random.Next(10000, 20000);
                //sleepTime = time;
                //msg = DateTime.Now + " offers " + time;
                //System.Threading.Thread.Sleep(time);
                //Delay(time);

            };
            process1.Start();
            process1.WaitForExit();
            process1.Close();


            System.Threading.Thread.Sleep(1000);




            //var info1 = new System.Diagnostics.ProcessStartInfo();
            info1.FileName = @"C:\Windows\System32\cmd.exe";
            info1.UseShellExecute = true;
            info1.WorkingDirectory = @"C:\TMP";
            info1.FileName = @"C:\Windows\System32\cmd.exe";
            info1.Verb = "runas";
            info1.Arguments = "/c " + String.Format("adb shell input tap 400 660"); ;
            info1.WindowStyle = ProcessWindowStyle.Hidden;
            //var process1 = new System.Diagnostics.Process();
            process1.StartInfo = info1;
            process1.EnableRaisingEvents = true;
            process1.Exited += (sv1, ev1) =>
            {
                int time = random.Next(10000, 20000);
                //sleepTime = time;
                //msg = DateTime.Now + " offers " + time;
                //System.Threading.Thread.Sleep(time);
                //Delay(time);

            };
            process1.Start();
            process1.WaitForExit();
            process1.Close();


            info1.FileName = @"C:\Windows\System32\cmd.exe";
            info1.UseShellExecute = true;
            info1.WorkingDirectory = @"C:\TMP";
            info1.FileName = @"C:\Windows\System32\cmd.exe";
            info1.Verb = "runas";
            info1.Arguments = "/c " + String.Format("adb shell input tap 400 200");
            info1.WindowStyle = ProcessWindowStyle.Hidden;
            //var process1 = new System.Diagnostics.Process();
            process1.StartInfo = info1;
            process1.EnableRaisingEvents = true;
            process1.Exited += (sv1, ev1) =>
            {
                int time = random.Next(10000, 20000);
                //sleepTime = time;
                //msg = DateTime.Now + " offers " + time;
                //System.Threading.Thread.Sleep(time);
                //Delay(time);

            };
            process1.Start();
            process1.WaitForExit();
            process1.Close();


            info1.FileName = @"C:\Windows\System32\cmd.exe";
            info1.UseShellExecute = true;
            info1.WorkingDirectory = @"C:\TMP";
            info1.FileName = @"C:\Windows\System32\cmd.exe";
            info1.Verb = "runas";
            info1.Arguments = "/c " + String.Format("adb shell input tap 600 800");
            info1.WindowStyle = ProcessWindowStyle.Hidden;
            //var process1 = new System.Diagnostics.Process();
            process1.StartInfo = info1;
            process1.EnableRaisingEvents = true;
            process1.Exited += (sv1, ev1) =>
            {
                int time = random.Next(10000, 20000);
                //sleepTime = time;
                //msg = DateTime.Now + " offers " + time;
                //System.Threading.Thread.Sleep(time);
                //Delay(time);

            };
            process1.Start();
            process1.WaitForExit();
            process1.Close();





            System.Threading.Thread.Sleep(1000);
            info1.FileName = @"C:\Windows\System32\cmd.exe";
            info1.UseShellExecute = true;
            info1.WorkingDirectory = @"C:\TMP";
            info1.FileName = @"C:\Windows\System32\cmd.exe";
            info1.Verb = "runas";
            info1.Arguments = "/c " + String.Format("adb shell input keyevent 4");
            info1.WindowStyle = ProcessWindowStyle.Hidden;
            //var process1 = new System.Diagnostics.Process();
            process1.StartInfo = info1;
            process1.EnableRaisingEvents = true;
            process1.Exited += (sv1, ev1) =>
            {
                int time = random.Next(10000, 20000);

            };
            process1.Start();
            process1.WaitForExit();
            process1.Close();


            System.Threading.Thread.Sleep(1000);
            info1.FileName = @"C:\Windows\System32\cmd.exe";
            info1.UseShellExecute = true;
            info1.WorkingDirectory = @"C:\TMP";
            info1.FileName = @"C:\Windows\System32\cmd.exe";
            info1.Verb = "runas";
            info1.Arguments = "/c " + String.Format("adb shell input keyevent 4");
            info1.WindowStyle = ProcessWindowStyle.Hidden;
            //var process1 = new System.Diagnostics.Process();
            process1.StartInfo = info1;
            process1.EnableRaisingEvents = true;
            process1.Exited += (sv1, ev1) =>
            {
                int time = random.Next(10000, 20000);

            };
            process1.Start();
            process1.WaitForExit();
            process1.Close();

            System.Threading.Thread.Sleep(1000);
            info1.FileName = @"C:\Windows\System32\cmd.exe";
            info1.UseShellExecute = true;
            info1.WorkingDirectory = @"C:\TMP";
            info1.FileName = @"C:\Windows\System32\cmd.exe";
            info1.Verb = "runas";
            info1.Arguments = "/c " + String.Format("adb shell input keyevent 4");
            info1.WindowStyle = ProcessWindowStyle.Hidden;
            //var process1 = new System.Diagnostics.Process();
            process1.StartInfo = info1;
            process1.EnableRaisingEvents = true;
            process1.Exited += (sv1, ev1) =>
            {
                int time = random.Next(10000, 20000);

            };
            process1.Start();
            process1.WaitForExit();
            process1.Close();


            System.Threading.Thread.Sleep(1000);


            info1.FileName = @"C:\Windows\System32\cmd.exe";
            info1.UseShellExecute = true;
            info1.WorkingDirectory = @"C:\TMP";
            info1.FileName = @"C:\Windows\System32\cmd.exe";
            info1.Verb = "runas";
            info1.Arguments = "/c " + String.Format("adb shell monkey -p com.scopely.headshot -c android.intent.category.LAUNCHER 1");
            info1.WindowStyle = ProcessWindowStyle.Hidden;
            //var process1 = new System.Diagnostics.Process();
            process1.StartInfo = info1;
            process1.EnableRaisingEvents = true;
            process1.Exited += (sv1, ev1) =>
            {
                int time = random.Next(10000, 20000);
                //sleepTime = time;
                //msg = DateTime.Now + " offers " + time;
                //System.Threading.Thread.Sleep(time);
                //Delay(time);

            };
            process1.Start();
            process1.WaitForExit();
            process1.Close();







        }

        private void button4_Click(object sender, EventArgs e)
        {
            var info1 = new System.Diagnostics.ProcessStartInfo();
            info1.FileName = @"C:\Windows\System32\cmd.exe";
            info1.UseShellExecute = true;
            info1.WorkingDirectory = @"C:\TMP";
            info1.FileName = @"C:\Windows\System32\cmd.exe";
            info1.Verb = "runas";
            info1.Arguments = "/c " + String.Format("adb shell am kill android.settings.SETTINGS"); ;
            info1.WindowStyle = ProcessWindowStyle.Hidden;
            var process1 = new System.Diagnostics.Process();
            process1.StartInfo = info1;
            process1.EnableRaisingEvents = true;
            process1.Exited += (sv1, ev1) =>
            {
                int time = random.Next(10000, 20000);
                //sleepTime = time;
                //msg = DateTime.Now + " offers " + time;
                //System.Threading.Thread.Sleep(time);
                //Delay(time);

            };
            process1.Start();
            process1.WaitForExit();
            process1.Close();

        }

        private void btnRun3_Click(object sender, EventArgs e)
        {





            int sleepTime = 0;
            string msg = "";

            //MethodInvoker myProcessStarter = new MethodInvoker(AppProcess.TakeSceenshot);
            //myProcessStarter.BeginInvoke(null, null);

            var info = new System.Diagnostics.ProcessStartInfo();
            string fileName = DateTime.Now.Ticks.ToString().Replace(' ', '-') + ".jpg";
            string anyCommand = String.Format("adb shell screencap -p /sdcard/screencap.jpg && adb pull /sdcard/screencap.jpg " + Globals.Temp_Dir + "\\" + fileName);
            info.FileName = @"C:\Windows\System32\cmd.exe";
            info.UseShellExecute = true;
            info.WorkingDirectory = @"C:\TMP";
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

            //return fileName;




            //string fileName = AppProcess.TakeSceenshot();

            //string fileName = Globals.fileName;
            //System.Threading.Thread.Sleep(1000);
            System.Threading.Timer TheTimer1 = null;
            int t1 = 0;
            TheTimer1 = new System.Threading.Timer((ot) =>
            {
                try
                {
                    TheTimer1.Dispose();
                }
                catch (Exception ex)
                {
                    if (TheTimer1 != null)
                        TheTimer1.Dispose();
                }

            }, null, 1000, 100);


            //string dirpath = Globals.Temp_Dir;
            string testImageTwo = Globals.Temp_Dir + "\\" + fileName;
            //System.Threading.Thread.Sleep(1000);


            if (ImageComparer.CompareImages(Globals.OfferImage, testImageTwo, Globals.AForgeConfig.CompareLevel, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true)
            {
                //MethodInvoker myProcessStarter1 = new MethodInvoker(AppProcess.RunOffer);
                //myProcessStarter1.BeginInvoke(null, null);

                //AppProcess.RunOffer();

                var info1 = new System.Diagnostics.ProcessStartInfo();
                info1.FileName = @"C:\Windows\System32\cmd.exe";
                info1.UseShellExecute = true;
                info1.WorkingDirectory = @"C:\TMP";
                info1.FileName = @"C:\Windows\System32\cmd.exe";
                info1.Verb = "runas";
                info1.Arguments = "/c " + String.Format("adb shell input tap 600 550"); ;
                info1.WindowStyle = ProcessWindowStyle.Hidden;
                var process1 = new System.Diagnostics.Process();
                process1.StartInfo = info1;
                process1.EnableRaisingEvents = true;
                process1.Exited += (sv1, ev1) =>
                {
                    //int time = random.Next(10000, 20000);
                    //sleepTime = time;
                    //msg = DateTime.Now + " offers " + time;
                    //System.Threading.Thread.Sleep(time);
                    //Delay(time);

                };
                process1.Start();
                process1.WaitForExit();



                int time = random.Next(10000, 20000);
                sleepTime = time;
                msg = DateTime.Now + " offers " + time;
            }
            else if (ImageComparer.CompareImages(Globals.NoOfferImage, testImageTwo, Globals.AForgeConfig.CompareLevel + 0.03, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true)
            {
                Globals.NoOffersInARow++;

                //MethodInvoker myProcessStarter2 = new MethodInvoker(AppProcess.CloseNoOfferWindow);
                //myProcessStarter2.BeginInvoke(null, null);

                //AppProcess.CloseNoOfferWindow();



                //Globals.NoOffersInARow++;
                //if (Globals.Log)
                //    Globals.WriteLog("no offer");
                var proc11 = new ProcessStartInfo();
                Random random = new Random();
                int x = random.Next(700, 780);
                int y = random.Next(420, 500);
                string anyCommand11 = String.Format("adb shell input tap {0} {1}", x, y);
                proc11.UseShellExecute = true;
                proc11.WorkingDirectory = @"C:\TMP";
                proc11.FileName = @"C:\Windows\System32\cmd.exe";
                proc11.Verb = "runas";
                proc11.Arguments = "/c " + anyCommand11;
                proc11.WindowStyle = ProcessWindowStyle.Hidden;
                var process21 = new System.Diagnostics.Process();
                //var process21 = Process.Start(proc11);
                process21.EnableRaisingEvents = true;
                process21.StartInfo = proc11;
                process21.Exited += (sv21, ev21) =>
                {
                    //System.Threading.Thread.Sleep(2000);
                    //Delay(2000);
                    //sleepTime = 2000;
                    //msg = DateTime.Now + " " + "no offer 2000";

                };
                process21.Start();
                process21.WaitForExit();



                sleepTime = 2000;
                msg = DateTime.Now + " " + "no offer 2000";
            }
            else if (ImageComparer.CompareImages(Globals.LoadingImage, testImageTwo, Globals.AForgeConfig.CompareLevel, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true)
            {
                sleepTime = 2000;
                msg = DateTime.Now + " " + "loading 2000";
            }
            else if (ImageComparer.CompareImages(Globals.NoBackPort1Image, testImageTwo, Globals.AForgeConfig.CompareLevel + 0.03, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true
                || ImageComparer.CompareImages(Globals.NoBackPort2Image, testImageTwo, Globals.AForgeConfig.CompareLevel + 0.03, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true
                )
            {
                //if (Globals.Log)
                //    Globals.WriteLog("no back port");
                var proc1 = new ProcessStartInfo();
                string anyCommand1 = String.Format("adb shell input tap 705 15");
                proc1.UseShellExecute = true;
                proc1.WorkingDirectory = @"C:\TMP";
                proc1.FileName = @"C:\Windows\System32\cmd.exe";
                proc1.Verb = "runas";
                proc1.Arguments = "/c " + anyCommand1;
                proc1.WindowStyle = ProcessWindowStyle.Hidden;
                var process2 = new System.Diagnostics.Process();

                //var process2 = Process.Start(proc1);
                process2.EnableRaisingEvents = true;
                process2.StartInfo = proc1;
                process2.Exited += (sv2, ev2) =>
                {
                    //System.Threading.Thread.Sleep(1000);
                    sleepTime = 1000;
                    msg = DateTime.Now + " " + "no back land 1000";

                    //Delay(1000);
                };
                process2.Start();
                process2.WaitForExit();
                //process2.Close();

            }

            else if (ImageComparer.CompareImages(Globals.NoBackLand1Image, testImageTwo, Globals.AForgeConfig.CompareLevel + 0.03, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true
                || ImageComparer.CompareImages(Globals.NoBackLand2Image, testImageTwo, Globals.AForgeConfig.CompareLevel + 0.03, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true
                )
            {
                //if (Globals.Log)
                //    Globals.WriteLog("no back land");
                var proc1 = new ProcessStartInfo();
                string anyCommand1 = String.Format("adb shell input tap 1450 15");
                proc1.UseShellExecute = true;
                proc1.WorkingDirectory = @"C:\TMP";
                proc1.FileName = @"C:\Windows\System32\cmd.exe";
                proc1.Verb = "runas";
                proc1.Arguments = "/c " + anyCommand1;
                proc1.WindowStyle = ProcessWindowStyle.Hidden;
                var process2 = new System.Diagnostics.Process();

                //var process2 = Process.Start(proc1);
                process2.EnableRaisingEvents = true;
                process2.StartInfo = proc1;
                process2.Exited += (sv2, ev2) =>
                {
                    //System.Threading.Thread.Sleep(1000);
                    sleepTime = 1000;
                    msg = DateTime.Now + " " + "no back land 1000";

                    //Delay(1000);
                };
                process2.Start();
                process2.WaitForExit();
                //process2.Close();

            }




            else if (ImageComparer.CompareImages(Globals.EndOfferImage, testImageTwo, Globals.AForgeConfig.CompareLevel + 0.03, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true)
            {
                Globals.NoOffersInARow = 0;
                Globals.WatchedAds++;
                sleepTime = 1000;
                msg = DateTime.Now + " " + "end of offer 1000";
                //MethodInvoker myProcessStarter2 = new MethodInvoker(AppProcess.CloseEndOfOfferWindow);
                //myProcessStarter2.BeginInvoke(null, null);


                //Globals.NoOffersInARow = 0;
                //Globals.WatchedAds++;
                var proc1 = new ProcessStartInfo();
                string anyCommand1 = String.Format("adb shell input keyevent 4");
                proc1.UseShellExecute = true;
                proc1.WorkingDirectory = @"C:\TMP";
                proc1.FileName = @"C:\Windows\System32\cmd.exe";
                proc1.Verb = "runas";
                proc1.Arguments = "/c " + anyCommand1;
                proc1.WindowStyle = ProcessWindowStyle.Hidden;
                var process2 = new System.Diagnostics.Process();
                process2.EnableRaisingEvents = true;
                process2.StartInfo = proc1;
                process2.Exited += (sv2, ev2) =>
                {
                    //System.Threading.Thread.Sleep(1000);
                    //sleepTime = 1000;
                    //msg = DateTime.Now + " " + "end of offer 1000";
                    //Delay(1000);
                };
                process2.Start();
                process2.WaitForExit();
                // process2.Close();




                //AppProcess.CloseEndOfOfferWindow();

            }

            else if (ImageComparer.CompareImages(Globals.PrepareImage, testImageTwo, Globals.AForgeConfig.CompareLevel - 0.10, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true)
            {
                //MethodInvoker myProcessStarter2 = new MethodInvoker(AppProcess.OpenOffersWindow);
                //myProcessStarter2.BeginInvoke(null, null);

                //AppProcess.OpenOffersWindow();



                var proc11 = new ProcessStartInfo();
                string anyCommand1 = String.Format("adb shell input tap 850 130");
                proc11.UseShellExecute = true;
                proc11.WorkingDirectory = @"C:\TMP";
                proc11.FileName = @"C:\Windows\System32\cmd.exe";
                proc11.Verb = "runas";
                proc11.Arguments = "/c " + anyCommand1;
                proc11.WindowStyle = ProcessWindowStyle.Hidden;
                var process1 = Process.Start(proc11);
                process1.EnableRaisingEvents = true;
                process1.Exited += (se1, sv1) =>
                {
                    //System.Threading.Thread.Sleep(1000);
                    //sleepTime = 1000;
                    //msg = DateTime.Now + " " + "prepare 1000";

                    //Delay(1000);
                };
                process1.WaitForExit();




                sleepTime = 1000;
                msg = DateTime.Now + " " + "prepare 1000";

            }
            else
            {
                //MethodInvoker myProcessStarter2 = new MethodInvoker(AppProcess.Wait);
                //myProcessStarter2.BeginInvoke(null, null);

                //AppProcess.Wait();


                var proc1 = new ProcessStartInfo();
                string anyCommand1 = String.Format("adb shell input keyevent 4");
                proc1.UseShellExecute = true;
                proc1.WorkingDirectory = @"C:\TMP";
                proc1.FileName = @"C:\Windows\System32\cmd.exe";
                proc1.Verb = "runas";
                proc1.Arguments = "/c " + anyCommand1;
                proc1.WindowStyle = ProcessWindowStyle.Hidden;
                var process2 = new System.Diagnostics.Process();
                //var process2 = Process.Start(proc1);
                process2.EnableRaisingEvents = true;
                process2.StartInfo = proc1;
                process2.Exited += (sv2, ev2) =>
                {
                    //System.Threading.Thread.Sleep(5000);
                    //sleepTime = 5000;
                    //msg = DateTime.Now + " " + "else 5000";

                    //Delay(5000);
                };
                process2.Start();
                process2.WaitForExit();



                sleepTime = 5000;
                msg = DateTime.Now + " " + "else 5000";
            }




            System.Threading.Timer TheTimer = null;
            int t = 0;
            TheTimer = new System.Threading.Timer((ot) =>
            {
                try
                {
                    TheTimer.Dispose();
                }
                catch (Exception ex)
                {
                    if (TheTimer != null)
                        TheTimer.Dispose();

                }


            }, null, sleepTime, 1000);


            Logger.WriteLog(msg);
            deleteFiles();



            if (chkActive.Checked == true)
                btnRun3_Click(null, null);


        }

        private void btnBackgoundWorker_Click(object sender, EventArgs e)
        {
            if (chkActive.Checked == true)
                backgroundWorker1.RunWorkerAsync();



        }

    }
}
