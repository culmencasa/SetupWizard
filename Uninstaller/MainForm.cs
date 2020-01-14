using SetupWizard.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SetupWizard.Uninstaller
{
    public partial class MainForm : RoundedCornerForm
    {
        public MainForm()
        {
            InitializeComponent();

            this.TitleText = "卸载";
            this.Load += MainForm_Load;
        }

        const string uninst = "uninst.xml";

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnBegin_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(this, "确定卸载程序吗?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.Yes)
            {
                if (!File.Exists(uninst))
                {
                    MessageBox.Show($"未能找到卸载配置文件 - {uninst}");
                    return;
                }


                bgwUninstall.RunWorkerAsync();

            }
        }

        private void bgwUninstall_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            int progress = 0;

            UninstallInfo info = Helper.Deserialize<UninstallInfo>(uninst);

            UnRegOcx(info.DestDir);


            DirectoryInfo di = new DirectoryInfo(info.DestDir);
            int total = di.GetFiles().Length + info.Manifest.Count();

            worker.ReportProgress(progress, total);

            foreach (var fi in di.GetFiles())
            {
                try
                {
                    fi.Delete();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Thread.Sleep(10);
                progress++;
                worker.ReportProgress(progress, progress);
            }

            foreach (InstalledFiles file in info.Manifest)
            {
                if (File.Exists(file.FullPath))
                {
                    File.Delete(file.FullPath);
                }
                Thread.Sleep(10);
                progress++;
                worker.ReportProgress(progress, progress);
            }

            worker.ReportProgress(total, total);

            try
            {
                Directory.Delete(info.DestDir, true);
            }
            catch
            { 
                
            }


            e.Result = true;
            


            
        }

        private void bgwUninstall_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (e.ProgressPercentage)
            {
                case 0: 
                    pnlProcessing.Visible = true;
                    btnBegin.Visible = false;

                    pbInstall.Maximum = (int)e.UserState;
                    pbInstall.Value = 0;
                    break;
                default: 
                    pbInstall.Value = (int)e.UserState;
                    if (pbInstall.Value >= pbInstall.Maximum)
                        pbInstall.Value = pbInstall.Maximum;
                    break;
            }

        }

        private void bgwUninstall_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((bool)e.Result == true)
            {
                btnBegin.Text = "卸载完成";
                btnBegin.Click -= btnBegin_Click;
                btnBegin.Click += (a, b) =>
                {
                    this.Close();
                    //todo: 使用批处理删除剩余文件
                };
                btnBegin.Visible = true;
                pnlProcessing.Visible = false;
            }
        }


        private void UnRegOcx(string dir)
        {
            // 需要以管理员权限运行
            string regocx = "regsvr32";
            string args = $" /s /u PPTButton.ocx";
            try
            {
                using (Process reg = new Process())
                {
                    reg.StartInfo.FileName = regocx;
                    reg.StartInfo.Arguments = args;
                    reg.StartInfo.WorkingDirectory = dir;
                    reg.StartInfo.UseShellExecute = false;
                    reg.StartInfo.CreateNoWindow = true;

                    reg.StartInfo.RedirectStandardOutput = true;
                    reg.StartInfo.RedirectStandardError = true;

                    reg.EnableRaisingEvents = true;
                    reg.Start();
                    reg.BeginErrorReadLine();
                    reg.BeginOutputReadLine();
                }
            }
            catch (Exception exc)
            {
                throw new Exception(regocx + " " + args, exc);
            }
        }


    }
}
