using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADB
{
    class Logger
    {

        public static void WriteLog(string log)
        {
            try
            {
                StreamWriter sw = new StreamWriter(Globals.LogFile, true);
                sw.WriteLine(log);
                sw.Close();
            }
            catch (Exception ex)
            {

            }
        }

        public static void ClearLog()
        {
            StreamWriter sw = new StreamWriter(Globals.LogFile);
            sw.Write("");
            sw.Close();
        }

        public static string[] ReadLog()
        {
            try
            {
                StreamReader sr = new StreamReader(Globals.LogFile);
                string all = sr.ReadToEnd();
                string[] lines = all.Split('\n');
                sr.Close();
                return lines;

            }
            catch (Exception ex)
            {
                return null;
            }

        }


    }
}
