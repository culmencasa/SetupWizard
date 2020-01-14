namespace SetupWizard.Uninstaller
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBegin = new System.Windows.Forms.CustomButton();
            this.pnlProcessing = new System.Windows.Forms.ClickThroughPanel();
            this.lblProgressInfo = new System.Windows.Forms.Label();
            this.pbInstall = new System.Windows.Forms.ProgressBar();
            this.bgwUninstall = new System.ComponentModel.BackgroundWorker();
            this.pnlProcessing.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBegin
            // 
            this.btnBegin.BackColor = System.Drawing.Color.White;
            this.btnBegin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(177)))), ((int)(((byte)(150)))));
            this.btnBegin.CornerRadius = 50;
            this.btnBegin.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBegin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(212)))), ((int)(((byte)(183)))));
            this.btnBegin.GradientMode = false;
            this.btnBegin.Location = new System.Drawing.Point(220, 156);
            this.btnBegin.Name = "btnBegin";
            this.btnBegin.RoundCorners = ((System.Windows.Forms.Corners)((((System.Windows.Forms.Corners.TopLeft | System.Windows.Forms.Corners.TopRight) 
            | System.Windows.Forms.Corners.BottomLeft) 
            | System.Windows.Forms.Corners.BottomRight)));
            this.btnBegin.ShadeMode = true;
            this.btnBegin.Size = new System.Drawing.Size(161, 49);
            this.btnBegin.TabIndex = 1002;
            this.btnBegin.Text = "卸    载";
            this.btnBegin.Click += new System.EventHandler(this.btnBegin_Click);
            // 
            // pnlProcessing
            // 
            this.pnlProcessing.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlProcessing.BackColor = System.Drawing.Color.White;
            this.pnlProcessing.BorderRadius = 0;
            this.pnlProcessing.Controls.Add(this.lblProgressInfo);
            this.pnlProcessing.Controls.Add(this.pbInstall);
            this.pnlProcessing.Location = new System.Drawing.Point(4, 280);
            this.pnlProcessing.Name = "pnlProcessing";
            this.pnlProcessing.Size = new System.Drawing.Size(592, 75);
            this.pnlProcessing.TabIndex = 1003;
            this.pnlProcessing.Visible = false;
            // 
            // lblProgressInfo
            // 
            this.lblProgressInfo.AutoSize = true;
            this.lblProgressInfo.Location = new System.Drawing.Point(24, 35);
            this.lblProgressInfo.Name = "lblProgressInfo";
            this.lblProgressInfo.Size = new System.Drawing.Size(17, 12);
            this.lblProgressInfo.TabIndex = 7;
            this.lblProgressInfo.Text = "0%";
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
            // bgwUninstall
            // 
            this.bgwUninstall.WorkerReportsProgress = true;
            this.bgwUninstall.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwUninstall_DoWork);
            this.bgwUninstall.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwUninstall_ProgressChanged);
            this.bgwUninstall.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwUninstall_RunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SetupWizard.Uninstaller.Properties.Resources.bg_2x;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(600, 360);
            this.Controls.Add(this.pnlProcessing);
            this.Controls.Add(this.btnBegin);
            this.Name = "MainForm";
            this.ShowFormShadow = true;
            this.ShowTitleCenter = true;
            this.ShowTitleText = false;
            this.Text = "Form1";
            this.Controls.SetChildIndex(this.btnBegin, 0);
            this.Controls.SetChildIndex(this.pnlProcessing, 0);
            this.pnlProcessing.ResumeLayout(false);
            this.pnlProcessing.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CustomButton btnBegin;
        private System.Windows.Forms.ClickThroughPanel pnlProcessing;
        private System.Windows.Forms.Label lblProgressInfo;
        private System.Windows.Forms.ProgressBar pbInstall;
        private System.ComponentModel.BackgroundWorker bgwUninstall;
    }
}

