using SetupWizard;

namespace SetupWizard.Views
{
    partial class LicenseForm
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
            this.ucContainer = new SetupWizard.MonoFlatBlue_ThemeContainer();
            this.btnAgree = new SetupWizard.MonoFlatBlue_Button();
            this.monoFlatBlue_Panel1 = new SetupWizard.MonoFlatBlue_Panel();
            this.txtContent = new System.Windows.Forms.RichTextBox();
            this.ucContainer.SuspendLayout();
            this.monoFlatBlue_Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucContainer
            // 
            this.ucContainer.BackColor = System.Drawing.Color.LightGray;
            this.ucContainer.CaptionBackColor = System.Drawing.Color.LightGray;
            this.ucContainer.Controls.Add(this.btnAgree);
            this.ucContainer.Controls.Add(this.monoFlatBlue_Panel1);
            this.ucContainer.CoverBackground = false;
            this.ucContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucContainer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ucContainer.Location = new System.Drawing.Point(2, 20);
            this.ucContainer.MaximumSize = new System.Drawing.Size(600, 486);
            this.ucContainer.Name = "ucContainer";
            this.ucContainer.RoundCorners = false;
            this.ucContainer.ShowCaption = true;
            this.ucContainer.Sizable = true;
            this.ucContainer.Size = new System.Drawing.Size(596, 464);
            this.ucContainer.SmartBounds = true;
            this.ucContainer.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.ucContainer.TabIndex = 0;
            this.ucContainer.Text = "软件协议书";
            // 
            // btnAgree
            // 
            this.btnAgree.BackColor = System.Drawing.Color.Transparent;
            this.btnAgree.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(176)))), ((int)(((byte)(164)))));
            this.btnAgree.BorderPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(152)))), ((int)(((byte)(140)))));
            this.btnAgree.ButtonFaceColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(207)))), ((int)(((byte)(194)))));
            this.btnAgree.ButtonPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(211)))), ((int)(((byte)(199)))));
            this.btnAgree.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnAgree.ForeColor = System.Drawing.Color.White;
            this.btnAgree.Image = null;
            this.btnAgree.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgree.Location = new System.Drawing.Point(223, 396);
            this.btnAgree.Name = "btnAgree";
            this.btnAgree.PressForeColor = System.Drawing.Color.White;
            this.btnAgree.Size = new System.Drawing.Size(146, 41);
            this.btnAgree.TabIndex = 3;
            this.btnAgree.Text = "同意";
            this.btnAgree.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnAgree.Click += new System.EventHandler(this.btnAgree_Click);
            // 
            // monoFlatBlue_Panel1
            // 
            this.monoFlatBlue_Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.monoFlatBlue_Panel1.Controls.Add(this.txtContent);
            this.monoFlatBlue_Panel1.Location = new System.Drawing.Point(12, 59);
            this.monoFlatBlue_Panel1.Name = "monoFlatBlue_Panel1";
            this.monoFlatBlue_Panel1.Padding = new System.Windows.Forms.Padding(5);
            this.monoFlatBlue_Panel1.Size = new System.Drawing.Size(572, 311);
            this.monoFlatBlue_Panel1.TabIndex = 2;
            this.monoFlatBlue_Panel1.Text = "monoFlatBlue_Panel1";
            // 
            // txtContent
            // 
            this.txtContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtContent.Location = new System.Drawing.Point(5, 5);
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(562, 301);
            this.txtContent.TabIndex = 0;
            this.txtContent.Text = "";
            // 
            // LicenseForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.LightGray;
            this.BackGradientDarkColor = System.Drawing.Color.LightGray;
            this.BackGradientLightColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(600, 486);
            this.Controls.Add(this.ucContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LicenseForm";
            this.ShowFormShadow = true;
            this.ShowLogo = false;
            this.ShowTitleText = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "软件协议书";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.LicenseForm_Load);
            this.Controls.SetChildIndex(this.ucContainer, 0);
            this.ucContainer.ResumeLayout(false);
            this.monoFlatBlue_Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MonoFlatBlue_ThemeContainer ucContainer;
        private MonoFlatBlue_Panel monoFlatBlue_Panel1;
        private System.Windows.Forms.RichTextBox txtContent;
        private MonoFlatBlue_Button btnAgree;
    }
}