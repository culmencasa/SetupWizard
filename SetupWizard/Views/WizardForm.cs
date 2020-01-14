using Ionic.Zip;
using IWshRuntimeLibrary;
using SetupWizard.Models;
using SetupWizard.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Windows.Utils;
using File = System.IO.File;

namespace SetupWizard.Views
{
    /// <summary>
    /// 安装向导
    /// </summary>
    public partial class WizardForm : RoundedCornerForm
    {
        #region 字段

        private FolderBrowserDialog fbd = new FolderBrowserDialog();

        private EZLogger logger;

        private BackgroundWorker worker = new BackgroundWorker();

        private UninstallInfo uninstInfo = new UninstallInfo();

        protected object _workLockObject = new object();
        #endregion

        #region DllImport


        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        internal static extern IntPtr LoadLibrary(string lpLibFileName);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        internal static extern int LoadString(IntPtr hInstance, uint wID, StringBuilder lpBuffer, int nBufferMax);

        #endregion


        #region 属性

        /// <summary>
        /// 安装路径 
        /// </summary>
        public string InstallDir { get; set; }

        /// <summary>
        /// 执行程序名称
        /// </summary>
        public string AppName { get; set; } = ConfigurationManager.AppSettings["AppName"];


        /// <summary>
        /// 产品名称
        /// </summary>
        public new string ProductName
        {
            get
            {
                return ConfigurationManager.AppSettings["LinkName"];
            }
        }

        /// <summary>
        /// 跳过Closing事件
        /// </summary>
        public bool CloseWithoutPrompt
        {
            get;
            set;
        }
        

        public bool IsCompleted
        {
            get;
            set;
        }


        #endregion


        #region 构造

        public WizardForm()
        {
            InitializeComponent();

            this.Text = ConfigurationManager.AppSettings["InstCaption"];

            // 启动日志
            logger = new EZLogger(Path.Combine(Application.StartupPath,
                @"Setup" + DateTime.Now.ToString("yyyyMMdd") + ".log"),
                true,
                (uint)EZLogger.Level.All);
            logger.Start();
        }

        #endregion

        #region 重写的成员

        #endregion

        #region 私有方法


        #endregion

        #region 事件处理

        // 窗体加载时
        private void frmWizard_Load(object sender, EventArgs e)
        {
            this.pnlOptions.Visible = false;
            this.Size = this.MinimumSize;
            //this.lblCompanyName.Text = CompanyName;

            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - this.MinimumSize.Height) / 2);
            //this.Update();

            // 设置对话框
            fbd.RootFolder = System.Environment.SpecialFolder.Desktop;
            fbd.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
            fbd.ShowNewFolderButton = true;

            // 设置文本框
            txtInstallPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\" + ProductName;
        }

        // 画产品背景
        private void ucThemeContainer_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.DrawImage(Resources.install_logo, 155, 26, 290, 85);
        }

        // 点击自定义选项按钮
        private void btnOptionSwitch_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Left)
                return;

            btnBegin.Visible = false;
            pnlProcessing.Visible = false;
            pnlOptions.Visible = true;
            pnlOptions.Location = new Point(10, 197);
            pnlOptions.BringToFront();

        }

        // 点击更改按钮
        private void btnChangePath_Click(object sender, EventArgs e)
        {
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtInstallPath.Text = fbd.SelectedPath + "\\" + ProductName;
            }
        }

        // 点击协议书
        private void lnkLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new LicenseForm().ShowDialog();
        }

        // 点击自定义选项文本
        private void lblOptionSwitch_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.Size == MaximumSize)
            {
                //btnOptionSwitch.NormalImage = Resources.up_hover;
            }
            else
            {
                //btnOptionSwitch.NormalImage = Resources.down_hover;
            }
        }

        // 焦点自定义选项文本
        private void lblOptionSwitch_MouseEnter(object sender, EventArgs e)
        {

            if (this.Size == MaximumSize)
            {
                btnOptionSwitch.NormalImage = Resources.up_hover;
            }
            else
            {
                btnOptionSwitch.NormalImage = Resources.down_hover;
            }
        }

        // 失焦自定义选项文本
        private void lblOptionSwitch_MouseLeave(object sender, EventArgs e)
        {
            if (this.Size == MaximumSize)
            {
                btnOptionSwitch.NormalImage = Resources.up_normal;
            }
            else
            {
                btnOptionSwitch.NormalImage = Resources.down_normal;
            }
        }


        // 点击安装按钮
        private void btnBegin_Click(object sender, EventArgs e)
        {
            if (!chkAgreeLicense.Checked)
            {
                DialogForm.Show("系统提示", "需勾选同意用户许可协议。", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string targetPath = txtInstallPath.Text;
            try
            {

                // 1.检测路径
                Directory.CreateDirectory(targetPath);

                // 设置权限
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(targetPath);
                FileSystemAccessRule fsar = new FileSystemAccessRule("Users", FileSystemRights.FullControl, AccessControlType.Allow);
                DirectorySecurity ds = di.GetAccessControl();
                ds.AddAccessRule(fsar);
                di.SetAccessControl(ds);

                InstallDir = targetPath;

                // 反安装记录
                this.uninstInfo.DestDir = targetPath;
                this.uninstInfo.Manifest = new List<InstalledFiles>();

                // 1.1检测zip文件
                string zipfile = "Release.zip";
                if (!System.IO.File.Exists(zipfile))
                {
                    DialogForm.Show("系统提示", "安装包不完整, 操作中止。");

                    try
                    {
                        Directory.Delete(targetPath);
                    }
                    catch
                    {
                    }

                    return;
                }

                // 2.开始
                HideFirstPage();
                ShowSecendPage();

                // 2.1解压到目标
                ExtractFile(zipfile, targetPath);

            }
            catch (UnauthorizedAccessException uacEx)
            {
                logger.Error(uacEx.StackTrace);

                DialogForm.Show("系统提示", "无法将文件安装到你选定的目录，请尝试用管理员身份运行。");
            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace);

                DialogForm.Show("系统提示", "无法将文件安装到你选定的目录，请检查路径是否正确或者是否拥有写权限。");
            }


        }

        public void SaveProgress(object sender, ProgressChangedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((ProgressChangedEventHandler)SaveProgress, new Object[] { sender, e });
            }
            else
            {
                if (e.ProgressPercentage == 0)
                {
                    pbInstall.Maximum = (int)e.UserState;
                    return;
                }

                if (e.ProgressPercentage >= pbInstall.Maximum)
                {
                    pbInstall.Value = pbInstall.Maximum;
                    // 3.结束
                    HideSecendPage();
                    ShowThirdPage();
                }
                else
                {
                    pbInstall.Value = e.ProgressPercentage;
                    lblProgressInfo.Text = string.Format("正在安装 ({0}%) ...", Math.Round(pbInstall.Value * 1.0d / pbInstall.Maximum * 100, 0));
                }
            }
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // 如果有对话框 , 把对话框关掉
            //DialogForm.Dismiss();


            IsCompleted = true;
        }

        #endregion  

        public void ExtractFile(string zipToUnpack, string unpackDirectory)
        {
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.ProgressChanged += SaveProgress;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            worker.DoWork += (o, e) =>
            {
                BackgroundWorker bgw = o as BackgroundWorker;
                //bgw.ReportProgress(0);

                using (ZipFile zip = ZipFile.Read(zipToUnpack))
                {
                    bgw.ReportProgress(0, zip.Count);

                    //double step = 100.0 / zip.Count;
                    int percentComplete = 0;


                    foreach (ZipEntry file in zip)
                    {
                        manualEvent.WaitOne(Timeout.Infinite);

                        if (bgw.CancellationPending)
                        {
                            e.Result = false;
                            return;
                        }

                        try
                        {
                            file.Extract(unpackDirectory, ExtractExistingFileAction.OverwriteSilently);
                        }
                        catch (Exception ex)
                        {
                            logger.Error(ex.Message);
                        }
                        percentComplete++;

                        // 到100%时不立即完成
                        if (percentComplete >= zip.Count)
                        {
                            percentComplete = zip.Count;
                        }
                        bgw.ReportProgress(percentComplete);
                    }

                    // 完成时等待一秒
                    Thread.Sleep(500);
                    percentComplete++;
                    bgw.ReportProgress(percentComplete);

                    // 不然work不会很快结束
                    e.Result = true;

                }
            };

            worker.RunWorkerAsync();
        }


        private void HideFirstPage()
        {
            btnBegin.Visible = false;
            pnlOptions.Visible = false;
            pnlOptionSwitch.Visible = false;
            chkAgreeLicense.Visible = false;
            lnkLicense.Visible = false;
            this.Size = this.MinimumSize;
        }

        private void ShowSecendPage()
        {
            btnBegin.Visible = false;
            pnlOptions.Visible = false;
            pnlProcessing.Visible = true;
            pnlProcessing.Location = new Point(4, 281);
            //pbInstall.Visible = true;
        }

        private void HideSecendPage()
        {
            pnlProcessing.Visible = false;
        }

        private void ShowThirdPage()
        {
            //pnlProcessing.Controls.Add(btnDone);
            btnDone.Location = btnBegin.Location;
            btnDone.Visible = true;

            pbSubtitle.Visible = false;

            pnlShortcuts.Visible = true;
            pnlShortcuts.Location = new Point(10, 315);
        }




        private void btnDone_Click(object sender, EventArgs e)
        {
            this.CloseWithoutPrompt = true;


            LastJob();

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = System.Windows.Forms.Application.ExecutablePath;
            startInfo.Verb = "runas";
            try
            {
                Process.Start(new ProcessStartInfo() { FileName = Path.Combine(InstallDir, this.AppName + ".exe") });
            }
            catch (Win32Exception ex)
            {
                // 操作被用户取消
                DialogForm.Show($"{ProductName}安装程序", "需要以管理员身份进行安装");
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        // 关闭自定义选项
        private void btnCloseOptionPanel_Click(object sender, EventArgs e)
        {
            pnlOptions.Visible = false;
            btnBegin.Visible = true;
        }

        static ManualResetEvent manualEvent = new ManualResetEvent(true);

        // 点击关闭窗体 
        private void WizardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CloseWithoutPrompt)
                return;


            if (worker != null && worker.IsBusy)
            {
                manualEvent.Reset();

                DialogResult quitDr = DialogForm.Show("问题", "要退出安装吗?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (quitDr == DialogResult.Yes)
                {
                    worker.CancelAsync();
                    e.Cancel = false;

                    manualEvent.Set();
                }
                else
                {
                    e.Cancel = true;

                    manualEvent.Set();
                }
            }
            else if (IsCompleted)
            {
                LastJob();
            }
            else
            {
            }
        }

        private bool ShortcutCreated { get; set; } = false;
        private void LastJob()
        {
            if (ShortcutCreated)
                return;

            RegOcx();


            WshShell shell = new WshShell();
            string lnkfile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), ProductName + ".lnk");
            string launcher = Path.Combine(InstallDir, this.AppName + ".exe");
            string ico = Path.Combine(InstallDir, "App.ico");

            // 创建桌面快捷方式
            if (chkDesktop.Checked)
            {
                IWshRuntimeLibrary.IWshShortcut wsDesktopShortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(lnkfile);
                wsDesktopShortcut.TargetPath = launcher;
                wsDesktopShortcut.WorkingDirectory = InstallDir;//工作文件夹
                wsDesktopShortcut.WindowStyle = 1;//窗体的样式：１为默认，２为最大化，３为最小化
                wsDesktopShortcut.Description = "";
                wsDesktopShortcut.IconLocation = ico;
                wsDesktopShortcut.Save();


                InstalledFiles item1 = new InstalledFiles();
                item1.FullPath = lnkfile;
                this.uninstInfo.Manifest.Add(item1);
            }

            // 创建快速启动快捷方式
            if (chkQuickLaunch.Checked)
            {

            }

            //在程序菜单中创建文件夹
            string menuDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Programs), ProductName);
            string menulnk = Path.Combine(menuDir, ProductName + ".lnk");
            if (!Directory.Exists(menuDir))
            {
                Directory.CreateDirectory(menuDir);
            }
            // 创建程序菜单中的主程序快捷方式
            IWshRuntimeLibrary.IWshShortcut wsStartMenuShortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(menulnk);
            wsStartMenuShortcut.TargetPath = launcher;
            wsStartMenuShortcut.WorkingDirectory = InstallDir;
            wsStartMenuShortcut.WindowStyle = 1;
            wsStartMenuShortcut.Description = "";
            wsStartMenuShortcut.IconLocation = ico;
            wsStartMenuShortcut.Save();


            InstalledFiles item2 = new InstalledFiles();
            item2.FullPath = menulnk;
            this.uninstInfo.Manifest.Add(item2);


            // 创建程序菜单中的卸载快捷方式
            //string uninstlnk = Path.Combine(menuDir, "卸载" + ProductName + ".lnk");
            //IWshRuntimeLibrary.IWshShortcut wsUninstallShortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(uninstlnk);
            //wsUninstallShortcut.TargetPath = "msiexec.exe";
            ////wsUninstallShortcut.Arguments = string.Format("/x {0}", productCode);
            //wsUninstallShortcut.WorkingDirectory = InstallDir;
            //wsUninstallShortcut.WindowStyle = 1;
            //wsUninstallShortcut.IconLocation = "msiexec.exe";// Path.Combine(rootDir, @"Resources\Icons\setup.ico");
            //wsUninstallShortcut.Description = "";
            //wsUninstallShortcut.Save();


            #region 自制的卸载程序

            string uninstallExeFileName = "Uninstaller.exe";
            string originalUninstallExePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, uninstallExeFileName);
            string targetUninstallExePath = Path.Combine(InstallDir, uninstallExeFileName);

            try
            {
                File.Copy(originalUninstallExePath, targetUninstallExePath, true);
            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace);
            }

            // 桌面上的卸载
            string uninstlnk = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), $"卸载{ProductName}.lnk");
            IWshRuntimeLibrary.IWshShortcut wsUninstallShortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(uninstlnk);
            wsUninstallShortcut.TargetPath = targetUninstallExePath;
            wsUninstallShortcut.WorkingDirectory = InstallDir;
            wsUninstallShortcut.WindowStyle = 1;
            wsUninstallShortcut.Description = "";
            wsUninstallShortcut.IconLocation = ico;
            wsUninstallShortcut.Save();


            // 开始菜单上的卸载
            string uninstMenulnk = Path.Combine(menuDir, $"卸载{ProductName}.lnk");
            IWshRuntimeLibrary.IWshShortcut wsStartMenuUninstallShortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(uninstMenulnk);
            wsStartMenuUninstallShortcut.TargetPath = launcher;
            wsStartMenuUninstallShortcut.WorkingDirectory = InstallDir;
            wsStartMenuUninstallShortcut.WindowStyle = 1;
            wsStartMenuUninstallShortcut.Description = "";
            wsStartMenuUninstallShortcut.IconLocation = ico;
            wsStartMenuUninstallShortcut.Save();


            InstalledFiles item3 = new InstalledFiles();
            item3.FullPath = uninstlnk;
            this.uninstInfo.Manifest.Add(item3);
            InstalledFiles item4 = new InstalledFiles();
            item4.FullPath = uninstMenulnk;
            this.uninstInfo.Manifest.Add(item4);



            // 卸载配置文件
            string unintsallConfig = Path.Combine(InstallDir, "uninst.xml");
            if (File.Exists(unintsallConfig))
            {
                File.Delete(unintsallConfig);
            }
            Helper.Serialize(unintsallConfig, this.uninstInfo);

            #endregion

            ShortcutCreated = true;
        }

        private void RegOcx()
        {
            // 需要以管理员权限运行
            string regocx = "regsvr32";
            string args = $" /s PPTButton.ocx";
            try
            {
                using (Process reg = new Process())
                {
                    reg.StartInfo.FileName = regocx;
                    reg.StartInfo.Arguments = args;
                    reg.StartInfo.WorkingDirectory = InstallDir;
                    reg.StartInfo.UseShellExecute = false;
                    reg.StartInfo.CreateNoWindow = true;

                    reg.StartInfo.RedirectStandardOutput = true;
                    reg.StartInfo.RedirectStandardError = true;

                    //reg.ErrorDataReceived += OnErrorDataReceived;
                    //reg.OutputDataReceived += OnOutputDataReceived;
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

        public static bool PinUnpinTaskbar(string filePath, bool pin)
        {
            if (!File.Exists(filePath)) throw new FileNotFoundException(filePath);
            int MAX_PATH = 255;
            var actionIndex = pin ? 5386 : 5387; // 5386 is the DLL index for"Pin to Tas&kbar", ref. http://www.win7dll.info/shell32_dll.html
                                                 //uncomment the following line to pin to start instead
                                                 //actionIndex = pin ? 51201 : 51394;
            StringBuilder szPinToStartLocalized = new StringBuilder(MAX_PATH);
            IntPtr hShell32 = LoadLibrary("Shell32.dll");
            LoadString(hShell32, (uint)actionIndex, szPinToStartLocalized, MAX_PATH);
            string localizedVerb = szPinToStartLocalized.ToString();

            string path = Path.GetDirectoryName(filePath);
            string fileName = Path.GetFileName(filePath);

            // create the shell application object
            dynamic shellApplication = Activator.CreateInstance(Type.GetTypeFromProgID("Shell.Application"));
            dynamic directory = shellApplication.NameSpace(path);
            dynamic link = directory.ParseName(fileName);

            dynamic verbs = link.Verbs();
            for (int i = 0; i < verbs.Count(); i++)
            {
                dynamic verb = verbs.Item(i);
                if (verb.Name.Equals(localizedVerb))
                {
                    verb.DoIt();
                    return true;
                }
            }
            return false;
        }
    }
}
