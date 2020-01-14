using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using SetupWizard.Properties;

namespace SetupWizard
{
    /// <summary>
    /// 自定义的消息窗口
    /// </summary>
    public partial class DialogForm : NonFrameForm
    {
        private static DialogForm instance;
        private static readonly object sysncRoot = new object();

        List<Control> displayButtons = new List<Control>();
        Dictionary<String, Image> imagelist = new Dictionary<string, Image>();


        private MessageBoxButtons _buttons;

        #region 构造函数

        protected DialogForm()
        {
            InitializeComponent();            

            imagelist.Add("Asterisk", Resources.Asterisk);
            imagelist.Add("Information", Resources.Information);
            imagelist.Add("Question", Resources.Question);
            imagelist.Add("Error", Resources.Error);
            imagelist.Add("Exclamation", Resources.Exclamation); 
            imagelist.Add("Warning", Resources.Exclamation);  
            imagelist.Add("Stop", Resources.Error);
            imagelist.Add("Hand", Resources.Error);

        }
        #endregion

        #region 确定事件
        private void pictureBox_confirm_Click(object sender, EventArgs e)
        {
            switch (_buttons)
            {
                case MessageBoxButtons.OK:
                case MessageBoxButtons.OKCancel:
                    this.DialogResult = DialogResult.OK;
                    break;
                case MessageBoxButtons.YesNo:
                case MessageBoxButtons.YesNoCancel:
                    this.DialogResult = DialogResult.Yes;
                    break;
            }
            CloseForm();
        }
        #endregion

        #region 取消事件
        private void pictureBox_cancel_Click(object sender, EventArgs e)
        {
            switch (_buttons)
            {
                case MessageBoxButtons.OK:
                case MessageBoxButtons.OKCancel:
                    this.DialogResult = DialogResult.Cancel;
                    break;
                case MessageBoxButtons.YesNo:
                case MessageBoxButtons.YesNoCancel:
                    this.DialogResult = DialogResult.No;
                    break;
            }
            CloseForm();
        }
        #endregion

        #region 对话框窗体单例模式

        public static DialogResult Show(string title, string content)
        {
            return Show(title, content, MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        public static DialogResult Show(string title, string content, MessageBoxButtons buttons)
        {
            return Show(title, content, buttons, MessageBoxIcon.None);
        }

        public static DialogResult Show(string title, string content, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            Form ownerForm = Application.OpenForms[Application.OpenForms.Count - 1];

            DialogResult result = DialogResult.None;
            try
            {
                if (instance != null)
                {
                    if (!instance.IsDisposed && instance.IsHandleCreated)
                    {
                        instance.Dispose();
                        instance = null;
                    }
                }

                if (instance == null)
                {
                    lock (sysncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new DialogForm();
                            instance.ControlBox = true;
                        }
                    }
                }

                if (instance.Parent != null)
                {
                    instance.StartPosition = FormStartPosition.CenterParent;
                }
                else
                {
                    instance.StartPosition = FormStartPosition.CenterScreen;
                }

                instance.Owner = ownerForm;

                instance.SetTitle(title);
                instance.SetContent(content);
                instance.SetButtons(buttons);
                instance.SetIcons(icon);

                //instance.Activate();

                result = instance.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //Show(title, content);
            }

            return result;
        }

        #endregion


        #region 私有方法

        #region 释放窗体
        /// <summary>
        /// 释放窗体
        /// </summary>
        private void CloseForm()
        {
            instance.Close();
            instance = null;
            //this.Close();
        }
        #endregion

        protected virtual void SetTitle(string value)
        {
            this.label_title.Text = value;
        }
        protected virtual void SetContent(string value)
        {
            this.lblContent.Text = value;
        }
        protected virtual void SetButtons(MessageBoxButtons buttons)
        {
            this.btnCancel.Visible = false;
            this.btnOK.Visible = false;
            this.displayButtons.Clear();


            _buttons = buttons;

            // 设置要显示的按钮
            switch (buttons)
            {
                case MessageBoxButtons.OK:
                    displayButtons.Add(this.btnOK);
                    this.btnOK.Location = new Point((this.Width - this.btnOK.Width) / 2, this.btnOK.Location.Y);
                    break;
                case MessageBoxButtons.AbortRetryIgnore:
                    displayButtons.Add(this.btnOK);
                    break;
                case MessageBoxButtons.OKCancel:
                    // 按顺序添加Button，以便下面遍历
                    displayButtons.Add(this.btnOK);
                    displayButtons.Add(this.btnCancel);

                    this.btnOK.Location = new Point(80, 21);
                    this.btnCancel.Location = new Point(193, 21);
                    break;
                case MessageBoxButtons.RetryCancel:
                    displayButtons.Add(this.btnOK); // 未完成
                    break;
                case MessageBoxButtons.YesNo:
                    displayButtons.Add(this.btnOK);
                    displayButtons.Add(this.btnCancel);
                    break;
                case MessageBoxButtons.YesNoCancel:
                    displayButtons.Add(this.btnOK); // 未完成
                    break;
            }

            foreach (Control button in this.pnlControlButtons.Controls)
            {
                if (displayButtons.Contains(button))
                    button.Visible = true;
                else
                    button.Visible = false;
            }

            // 设置按钮显示的位置
            CalculateButtonPositons();
        }

        protected virtual void SetIcons(MessageBoxIcon icon)
        {
            // 根据文本的内容修改窗体大小
            lblContent.MaximumSize = new Size(pnlMsg.Width - (pbDialogIcon.Visible ? pbDialogIcon.Width : 0) - 26 - pnlMsg.Padding.Right, Screen.PrimaryScreen.Bounds.Height);
            lblContent.AutoSize = true;
            int newHeight = lblContent.Height;
            lblContent.AutoSize = false;
            lblContent.Width = 240;
            lblContent.Height = newHeight;
            int change = newHeight + pnlMsg.Padding.Top + pnlMsg.Padding.Bottom - pnlMsg.Height;
            this.Height = this.Height + change;

            if (icon == MessageBoxIcon.None)
            {
                lblContent.Dock = DockStyle.Fill;

                pbDialogIcon.Visible = false;
                pbDialogIcon.Image = null;
            }
            else
            {

                lblContent.Dock = DockStyle.Right;

                pbDialogIcon.Visible = true;
                pbDialogIcon.Location = new Point(20, 8);

                pbDialogIcon.Image = imagelist[icon.ToString()];
            }
        }

        /// <summary>
        /// 计算按钮的位置
        /// </summary>
        private void CalculateButtonPositons()
        {
            int width = this.displayButtons.Sum(p => p.Width) + 37 * (this.displayButtons.Count - 1);
            int left = (this.Width - width) / 2;
            int top = (pnlControlButtons.Height - btnOK.Height) / 2;
            int index = 0;
            foreach (Control button in this.displayButtons)
            {
                button.Location = new Point(left + 37 * index + button.Width * index, top);
                index++;
            }
        }

        #endregion


        public static void Dismiss()
        {
            if (instance != null)
            {
                instance.DialogResult = DialogResult.Abort;
                instance.Close();
            }
        }

        private void pnlControlButtons_Resize(object sender, EventArgs e)
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            // 画边框
            Rectangle borderRect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            //g.DrawRoundedRectangleAlpha(this.BorderColor, Color.Transparent, borderRect, new Size(2, 2), 255);
            using (Pen borderPen = new Pen(this.BorderColor))
            {
                g.DrawRectangle(borderPen, borderRect);
            }
        }


        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                if (!DesignMode)
                {
                    // 点击任务栏切换最小化/最大化
                    if (MaximizeBox) { cp.Style |= (int)WindowStyle.WS_MAXIMIZEBOX; }
                    if (MinimizeBox) { cp.Style |= (int)WindowStyle.WS_MINIMIZEBOX; }
                    if (OSFeature.IsPresent(SystemParameter.DropShadow))
                        cp.ClassStyle &= ~0x20000;
                }
                return cp;
            }
        }

    }
}