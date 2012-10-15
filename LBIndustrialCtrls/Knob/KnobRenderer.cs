/*---------------------------------------------------------------------------
 * File: KnobRenderer.cs
 * Utente: lucabonotto
 * Date: 05/04/2009
 *-------------------------------------------------------------------------*/

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using LBSoft.IndustrialCtrls.Utils;
using LBSoft.IndustrialCtrls.Base;

namespace LBSoft.IndustrialCtrls.Knobs
{
	/// <summary>
	/// Base class for the renderers of the knob
	/// </summary>
	public class LBKnobRenderer : LBRendererBase
	{
		#region (* Variables *)
        private RectangleF drawRect;
        private RectangleF rectScale;
        private RectangleF rectKnob;
        private PointF knobCenter;
        private PointF knobIndicatorPos;
        private float drawRatio;
        #endregion
		
		#region (* Properies *)
		public LBKnob Knob
		{
			get { return this.Control as LBKnob; }
		}
		#endregion

        #region (* Overrided method *)
        public override bool Update()
        {
            // Check Button object
            if (this.Knob == null)
                throw new NullReferenceException("Invalid 'Knob' object");

            // Rectangle
            float x, y, w, h;
            x = 0;
            y = 0;
            w = this.Knob.Size.Width;
            h = this.Knob.Size.Height;

            // Calculate ratio
            drawRatio = (Math.Min(w, h)) / 200;
            if (drawRatio == 0.0)
                drawRatio = 1;

            // Draw rectangle
            drawRect.X = x;
            drawRect.Y = y;
            drawRect.Width = w - 2;
            drawRect.Height = h - 2;

            if (w < h)
                drawRect.Height = w;
            else if (w > h)
                drawRect.Width = h;

            if (drawRect.Width < 10)
                drawRect.Width = 10;
            if (drawRect.Height < 10)
                drawRect.Height = 10;

            this.rectScale = this.drawRect;
            this.rectKnob = this.drawRect;
            this.rectKnob.Inflate(-20 * this.drawRatio, -20 * this.drawRatio);

            this.knobCenter.X = this.rectKnob.Left + (this.rectKnob.Width * 0.5F);
            this.knobCenter.Y = this.rectKnob.Top + (this.rectKnob.Height * 0.5F);

            this.knobIndicatorPos = this.Knob.GetPositionFromValue(this.Knob.Value);

            this.Knob.KnobRect = this.rectKnob;
            this.Knob.KnobCenter = this.knobCenter;
            this.Knob.DrawRatio = this.drawRatio;
            return true;
        }

        public override void Draw(Graphics Gr)
        {
            if (Gr == null)
                throw new ArgumentNullException("Gr");

            LBKnob ctrl = this.Knob;
            if (ctrl == null)
                throw new NullReferenceException("Associated control is not valid");

            this.DrawBackground(Gr, ctrl.Bounds);
            this.DrawScale(Gr, this.rectScale);
            this.DrawKnob(Gr, this.rectKnob);
            this.DrawKnobIndicator(Gr, this.rectKnob, this.knobIndicatorPos);
        }
        #endregion

        #region (* Virtual method *)
        /// <summary>
		/// Draw the background of the control
		/// </summary>
		/// <param name="Gr"></param>
		/// <param name="rc"></param>
		/// <returns></returns>
		public virtual bool DrawBackground( Graphics Gr, RectangleF rc )
		{
			if ( this.Knob == null )
				return false;
			
			Color c = this.Knob.BackColor;
			SolidBrush br = new SolidBrush ( c );
			Pen pen = new Pen ( c );
			
			Rectangle _rcTmp = new Rectangle(0, 0, this.Knob.Width, this.Knob.Height );
			Gr.DrawRectangle ( pen, _rcTmp );
			Gr.FillRectangle ( br, rc );
			
			br.Dispose();
			pen.Dispose();
			
			return true;
		}

		/// <summary>
		/// Draw the scale of the control
		/// </summary>
		/// <param name="Gr"></param>
		/// <param name="rc"></param>
		/// <returns></returns>
		public virtual bool DrawScale( Graphics Gr, RectangleF rc )
		{
			if ( this.Knob == null )
				return false;
			
			Color cKnob = this.Knob.ScaleColor;
			Color cKnobDark = LBColorManager.StepColor ( cKnob, 60 );
			
			LinearGradientBrush br = new LinearGradientBrush ( rc, cKnobDark, cKnob, 45 );
				
			Gr.FillEllipse ( br, rc );
			
			br.Dispose();

			return true;
		}

		/// <summary>
		/// Draw the knob of the control
		/// </summary>
		/// <param name="Gr"></param>
		/// <param name="rc"></param>
		/// <returns></returns>
		public virtual bool DrawKnob( Graphics Gr, RectangleF rc )
		{
			if ( this.Knob == null )
				return false;
			
			Color cKnob = this.Knob.KnobColor;
			Color cKnobDark = LBColorManager.StepColor ( cKnob, 60 );
			
			LinearGradientBrush br = new LinearGradientBrush ( rc, cKnob, cKnobDark, 45 );
				
			Gr.FillEllipse ( br, rc );
			
			br.Dispose();

			return true;
		}
		
		public virtual bool DrawKnobIndicator( Graphics Gr, RectangleF rc, PointF pos )
		{
			if ( this.Knob == null )
				return false;
			
			RectangleF _rc = rc;
			_rc.X = pos.X - 4;
			_rc.Y = pos.Y - 4;
			_rc.Width = 8;
			_rc.Height = 8;
			
			Color cKnob = this.Knob.IndicatorColor;
			Color cKnobDark = LBColorManager.StepColor ( cKnob, 60 );
			
			LinearGradientBrush br = new LinearGradientBrush ( _rc, cKnobDark, cKnob, 45 );
				
			Gr.FillEllipse ( br, _rc );
			
			br.Dispose();

			return true;
		}
		#endregion
	}
}
