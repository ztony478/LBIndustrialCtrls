/*
 * Creato da SharpDevelop.
 * Utente: lucabonotto
 * Data: 03/04/2008
 * Ora: 14.34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using LBSoft.IndustrialCtrls;
using LBSoft.IndustrialCtrls.Meters;
using LBSoft.IndustrialCtrls.Utils;

namespace TestApp
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private LBMyAnalogMeterRenderer myRenderer;
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			this.myRenderer = new LBMyAnalogMeterRenderer();
						
			LBMeterThreshold threshold = new LBMeterThreshold();
			threshold.Color = Color.Yellow;
			threshold.StartValue = 50;
			threshold.EndValue = 70;
			this.lbAnalogMeter1.Thresholds.Add ( threshold );
			threshold = new LBMeterThreshold();
			threshold.Color = Color.Red;
			threshold.StartValue = 70;
			threshold.EndValue = 100;
			this.lbAnalogMeter1.Thresholds.Add ( threshold );
			this.lbAnalogMeter1.Renderer = this.myRenderer;
								
			threshold = new LBMeterThreshold();
			threshold.Color = Color.Yellow;
			threshold.StartValue = 50;
			threshold.EndValue = 70;
			this.lbAnalogMeter2.Thresholds.Add ( threshold );
			threshold = new LBMeterThreshold();
			threshold.Color = Color.Red;
			threshold.StartValue = 70;
			threshold.EndValue = 100;
			this.lbAnalogMeter2.Thresholds.Add ( threshold );
        }

        private void btnRepeat_ButtonChangeState(object sender, LBSoft.IndustrialCtrls.Buttons.LBButtonEventArgs e)
        {
            if (e.State != LBSoft.IndustrialCtrls.Buttons.LBButton.ButtonState.Normal)
                return;

            this.sdRepeat.Value = 0;
        }

        private void btnRepeat_ButtonRepeatState(object sender, LBSoft.IndustrialCtrls.Buttons.LBButtonEventArgs e)
        {
            int v = this.sdRepeat.Value;
            v++;
            if (v > 9)
                v = 0;

            this.sdRepeat.Value = v;
        }
	}

	/// <summary>
	/// Custom renderer class
	/// </summary>
	public class LBMyAnalogMeterRenderer : LBAnalogMeterRenderer
	{
		public override bool DrawBody( Graphics Gr, RectangleF rc )
		{
			return true;
		}
		
		public override bool DrawGlass( Graphics Gr, RectangleF rc )
		{
			return true;
		}
		
		public override bool DrawDivisions( Graphics Gr, RectangleF rc )
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

			Pen pen = new Pen ( scaleColor, ( 2 * drawRatio ) );
			SolidBrush br = new SolidBrush ( scaleColor );
			
			PointF ptStart = new PointF(0,0);
			PointF ptEnd = new PointF(0,0);
			PointF ptCenter = new PointF(0,0);
			RectangleF rcTick = new RectangleF(0,0,0,0);
			SizeF sizeMax = new SizeF( 10 * drawRatio, 10 * drawRatio );
			SizeF sizeMin = new SizeF( 4 * drawRatio, 4 * drawRatio );
			
			int n = 0;
			for( ; n < scaleDivisions; n++ )
			{
					//Draw Thick Line
				ptCenter.X = (float)(cx + (radius - w/90) * Math.Cos(currentAngle));
				ptCenter.Y = (float)(cy + (radius - w/90) * Math.Sin(currentAngle));
				ptStart.X = ptCenter.X - ( 5 * drawRatio );
				ptStart.Y = ptCenter.Y - ( 5 * drawRatio );
				rcTick.Location = ptStart;
				rcTick.Size = sizeMax;				
				Gr.FillEllipse( br, rcTick );
				
       				//Draw Strings
       			Font font = new Font ( this.AnalogMeter.Font.FontFamily, (float)( 8F * drawRatio ), FontStyle.Italic );
		
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
					break;
		
				if ( scaleDivisions <= 0 )
					currentAngle += incr;
				else
				{
			        for (int j = 0; j <= scaleSubDivisions; j++)
			        {
						currentAngle += incr;

			        	ptCenter.X = (float)(cx + (radius - w/90) * Math.Cos(currentAngle));
						ptCenter.Y = (float)(cy + (radius - w/90) * Math.Sin(currentAngle));
						ptStart.X = ptCenter.X - ( 2 * drawRatio );
						ptStart.Y = ptCenter.Y - ( 2 * drawRatio );
						rcTick.Location = ptStart;
						rcTick.Size = sizeMin;				
						Gr.FillEllipse( br, rcTick );
					}
				}
			}
			
			return true;
		}
	}
}
