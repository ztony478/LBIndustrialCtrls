/*---------------------------------------------------------------------------
 * File: ButtonRenderer.cs
 * Utente: lucabonotto
 * Date: 05/04/2009
 * Time: 13.36
 *-------------------------------------------------------------------------*/

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using LBSoft.IndustrialCtrls.Utils;
using LBSoft.IndustrialCtrls.Base;

namespace LBSoft.IndustrialCtrls.Buttons	
{
	/// <summary>
	/// Base class for the button renderers
	/// </summary>
	public class LBButtonRenderer : LBRendererBase
	{
		#region (* Variables *)
		protected RectangleF 	rectCtrl;
		protected RectangleF 	rectBody;
		protected RectangleF 	rectText;		
		protected float			drawRatio = 1.0F;
		#endregion
				
		#region (* Constructor *)
		public LBButtonRenderer()
		{
			this.rectCtrl = new RectangleF ( 0, 0, 0, 0 );
		}
		#endregion
		
		#region (* Overrided methods *)
        /// <summary>
        /// Update the rectangles for drawing
        /// </summary>
        /// <returns></returns>
		public override bool Update()
		{
            // Check Button object
			if ( this.Button == null )
				throw new NullReferenceException ( "Invalid 'Button' object" );
	
			// Control rectangle
			this.rectCtrl.X = 0;
			this.rectCtrl.Y = 0;
			this.rectCtrl.Width = this.Button.Width;
			this.rectCtrl.Height = this.Button.Height;

            if (this.Button.Style == LBButton.ButtonStyle.Circular)
            {
                if (rectCtrl.Width < rectCtrl.Height)
                    rectCtrl.Height = rectCtrl.Width;
                else if (rectCtrl.Width > rectCtrl.Height)
                    rectCtrl.Width = rectCtrl.Height;

                if (rectCtrl.Width < 10)
                    rectCtrl.Width = 10;
                if (rectCtrl.Height < 10)
                    rectCtrl.Height = 10;
            }

            this.rectBody = this.rectCtrl;
            this.rectBody.Width -= 1;
            this.rectBody.Height -= 1;

            this.rectText = this.rectCtrl;
            this.rectText.Width -= 2;
            this.rectText.Height -= 2;

			// Calculate ratio 计算比例
			drawRatio = (Math.Min(rectCtrl.Width,rectCtrl.Height)) / 200;
			if ( drawRatio == 0.0 )
				drawRatio = 1;
				
			return true;
		}
		
        /// <summary>
        /// Draw the button object
        /// </summary>
        /// <param name="Gr"></param>
		public override void Draw ( Graphics Gr )
		{
			if ( Gr == null )
				throw new ArgumentNullException ( "Gr", "Invalid Graphics object" );
			
			if ( this.Button == null )
				throw new NullReferenceException ( "Invalid 'Button' object" );
			
			this.DrawBackground( Gr, this.rectCtrl );			
			this.DrawBody ( Gr, this.rectBody );			
			this.DrawText ( Gr, this.rectText );
		}		
		#endregion
		
		#region (* Properies *)
        /// <summary>
        /// Get the associated button object
        /// </summary>
		public LBButton Button
		{
			get { return this.Control as LBButton; }
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
			if ( this.Button == null )
				return false;
			
			Color c = this.Button.BackColor;
			SolidBrush br = new SolidBrush ( c );
			Pen pen = new Pen ( c );
			
			Rectangle _rcTmp = new Rectangle(0, 0, this.Button.Width, this.Button.Height );
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
		public virtual bool DrawBody( Graphics Gr, RectangleF rc )
		{
			if ( this.Button == null )
				return false;
			
			Color bodyColor = this.Button.ButtonColor;

            //结束颜色。bodyColor基色，60渐变系数
			Color cDark = LBColorManager.StepColor ( bodyColor, 60 );
			
			LinearGradientBrush br1 = new LinearGradientBrush ( rc, 
			                                                   bodyColor,
			                                                   cDark,
			                                                   270 );
            
            if ((this.Button.Style == LBButton.ButtonStyle.Circular) ||
                (this.Button.Style == LBButton.ButtonStyle.Elliptical))
            {
                Gr.FillEllipse(br1, rc);
            }
            else
            {
                GraphicsPath path = this.RoundedRect(rc, 15F);
                Gr.FillPath(br1, path);
                path.Dispose();
            }
			
			if ( this.Button.State == LBButton.ButtonState.Pressed )
			{			
			    RectangleF _rc = rc;
			    _rc.Inflate ( -15F * this.drawRatio, -15F * drawRatio );
			    LinearGradientBrush br2 = new LinearGradientBrush ( _rc, 
			                                                       cDark,
			                                                       bodyColor,
			                                                       270 );
                if ((this.Button.Style == LBButton.ButtonStyle.Circular) ||
                    (this.Button.Style == LBButton.ButtonStyle.Elliptical))
                {
                    Gr.FillEllipse(br2, _rc);
                }
                else
                {
                    GraphicsPath path = this.RoundedRect(_rc, 10F);
                    Gr.FillPath(br2, path);
                    path.Dispose();
                }

                br2.Dispose();
			}
			
			br1.Dispose();
			return true;
		}
		
		/// <summary>
		/// Draw the text of the control
		/// </summary>
		/// <param name="Gr"></param>
		/// <param name="rc"></param>
		/// <returns></returns>
		public virtual bool DrawText( Graphics Gr, RectangleF rc )
		{
			if ( this.Button == null )
				return false;
			
			//Draw Strings
       		Font font = new Font ( this.Button.Font.FontFamily, 
                                   this.Button.Font.Size * this.drawRatio,
                                   this.Button.Font.Style );

	        String str = this.Button.Label;
	
	        Color bodyColor = this.Button.ButtonColor;
			Color cDark = LBColorManager.StepColor ( bodyColor, 20 );

			SizeF size = Gr.MeasureString ( str, font );
			
			SolidBrush br1 = new SolidBrush ( bodyColor );
			SolidBrush br2 = new SolidBrush ( cDark );
			
			Gr.DrawString ( str, 
			                font, 
			                br1, 
			                rc.Left + ( ( rc.Width * 0.5F ) - (float)( size.Width * 0.5F ) ) + (float)( 1 * this.drawRatio ),
			                rc.Top + ( ( rc.Height * 0.5F ) - (float)( size.Height * 0.5 ) ) + (float)( 1 * this.drawRatio ) );
			
			Gr.DrawString ( str, 
			                font, 
			                br2, 
			                rc.Left + ( ( rc.Width * 0.5F ) - (float)( size.Width * 0.5F ) ),
			                rc.Top + ( ( rc.Height * 0.5F ) - (float)( size.Height * 0.5 ) ) );
			
			br1.Dispose();
			br2.Dispose();
			font.Dispose();
			
			return false;
		}
		#endregion

        #region (* Protected Methods *)
        protected GraphicsPath RoundedRect(RectangleF rect, float radius)
        {
            RectangleF baseRect = rect;
            float diameter = (radius*this.drawRatio) * 2.0f;
            SizeF sizeF = new SizeF(diameter, diameter);
            RectangleF arc = new RectangleF(baseRect.Location, sizeF);
            GraphicsPath path = new GraphicsPath();

            // top left arc
            path.AddArc(arc, 180, 90);
            // top right arc 
            arc.X = baseRect.Right - diameter;
            path.AddArc(arc, 270, 90);
            // bottom right  arc 
            arc.Y = baseRect.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            // bottom left arc
            arc.X = baseRect.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }
        #endregion
    }
}
