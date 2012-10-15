/*---------------------------------------------------------------------------
 * File: LBKnob.cs
 * Utente: lucabonotto
 * Date: 05/04/2009
 *-------------------------------------------------------------------------*/

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using LBSoft.IndustrialCtrls.Base;

namespace LBSoft.IndustrialCtrls.Knobs
{
	/// <summary>
	/// Description of LBKnob.
	/// </summary>
	public partial class LBKnob : LBIndustrialCtrlBase
	{
		#region *( Enumerators *)
		public enum KnobStyle
		{
			Circular = 0,
		}
		#endregion
		
		#region (* Properties variables *)
		private float			minValue = 0.0F;
		private float			maxValue = 1.0F;
		private float			stepValue = 0.1F;
		private float			currValue = 0.0F;
        private RectangleF      knobRect = RectangleF.Empty;
        private PointF          knobCenter = PointF.Empty;
		private KnobStyle		style = KnobStyle.Circular;
		private Color			scaleColor = Color.Green;
		private Color			knobColor = Color.Black ;
		private Color			indicatorColor = Color.Red;
		private float			indicatorOffset = 10F;
        private float           drawRatio = 1F;
		#endregion
		
		#region (* Class variables *)
		private bool			isKnobRotating = false;
		#endregion		
		
		#region (* Constructor *)
		public LBKnob()
		{
			InitializeComponent();
			
			this.CalculateDimensions();
		}
		#endregion
		
		#region (* Properties *)
		[
			Category("Knob"),
			Description("Minimum value of the knob")
		]
		public float MinValue
		{
			set 
			{ 
				this.minValue = value;
				this.Invalidate();
			}
			get { return this.minValue; }
		}

		[
			Category("Knob"),
			Description("Maximum value of the knob")
		]
		public float MaxValue
		{
			set 
			{ 
				this.maxValue = value;
				this.Invalidate();
			}
			get { return this.maxValue; }
		}

		[
			Category("Knob"),
			Description("Step value of the knob")
		]
		public float StepValue
		{
			set 
			{ 
				this.stepValue = value;
				this.Invalidate();
			}
			get { return this.stepValue; }
		}
		
		[
			Category("Knob"),
			Description("Current value of the knob")
		]
		public float Value
		{
			set 
			{ 
				if ( value != this.currValue )
				{
					this.currValue = value;
                    this.CalculateDimensions();
                    this.Invalidate();
					
					LBKnobEventArgs e = new LBKnobEventArgs();
					e.Value = this.currValue;
					this.OnKnobChangeValue( e );
				}
			}
			get { return this.currValue; }
		}
				
		[
			Category("Knob"),
			Description("Style of the knob")
		]
		public KnobStyle Style
		{
			set 
			{ 
				this.style = value;
				this.Invalidate();
			}
			get { return this.style; }
		}		
				
		[
			Category("Knob"),
			Description("Color of the knob")
		]
		public Color KnobColor
		{
			set 
			{ 
				this.knobColor = value;
				this.Invalidate();
			}
			get { return this.knobColor; }
		}		
				
		[
			Category("Knob"),
			Description("Color of the scale")
		]
		public Color ScaleColor
		{
			set 
			{ 
				this.scaleColor = value;
				this.Invalidate();
			}
			get { return this.scaleColor; }
		}
		
		[
			Category("Knob"),
			Description("Color of the indicator")
		]
		public Color IndicatorColor
		{
			set 
			{ 
				this.indicatorColor = value;
				this.Invalidate();
			}
			get { return this.indicatorColor; }
		}
		
		[
			Category("Knob"),
			Description("Offset of the indicator from the kob border")
		]
		public float IndicatorOffset
		{
			set 
			{ 
				this.indicatorOffset = value;
				this.CalculateDimensions();
				this.Invalidate();
			}
			get { return this.indicatorOffset; }
		}
		
		[Browsable(false)]
		public PointF KnobCenter
		{
            set { this.knobCenter = value; }
			get { return this.knobCenter; }
		}

        [Browsable(false)]
        public RectangleF KnobRect
        {
            set { this.knobRect = value; }
            get { return this.knobRect; }
        }

        [Browsable(false)]
        public float DrawRatio
        {
            set { this.drawRatio = value; }
            get { return this.drawRatio; }
        }
        #endregion

		#region (* Events delegates *)
		
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			bool blResult = true;

			/// <summary>
			/// Specified WM_KEYDOWN enumeration value.
			/// </summary>
			const int WM_KEYDOWN = 0x0100;

			/// <summary>
			/// Specified WM_SYSKEYDOWN enumeration value.
			/// </summary>
			const int WM_SYSKEYDOWN = 0x0104;

			float val = this.Value;
			
			if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
			{
				switch(keyData)
				{
					case Keys.Up:
						val += this.StepValue;
						if ( val <= this.MaxValue )
							this.Value = val;
						break;

					case Keys.Down:
						val -= this.StepValue;
						if ( val >= this.MinValue )
							this.Value = val;
						break;
						
					case Keys.PageUp:
						if ( val <  this.MaxValue )
						{
							val += ( this.StepValue * 10 );
							this.Value = val;
						}
						break;
						
					case Keys.PageDown:
						if ( val > this.MinValue )
						{
							val -= ( this.StepValue * 10 );
							this.Value = val;
						}
						break;

					case Keys.Home:
						this.Value = this.MinValue;
						break;
						
					case Keys.End:
						this.Value = this.MaxValue;
						break;

					default:
						blResult = base.ProcessCmdKey(ref msg,keyData);
						break;
				}
			}

			return blResult;
		}
		
		[System.ComponentModel.EditorBrowsableAttribute()]
		protected override void OnClick(EventArgs e)
		{
			this.Focus();
			this.Invalidate();
			base.OnClick(e);
		}
		
		void OnMouseUp(object sender, MouseEventArgs e)
		{
			this.isKnobRotating = false;

            if (this.knobRect.Contains(e.Location) == false)
				return;
			
			float val = this.GetValueFromPosition ( e.Location );
			if ( val != this.Value )
			{
				this.Value = val;
				this.Invalidate();
			}
		}
		
		void OnMouseDown(object sender, MouseEventArgs e)
		{
            if (this.knobRect.Contains(e.Location) == false)
				return;
			
			this.isKnobRotating = true;
			
			this.Focus();
		}
		
		void OnMouseMove(object sender, MouseEventArgs e)
		{
			if ( this.isKnobRotating == false )
				return;
			
			float val = this.GetValueFromPosition ( e.Location );
			if ( val != this.Value )
			{
				this.Value = val;
				this.Invalidate ();
			}
		}
		
		void OnKeyDown(object sender, KeyEventArgs e)
		{
			float val = this.Value;

			switch ( e.KeyCode )
			{
				case Keys.Up:
					val = this.Value + this.StepValue;
					break;

				case Keys.Down:
					val = this.Value - this.StepValue;
					break;
			}

			if ( val < this.MinValue )
				val = this.MinValue;
			   
			if ( val > this.MaxValue )
				val = this.MaxValue;
			
			this.Value = val;
		}
		#endregion
		
		#region (* Virtual methods *)
		public virtual float GetValueFromPosition ( PointF position )
		{
			float degree = 0.0F;
			float v = 0.0F;
		
			PointF center = this.KnobCenter;
			
			if ( position.X <= center.X )
			{
				degree  = (center.Y - position.Y ) /  (center.X - position.X );
				degree = (float)Math.Atan(degree);
				degree = (float)((degree) * (180F / Math.PI) + 45F);
				v = (degree * ( this.MaxValue - this.MinValue )/ 270F);
			}
			else
			{
				if ( position.X > center.X )
				{
					degree  = (position.Y - center.Y ) /  (position.X - center.X );
					degree = (float)Math.Atan(degree);
					degree = (float)(225F + (degree) * (180F / Math.PI));
					v = (degree * ( this.MaxValue - this.MinValue ) / 270F);
				}
			}
		
			if ( v > this.MaxValue )
				v = this.MaxValue;
		
			if (v < this.MinValue )
				v = this.MinValue;
		
			return v;					
		}
		
		public virtual PointF GetPositionFromValue ( float val )
		{
			PointF pos = new PointF( 0.0F, 0.0F );
				
				// Elimina la divisione per 0
			if ( ( this.MaxValue - this.MinValue ) == 0 )	
				return pos;
		
			float _indicatorOffset = this.IndicatorOffset * this.drawRatio;
			
			float degree = 270F * val / ( this.MaxValue - this.MinValue );
			degree = (degree + 135F) * (float)Math.PI / 180F;

            pos.X = (int)(Math.Cos(degree) * ((this.knobRect.Width * 0.5F) - indicatorOffset) + this.knobRect.X + (this.knobRect.Width * 0.5F));
            pos.Y = (int)(Math.Sin(degree) * ((this.knobRect.Width * 0.5F) - indicatorOffset) + this.knobRect.Y + (this.knobRect.Height * 0.5F));
		
			return pos;
		}
		#endregion

		#region (* Fire events *)
		public event KnobChangeValue KnobChangeValue;
		protected virtual void OnKnobChangeValue( LBKnobEventArgs e )
	    {
	        if( this.KnobChangeValue != null )
	            this.KnobChangeValue( this, e );
	    }		
		#endregion

        #region (* Overrided method *)
        protected override ILBRenderer CreateDefaultRenderer()
        {
            return new LBKnobRenderer();
        }
        #endregion
    }

	#region (* Classes for event and event delagates args *)
	
	#region (* Event args class *)
	/// <summary>
	/// Class for events delegates
	/// </summary>
	public class LBKnobEventArgs : EventArgs
	{
		private float val;
			
		public LBKnobEventArgs()
		{			
		}
	
		public float Value
		{
			get { return this.val; }
			set { this.val = value; }
		}
	}
	#endregion
	
	#region (* Delegates *)
	public delegate void KnobChangeValue ( object sender, LBKnobEventArgs e );
	#endregion
	
	#endregion
}
