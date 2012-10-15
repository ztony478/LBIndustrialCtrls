/*---------------------------------------------------------------------------
 * File: LBLed.cs
 * Utente: lucabonotto
 * Date: 05/04/2009
 *-------------------------------------------------------------------------*/

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using LBSoft.IndustrialCtrls.Base;

namespace LBSoft.IndustrialCtrls.Leds
{
	/// <summary>
	/// Description of LB7SegmentDisplay.
	/// </summary>
	public partial class LB7SegmentDisplay : LBIndustrialCtrlBase
	{
		#region (* Constructor *)
		public LB7SegmentDisplay()
		{
			InitializeComponent();
		}
		#endregion

		#region (* Properties *)
        public int val = 0;
        [
            Category("Display"),
            Description("Value of the display")
        ]
        public int Value
        {
            set { this.val = value; this.Invalidate(); }
            get { return this.val; }
        }

        private bool showDp = false;
        [
            Category("Display"),
            Description("Show the point of the display")
        ]
        public bool ShowDP
        {
            set { this.showDp = value; this.Invalidate(); }
            get { return this.showDp; }
        }
		#endregion

        #region (* Overrided methods *)
        protected override ILBRenderer CreateDefaultRenderer()
        {
            return new LB7SegmentDisplayRenderer();
        }
        #endregion
    }
}
