using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace System.Windows.Forms
{

    public class ClickThroughPanel : Panel
    {
        public ClickThroughPanel()
        {
            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor, true);
            UpdateStyles();
        }

        protected override void WndProc(ref Message m)
        {
            if (!DesignMode)
            {
                if (m.Msg == Win32.WM_NCHITTEST)
                {
                    m.Result = new IntPtr(Win32.HTTRANSPARENT);
                    return;
                }
            }

            base.WndProc(ref m);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            if (!DesignMode)
            {
                this.SendToBack();
            }
        }

        private int _borderRadius = 0;
        [Category("边框圆角值")]
        public int BorderRadius { get
            {
                return _borderRadius;
            } set
            {
                _borderRadius = value;
                UpdateBorder();

            }
        }

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);

            UpdateBorder();
        }

        protected void UpdateBorder()
        {
            if (BorderRadius > 0)
            {
                IntPtr hrgn = Win32.CreateRoundRectRgn(0, 0, Width + 1, Height + 1, BorderRadius, BorderRadius);
                this.Region = System.Drawing.Region.FromHrgn(hrgn);
                this.Update();
            }
        }
    }
}
