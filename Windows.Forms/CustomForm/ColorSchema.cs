using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace System.Windows.Forms
{
    public class ColorSchema
    {
        public Color BackColor { get; set; }
        public Color BorderColor { get; set; }
        public Color BackGradientLightColor { get; set; }
        public Color BackGradientDarkColor { get; set; }
        public Color ShadeColor { get; set; }

        private static ColorSchema systemSchema = null;
        private static ColorSchema defaultSchema = null;
        private static ColorSchema graySchema = null;

        public static ColorSchema System
        {
            get
            {
                if (systemSchema == null)
                {
                    systemSchema = new ColorSchema();

                    systemSchema.BackColor = ControlPaint.Dark(SystemColors.GradientActiveCaption, 0.2f);
                    systemSchema.BorderColor = SystemColors.InactiveBorder;
                    systemSchema.BackGradientLightColor = SystemColors.GradientInactiveCaption;
                    systemSchema.BackGradientDarkColor = ControlPaint.Dark(SystemColors.GradientActiveCaption, 0.5f);
                    systemSchema.ShadeColor = Color.FromArgb(100, 70, 130, 180);
                }

                return systemSchema;
            }
        }

        public static ColorSchema Default
        {
            get
            {
                if (defaultSchema == null)
                {
                    defaultSchema = new ColorSchema();

                    defaultSchema.BackColor = Color.FromArgb(255, 244, 244, 244);
                    defaultSchema.BackGradientLightColor = Color.FromArgb(244, 244, 244);
                    defaultSchema.BackGradientDarkColor = Color.FromArgb(73, 73, 73);
                    defaultSchema.BorderColor = Color.FromArgb(100, 100, 100);
                    defaultSchema.ShadeColor = ControlPaint.Light(defaultSchema.BackGradientDarkColor, 0.7f);
                }

                return defaultSchema;
            }
        }

        public static ColorSchema Gray
        {
            get
            {
                if (graySchema == null)
                {
                    graySchema = new ColorSchema();

                    graySchema.BackColor = Color.FromArgb(255, 217, 217, 217);
                    graySchema.BackGradientLightColor = Color.FromArgb(217, 217, 217);
                    graySchema.BackGradientDarkColor = Color.FromArgb(217, 217, 217);
                    graySchema.BorderColor = Color.FromArgb(0, 0, 0);
                    //graySchema.ShadeColor = ControlPaint.Light(graySchema.BackGradientDarkColor, 0.7f);
                }

                return graySchema;
            }
        }


        public static ColorSchema White
        {
            get
            {
                if (graySchema == null)
                {
                    graySchema = new ColorSchema();

                    graySchema.BackColor = Color.FromArgb(255, 244, 244, 244);
                    graySchema.BackGradientLightColor = Color.FromArgb(255, 244, 244, 244);
                    graySchema.BackGradientDarkColor = Color.FromArgb(255, 244, 244, 244);
                    graySchema.BorderColor = Color.FromArgb(200, 200, 200);
                    //graySchema.ShadeColor = ControlPaint.Light(graySchema.BackGradientDarkColor, 0.7f);
                }

                return graySchema;
            }
        }
    }
}
