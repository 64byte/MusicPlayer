using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayer.Control
{
    class WatermarkTextBox : TextBox
    {
        private Font oldFont;
        private string watermarkText;

        public string WatermarkText
        {
            get { return watermarkText; }
            set
            {
                watermarkText = value;
                Invalidate();
            }
        }

        private bool waterarkActive;

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            if (Text.Length <= 0)
                AttachWatermarkText();
            else
                DetachWatermarkText();
        }

        public WatermarkTextBox()
        {
            this.GotFocus += (s, e) =>
            {
                if (waterarkActive)
                {
                    DetachWatermarkText();
                }
            };

            this.LostFocus += (s, e) =>
            {
                if (!waterarkActive)
                {
                    if (Text.Length <= 0)
                    {
                        AttachWatermarkText();
                    }
                }
            };

            this.FontChanged += (s, e) =>
            {
                if (waterarkActive)
                {
                    oldFont = new Font(Font.FontFamily, Font.Size, Font.Style, Font.Unit);
                    Refresh();
                }
            };
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!waterarkActive)
            {
                e.Graphics.DrawString(Text, Font, Brushes.Black, ClientRectangle);
            }
            else
            {
                Graphics g = CreateGraphics();
                g.DrawString(WatermarkText, Font, Brushes.Gray, ClientRectangle);
            }
            
            base.OnPaint(e);
        }

        private void AttachWatermarkText()
        {
            oldFont = new Font(Font.FontFamily, Font.Size, Font.Style, Font.Unit);

            waterarkActive = true;
            SetStyle(ControlStyles.UserPaint, true);
            Refresh();
        }

        private void DetachWatermarkText()
        {
            waterarkActive = false;
            SetStyle(ControlStyles.UserPaint, false);

            if (oldFont != null)
                Font = new Font(oldFont.FontFamily, oldFont.Size, oldFont.Style, oldFont.Unit);
        }
    }
}
