using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// adb shell settings get secure android_id //get UUID

namespace ADB
{
    class Globals
    {
        public static string OfferImage = @"Base\offers.jpg";
        public static string EndOfferImage = @"Base\end-offer.jpg";
        public static string NoOfferImage = @"Base\no-offer.jpg";
        public static string LoadingImage = @"Base\loading.jpg";
        public static string PrepareImage = @"Base\prepare.jpg";
        public static string CloseImage = @"Base\close.jpg";
        public static string IntroImage = @"Base\intro.jpg";
        public static string FirstScene1Image = @"Base\first-scene-1.jpg";
        public static string FirstScene2Image = @"Base\first-scene-2.jpg";
        public static string NoBackPort1Image = @"Base\no-back-port-1.jpg";
        public static string NoBackPort2Image = @"Base\no-back-port-2.jpg";
        public static string NoBackLand1Image = @"Base\no-back-land-1.jpg";
        public static string NoBackLand2Image = @"Base\no-back-land-2.jpg";
        public static string NetError1Image = @"Base\net-error-1.jpg";
        public static string NetError2Image = @"Base\net-error-2.jpg";
        public static string PrestigeRewardsImage = @"Base\pr-rewards.jpg";
        public static string PrestigeRewardsClaimImage = @"Base\pr-rewards-claim.jpg";


        public static string Base_Dir;
        public static string Temp_Dir;
        public static string Working_Directory_Dir;
        public static string CommandName = @"C:\Windows\System32\cmd.exe";



        public static int WatchedAds = 0;
        public static int NoOffersInARow = 0;
        public static int LoadingTriesInARow = 0;
        public static int ElseInARow = 0;






        public static bool GameCrashed = false;


        public static String[] AdsActivities = { 
                                               "com.mopub.mobileads",
                                               "com.unity3d.ads.adunit",
                                               "com.adcolony.sdk"
                                               };

        public static String[] GameActivities = { 
                                               "com.iugome.client"
                                               };


        //public static Size ScreenSize = new Size(1480, 720);
        public static Size ScreenSize = new Size(0,0);

        public static class AForgeConfig
        {
            public static float SimilarityThreshold = 0.50f;
            public static double CompareLevel = 0.95;
        }


        public static string fileName = "";





        public static string LogFile = @"Logs\logs.txt";

        public static bool Log = true;





    }
}
