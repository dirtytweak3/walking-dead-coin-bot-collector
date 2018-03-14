using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADB
{
    public partial class frmRegister : Form
    {

        string PcId = "";
        string PhoneId = "";
        private BackgroundWorker bwGetIds;
        public frmRegister()
        {
            bwGetIds = new System.ComponentModel.BackgroundWorker();
            bwGetIds.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwGetIds_DoWork);
            bwGetIds.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwGetIds_RunWorkerCompleted);

            InitializeComponent();
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            bwGetIds.RunWorkerAsync();
        }

        private void bwGetIds_DoWork(object sender, DoWorkEventArgs e)
        {
            PcId = FingerPrint.Value();
            PhoneId = AppProcess.GetAndroidId();
        }

        private void bwGetIds_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            txtPcId.Text = PcId;
            txtPhoneId.Text = PhoneId;

        }
    }
}
