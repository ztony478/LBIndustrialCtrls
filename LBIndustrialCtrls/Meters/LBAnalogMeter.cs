/*---------------------------------------------------------------------------
 * File: LBAnalogMeter.cs
 * Utente: lucabonotto
 * Date: 05/04/2009
 *-------------------------------------------------------------------------*/

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using LBSoft.IndustrialCtrls.Base;

namespace LBSoft.IndustrialCtrls.Meters
{
	/// <summary>
	/// Class for the analog meter control
	/// </summary>
	public partial class LBAnalogMeter : LBIndustrialCtrlBase
	{		
		#region (* Enumerator *)
		public enum AnalogMeterStyle
		{
			Circular	= 0,
		};
		#endregion
		
		#region (* Properties variables *)
		private	AnalogMeterStyle 					meterStyle;
		private Color								bodyColor;
		private Color								needleColor;
		private Color								scaleColor;
		private bool								viewGlass;
		private double								currValue;
		private double								minValue;
		private double								maxValue;
		private int									scaleDivisions;
		private int									scaleSubDivisions;
		private LBMeterThresholdCollection			listThreshold;
		#endregion

		#region (* Class variables *)
		protected float					startAngle;
		protected float					endAngle;
		#endregion
		
		#region (* Costructors *)
		public LBAnalogMeter()
		{
			// Initialization
			InitializeComponent();
			
			// Properties initialization
			this.bodyColor = Color.Red;
			this.needleColor = Color.Yellow;
			this.scaleColor = Color.White;
			this.meterStyle = AnalogMeterStyle.Circular;
			this.viewGlass = false;
			this.startAngle = 135;
			this.endAngle = 405;
			this.minValue = 0;
			this.maxValue = 1;
			this.currValue = 0;
			this.scaleDivisions = 10;
			this.scaleSubDivisions = 10;

			// Create the sector list
			this.listThreshold = new LBMeterThresholdCollection();
			
			this.CalculateDimensions();
		}
		#endregion
		
		#region (* Properties *)
		[
			Category("Analog Meter"),
			Description("Style of the control")
		]
		public AnalogMeterStyle MeterStyle
		{
			get { return meterStyle;}
			set
			{
				meterStyle = value;
				Invalidate();
			}
		}
		
		
		[
			Category("Analog Meter"),
			Description("Color of the body of the control")
		]
		public Color BodyColor
		{
			get { return bodyColor; }
			set
			{
				bodyColor = value;
				Invalidate();
			}
		}
		
		
		[
			Category("Analog Meter"),
			Description("Color of the needle")
		]
		public Color NeedleColor
		{
			get { return needleColor; }
			set
			{
				needleColor = value;
				Invalidate();
			}
		}
		
		
		[
			Category("Analog Meter"),
			Description("Show or hide the glass effect")
		]
		public bool ViewGlass
		{
			get { return viewGlass; }
			set
			{
				viewGlass = value;
				Invalidate();
			}
		}
		
		
		[
			Category("Analog Meter"),
			Description("Color of the scale of the control")
		]
		public Color ScaleColor
		{
			get { return scaleColor; }
			set
			{
				scaleColor = value;
				Invalidate();
			}
		}
		
		
		[
			Category("Analog Meter"),
			Description("Value of the data")
		]
		public double Value
		{
			get { return currValue; }
			set
			{
				double val = value;
				if ( val > maxValue )
					val = maxValue;
				
				if ( val < minValue )
					val = minValue;
				
				currValue = val;
				Invalidate();
			}
		}
		
		
		[
			Category("Analog Meter"),
			Description("Minimum value of the data")
		]
		public double MinValue
		{
			get { return minValue; }
			set
			{
				minValue = value;
				Invalidate();
			}
		}
		
		
		[
			Category("Analog Meter"),
			Description("Maximum value of the data")
		]
		public double MaxValue
		{
			get { return maxValue; }
			set
			{
				maxValue = value;
				Invalidate();
			}
		}
		
		
		[
			Category("Analog Meter"),
			Description("Number of the scale divisions")
		]
		public int ScaleDivisions
		{
			get { return scaleDivisions; }
			set
			{
				scaleDivisions = value;
				this.CalculateDimensions();
			}
		}
		
		
		[
			Category("Analog Meter"),
			Description("Number of the scale subdivisions")
		]
		public int ScaleSubDivisions
		{
			get { return scaleSubDivisions; }
			set
			{
				scaleSubDivisions = value;
				this.CalculateDimensions();
			}
		}

		[Browsable(false)]
		public LBMeterThresholdCollection Thresholds
		{
			get { return this.listThreshold; }
		}
		#endregion
		
		#region (* Public methods *)
		public float GetStartAngle()
		{
			return this.startAngle;
		}
		
		public float GetEndAngle()
		{
			return this.endAngle;
		}
		#endregion
		
        #region (* Overrided methods *)
        protected override ILBRenderer CreateDefaultRenderer()
        {
            return new LBAnalogMeterRenderer();
        }
        #endregion
	}
}
