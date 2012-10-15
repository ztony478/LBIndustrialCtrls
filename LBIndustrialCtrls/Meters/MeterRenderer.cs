/*---------------------------------------------------------------------------
 * File: MeterRenderer.cs
 * Utente: lucabonotto
 * Date: 05/04/2009
 *-------------------------------------------------------------------------*/

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using LBSoft.IndustrialCtrls.Utils;
using LBSoft.IndustrialCtrls.Base;

namespace LBSoft.IndustrialCtrls.Meters
{
	/// <summary>
	/// Base class for the renderers of the analog meter
	/// </summary>
	public class LBAnalogMeterRenderer : LBRendererBase
	{
		#region (* Variables *)
        protected PointF needleCenter;
        protected RectangleF drawRect;
        protected RectangleF glossyRect;
        protected RectangleF needleCoverRect;
        protected float drawRatio;
        #endregion
		
		#region (* Properties *)
		public LBAnalogMeter AnalogMeter
		{
			get { return this.Control as LBAnalogMeter; }
		}
		#endregion

        #region (* Overrided method *)
        public override bool Update()
        {
            // Check Button object
            if (this.AnalogMeter == null)
                throw new NullReferenceException("Invalid 'AnalogMeter' object");

            // Rectangle
            float x, y, w, h;
            x = 0;
            y = 0;
            w = this.AnalogMeter.Size.Width;
            h = this.AnalogMeter.Size.Height;

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

            // Calculate needle center
            needleCenter.X = drawRect.X + (drawRect.Width / 2);
            needleCenter.Y = drawRect.Y + (drawRect.Height / 2);

            // Needle cover rect
            needleCoverRect.X = needleCenter.X - (20 * drawRatio);
            needleCoverRect.Y = needleCenter.Y - (20 * drawRatio);
            needleCoverRect.Width = 40 * drawRatio;
            needleCoverRect.Height = 40 * drawRatio;

            // Glass effect rect
            glossyRect.X = drawRect.X + (20 * drawRatio);
            glossyRect.Y = drawRect.Y + (10 * drawRatio);
            glossyRect.Width = drawRect.Width - (40 * drawRatio);
            glossyRect.Height = needleCenter.Y + (30 * drawRatio);

            return false;
        }

        public override void Draw(Graphics Gr)
        {
            if (Gr == null)
                throw new ArgumentNullException("Gr");

            LBAnalogMeter ctrl = this.AnalogMeter;
            if (ctrl == null)
                throw new NullReferenceException("Associated control is not valid");

            this.DrawBackground(Gr, ctrl.Bounds);
            this.DrawBody(Gr, drawRect);
            this.DrawThresholds(Gr, drawRect);
            this.DrawDivisions(Gr, drawRect);
            this.DrawUM(Gr, drawRect);
            this.DrawValue(Gr, drawRect);
            this.DrawNeedle(Gr, drawRect);
            this.DrawNeedleCover(Gr, this.needleCoverRect);
            this.DrawGlass(Gr, this.glossyRect);
        }
        #endregion

        #region (* Virtual method *)
        public virtual bool DrawBackground( Graphics gr, RectangleF rc )
		{
			if ( this.AnalogMeter == null )
				return false;
			
			Color c = this.AnalogMeter.BackColor;
			SolidBrush br = new SolidBrush ( c );
			Pen pen = new Pen ( c );
			
			Rectangle _rcTmp = new Rectangle(0, 0, this.AnalogMeter.Width, this.AnalogMeter.Height );
			gr.DrawRectangle ( pen, _rcTmp );
			gr.FillRectangle ( br, rc );
			
			br.Dispose();
			pen.Dispose();
			
			return true;
		}
		
		public virtual bool DrawBody( Graphics Gr, RectangleF rc )
		{
			if ( this.AnalogMeter == null )
				return false;
			
			Color bodyColor = this.AnalogMeter.BodyColor;
			Color cDark = LBColorManager.StepColor ( bodyColor, 20 );
			
			LinearGradientBrush br1 = new LinearGradientBrush ( rc, 
			                                                   bodyColor,
			                                                   cDark,
			                                                   45 );
			Gr.FillEllipse ( br1, rc );
			
			RectangleF _rc = rc;
			_rc.X += 3 * drawRatio;
			_rc.Y += 3 * drawRatio;
			_rc.Width -= 6 * drawRatio;
			_rc.Height -= 6 * drawRatio;

			LinearGradientBrush br2 = new LinearGradientBrush ( _rc,
			                                                   cDark,
			                                                   bodyColor,
			                                                   45 );
			Gr.FillEllipse ( br2, _rc );
			
			return true;
		}
		
		public virtual bool DrawThresholds( Graphics Gr, RectangleF rc )
		{
			if ( this.AnalogMeter == null )
				return false;
			
			RectangleF _rc = rc;
			_rc.Inflate ( -18F * drawRatio, -18F * drawRatio );
			
			double w = _rc.Width;
			double radius = w / 2 - ( w * 0.075);
			
			float startAngle = this.AnalogMeter.GetStartAngle();
			float endAngle = this.AnalogMeter.GetEndAngle();
			float rangeAngle = endAngle - startAngle;
			float minValue = (float)this.AnalogMeter.MinValue;
			float maxValue = (float)this.AnalogMeter.MaxValue;
			
			double stepVal = rangeAngle / ( maxValue - minValue );

			foreach ( LBMeterThreshold sect in this.AnalogMeter.Thresholds )
			{
				
				float startPathAngle	= ( (float)(startAngle + ( stepVal *  sect.StartValue )));
				float endPathAngle		= ( (float)( ( stepVal * ( sect.EndValue - sect.StartValue ))));
					
				GraphicsPath pth = new GraphicsPath();
				pth.AddArc ( _rc, startPathAngle, endPathAngle );
				
				Pen pen = new Pen( sect.Color, 4.5F * drawRatio );
				
				Gr.DrawPath ( pen, pth );
				
				pen.Dispose();
				pth.Dispose();
			}
			
			return false;
		}
		
		public virtual bool DrawDivisions( Graphics Gr, RectangleF rc )
		{
			if ( this.AnalogMeter == null )
				return false;
			
			float startAngle = this.AnalogMeter.GetStartAngle();
			float endAngle = this.AnalogMeter.GetEndAngle();
			float scaleDivisions = this.AnalogMeter.ScaleDivisions;
			float scaleSubDivisions = this.AnalogMeter.ScaleSubDivisions;
			double minValue = this.AnalogMeter.MinValue;
			double maxValue = this.AnalogMeter.MaxValue;
			Color scaleColor = this.AnalogMeter.ScaleColor;
			
			float cx = needleCenter.X;
			float cy = needleCenter.Y;
			float w = rc.Width;
			float h = rc.Height;

			float incr = LBMath.GetRadian(( endAngle - startAngle ) / (( scaleDivisions - 1 )* (scaleSubDivisions + 1)));
			float currentAngle = LBMath.GetRadian( startAngle );
			float radius = (float)(w / 2 - ( w * 0.08));
			float rulerValue = (float)minValue;

			Pen pen = new Pen ( scaleColor, ( 1 * drawRatio ) );
			SolidBrush br = new SolidBrush ( scaleColor );
			
			PointF ptStart = new PointF(0,0);
			PointF ptEnd = new PointF(0,0);
			int n = 0;
			for( ; n < scaleDivisions; n++ )
			{
					//Draw Thick Line
				ptStart.X = (float)(cx + radius * Math.Cos(currentAngle));
				ptStart.Y = (float)(cy + radius * Math.Sin(currentAngle));
				ptEnd.X = (float)(cx + (radius - w/20) * Math.Cos(currentAngle));
				ptEnd.Y = (float)(cy + (radius - w/20) * Math.Sin(currentAngle));
				Gr.DrawLine( pen, ptStart, ptEnd );
				
       				//Draw Strings
       			Font font = new Font ( this.AnalogMeter.Font.FontFamily, (float)( 6F * drawRatio ) );
		
				float tx = (float)(cx + (radius - ( 20 * drawRatio )) * Math.Cos(currentAngle));
		        float ty = (float)(cy + (radius - ( 20 * drawRatio )) * Math.Sin(currentAngle));
		        double val = Math.Round ( rulerValue );
		        String str = String.Format( "{0,0:D}", (int)val );
		
				SizeF size = Gr.MeasureString ( str, font );
				Gr.DrawString ( str, 
				                font, 
				                br, 
				                tx - (float)( size.Width * 0.5 ), 
				                ty - (float)( size.Height * 0.5 ) );

				rulerValue += (float)(( maxValue - minValue) / (scaleDivisions - 1));
		
				if ( n == scaleDivisions -1)
				{
					font.Dispose();
					break;
				}
		
				if ( scaleDivisions <= 0 )
					currentAngle += incr;
				else
				{
			        for (int j = 0; j <= scaleSubDivisions; j++)
			        {
						currentAngle += incr;
						ptStart.X = (float)(cx + radius * Math.Cos(currentAngle));
						ptStart.Y = (float)(cy + radius * Math.Sin(currentAngle));
						ptEnd.X = (float)(cx + (radius - w/50) * Math.Cos(currentAngle));
						ptEnd.Y = (float)(cy + (radius - w/50) * Math.Sin(currentAngle));
						Gr.DrawLine( pen, ptStart, ptEnd );
			        }
				}
				
				font.Dispose();
			}
			
			return true;
		}
		
		public virtual bool DrawUM( Graphics gr, RectangleF rc )
		{
			return false;
		}
		
		public virtual bool DrawValue( Graphics gr, RectangleF rc )
		{
			return false;
		}
		
		public virtual bool DrawNeedle( Graphics Gr, RectangleF rc )
		{
			if ( this.AnalogMeter == null )
				return false;
			
			float w, h ;		
			w = rc.Width;
			h = rc.Height;
		
			double minValue = this.AnalogMeter.MinValue;
			double maxValue = this.AnalogMeter.MaxValue;
			double currValue = this.AnalogMeter.Value;
			float startAngle = this.AnalogMeter.GetStartAngle();
			float endAngle = this.AnalogMeter.GetEndAngle();
			
			float radius = (float)(w / 2 - ( w * 0.12));
			float val = (float)(maxValue - minValue);
		
			val = (float)((100 * ( currValue - minValue )) / val);
			val = (( endAngle - startAngle ) * val) / 100;
		    val += startAngle;
			
		    float angle = LBMath.GetRadian ( val );
		    
		    float cx = needleCenter.X;
		    float cy = needleCenter.Y;
		    
		    PointF ptStart = new PointF(0,0);
		    PointF ptEnd = new PointF(0,0);

		    GraphicsPath pth1 = new GraphicsPath();
				    
		    ptStart.X = cx;
		    ptStart.Y = cy;		    
		    angle = LBMath.GetRadian(val + 10);
			ptEnd.X = (float)(cx + (w * .09F) * Math.Cos(angle));
		    ptEnd.Y = (float)(cy + (w * .09F) * Math.Sin(angle));
		    pth1.AddLine ( ptStart, ptEnd );
		    
		    ptStart = ptEnd;
		    angle = LBMath.GetRadian(val);
		    ptEnd.X = (float)(cx + radius * Math.Cos(angle));
		    ptEnd.Y = (float)(cy + radius * Math.Sin(angle));
			pth1.AddLine ( ptStart, ptEnd );

		    ptStart = ptEnd;
		    angle = LBMath.GetRadian(val - 10);
			ptEnd.X = (float)(cx + (w * .09F) * Math.Cos(angle));
		    ptEnd.Y = (float)(cy + (w * .09F) * Math.Sin(angle));
		    pth1.AddLine ( ptStart, ptEnd );
			
		    pth1.CloseFigure();
		    
			SolidBrush br = new SolidBrush( this.AnalogMeter.NeedleColor );
		    Pen pen = new Pen ( this.AnalogMeter.NeedleColor );
			Gr.DrawPath ( pen, pth1 );
			Gr.FillPath ( br, pth1 );
			
			return true;
		}
		
		public virtual bool DrawNeedleCover( Graphics Gr, RectangleF rc )
		{
			if ( this.AnalogMeter == null )
				return false;
			
			Color clr = this.AnalogMeter.NeedleColor;
			RectangleF _rc = rc;

            Color clr1 = Color.FromArgb( 70, clr );
			
			_rc.Inflate ( 5 * drawRatio, 5 * drawRatio );
		
			SolidBrush brTransp = new SolidBrush ( clr1 );
			Gr.FillEllipse ( brTransp, _rc );
			
			clr1 = clr;
			Color clr2 = LBColorManager.StepColor ( clr, 75 );
			LinearGradientBrush br1 = new LinearGradientBrush( rc,
			                                                   clr1,
			                                                   clr2,
			                                                   45 );
			Gr.FillEllipse ( br1, rc );
			return true;
		}
		
		public virtual bool DrawGlass( Graphics Gr, RectangleF rc )
		{
			if ( this.AnalogMeter == null )
				return false;
			
			if ( this.AnalogMeter.ViewGlass == false )
				return true;
			
			Color clr1 = Color.FromArgb( 40, 200, 200, 200 );
			
			Color clr2 = Color.FromArgb( 0, 200, 200, 200 );
			LinearGradientBrush br1 = new LinearGradientBrush( rc,
			                                                   clr1,
			                                                   clr2,
			                                                   45 );
			Gr.FillEllipse ( br1, rc );
			
			return true;
		}
		#endregion
	}
}
