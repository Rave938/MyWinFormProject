using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace WinFormsAppfinalhwk
{
    public class RoundTextBox : TextBox
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, 10, 10, 180, 90);
                path.AddArc(Width - 10, 0, 10, 10, 270, 90);
                path.AddArc(Width - 10, Height - 10, 10, 10, 0, 90);
                path.AddArc(0, Height - 10, 10, 10, 90, 90);
                path.CloseAllFigures();
                this.Region = new Region(path);
            }
        }
    }

    public class RoundButton : Button
    {
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, 20, 20, 180, 90);
                path.AddArc(Width - 20, 0, 20, 20, 270, 90);
                path.AddArc(Width - 20, Height - 20, 20, 20, 0, 90);
                path.AddArc(0, Height - 20, 20, 20, 90, 90);
                path.CloseAllFigures();
                this.Region = new Region(path);
            }
        }
    }
}