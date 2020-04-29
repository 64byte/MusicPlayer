using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace MusicPlayer.Control
{
    public partial class MediaTrackBar : TrackBar
    {

        private Rectangle trackRectangle = new Rectangle();

        public MediaTrackBar() : base()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetupMediaTrackBar();

        }

        private void SetupMediaTrackBar()
        {
            using (Graphics g = this.CreateGraphics())
            {
                //rec.Width = (int)(rec.Width * ((double)Value / Maximum)) - 4;
                Debug.WriteLine("X, Y = " + this.Width + " " +  ClientRectangle.Y);
                trackRectangle.X = ClientRectangle.X;
                trackRectangle.Y = ClientRectangle.Y;
                trackRectangle.Width = 500;
                trackRectangle.Height = 5;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            TrackBarRenderer.DrawHorizontalTrack(e.Graphics, trackRectangle);

            //            int width = (int)(e.ClipRectangle.Width)
            int w = (int)(e.ClipRectangle.X * ((double)Value / Maximum));
            Debug.WriteLine("Data = " + e.ClipRectangle.Width + " v = " + e.ClipRectangle.X);
            Debug.WriteLine("Value = " + Value);
            e.Graphics.FillRectangle(Brushes.CornflowerBlue, ClientRectangle.X, ClientRectangle.Y, Value, 5);
        }
    }
}
