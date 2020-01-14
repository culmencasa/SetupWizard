using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Windows.Forms;

namespace SetupWizard.Views
{
    public partial class LicenseForm : RoundedCornerForm
    {
        public LicenseForm()
        {
            InitializeComponent();
        }

        private void LicenseForm_Load(object sender, EventArgs e)
        {
            //txtContent.Text = SetupWizard.Properties.Resources.ResourceManager.GetString("软件协议书");

            txtContent.LoadFile("license.rtf", RichTextBoxStreamType.RichText);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
        }

        //public override void OnShadowNeeded()
        //{
        //    // 用了圆角再显示阴影会有白边
        //    //base.OnShadowNeeded();
        //}

        private void btnAgree_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }


    }
}
