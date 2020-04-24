using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADB
{

    public partial class frmStableVersion : Form
    {
        Random random = new Random();
        private BackgroundWorker bwPlayAndWatchAds;
        private BackgroundWorker bwCloseAndReopenGame;
        private BackgroundWorker bwOpenGame;
        private BackgroundWorker bwResetAdId;
        private Boolean ToAddAsWatched = true;
        private DateTime startDate = new DateTime();
        IniFile f;

        public frmStableVersion()
        {
            InitializeComponent();

            bwPlayAndWatchAds = new System.ComponentModel.BackgroundWorker();
            bwPlayAndWatchAds.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwPlayAndWatchAds_DoWork);
            bwPlayAndWatchAds.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwPlayAndWatchAds_RunWorkerCompleted);
            //backgroundWorker1.ProgressChanged +=new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);

            bwCloseAndReopenGame = new System.ComponentModel.BackgroundWorker();
            bwCloseAndReopenGame.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwCloseAndReopenGame_DoWork);
            bwCloseAndReopenGame.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwCloseAndReopenGame_RunWorkerCompleted);

            bwResetAdId = new System.ComponentModel.BackgroundWorker();
            bwResetAdId.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwResetAdId_DoWork);
            bwResetAdId.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwResetAdId_RunWorkerCompleted);

            bwOpenGame = new System.ComponentModel.BackgroundWorker();
            bwOpenGame.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwOpenGame_DoWork);
            bwOpenGame.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwOpenGame_RunWorkerCompleted);



            f = new IniFile(@"Config\config.ini");


        }


        BindingList<string> bind = new BindingList<string>(Globals.MainLogs);

        private void bwPlayAndWatchAds_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //bind = new BindingList<string>(Globals.MainLogs);
            lstLog.DataSource = null;
            lstLog.DataSource = Globals.MainLogs;
            lstLog.SelectedIndex = -1;
            //lstLog.BeginUpdate();
            //if (Logger.ReadLog() != null)
            //{
            //    string[] lines = Logger.ReadLog();
            //    lstLog.Items.Clear();
            //    if (lines != null)
            //        lstLog.Items.AddRange(lines);
            //}

            ////((CurrencyManager)lstLog.BindingContext[Globals.MainLogs]).Refresh();
            //lstLog.EndUpdate();

            //if (Logger.ReadLog() != null)
            //{
            //    string[] lines = Logger.ReadLog();
            //    lstLog.Items.Clear();
            //    if (lines != null)
            //        lstLog.Items.AddRange(lines);
            //}

            lblNoOfferInARow.Text = Globals.NoOffersInARow + "";
            lblWatchedAds.Text = Globals.WatchedAds + "";
            lblLoadingInARow.Text = Globals.LoadingTriesInARow + "";
            lblElseInARow.Text = Globals.ElseInARow + "";
            lblAppNotRunningInARow.Text = Globals.AppNotRunningInARow + "";

            //if (Globals.ElseInARow > 20)
            //{
            //    AppProcess.Tap(1360, 50);
            //    Globals.ElseInARow = 0;
            //    Globals.WriteLog(DateTime.Now + "tap close button 0000");
            //    return;
            //}

            if (Globals.AppNotRunningInARow > 15)
            {
                bwOpenGame.RunWorkerAsync();
                return;
            }


            if (Globals.GameCrashed == true)
            {
                Globals.GameCrashed = false;
                bwCloseAndReopenGame.RunWorkerAsync();
                return;
            }


            if (Globals.LoadingTriesInARow > 15)
            {
                bwCloseAndReopenGame.RunWorkerAsync();
                return;
            }

            if (Globals.NoOffersInARow > 5)
            {

                //lstWatchedAds.Items.Add(Globals.WatchedAds);
                //Globals.WatchedAds = 0;
                //Globals.NoOffersInARow = 0;
                //Globals.LoadingTriesInARow = 0;


                bwResetAdId.RunWorkerAsync();
                return;
            }

            if (chkActive.Checked == true)
            {
                bwPlayAndWatchAds.RunWorkerAsync();
                return;
            }
            else
            {
                lstWatchedAds.Items.Add(Globals.WatchedAds);
                Globals.WatchedAds = 0;
                lblWatchedAds.Text = "0";

            }

            //int sm = 0;
            //foreach (string s in lstWatchedAds.Items)
            //{
            //    sm += Int32.Parse(s.Trim());
            //}
            //lblSum.Text = "Sum : " + sm;

        }

        private void bwCloseAndReopenGame_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (chkActive.Checked == true)
            {
                Globals.LoadingTriesInARow = 0;
                Globals.NoOffersInARow = 0;
                Globals.ElseInARow = 0;
                Globals.AppNotRunningInARow = 0;
                bwPlayAndWatchAds.RunWorkerAsync();
                return;
            }
            else
            {
                lstWatchedAds.Items.Add(Globals.WatchedAds);
                Globals.WatchedAds = 0;
                lblWatchedAds.Text = "0";
            }
        }

        private void bwResetAdId_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (chkActive.Checked == true)
            {
                Globals.LoadingTriesInARow = 0;
                Globals.NoOffersInARow = 0;
                Globals.ElseInARow = 0;
                Globals.AppNotRunningInARow = 0;
                bwPlayAndWatchAds.RunWorkerAsync();
                return;
            }
            else
            {
                lstWatchedAds.Items.Add(Globals.WatchedAds);
                Globals.WatchedAds = 0;
                lblWatchedAds.Text = "0";
            }

        }

        private void bwOpenGame_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (chkActive.Checked == true)
            {
                Globals.LoadingTriesInARow = 0;
                Globals.NoOffersInARow = 0;
                Globals.ElseInARow = 0;
                Globals.AppNotRunningInARow = 0;
                bwPlayAndWatchAds.RunWorkerAsync();
                return;
            }
            else
            {
                lstWatchedAds.Items.Add(Globals.WatchedAds);
                Globals.WatchedAds = 0;
                lblWatchedAds.Text = "0";
            }
        }


        private void bwPlayAndWatchAds_DoWork(object sender, DoWorkEventArgs e)
        {
            int sleepTime = 0;
            string msg = "";
            string fileName = "";
            string testImageTwo = "";

            if (AppProcess.isAppRunning() == false)
            {
                Globals.AppNotRunningInARow++;
                return;
            }





            if (AppProcess.isAdActivity() == true)
            {
                if (ToAddAsWatched == true)
                {
                    Globals.WatchedAds++;
                    Globals.NoOffersInARow = 0;
                    ToAddAsWatched = false;
                    Globals.LoadingTriesInARow = 0;
                    Globals.ElseInARow = 0;
                    startDate = DateTime.Now;
                }

                AppProcess.Wait();
                Globals.ElseInARow++;
                sleepTime = 2000;

                msg = DateTime.Now + " " + "else 2000 diffs : " + DateTime.Now.Subtract(startDate).Seconds + "";
                Globals.MainLogs.Add(msg);


                System.Threading.Thread.Sleep(2000);

                if (DateTime.Now.Subtract(startDate).Seconds > 35)
                {
                    fileName = AppProcess.TakeSceenshot();
                    testImageTwo = Globals.Temp_Dir + "\\" + fileName;
                    System.Drawing.Image imageOne;
                    using (var bmpTemp = new Bitmap(testImageTwo))
                    {
                        imageOne = new Bitmap(bmpTemp);
                    }

                    if (imageOne.Size.Width == Globals.ScreenSize.Height)
                    {
                        AppProcess.Tap(new Point(650, 50));
                        //AppProcess.Tap(ConfigReader.GetPoint("touch", "no-close-issue-port"));
                    }
                    else
                    {
                        AppProcess.Tap(new Point(1360, 50));
                        //AppProcess.Tap(ConfigReader.GetPoint("touch", "no-close-issue-land"));
                    }

                    Globals.ElseInARow = 0;
                    msg = DateTime.Now + " " + "tap close button 0000";
                    Logger.WriteLog(msg);
                    Globals.MainLogs.Add(msg);
                    //return;
                }






            }
            else
            {

                fileName = AppProcess.TakeSceenshot();
                //System.Threading.Thread.Sleep(1000);
                //System.Threading.Timer TheTimer1 = null;
                //int t1 = 0;
                //TheTimer1 = new System.Threading.Timer((ot) =>
                //{
                //    try
                //    {
                //        TheTimer1.Dispose();
                //    }
                //    catch (Exception ex)
                //    {
                //        if (TheTimer1 != null)
                //            TheTimer1.Dispose();
                //    }

                //}, null, 1000, 100);
                testImageTwo = Globals.Temp_Dir + "\\" + fileName;
                //System.Threading.Thread.Sleep(1000);
                if (ImageComparer.CompareImages(Globals.OfferImage, testImageTwo, Globals.AForgeConfig.CompareLevel, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true)
                {
                    ToAddAsWatched = true;
                    AppProcess.RunOffer();
                    int time = random.Next(10000, 20000);
                    sleepTime = time;
                    msg = DateTime.Now + " offers " + time;
                    Globals.MainLogs.Add(msg);
                }
                else if (ImageComparer.CompareImages(Globals.NoOfferImage, testImageTwo, Globals.AForgeConfig.CompareLevel + 0.01, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true)
                {
                    Globals.NoOffersInARow++;
                    Globals.LoadingTriesInARow = 0;
                    Globals.ElseInARow = 0;
                    AppProcess.CloseNoOfferWindow();
                    sleepTime = 2000;
                    msg = DateTime.Now + " " + "no offer 2000";
                    Globals.MainLogs.Add(msg);
                }
                else if (ImageComparer.CompareImages(Globals.LoadingImage, testImageTwo, Globals.AForgeConfig.CompareLevel, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true)
                {
                    Globals.LoadingTriesInARow++;
                    Globals.ElseInARow = 0;

                    sleepTime = 2000;
                    msg = DateTime.Now + " " + "loading 2000";
                    Globals.MainLogs.Add(msg);
                }
                else if (ImageComparer.CompareImages(Globals.EndOfferImage, testImageTwo, Globals.AForgeConfig.CompareLevel + 0.03, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true)
                {
                    Globals.NoOffersInARow = 0;
                    Globals.LoadingTriesInARow = 0;
                    Globals.ElseInARow = 0;
                    //Globals.WatchedAds++;
                    sleepTime = 1000;
                    msg = DateTime.Now + " " + "end of offer 1000";
                    Globals.MainLogs.Add(msg);
                    AppProcess.CloseEndOfOfferWindow();
                }
                else if (ImageComparer.CompareImages(Globals.IntroImage, testImageTwo, Globals.AForgeConfig.CompareLevel, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true)
                {
                    Globals.NoOffersInARow = 0;
                    Globals.LoadingTriesInARow = 0;
                    Globals.ElseInARow = 0;
                    //Globals.WatchedAds++;
                    sleepTime = 1000;
                    msg = DateTime.Now + " " + "crashed 1000";
                    Globals.MainLogs.Add(msg);
                    Globals.GameCrashed = true;
                }

                else if (ImageComparer.CompareImages(Globals.PrepareImage, testImageTwo, Globals.AForgeConfig.CompareLevel - 0.10, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true)
                {
                    AppProcess.OpenOffersWindow();
                    sleepTime = 1000;
                    msg = DateTime.Now + " " + "prepare 1000";
                    Globals.MainLogs.Add(msg);

                }
                else if (ImageComparer.CompareImages(Globals.PrestigeRewardsImage, testImageTwo, Globals.AForgeConfig.CompareLevel, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true)
                {



                    //AppProcess.Tap(ConfigReader.GetPoint("touch", "pr-rewards"));
                    AppProcess.Tap(new Point(740, 500));
                    System.Threading.Thread.Sleep(500);
                    //AppProcess.Tap(ConfigReader.GetPoint("touch", "pr-rewards"));
                    AppProcess.Tap(new Point(740, 500));
                    sleepTime = 1000;
                    msg = DateTime.Now + " " + "prestige rewards 1000";
                    Globals.MainLogs.Add(msg);

                }
                else if (ImageComparer.CompareImages(Globals.PrestigeRewardsClaimImage, testImageTwo, Globals.AForgeConfig.CompareLevel, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true)
                {

                    //AppProcess.Tap(ConfigReader.GetPoint("touch", "pr-rewards-claim"));
                    AppProcess.Tap(new Point(860, 620));
                    sleepTime = 1000;
                    msg = DateTime.Now + " " + "prestige rewards claim 1000";
                    Globals.MainLogs.Add(msg);

                }
                else if (ImageComparer.CompareImages(Globals.WarWindow1Image, testImageTwo, Globals.AForgeConfig.CompareLevel, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true)
                {


                    //AppProcess.Tap(ConfigReader.GetPoint("touch", "war-window-1"));
                    AppProcess.Tap(new Point(740, 660));
                    sleepTime = 1000;
                    msg = DateTime.Now + " " + "war window 1 1000";
                    Globals.MainLogs.Add(msg);

                }
                else if (ImageComparer.CompareImages(Globals.WarWindow2Image, testImageTwo, Globals.AForgeConfig.CompareLevel, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true)
                {
                    AppProcess.Tap(ConfigReader.GetPoint("touch", "war-window-2"));
                    //AppProcess.Tap(new Point(740, 630));
                    sleepTime = 1000;
                    msg = DateTime.Now + " " + "war window 2 1000";
                    Globals.MainLogs.Add(msg);

                }
                else if (ImageComparer.CompareImages(Globals.FirstScene1Image, testImageTwo, Globals.AForgeConfig.CompareLevel - 0.1, Globals.Temp_Dir,
                    Globals.AForgeConfig.SimilarityThreshold) == true)
                {
                    AppProcess.Swipe(new Point(1200, 700), new Point(100, 0), 500);
                    sleepTime = 1000;
                    msg = DateTime.Now + " " + "first screen 1 1000";
                    Globals.MainLogs.Add(msg);
                }
                else if (ImageComparer.CompareImages(Globals.FirstScene2Image, testImageTwo, Globals.AForgeConfig.CompareLevel - 0.1, Globals.Temp_Dir,
                    Globals.AForgeConfig.SimilarityThreshold) == true)
                {
                    AppProcess.Swipe(new Point(1200, 700), new Point(100, 0), 500);
                    sleepTime = 1000;
                    msg = DateTime.Now + " " + "first screen 2 1000";
                    Globals.MainLogs.Add(msg);
                }
                else
                {
                    AppProcess.Wait();
                    Globals.ElseInARow++;
                    sleepTime = 2000;
                    msg = DateTime.Now + " " + "else 2000";
                    Globals.MainLogs.Add(msg);
                }

            }



            //if (Globals.ElseInARow > 20)
            //{
            //    System.Drawing.Image imageOne;
            //    using (var bmpTemp = new Bitmap(testImageTwo))
            //    {
            //        imageOne = new Bitmap(bmpTemp);
            //    }

            //    if (imageOne.Size.Width == Globals.ScreenSize.Height)
            //    {
            //        AppProcess.Tap(new Point(650, 50));
            //    }
            //    else
            //    {
            //        AppProcess.Tap(new Point(1360, 50));
            //    }

            //    Globals.ElseInARow = 0;
            //    Logger.WriteLog(DateTime.Now + " " + "tap close button 0000");
            //    //return;
            //}
            //System.Threading.Thread.Sleep(sleepTime);




            //System.Threading.Timer TheTimer = null;
            //int t = 0;
            //TheTimer = new System.Threading.Timer((ot) =>
            //{
            //    try
            //    {
            //        TheTimer.Dispose();
            //    }
            //    catch (Exception ex)
            //    {
            //        if (TheTimer != null)
            //            TheTimer.Dispose();

            //    }


            //}, null, sleepTime, 1000);

            Logger.WriteLog(msg);

            deleteFiles();

        }


        private void bwCloseAndReopenGame_DoWork(object sender, DoWorkEventArgs e)
        {
            AppProcess.CloseGame();
            System.Threading.Thread.Sleep(2000);
            AppProcess.OpenGame();
            System.Threading.Thread.Sleep(10000);

            string fileName = "";
            string testImageTwo = "";

            int cnt = 0;
            bool whileLoopExit = false;

            while (true)
            {
                if (cnt > 5)
                {
                    break;
                }

                System.Threading.Thread.Sleep(500);
                fileName = AppProcess.TakeSceenshot();
                System.Threading.Thread.Sleep(1000);

                //System.Threading.Timer TheTimer1 = null;
                //int t1 = 0;
                //TheTimer1 = new System.Threading.Timer((ot) =>
                //{
                //    try
                //    {
                //        TheTimer1.Dispose();
                //    }
                //    catch (Exception ex)
                //    {
                //        if (TheTimer1 != null)
                //            TheTimer1.Dispose();
                //    }

                //}, null, 1000, 100);


                testImageTwo = Globals.Temp_Dir + "\\" + fileName;

                if (ImageComparer.CompareImages(Globals.WarWindow1Image, testImageTwo, Globals.AForgeConfig.CompareLevel, Globals.Temp_Dir,
Globals.AForgeConfig.SimilarityThreshold) == true)
                {
                    AppProcess.Tap(new Point(740, 660));
                    continue;
                }
                else if (ImageComparer.CompareImages(Globals.WarWindow11Image, testImageTwo, Globals.AForgeConfig.CompareLevel, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true)
                {
                    AppProcess.Tap(new Point(740, 660));
                    continue;

                }

                else if (ImageComparer.CompareImages(Globals.WarWindow2Image, testImageTwo, Globals.AForgeConfig.CompareLevel, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true)
                {
                    AppProcess.Tap(new Point(740, 630));
                    continue;

                }


                if (ImageComparer.CompareImages(Globals.PrestigeRewardsClaimImage, testImageTwo, Globals.AForgeConfig.CompareLevel, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true)
                {
                    AppProcess.Tap(new Point(860, 620));
                    continue;
                }

                if (ImageComparer.CompareImages(Globals.StartGamePrestigeRewardsClaimImage, testImageTwo, Globals.AForgeConfig.CompareLevel, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true)
                {
                    AppProcess.Tap(new Point(740, 620));
                    continue;
                }


                if (ImageComparer.CompareImages(Globals.FirstScene1Image, testImageTwo, Globals.AForgeConfig.CompareLevel - 0.1, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true)
                {
                    break;
                }

                if (ImageComparer.CompareImages(Globals.WarWindow1Image, testImageTwo, Globals.AForgeConfig.CompareLevel, Globals.Temp_Dir,
                    Globals.AForgeConfig.SimilarityThreshold) == true)
                {
                    AppProcess.Tap(new Point(740, 660));
                    System.Threading.Thread.Sleep(500);
                    AppProcess.Swipe(new Point(1200, 700), new Point(100, 0), 500);


                    continue;
                }
                else if (ImageComparer.CompareImages(Globals.WarWindow2Image, testImageTwo, Globals.AForgeConfig.CompareLevel, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true)
                {
                    AppProcess.Tap(new Point(740, 630));

                    System.Threading.Thread.Sleep(500);
                    AppProcess.Swipe(new Point(1200, 700), new Point(100, 0), 500);

                    continue;

                }



                else
                {
                    AppProcess.SendKey(AndroidKeys.KEYCODE_BACK);
                }

                cnt++;

                deleteFiles();
            }

            if (whileLoopExit == true)
            {
                fileName = AppProcess.TakeSceenshot();
                testImageTwo = Globals.Temp_Dir + "\\" + fileName;
                if (ImageComparer.CompareImages(Globals.ExitImage, testImageTwo, Globals.AForgeConfig.CompareLevel + 0.01, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true)
                {
                    AppProcess.SendKey(AndroidKeys.KEYCODE_BACK);
                }
                deleteFiles();
            }


            AppProcess.Swipe(new Point(1200, 700), new Point(100, 0), 500);

        }

        private void bwResetAdId_DoWork(object sender, DoWorkEventArgs e)
        {

            AppProcess.CloseGame();
            System.Threading.Thread.Sleep(500);
            AppProcess.DisableRotation();
            System.Threading.Thread.Sleep(500);
            AppProcess.OpenSettings();
            System.Threading.Thread.Sleep(1000);
            //AppProcess.Swipe(new Point(100, 800), new Point(100, 100), 500);
            System.Threading.Thread.Sleep(1000);
            //AppProcess.Tap(new Point(400, 600));
            //System.Threading.Thread.Sleep(500);
            //AppProcess.Tap(new Point(400, 660));
            //System.Threading.Thread.Sleep(500);


            AppProcess.Tap(ConfigReader.GetPoint("touch", "reset-id"));
            //AppProcess.Tap(new Point(400, 200));



            System.Threading.Thread.Sleep(500);


            AppProcess.Tap(ConfigReader.GetPoint("touch", "reset-id-dialog"));
            //AppProcess.Tap(new Point(600, 800));




            System.Threading.Thread.Sleep(500);
            AppProcess.SendKey(AndroidKeys.KEYCODE_BACK);

            //System.Threading.Thread.Sleep(500);
            //AppProcess.SendKey(AndroidKeys.KEYCODE_BACK);
            //System.Threading.Thread.Sleep(500);
            //AppProcess.SendKey(AndroidKeys.KEYCODE_BACK);

            System.Threading.Thread.Sleep(500);
            AppProcess.EnableRotation();
            System.Threading.Thread.Sleep(500);
            AppProcess.OpenGame();
            System.Threading.Thread.Sleep(10000);


            string fileName = "";
            string testImageTwo = "";
            int cnt = 0;
            bool whileLoopExit = false;
            while (true)
            {
                if (cnt > 5)
                {
                    whileLoopExit = true;
                    break;
                }

                System.Threading.Thread.Sleep(500);
                fileName = AppProcess.TakeSceenshot();
                System.Threading.Thread.Sleep(1000);

                //System.Threading.Timer TheTimer1 = null;
                //int t1 = 0;
                //TheTimer1 = new System.Threading.Timer((ot) =>
                //{
                //    try
                //    {
                //        TheTimer1.Dispose();
                //    }
                //    catch (Exception ex)
                //    {
                //        if (TheTimer1 != null)
                //            TheTimer1.Dispose();
                //    }

                //}, null, 1000, 100);

                testImageTwo = Globals.Temp_Dir + "\\" + fileName;


                if (ImageComparer.CompareImages(Globals.WarWindow1Image, testImageTwo, Globals.AForgeConfig.CompareLevel, Globals.Temp_Dir,
Globals.AForgeConfig.SimilarityThreshold) == true)
                {
                    AppProcess.Tap(new Point(740, 660));
                    continue;
                }
                else if (ImageComparer.CompareImages(Globals.WarWindow11Image, testImageTwo, Globals.AForgeConfig.CompareLevel, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true)
                {
                    AppProcess.Tap(new Point(740, 660));
                    continue;

                }

                else if (ImageComparer.CompareImages(Globals.WarWindow2Image, testImageTwo, Globals.AForgeConfig.CompareLevel, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true)
                {
                    AppProcess.Tap(new Point(740, 630));
                    continue;

                }




                if (ImageComparer.CompareImages(Globals.PrestigeRewardsClaimImage, testImageTwo, Globals.AForgeConfig.CompareLevel, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true)
                {
                    AppProcess.Tap(new Point(860, 620));
                    continue;
                }

                if (ImageComparer.CompareImages(Globals.StartGamePrestigeRewardsClaimImage, testImageTwo, Globals.AForgeConfig.CompareLevel, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true)
                {
                    AppProcess.Tap(new Point(740, 620));
                    continue;
                }



                if (ImageComparer.CompareImages(Globals.FirstScene1Image, testImageTwo, Globals.AForgeConfig.CompareLevel - 0.1, Globals.Temp_Dir,
                    Globals.AForgeConfig.SimilarityThreshold) == true)
                {
                    break;
                }




                else
                {
                    AppProcess.SendKey(AndroidKeys.KEYCODE_BACK);
                }


                cnt++;

                deleteFiles();
            }


            if (whileLoopExit == true)
            {
                fileName = AppProcess.TakeSceenshot();
                testImageTwo = Globals.Temp_Dir + "\\" + fileName;
                if (ImageComparer.CompareImages(Globals.ExitImage, testImageTwo, Globals.AForgeConfig.CompareLevel + 0.01,
                    Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true)
                {
                    AppProcess.SendKey(AndroidKeys.KEYCODE_BACK);
                }

                deleteFiles();
            }


            AppProcess.Swipe(new Point(1200, 700), new Point(100, 0), 500);


        }


        private void bwOpenGame_DoWork(object sender, DoWorkEventArgs e)
        {
            AppProcess.CloseGame();
            System.Threading.Thread.Sleep(2000);
            AppProcess.OpenGame();
            System.Threading.Thread.Sleep(10000);

            string fileName = "";
            string testImageTwo = "";

            int cnt = 0;
            bool whileLoopExit = false;

            while (true)
            {
                if (cnt > 5)
                {
                    break;
                }

                System.Threading.Thread.Sleep(500);
                fileName = AppProcess.TakeSceenshot();
                System.Threading.Thread.Sleep(1000);

                //System.Threading.Timer TheTimer1 = null;
                //int t1 = 0;
                //TheTimer1 = new System.Threading.Timer((ot) =>
                //{
                //    try
                //    {
                //        TheTimer1.Dispose();
                //    }
                //    catch (Exception ex)
                //    {
                //        if (TheTimer1 != null)
                //            TheTimer1.Dispose();
                //    }

                //}, null, 1000, 100);


                testImageTwo = Globals.Temp_Dir + "\\" + fileName;


                if (ImageComparer.CompareImages(Globals.WarWindow1Image, testImageTwo, Globals.AForgeConfig.CompareLevel, Globals.Temp_Dir,
Globals.AForgeConfig.SimilarityThreshold) == true)
                {
                    AppProcess.Tap(new Point(740, 660));
                    continue;
                }
                else if (ImageComparer.CompareImages(Globals.WarWindow11Image, testImageTwo, Globals.AForgeConfig.CompareLevel, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true)
                {
                    AppProcess.Tap(new Point(740, 660));
                    continue;

                }

                else if (ImageComparer.CompareImages(Globals.WarWindow2Image, testImageTwo, Globals.AForgeConfig.CompareLevel, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true)
                {
                    AppProcess.Tap(new Point(740, 630));
                    continue;

                }



                if (ImageComparer.CompareImages(Globals.PrestigeRewardsClaimImage, testImageTwo, Globals.AForgeConfig.CompareLevel, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true)
                {
                    AppProcess.Tap(new Point(860, 620));
                    continue;
                }

                if (ImageComparer.CompareImages(Globals.StartGamePrestigeRewardsClaimImage, testImageTwo, Globals.AForgeConfig.CompareLevel, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true)
                {
                    AppProcess.Tap(new Point(740, 620));
                    continue;
                }


                if (ImageComparer.CompareImages(Globals.FirstScene1Image, testImageTwo, Globals.AForgeConfig.CompareLevel - 0.1, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true)
                {
                    break;
                }


                else
                {
                    AppProcess.SendKey(AndroidKeys.KEYCODE_BACK);
                }

                cnt++;

                deleteFiles();
            }

            if (whileLoopExit == true)
            {
                fileName = AppProcess.TakeSceenshot();
                testImageTwo = Globals.Temp_Dir + "\\" + fileName;
                if (ImageComparer.CompareImages(Globals.ExitImage, testImageTwo, Globals.AForgeConfig.CompareLevel + 0.01, Globals.Temp_Dir, Globals.AForgeConfig.SimilarityThreshold) == true)
                {
                    AppProcess.SendKey(AndroidKeys.KEYCODE_BACK);
                }
                deleteFiles();
            }


            AppProcess.Swipe(new Point(1200, 700), new Point(100, 0), 500);



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





        private void btnPrepare_Click(object sender, EventArgs e)
        {
            AppProcess.Swipe(new Point(1200, 700), new Point(100, 0), 500);
            System.Threading.Thread.Sleep(1000);
            AppProcess.Tap(new Point(850, 130));
        }


        private void frmStableVersion_Load(object sender, EventArgs e)
        {

            
            Globals.ScreenSize.Width = Int32.Parse(f.IniReadValue("phone", "width").ToString());
            Globals.ScreenSize.Height = Int32.Parse(f.IniReadValue("phone", "height").ToString());

            //tsslStatus.Text = AppProcess.GetDeviceDetails();
            //lbl.Text = Globals.ScreenSize.Width + "  " + Globals.ScreenSize.Height;

            Logger.ClearLog();
            //tmrLog.Enabled = Globals.Log;

            Globals.Base_Dir = Application.StartupPath + "\\Base";
            Globals.Temp_Dir = Application.StartupPath + "\\Temp";
            Globals.Working_Directory_Dir = Application.StartupPath + "\\WorkingDirectory";


            if (Directory.Exists(Application.StartupPath + "\\Temp") == false)
                Directory.CreateDirectory(Application.StartupPath + "\\Temp");

            if (Directory.Exists(Application.StartupPath + "\\WorkingDirectory") == false)
                Directory.CreateDirectory(Application.StartupPath + "\\WorkingDirectory");

            lstLog.DataSource = Globals.MainLogs;




        }



        private void btnClearLogs_Click(object sender, EventArgs e)
        {
            Logger.ClearLog();
            lstLog.DataSource = null;
            Globals.MainLogs.Clear();
            lstLog.Items.Clear();
            lstLog.DataSource = Globals.MainLogs;


        }


        private void button3_Click(object sender, EventArgs e)
        {

            AppProcess.CloseGame();
            System.Threading.Thread.Sleep(500);
            AppProcess.DisableRotation();
            System.Threading.Thread.Sleep(500);
            AppProcess.OpenSettings();
            System.Threading.Thread.Sleep(1000);
            AppProcess.Swipe(new Point(100, 800), new Point(100, 100), 500);
            System.Threading.Thread.Sleep(1000);
            AppProcess.Tap(new Point(400, 600));
            System.Threading.Thread.Sleep(1000);
            AppProcess.Tap(new Point(400, 660));
            System.Threading.Thread.Sleep(1000);
            AppProcess.Tap(new Point(400, 200));
            System.Threading.Thread.Sleep(1000);
            AppProcess.Tap(new Point(600, 800));
            System.Threading.Thread.Sleep(1000);
            AppProcess.SendKey(AndroidKeys.KEYCODE_BACK);
            System.Threading.Thread.Sleep(1000);
            AppProcess.SendKey(AndroidKeys.KEYCODE_BACK);
            System.Threading.Thread.Sleep(1000);
            AppProcess.SendKey(AndroidKeys.KEYCODE_BACK);
            System.Threading.Thread.Sleep(500);
            AppProcess.EnableRotation();
            System.Threading.Thread.Sleep(500);
            AppProcess.OpenGame();
            System.Threading.Thread.Sleep(10000);
            AppProcess.Swipe(new Point(1200, 700), new Point(100, 0), 500);

        }


        private void btnBackgoundWorker_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkActive.Checked == true)
                    bwPlayAndWatchAds.RunWorkerAsync();

            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Running");
            }

        }

        private void chkRun_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkRun.Checked == true)
                {
                    bwOpenGame.RunWorkerAsync();
                    chkRun.Text = "Running";
                }
                else
                {
                    bwPlayAndWatchAds.CancelAsync();
                    chkRun.Text = "Stopped";
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Running");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bwCloseAndReopenGame.RunWorkerAsync();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProcessOutput output = AppProcess.RunProcess("adb devices");
            lbl.Text = output.Output + "\n" + output.Error;

        }

        private void tmrStatus_Tick(object sender, EventArgs e)
        {

            tsslStatus.Text = AppProcess.GetDeviceDetails();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string cpuInfo = string.Empty;
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();

            foreach (ManagementObject mo in moc)
            {
                if (cpuInfo == "")
                {
                    //Get only the first CPU's ID
                    cpuInfo = mo.Properties["processorID"].Value.ToString();
                    string Revision = mo.Properties["Revision"].Value.ToString();
                    MessageBox.Show(cpuInfo + "-----" + Revision);
                    //break;
                }
            }
        }


        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show(FingerPrint.Value() + " // " + AppProcess.GetAndroidId());
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmRegister().ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string line = AppProcess.RunProcess("adb shell settings get system accelerometer_rotation").Output;

            MessageBox.Show(line.Trim().Split('\n').Length + "");
        }

        private void imageComaratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmImageComparator().ShowDialog();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lstWatchedAds.Items.Clear();
        }

    }
}
