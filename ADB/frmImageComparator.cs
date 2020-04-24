using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADB
{


    public partial class frmImageComparator : Form
    {


        int imgcnt=1;
        string Image1Path, Image2Path;
        float SimilarityThreshold = 0.5f;
        double CompareLevel = 0.95;

        public frmImageComparator()
        {
            InitializeComponent();
        }

        private void frmImageComparator_Load(object sender, EventArgs e)
        {
            txtSimilarityThreshold.Text = SimilarityThreshold + "";
            txtCompareLevel.Text = CompareLevel + "";

        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            CompareLevel = Double.Parse(txtCompareLevel.Text);
            SimilarityThreshold = Single.Parse(txtSimilarityThreshold.Text);
            lblResult.Text = ImageComparer.CompareImages(Image1Path, Image2Path, CompareLevel, Globals.Temp_Dir, SimilarityThreshold) + "";
        }

        private void btnImage1_Click(object sender, EventArgs e)
        {
            try
            {
                ofd.Filter = "*.jpg|*.jpg";
                string path; // this is the path that you are checking.
                if (Directory.Exists(Globals.Base_Dir))
                {
                    ofd.InitialDirectory = Globals.Base_Dir;
                }
                else
                {
                    ofd.InitialDirectory = @"C:\";
                }
                ofd.ShowDialog();

                Image1Path = ofd.FileName;

                pct1.Image = new Bitmap(Image1Path);

            }
            catch (Exception ex)
            {

            }
        }

        private void btnImage2_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(Image2Path) == false && File.Exists(Image2Path) == true)
            //{
            //    pct2.Image = null;
            //    File.Delete(Image2Path);
            //}

            Image2Path = Globals.Temp_Dir + "\\" + AppProcess.TakeSceenshot(string.Format("sec{0}.jpg",imgcnt));
            //pct2.Image = null;
            pct2.Image = new Bitmap(Image2Path);
            imgcnt++;
            //pct2.Refresh();
        }
    }
}
