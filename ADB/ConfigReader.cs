using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADB
{
    class ConfigReader
    {

        public static Point GetPoint(string section, string key)
        {

            IniFile f = new IniFile(@"Config\config.ini");
            string s = f.IniReadValue(section, key);
            String[] ss = s.Trim().Split(',');
            Point p = new Point(Int32.Parse(ss[0]), Int32.Parse(ss[1]));
            return p;

        }




    }
}
