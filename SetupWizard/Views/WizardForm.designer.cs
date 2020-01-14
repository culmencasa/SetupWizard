using SetupWizard;
using System.Windows.Forms;

namespace SetupWizard.Views
{
    partial class WizardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WizardForm));
            this.pnlProcessing = new System.Windows.Forms.ClickThroughPanel();
            this.lblProgressInfo = new System.Windows.Forms.Label();
            this.pbInstall = new System.Windows.Forms.ProgressBar();
            this.pnlOptionSwitch = new System.Windows.Forms.Panel();
            this.lblOptionSwitch = new System.Windows.Forms.Label();
            this.btnOptionSwitch = new System.Windows.Forms.ImageButton();
            this.pnlOptions = new System.Windows.Forms.ClickThroughPanel();
            this.btnCloseOptionPanel = new System.Windows.Forms.CustomButton();
            this.btnBegin2 = new System.Windows.Forms.CustomButton();
            this.lblPathHead = new System.Windows.Forms.Label();
            this.btnBegin = new System.Windows.Forms.CustomButton();
            this.pbTitle = new System.Windows.Forms.PictureBox();
            this.pbSubtitle = new System.Windows.Forms.PictureBox();
            this.btnDone = new System.Windows.Forms.CustomButton();
            this.pnlShortcuts = new System.Windows.Forms.Panel();
            this.chkDesktop = new SetupWizard.MonoFlatBlue_CheckBox();
            this.chkQuickLaunch = new SetupWizard.MonoFlatBlue_CheckBox();
            this.lnkLicense = new SetupWizard.MonoFlatBlue_LinkLabel();
            this.chkAgreeLicense = new SetupWizard.MonoFlatBlue_CheckBox();
            this.btnChangePath = new SetupWizard.MonoFlatBlue_Button();
            this.txtInstallPath = new Ambiance.Ambiance_TextBox();
            this.pnlProcessing.SuspendLayout();
            this.pnlOptionSwitch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOptionSwitch)).BeginInit();
            this.pnlOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSubtitle)).BeginInit();
            this.pnlShortcuts.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlProcessing
            // 
            this.pnlProcessing.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlProcessing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.pnlProcessing.Controls.Add(this.lblProgressInfo);
            this.pnlProcessing.Controls.Add(this.pbInstall);
            this.pnlProcessing.Location = new System.Drawing.Point(4, 281);
            this.pnlProcessing.Name = "pnlProcessing";
            this.pnlProcessing.Size = new System.Drawing.Size(592, 75);
            this.pnlProcessing.TabIndex = 5;
            this.pnlProcessing.Visible = false;
            // 
            // lblProgressInfo
            // 
            this.lblProgressInfo.AutoSize = true;
            this.lblProgressInfo.Location = new System.Drawing.Point(24, 35);
            this.lblProgressInfo.Name = "lblProgressInfo";
            this.lblProgressInfo.Size = new System.Drawing.Size(51, 20);
            this.lblProgressInfo.TabIndex = 7;
            this.lblProgressInfo.Text = "label1";
            // 
            // pbInstall
            // 
            this.pbInstall.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(205)))), ((int)(((byte)(191)))));
            this.pbInstall.Location = new System.Drawing.Point(15, 16);
            this.pbInstall.Name = "pbInstall";
            this.pbInstall.Size = new System.Drawing.Size(560, 10);
            this.pbInstall.Step = 1;
            this.pbInstall.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbInstall.TabIndex = 6;
            this.pbInstall.Value = 100;
            // 
            // pnlOptionSwitch
            // 
            this.pnlOptionSwitch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOptionSwitch.Controls.Add(this.lblOptionSwitch);
            this.pnlOptionSwitch.Controls.Add(this.btnOptionSwitch);
            this.pnlOptionSwitch.Location = new System.Drawing.Point(483, 324);
            this.pnlOptionSwitch.Name = "pnlOptionSwitch";
            this.pnlOptionSwitch.Size = new System.Drawing.Size(109, 22);
            this.pnlOptionSwitch.TabIndex = 4;
            // 
            // lblOptionSwitch
            // 
            this.lblOptionSwitch.AutoSize = true;
            this.lblOptionSwitch.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOptionSwitch.Location = new System.Drawing.Point(22, 0);
            this.lblOptionSwitch.Name = "lblOptionSwitch";
            this.lblOptionSwitch.Size = new System.Drawing.Size(79, 19);
            this.lblOptionSwitch.TabIndex = 3;
            this.lblOptionSwitch.Text = "自定义选项";
            this.lblOptionSwitch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnOptionSwitch_MouseClick);
            this.lblOptionSwitch.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblOptionSwitch_MouseDown);
            this.lblOptionSwitch.MouseEnter += new System.EventHandler(this.lblOptionSwitch_MouseEnter);
            this.lblOptionSwitch.MouseLeave += new System.EventHandler(this.lblOptionSwitch_MouseLeave);
            // 
            // btnOptionSwitch
            // 
            this.btnOptionSwitch.BackColor = System.Drawing.Color.Transparent;
            this.btnOptionSwitch.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnOptionSwitch.DownImage = global::SetupWizard.Properties.Resources.down_hover;
            this.btnOptionSwitch.Location = new System.Drawing.Point(4, 0);
            this.btnOptionSwitch.Name = "btnOptionSwitch";
            this.btnOptionSwitch.NormalImage = global::SetupWizard.Properties.Resources.down_normal;
            this.btnOptionSwitch.ShowFocusLine = false;
            this.btnOptionSwitch.Size = new System.Drawing.Size(15, 15);
            this.btnOptionSwitch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnOptionSwitch.TabIndex = 2;
            this.btnOptionSwitch.ToolTipText = null;
            this.btnOptionSwitch.Visible = false;
            this.btnOptionSwitch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnOptionSwitch_MouseClick);
            // 
            // pnlOptions
            // 
            this.pnlOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOptions.BackColor = System.Drawing.Color.Transparent;
            this.pnlOptions.Controls.Add(this.btnCloseOptionPanel);
            this.pnlOptions.Controls.Add(this.btnBegin2);
            this.pnlOptions.Controls.Add(this.btnChangePath);
            this.pnlOptions.Controls.Add(this.txtInstallPath);
            this.pnlOptions.Controls.Add(this.lblPathHead);
            this.pnlOptions.Location = new System.Drawing.Point(10, 197);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(583, 156);
            this.pnlOptions.TabIndex = 5;
            this.pnlOptions.Visible = false;
            // 
            // btnCloseOptionPanel
            // 
            this.btnCloseOptionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseOptionPanel.BorderColor = System.Drawing.Color.Transparent;
            this.btnCloseOptionPanel.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCloseOptionPanel.GradientMode = false;
            this.btnCloseOptionPanel.Location = new System.Drawing.Point(389, 119);
            this.btnCloseOptionPanel.Name = "btnCloseOptionPanel";
            this.btnCloseOptionPanel.ShadeMode = false;
            this.btnCloseOptionPanel.Size = new System.Drawing.Size(75, 23);
            this.btnCloseOptionPanel.TabIndex = 1006;
            this.btnCloseOptionPanel.Text = "< 返回";
            this.btnCloseOptionPanel.Click += new System.EventHandler(this.btnCloseOptionPanel_Click);
            // 
            // btnBegin2
            // 
            this.btnBegin2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBegin2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(212)))), ((int)(((byte)(183)))));
            this.btnBegin2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnBegin2.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBegin2.ForeColor = System.Drawing.Color.White;
            this.btnBegin2.GradientMode = false;
            this.btnBegin2.Location = new System.Drawing.Point(476, 114);
            this.btnBegin2.Name = "btnBegin2";
            this.btnBegin2.RoundCorners = ((System.Windows.Forms.Corners)((((System.Windows.Forms.Corners.TopLeft | System.Windows.Forms.Corners.TopRight) 
            | System.Windows.Forms.Corners.BottomLeft) 
            | System.Windows.Forms.Corners.BottomRight)));
            this.btnBegin2.ShadeMode = false;
            this.btnBegin2.Size = new System.Drawing.Size(96, 32);
            this.btnBegin2.TabIndex = 1005;
            this.btnBegin2.Text = "立即安装";
            this.btnBegin2.Click += new System.EventHandler(this.btnBegin_Click);
            // 
            // lblPathHead
            // 
            this.lblPathHead.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPathHead.ForeColor = System.Drawing.Color.White;
            this.lblPathHead.Location = new System.Drawing.Point(29, 17);
            this.lblPathHead.Name = "lblPathHead";
            this.lblPathHead.Size = new System.Drawing.Size(73, 25);
            this.lblPathHead.TabIndex = 5;
            this.lblPathHead.Text = "安装路径:";
            this.lblPathHead.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBegin
            // 
            this.btnBegin.BackColor = System.Drawing.Color.White;
            this.btnBegin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(177)))), ((int)(((byte)(150)))));
            this.btnBegin.CornerRadius = 50;
            this.btnBegin.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBegin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(212)))), ((int)(((byte)(183)))));
            this.btnBegin.GradientMode = false;
            this.btnBegin.Location = new System.Drawing.Point(220, 179);
            this.btnBegin.Name = "btnBegin";
            this.btnBegin.RoundCorners = ((System.Windows.Forms.Corners)((((System.Windows.Forms.Corners.TopLeft | System.Windows.Forms.Corners.TopRight) 
            | System.Windows.Forms.Corners.BottomLeft) 
            | System.Windows.Forms.Corners.BottomRight)));
            this.btnBegin.ShadeMode = true;
            this.btnBegin.Size = new System.Drawing.Size(161, 49);
            this.btnBegin.TabIndex = 1001;
            this.btnBegin.Text = "快速安装";
            this.btnBegin.Click += new System.EventHandler(this.btnBegin_Click);
            // 
            // pbTitle
            // 
            this.pbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbTitle.BackColor = System.Drawing.Color.Transparent;
            this.pbTitle.Location = new System.Drawing.Point(194, 80);
            this.pbTitle.Name = "pbTitle";
            this.pbTitle.Size = new System.Drawing.Size(213, 31);
            this.pbTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTitle.TabIndex = 1002;
            this.pbTitle.TabStop = false;
            // 
            // pbSubtitle
            // 
            this.pbSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.pbSubtitle.Location = new System.Drawing.Point(136, 128);
            this.pbSubtitle.Name = "pbSubtitle";
            this.pbSubtitle.Size = new System.Drawing.Size(328, 17);
            this.pbSubtitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSubtitle.TabIndex = 1003;
            this.pbSubtitle.TabStop = false;
            // 
            // btnDone
            // 
            this.btnDone.BackColor = System.Drawing.Color.White;
            this.btnDone.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(177)))), ((int)(((byte)(150)))));
            this.btnDone.CornerRadius = 50;
            this.btnDone.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(212)))), ((int)(((byte)(183)))));
            this.btnDone.GradientMode = false;
            this.btnDone.Location = new System.Drawing.Point(418, 38);
            this.btnDone.Name = "btnDone";
            this.btnDone.RoundCorners = ((System.Windows.Forms.Corners)((((System.Windows.Forms.Corners.TopLeft | System.Windows.Forms.Corners.TopRight) 
            | System.Windows.Forms.Corners.BottomLeft) 
            | System.Windows.Forms.Corners.BottomRight)));
            this.btnDone.ShadeMode = true;
            this.btnDone.Size = new System.Drawing.Size(161, 49);
            this.btnDone.TabIndex = 1004;
            this.btnDone.Text = "立即使用";
            this.btnDone.Visible = false;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // pnlShortcuts
            // 
            this.pnlShortcuts.Controls.Add(this.chkDesktop);
            this.pnlShortcuts.Controls.Add(this.chkQuickLaunch);
            this.pnlShortcuts.Location = new System.Drawing.Point(16, 27);
            this.pnlShortcuts.Name = "pnlShortcuts";
            this.pnlShortcuts.Size = new System.Drawing.Size(359, 41);
            this.pnlShortcuts.TabIndex = 1007;
            this.pnlShortcuts.Visible = false;
            // 
            // chkDesktop
            // 
            this.chkDesktop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkDesktop.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(212)))), ((int)(((byte)(183)))));
            this.chkDesktop.CheckBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(212)))), ((int)(((byte)(183)))));
            this.chkDesktop.CheckColor = System.Drawing.Color.White;
            this.chkDesktop.Checked = true;
            this.chkDesktop.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chkDesktop.Location = new System.Drawing.Point(13, 12);
            this.chkDesktop.Name = "chkDesktop";
            this.chkDesktop.Size = new System.Drawing.Size(122, 16);
            this.chkDesktop.TabIndex = 1005;
            this.chkDesktop.Text = "创建桌面快捷方式";
            // 
            // chkQuickLaunch
            // 
            this.chkQuickLaunch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkQuickLaunch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(212)))), ((int)(((byte)(183)))));
            this.chkQuickLaunch.CheckBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(212)))), ((int)(((byte)(183)))));
            this.chkQuickLaunch.CheckColor = System.Drawing.Color.White;
            this.chkQuickLaunch.Checked = false;
            this.chkQuickLaunch.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chkQuickLaunch.Location = new System.Drawing.Point(153, 12);
            this.chkQuickLaunch.Name = "chkQuickLaunch";
            this.chkQuickLaunch.Size = new System.Drawing.Size(187, 16);
            this.chkQuickLaunch.TabIndex = 1006;
            this.chkQuickLaunch.Text = "创建快捷方式到快速启动栏";
            this.chkQuickLaunch.Visible = false;
            // 
            // lnkLicense
            // 
            this.lnkLicense.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(212)))), ((int)(((byte)(183)))));
            this.lnkLicense.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lnkLicense.AutoSize = true;
            this.lnkLicense.BackColor = System.Drawing.Color.Transparent;
            this.lnkLicense.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lnkLicense.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.lnkLicense.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(212)))), ((int)(((byte)(183)))));
            this.lnkLicense.Location = new System.Drawing.Point(123, 328);
            this.lnkLicense.Name = "lnkLicense";
            this.lnkLicense.Size = new System.Drawing.Size(79, 15);
            this.lnkLicense.TabIndex = 5;
            this.lnkLicense.TabStop = true;
            this.lnkLicense.Text = "用户许可协议";
            this.lnkLicense.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(126)))), ((int)(((byte)(230)))));
            this.lnkLicense.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLicense_LinkClicked);
            // 
            // chkAgreeLicense
            // 
            this.chkAgreeLicense.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkAgreeLicense.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(212)))), ((int)(((byte)(183)))));
            this.chkAgreeLicense.CheckBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(212)))), ((int)(((byte)(183)))));
            this.chkAgreeLicense.CheckColor = System.Drawing.Color.White;
            this.chkAgreeLicense.Checked = true;
            this.chkAgreeLicense.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.chkAgreeLicense.Location = new System.Drawing.Point(16, 327);
            this.chkAgreeLicense.Name = "chkAgreeLicense";
            this.chkAgreeLicense.Size = new System.Drawing.Size(122, 16);
            this.chkAgreeLicense.TabIndex = 1;
            this.chkAgreeLicense.Text = "已经阅读并同意";
            // 
            // btnChangePath
            // 
            this.btnChangePath.BackColor = System.Drawing.Color.Transparent;
            this.btnChangePath.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(207)))), ((int)(((byte)(194)))));
            this.btnChangePath.BorderPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(160)))), ((int)(((byte)(149)))));
            this.btnChangePath.ButtonFaceColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(207)))), ((int)(((byte)(194)))));
            this.btnChangePath.ButtonPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(160)))), ((int)(((byte)(149)))));
            this.btnChangePath.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.btnChangePath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnChangePath.Image = null;
            this.btnChangePath.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChangePath.Location = new System.Drawing.Point(499, 16);
            this.btnChangePath.Name = "btnChangePath";
            this.btnChangePath.PressForeColor = System.Drawing.Color.White;
            this.btnChangePath.Size = new System.Drawing.Size(58, 27);
            this.btnChangePath.TabIndex = 1004;
            this.btnChangePath.Text = "浏览...";
            this.btnChangePath.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnChangePath.Click += new System.EventHandler(this.btnChangePath_Click);
            // 
            // txtInstallPath
            // 
            this.txtInstallPath.BackColor = System.Drawing.Color.Transparent;
            this.txtInstallPath.BorderActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(225)))), ((int)(((byte)(214)))));
            this.txtInstallPath.BorderNormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(209)))), ((int)(((byte)(193)))));
            this.txtInstallPath.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInstallPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(90)))), ((int)(((byte)(110)))));
            this.txtInstallPath.Location = new System.Drawing.Point(108, 13);
            this.txtInstallPath.MaxLength = 32767;
            this.txtInstallPath.Multiline = false;
            this.txtInstallPath.Name = "txtInstallPath";
            this.txtInstallPath.ReadOnly = false;
            this.txtInstallPath.Size = new System.Drawing.Size(384, 32);
            this.txtInstallPath.TabIndex = 3;
            this.txtInstallPath.Text = "adfadsfasfasdfa";
            this.txtInstallPath.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtInstallPath.UseSystemPasswordChar = false;
            // 
            // WizardForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::SetupWizard.Properties.Resources.bg_2x;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(600, 360);
            this.Controls.Add(this.pnlShortcuts);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.pbSubtitle);
            this.Controls.Add(this.pnlOptionSwitch);
            this.Controls.Add(this.lnkLicense);
            this.Controls.Add(this.pbTitle);
            this.Controls.Add(this.btnBegin);
            this.Controls.Add(this.chkAgreeLicense);
            this.Controls.Add(this.pnlOptions);
            this.Controls.Add(this.pnlProcessing);
            this.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(212)))), ((int)(((byte)(183)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 360);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 360);
            this.Name = "WizardForm";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.ShowFormShadow = true;
            this.ShowLogo = false;
            this.ShowTitleCenter = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "智慧课堂安装向导";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WizardForm_FormClosing);
            this.Load += new System.EventHandler(this.frmWizard_Load);
            this.Controls.SetChildIndex(this.pnlProcessing, 0);
            this.Controls.SetChildIndex(this.pnlOptions, 0);
            this.Controls.SetChildIndex(this.chkAgreeLicense, 0);
            this.Controls.SetChildIndex(this.btnBegin, 0);
            this.Controls.SetChildIndex(this.pbTitle, 0);
            this.Controls.SetChildIndex(this.lnkLicense, 0);
            this.Controls.SetChildIndex(this.pnlOptionSwitch, 0);
            this.Controls.SetChildIndex(this.pbSubtitle, 0);
            this.Controls.SetChildIndex(this.btnDone, 0);
            this.Controls.SetChildIndex(this.pnlShortcuts, 0);
            this.pnlProcessing.ResumeLayout(false);
            this.pnlProcessing.PerformLayout();
            this.pnlOptionSwitch.ResumeLayout(false);
            this.pnlOptionSwitch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOptionSwitch)).EndInit();
            this.pnlOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSubtitle)).EndInit();
            this.pnlShortcuts.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ClickThroughPanel pnlProcessing;
        private System.Windows.Forms.Panel pnlOptionSwitch;
        private System.Windows.Forms.Label lblOptionSwitch;
        private System.Windows.Forms.ImageButton btnOptionSwitch;
        private ClickThroughPanel pnlOptions;
        private Ambiance.Ambiance_TextBox txtInstallPath;
        private MonoFlatBlue_CheckBox chkAgreeLicense;
        private MonoFlatBlue_LinkLabel lnkLicense;
        private System.Windows.Forms.ProgressBar pbInstall;
        private CustomButton btnBegin;
        private PictureBox pbTitle;
        private Label lblProgressInfo;
        private PictureBox pbSubtitle;
        private MonoFlatBlue_Button btnChangePath;
        private Label lblPathHead;
        private CustomButton btnBegin2;
        private CustomButton btnCloseOptionPanel;
        private CustomButton btnDone;
        private MonoFlatBlue_CheckBox chkDesktop;
        private MonoFlatBlue_CheckBox chkQuickLaunch;
        private Panel pnlShortcuts;
    }
}