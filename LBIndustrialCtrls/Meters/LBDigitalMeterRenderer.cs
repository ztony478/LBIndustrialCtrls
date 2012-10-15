using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using LBSoft.IndustrialCtrls.Base;

namespace LBSoft.IndustrialCtrls.Meters
{
    public class LBDigitalMeterRenderer : LBRendererBase
    {
        #region (* Constructor *)
        public LBDigitalMeterRenderer()
        {
        }
        #endregion

        #region (* Overrided methods *)
        public override void Draw(Graphics Gr)
        {
            if (this.Meter == null)
                return;

            RectangleF _rc = new RectangleF(0, 0, this.Meter.Width, this.Meter.Height);
            Gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            this.DrawBackground(Gr, _rc);
            this.DrawBorder(Gr, _rc);
        }
        #endregion

        #region (* Properties *)
        public LBDigitalMeter Meter
        {
            get { return this.Control as LBDigitalMeter; }
        }
        #endregion

        #region (* Virtual methods *)
        public virtual bool DrawBackground(Graphics gr, RectangleF rc)
        {
            if (this.Meter == null)
                return false;

            Color c = this.Meter.BackColor;
            SolidBrush br = new SolidBrush(c);
            Pen pen = new Pen(c);

            Rectangle _rcTmp = new Rectangle(0, 0, this.Meter.Width, this.Meter.Height);
            gr.DrawRectangle(pen, _rcTmp);
            gr.FillRectangle(br, rc);

            br.Dispose();
            pen.Dispose();

            return true;
        }

        public virtual bool DrawBorder(Graphics gr, RectangleF rc)
        {
            if (this.Meter == null)
                return false;

            return true;
        }
        #endregion
    }
}
