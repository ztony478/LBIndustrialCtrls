/*---------------------------------------------------------------------------
 * File: LedRenderer.cs
 * Utente: lucabonotto
 * Date: 05/04/2009
 *-------------------------------------------------------------------------*/

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using LBSoft.IndustrialCtrls.Utils;
using LBSoft.IndustrialCtrls.Base;

namespace LBSoft.IndustrialCtrls.Leds
{
	/// <summary>
	/// Base class for the led renderers
	/// </summary>
    public class LBLedRenderer : LBRendererBase
	{
		#region (* Variables *)
        private RectangleF drawRect;
        private RectangleF rectLed;
        private RectangleF rectLabel;
        #endregion
		
		#region (* Properies *)
        /// <summary>
        /// Get the associated led object
        /// </summary>
		public LBLed Led
		{
			get { return this.Control as LBLed; }
		}
		#endregion

        #region (* Overrided method *)
        /// <summary>
        /// Update the rectangles for drawing
        /// </summary>
        /// <returns></returns>
        public override bool Update()
        {
            // Check Led object
            if (this.Led == null)
                throw new NullReferenceException("Invalid 'Led' object");

            // Dati del rettangolo
            float x, y, w, h;
            x = 0;
            y = 0;
            w = this.Led.Size.Width;
            h = this.Led.Size.Height;

            // Rettangolo di disegno
            drawRect.X = x;
            drawRect.Y = y;
            drawRect.Width = w - 2;
            drawRect.Height = h - 2;
            if (drawRect.Width <= 0)
                drawRect.Width = 20;
            if (drawRect.Height <= 0)
                drawRect.Height = 20;

            this.rectLed = drawRect;
            this.rectLabel = drawRect;

            if (this.Led.LabelPosition == LBLed.LedLabelPosition.Bottom)
            {
                this.rectLed.X = (this.rectLed.Width * 0.5F) - (this.Led.LedSize.Width * 0.5F);
                this.rectLed.Width = this.Led.LedSize.Width;
                this.rectLed.Height = this.Led.LedSize.Height;

                this.rectLabel.Y = this.rectLed.Bottom;
            }

            else if (this.Led.LabelPosition == LBLed.LedLabelPosition.Top)
            {
                this.rectLed.X = (this.rectLed.Width * 0.5F) - (this.Led.LedSize.Width * 0.5F);
                this.rectLed.Y = this.rectLed.Height - this.Led.LedSize.Height;
                this.rectLed.Width = this.Led.LedSize.Width;
                this.rectLed.Height = this.Led.LedSize.Height;

                this.rectLabel.Height = this.rectLed.Top;
            }

            else if (this.Led.LabelPosition == LBLed.LedLabelPosition.Left)
            {
                this.rectLed.X = this.rectLed.Width - this.Led.LedSize.Width;
                this.rectLed.Width = this.Led.LedSize.Width;
                this.rectLed.Height = this.Led.LedSize.Height;

                this.rectLabel.Width = this.rectLabel.Width - this.rectLed.Width;
            }

            else if (this.Led.LabelPosition == LBLed.LedLabelPosition.Right)
            {
                this.rectLed.Width = this.Led.LedSize.Width;
                this.rectLed.Height = this.Led.LedSize.Height;

                this.rectLabel.X = this.rectLed.Right;
            }

            return true;
        }

        /// <summary>
        /// Draw the led object
        /// </summary>
        /// <param name="Gr"></param>
        public override void Draw(Graphics Gr)
        {
            if (Gr == null)
                throw new ArgumentNullException("Gr");

            LBLed ctrl = this.Led;
            if (ctrl == null)
                throw new NullReferenceException("Associated control is not valid");

            Rectangle rc = ctrl.Bounds;

            this.DrawBackground(Gr, rc);

            if (this.rectLed.Width <= 0)
                this.rectLed.Width = rectLabel.Width;
            if (this.rectLed.Height <= 0)
                this.rectLed.Height = ctrl.LedSize.Height;

            this.DrawLed(Gr, this.rectLed);

            this.DrawLabel(Gr, this.rectLabel);
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
			if ( this.Led == null )
				return false;
	
			Color c = this.Led.BackColor;
			SolidBrush br = new SolidBrush ( c );
			Pen pen = new Pen ( c );
			
			Rectangle _rcTmp = new Rectangle(0, 0, this.Led.Width, this.Led.Height );
			Gr.DrawRectangle ( pen, _rcTmp );
			Gr.FillRectangle ( br, rc );
			
			br.Dispose();
			pen.Dispose();
			
			return true;
		}
		
		/// <summary>
		/// Draw the body of the control
		/// </summary>
		/// <param name="Gr"></param>
		/// <param name="rc"></param>
		/// <returns></returns>
		public virtual bool DrawLed( Graphics Gr, RectangleF rc )
		{
			if ( this.Led == null )
				return false;
	
			Color cDarkOff = LBColorManager.StepColor ( Color.LightGray, 20 );
			Color cDarkOn = LBColorManager.StepColor ( this.Led.LedColor, 60 );
			
			LinearGradientBrush brOff = new LinearGradientBrush ( rc, 
			                                                   	  Color.Gray,
			                                                   	  cDarkOff,
			                                                	  45 );
			
			LinearGradientBrush brOn = new LinearGradientBrush ( rc, 
			                                                  	 this.Led.LedColor,
			                                                  	 cDarkOn,
			                                                  	 45 );
			if ( this.Led.State == LBLed.LedState.Blink )
			{
                if (this.Led.BlinkIsOn == false)
                {
                    if (this.Led.Style == LBLed.LedStyle.Circular)
                        Gr.FillEllipse(brOff, rc);
                    else if (this.Led.Style == LBLed.LedStyle.Rectangular)
                        Gr.FillRectangle(brOff, rc);
                }
                else
                {
                    if (this.Led.Style == LBLed.LedStyle.Circular)
                        Gr.FillEllipse(brOn, rc);
                    else if (this.Led.Style == LBLed.LedStyle.Rectangular)
                        Gr.FillRectangle(brOn, rc);
                }
			}
			else
			{
                if (this.Led.State == LBLed.LedState.Off)
                {
                    if (this.Led.Style == LBLed.LedStyle.Circular)
                        Gr.FillEllipse(brOff, rc);
                    else if (this.Led.Style == LBLed.LedStyle.Rectangular)
                        Gr.FillRectangle(brOff, rc);
                }
                else
                {
                    if (this.Led.Style == LBLed.LedStyle.Circular)
                        Gr.FillEllipse(brOn, rc);
                    else if (this.Led.Style == LBLed.LedStyle.Rectangular)
                        Gr.FillRectangle(brOn, rc);
                }
			}
			
			brOff.Dispose();
			brOn.Dispose();
			
			return true;
		}
		
		/// <summary>
		/// Draw the text of the control
		/// </summary>
		/// <param name="Gr"></param>
		/// <param name="rc"></param>
		/// <returns></returns>
		public virtual bool DrawLabel( Graphics Gr, RectangleF rc )
		{
			if ( this.Led == null )
				return false;
	
			if ( this.Led.Label == String.Empty )
				return false;
						
			SizeF size = Gr.MeasureString (  this.Led.Label, this.Led.Font );
			
			SolidBrush br1 = new SolidBrush ( this.Led.ForeColor );

			float hPos = 0;
			float vPos = 0;
			switch ( this.Led.LabelPosition )
			{
				case LBLed.LedLabelPosition.Top:
					hPos = (float)(rc.Width*0.5F)-(float)(size.Width*0.5F);
					vPos = rc.Bottom - size.Height;
					break;
					
				case LBLed.LedLabelPosition.Bottom:
					hPos = (float)(rc.Width*0.5F)-(float)(size.Width*0.5F);
					break;
					
				case LBLed.LedLabelPosition.Left:
					hPos = rc.Width - size.Width;
					vPos = (float)(rc.Height*0.5F)-(float)(size.Height*0.5F);
					break;
					
				case LBLed.LedLabelPosition.Right:
					vPos = (float)(rc.Height*0.5F)-(float)(size.Height*0.5F);
					break;
			}
			
			Gr.DrawString ( this.Led.Label, 
			                this.Led.Font, 
			                br1, 
			                rc.Left + hPos,
			                rc.Top + vPos );	
			
			return true;
		}
		#endregion
	}
}
