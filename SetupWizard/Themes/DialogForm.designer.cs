using SetupWizard;
using System.Windows.Forms;

namespace SetupWizard
{
    partial class DialogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DialogForm));
            this.lblContent = new System.Windows.Forms.Label();
            this.label_title = new System.Windows.Forms.Label();
            this.pnlControlButtons = new System.Windows.Forms.GradientPanel();
            this.pnlMsg = new System.Windows.Forms.Panel();
            this.pbDialogIcon = new System.Windows.Forms.PictureBox();
            this.btnOK = new System.Windows.Forms.CustomButton();
            this.btnCancel = new System.Windows.Forms.CustomButton();
            this.pnlControlButtons.SuspendLayout();
            this.pnlMsg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDialogIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // lblContent
            // 
            this.lblContent.BackColor = System.Drawing.Color.Transparent;
            this.lblContent.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblContent.ForeColor = System.Drawing.Color.White;
            this.lblContent.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblContent.ImageIndex = 0;
            this.lblContent.Location = new System.Drawing.Point(100, 20);
            this.lblContent.MaximumSize = new System.Drawing.Size(232, 9999);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(232, 38);
            this.lblContent.TabIndex = 1;
            // 
            // label_title
            // 
            this.label_title.AutoSize = true;
            this.label_title.BackColor = System.Drawing.Color.Transparent;
            this.label_title.Font = new System.Drawing.Font("宋体", 11F);
            this.label_title.ForeColor = System.Drawing.SystemColors.Control;
            this.label_title.Location = new System.Drawing.Point(14, 12);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(0, 15);
            this.label_title.TabIndex = 0;
            // 
            // pnlControlButtons
            // 
            this.pnlControlButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.pnlControlButtons.BorderColor = System.Drawing.Color.Empty;
            this.pnlControlButtons.BorderWidth = 1;
            this.pnlControlButtons.BottomBorderColor = System.Drawing.Color.Empty;
            this.pnlControlButtons.Controls.Add(this.btnCancel);
            this.pnlControlButtons.Controls.Add(this.btnOK);
            this.pnlControlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlControlButtons.FirstColor = System.Drawing.Color.Empty;
            this.pnlControlButtons.Location = new System.Drawing.Point(1, 109);
            this.pnlControlButtons.Name = "pnlControlButtons";
            this.pnlControlButtons.RoundBorderRadius = 0;
            this.pnlControlButtons.SecondColor = System.Drawing.Color.Empty;
            this.pnlControlButtons.Size = new System.Drawing.Size(352, 70);
            this.pnlControlButtons.TabIndex = 7;
            this.pnlControlButtons.Resize += new System.EventHandler(this.pnlControlButtons_Resize);
            // 
            // pnlMsg
            // 
            this.pnlMsg.BackColor = System.Drawing.Color.Transparent;
            this.pnlMsg.Controls.Add(this.lblContent);
            this.pnlMsg.Controls.Add(this.pbDialogIcon);
            this.pnlMsg.Location = new System.Drawing.Point(1, 32);
            this.pnlMsg.Name = "pnlMsg";
            this.pnlMsg.Padding = new System.Windows.Forms.Padding(20);
            this.pnlMsg.Size = new System.Drawing.Size(352, 78);
            this.pnlMsg.TabIndex = 8;
            // 
            // pbDialogIcon
            // 
            this.pbDialogIcon.Location = new System.Drawing.Point(23, 11);
            this.pbDialogIcon.Name = "pbDialogIcon";
            this.pbDialogIcon.Size = new System.Drawing.Size(56, 56);
            this.pbDialogIcon.TabIndex = 2;
            this.pbDialogIcon.TabStop = false;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(206)))), ((int)(((byte)(194)))));
            this.btnOK.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(148)))), ((int)(((byte)(131)))));
            this.btnOK.CornerRadius = 12;
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.GradientMode = false;
            this.btnOK.Location = new System.Drawing.Point(131, 20);
            this.btnOK.Name = "btnOK";
            this.btnOK.RoundCorners = ((System.Windows.Forms.Corners)((((System.Windows.Forms.Corners.TopLeft | System.Windows.Forms.Corners.TopRight) 
            | System.Windows.Forms.Corners.BottomLeft) 
            | System.Windows.Forms.Corners.BottomRight)));
            this.btnOK.ShadeMode = false;
            this.btnOK.Size = new System.Drawing.Size(101, 30);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.pictureBox_confirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.BorderColor = System.Drawing.Color.Silver;
            this.btnCancel.CornerRadius = 12;
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancel.GradientMode = false;
            this.btnCancel.Location = new System.Drawing.Point(238, 20);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.RoundCorners = ((System.Windows.Forms.Corners)((((System.Windows.Forms.Corners.TopLeft | System.Windows.Forms.Corners.TopRight) 
            | System.Windows.Forms.Corners.BottomLeft) 
            | System.Windows.Forms.Corners.BottomRight)));
            this.btnCancel.ShadeMode = false;
            this.btnCancel.Size = new System.Drawing.Size(101, 30);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.pictureBox_cancel_Click);
            // 
            // DialogForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(213)))), ((int)(((byte)(191)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(354, 180);
            this.Controls.Add(this.pnlMsg);
            this.Controls.Add(this.pnlControlButtons);
            this.Controls.Add(this.label_title);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(480, 640);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(270, 180);
            this.Name = "DialogForm";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Controls.SetChildIndex(this.label_title, 0);
            this.Controls.SetChildIndex(this.pnlControlButtons, 0);
            this.Controls.SetChildIndex(this.pnlMsg, 0);
            this.pnlControlButtons.ResumeLayout(false);
            this.pnlMsg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbDialogIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.GradientPanel pnlControlButtons;
        private System.Windows.Forms.Panel pnlMsg;
        private System.Windows.Forms.PictureBox pbDialogIcon;
        private CustomButton btnCancel;
        private CustomButton btnOK;
    }
}