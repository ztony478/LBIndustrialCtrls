/*
 * Creato da SharpDevelop.
 * Utente: lucabonotto
 * Data: 03/04/2008
 * Ora: 14.34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Windows.Forms;

namespace TestApp
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sdRepeat = new LBSoft.IndustrialCtrls.Leds.LB7SegmentDisplay();
            this.label4 = new System.Windows.Forms.Label();
            this.lB7SegmentDisplay1 = new LBSoft.IndustrialCtrls.Leds.LB7SegmentDisplay();
            this.lB7SegmentDisplay2 = new LBSoft.IndustrialCtrls.Leds.LB7SegmentDisplay();
            this.lbLed4 = new LBSoft.IndustrialCtrls.Leds.LBLed();
            this.lbLed3 = new LBSoft.IndustrialCtrls.Leds.LBLed();
            this.lbLed2 = new LBSoft.IndustrialCtrls.Leds.LBLed();
            this.lbLed1 = new LBSoft.IndustrialCtrls.Leds.LBLed();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRepeat = new LBSoft.IndustrialCtrls.Buttons.LBButton();
            this.lbButton3 = new LBSoft.IndustrialCtrls.Buttons.LBButton();
            this.lbButton2 = new LBSoft.IndustrialCtrls.Buttons.LBButton();
            this.lbButton1 = new LBSoft.IndustrialCtrls.Buttons.LBButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.labelCurrCtrl = new System.Windows.Forms.Label();
            this.lbDigitalMeter1 = new LBSoft.IndustrialCtrls.Meters.LBDigitalMeter();
            this.lbAnalogMeter2 = new LBSoft.IndustrialCtrls.Meters.LBAnalogMeter();
            this.lbKnob1 = new LBSoft.IndustrialCtrls.Knobs.LBKnob();
            this.lbAnalogMeter1 = new LBSoft.IndustrialCtrls.Meters.LBAnalogMeter();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.sdRepeat);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lB7SegmentDisplay1);
            this.groupBox1.Controls.Add(this.lB7SegmentDisplay2);
            this.groupBox1.Controls.Add(this.lbLed4);
            this.groupBox1.Controls.Add(this.lbLed3);
            this.groupBox1.Controls.Add(this.lbLed2);
            this.groupBox1.Controls.Add(this.lbLed1);
            this.groupBox1.Location = new System.Drawing.Point(143, 238);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 311);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Leds";
            // 
            // sdRepeat
            // 
            this.sdRepeat.BackColor = System.Drawing.Color.Black;
            this.sdRepeat.ForeColor = System.Drawing.Color.Red;
            this.sdRepeat.Location = new System.Drawing.Point(32, 236);
            this.sdRepeat.Name = "sdRepeat";
            this.sdRepeat.Renderer = null;
            this.sdRepeat.ShowDP = false;
            this.sdRepeat.Size = new System.Drawing.Size(32, 46);
            this.sdRepeat.TabIndex = 18;
            this.sdRepeat.Value = 2;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(145, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "7 Segments display";
            // 
            // lB7SegmentDisplay1
            // 
            this.lB7SegmentDisplay1.BackColor = System.Drawing.Color.Black;
            this.lB7SegmentDisplay1.ForeColor = System.Drawing.Color.Red;
            this.lB7SegmentDisplay1.Location = new System.Drawing.Point(148, 41);
            this.lB7SegmentDisplay1.Name = "lB7SegmentDisplay1";
            this.lB7SegmentDisplay1.Renderer = null;
            this.lB7SegmentDisplay1.ShowDP = false;
            this.lB7SegmentDisplay1.Size = new System.Drawing.Size(32, 46);
            this.lB7SegmentDisplay1.TabIndex = 15;
            this.lB7SegmentDisplay1.Value = 2;
            this.lB7SegmentDisplay1.Click += new System.EventHandler(this.OnObjectClicked);
            // 
            // lB7SegmentDisplay2
            // 
            this.lB7SegmentDisplay2.BackColor = System.Drawing.Color.Black;
            this.lB7SegmentDisplay2.ForeColor = System.Drawing.Color.LawnGreen;
            this.lB7SegmentDisplay2.Location = new System.Drawing.Point(148, 96);
            this.lB7SegmentDisplay2.Name = "lB7SegmentDisplay2";
            this.lB7SegmentDisplay2.Renderer = null;
            this.lB7SegmentDisplay2.ShowDP = false;
            this.lB7SegmentDisplay2.Size = new System.Drawing.Size(99, 135);
            this.lB7SegmentDisplay2.TabIndex = 16;
            this.lB7SegmentDisplay2.Value = 3;
            this.lB7SegmentDisplay2.Click += new System.EventHandler(this.OnObjectClicked);
            // 
            // lbLed4
            // 
            this.lbLed4.BackColor = System.Drawing.Color.Transparent;
            this.lbLed4.BlinkInterval = 500;
            this.lbLed4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLed4.ForeColor = System.Drawing.Color.Black;
            this.lbLed4.Label = "Fixed & Top";
            this.lbLed4.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Top;
            this.lbLed4.LedColor = System.Drawing.Color.Red;
            this.lbLed4.LedSize = new System.Drawing.SizeF(20F, 20F);
            this.lbLed4.Location = new System.Drawing.Point(4, 54);
            this.lbLed4.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.lbLed4.Name = "lbLed4";
            this.lbLed4.Renderer = null;
            this.lbLed4.Size = new System.Drawing.Size(103, 36);
            this.lbLed4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On;
            this.lbLed4.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Circular;
            this.lbLed4.TabIndex = 3;
            this.lbLed4.Click += new System.EventHandler(this.OnObjectClicked);
            // 
            // lbLed3
            // 
            this.lbLed3.BackColor = System.Drawing.Color.Transparent;
            this.lbLed3.BlinkInterval = 200;
            this.lbLed3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLed3.ForeColor = System.Drawing.Color.Black;
            this.lbLed3.Label = "Left & Blink";
            this.lbLed3.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Left;
            this.lbLed3.LedColor = System.Drawing.Color.Yellow;
            this.lbLed3.LedSize = new System.Drawing.SizeF(30F, 30F);
            this.lbLed3.Location = new System.Drawing.Point(10, 172);
            this.lbLed3.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.lbLed3.Name = "lbLed3";
            this.lbLed3.Renderer = null;
            this.lbLed3.Size = new System.Drawing.Size(112, 36);
            this.lbLed3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;
            this.lbLed3.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Circular;
            this.lbLed3.TabIndex = 2;
            this.lbLed3.Click += new System.EventHandler(this.OnObjectClicked);
            // 
            // lbLed2
            // 
            this.lbLed2.BackColor = System.Drawing.Color.Transparent;
            this.lbLed2.BlinkInterval = 500;
            this.lbLed2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLed2.ForeColor = System.Drawing.Color.Black;
            this.lbLed2.Label = "Right & Fixed";
            this.lbLed2.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Right;
            this.lbLed2.LedColor = System.Drawing.Color.Lime;
            this.lbLed2.LedSize = new System.Drawing.SizeF(20F, 20F);
            this.lbLed2.Location = new System.Drawing.Point(10, 109);
            this.lbLed2.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.lbLed2.Name = "lbLed2";
            this.lbLed2.Renderer = null;
            this.lbLed2.Size = new System.Drawing.Size(112, 27);
            this.lbLed2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;
            this.lbLed2.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Circular;
            this.lbLed2.TabIndex = 1;
            this.lbLed2.Click += new System.EventHandler(this.OnObjectClicked);
            // 
            // lbLed1
            // 
            this.lbLed1.BackColor = System.Drawing.Color.Transparent;
            this.lbLed1.BlinkInterval = 500;
            this.lbLed1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLed1.ForeColor = System.Drawing.Color.Black;
            this.lbLed1.Label = "Fixed & Bottom";
            this.lbLed1.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Bottom;
            this.lbLed1.LedColor = System.Drawing.Color.Red;
            this.lbLed1.LedSize = new System.Drawing.SizeF(20F, 20F);
            this.lbLed1.Location = new System.Drawing.Point(4, 18);
            this.lbLed1.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.lbLed1.Name = "lbLed1";
            this.lbLed1.Renderer = null;
            this.lbLed1.Size = new System.Drawing.Size(103, 36);
            this.lbLed1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;
            this.lbLed1.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Circular;
            this.lbLed1.TabIndex = 0;
            this.lbLed1.Click += new System.EventHandler(this.OnObjectClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btnRepeat);
            this.groupBox2.Controls.Add(this.lbButton3);
            this.groupBox2.Controls.Add(this.lbButton2);
            this.groupBox2.Controls.Add(this.lbButton1);
            this.groupBox2.Location = new System.Drawing.Point(13, 238);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(124, 311);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Buttons";
            // 
            // btnRepeat
            // 
            this.btnRepeat.BackColor = System.Drawing.Color.Transparent;
            this.btnRepeat.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.btnRepeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRepeat.Label = "Repeat";
            this.btnRepeat.Location = new System.Drawing.Point(6, 228);
            this.btnRepeat.Name = "btnRepeat";
            this.btnRepeat.Renderer = null;
            this.btnRepeat.RepeatInterval = 100;
            this.btnRepeat.RepeatState = true;
            this.btnRepeat.Size = new System.Drawing.Size(103, 65);
            this.btnRepeat.StartRepeatInterval = 500;
            this.btnRepeat.State = LBSoft.IndustrialCtrls.Buttons.LBButton.ButtonState.Normal;
            this.btnRepeat.Style = LBSoft.IndustrialCtrls.Buttons.LBButton.ButtonStyle.Rectangular;
            this.btnRepeat.TabIndex = 3;
            this.btnRepeat.ButtonChangeState += new LBSoft.IndustrialCtrls.Buttons.ButtonChangeState(this.btnRepeat_ButtonChangeState);
            this.btnRepeat.ButtonRepeatState += new LBSoft.IndustrialCtrls.Buttons.ButtonRepeatState(this.btnRepeat_ButtonRepeatState);
            this.btnRepeat.Click += new System.EventHandler(this.OnObjectClicked);
            // 
            // lbButton3
            // 
            this.lbButton3.BackColor = System.Drawing.Color.Transparent;
            this.lbButton3.ButtonColor = System.Drawing.Color.Yellow;
            this.lbButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbButton3.Label = "Warn";
            this.lbButton3.Location = new System.Drawing.Point(15, 158);
            this.lbButton3.Name = "lbButton3";
            this.lbButton3.Renderer = null;
            this.lbButton3.RepeatInterval = 100;
            this.lbButton3.RepeatState = false;
            this.lbButton3.Size = new System.Drawing.Size(103, 65);
            this.lbButton3.StartRepeatInterval = 500;
            this.lbButton3.State = LBSoft.IndustrialCtrls.Buttons.LBButton.ButtonState.Normal;
            this.lbButton3.Style = LBSoft.IndustrialCtrls.Buttons.LBButton.ButtonStyle.Circular;
            this.lbButton3.TabIndex = 2;
            this.lbButton3.ButtonChangeState += new LBSoft.IndustrialCtrls.Buttons.ButtonChangeState(this.OnWarnStateChanged);
            this.lbButton3.Click += new System.EventHandler(this.OnObjectClicked);
            // 
            // lbButton2
            // 
            this.lbButton2.BackColor = System.Drawing.Color.Transparent;
            this.lbButton2.ButtonColor = System.Drawing.Color.Green;
            this.lbButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbButton2.Label = "Start";
            this.lbButton2.Location = new System.Drawing.Point(15, 88);
            this.lbButton2.Name = "lbButton2";
            this.lbButton2.Renderer = null;
            this.lbButton2.RepeatInterval = 100;
            this.lbButton2.RepeatState = false;
            this.lbButton2.Size = new System.Drawing.Size(103, 65);
            this.lbButton2.StartRepeatInterval = 500;
            this.lbButton2.State = LBSoft.IndustrialCtrls.Buttons.LBButton.ButtonState.Normal;
            this.lbButton2.Style = LBSoft.IndustrialCtrls.Buttons.LBButton.ButtonStyle.Elliptical;
            this.lbButton2.TabIndex = 1;
            this.lbButton2.ButtonChangeState += new LBSoft.IndustrialCtrls.Buttons.ButtonChangeState(this.OnStartStateChanged);
            this.lbButton2.Click += new System.EventHandler(this.OnObjectClicked);
            // 
            // lbButton1
            // 
            this.lbButton1.BackColor = System.Drawing.Color.Transparent;
            this.lbButton1.ButtonColor = System.Drawing.Color.Red;
            this.lbButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbButton1.Label = "Stop";
            this.lbButton1.Location = new System.Drawing.Point(15, 18);
            this.lbButton1.Name = "lbButton1";
            this.lbButton1.Renderer = null;
            this.lbButton1.RepeatInterval = 100;
            this.lbButton1.RepeatState = false;
            this.lbButton1.Size = new System.Drawing.Size(103, 65);
            this.lbButton1.StartRepeatInterval = 500;
            this.lbButton1.State = LBSoft.IndustrialCtrls.Buttons.LBButton.ButtonState.Normal;
            this.lbButton1.Style = LBSoft.IndustrialCtrls.Buttons.LBButton.ButtonStyle.Rectangular;
            this.lbButton1.TabIndex = 0;
            this.lbButton1.ButtonChangeState += new LBSoft.IndustrialCtrls.Buttons.ButtonChangeState(this.OnStopStateChanged);
            this.lbButton1.Click += new System.EventHandler(this.OnObjectClicked);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(72, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 27);
            this.label1.TabIndex = 10;
            this.label1.Text = "Analog meter with default renderer";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(280, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 27);
            this.label2.TabIndex = 11;
            this.label2.Text = "Analog meter with custom renderer";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(479, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 27);
            this.label3.TabIndex = 12;
            this.label3.Text = "Knob for change the analog values";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGrid1.HelpVisible = false;
            this.propertyGrid1.Location = new System.Drawing.Point(424, 238);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(251, 311);
            this.propertyGrid1.TabIndex = 13;
            this.propertyGrid1.ToolbarVisible = false;
            // 
            // labelCurrCtrl
            // 
            this.labelCurrCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCurrCtrl.Location = new System.Drawing.Point(420, 215);
            this.labelCurrCtrl.Name = "labelCurrCtrl";
            this.labelCurrCtrl.Size = new System.Drawing.Size(257, 13);
            this.labelCurrCtrl.TabIndex = 14;
            this.labelCurrCtrl.Text = "Click to the controls to view the properties";
            // 
            // lbDigitalMeter1
            // 
            this.lbDigitalMeter1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDigitalMeter1.BackColor = System.Drawing.Color.Black;
            this.lbDigitalMeter1.ForeColor = System.Drawing.Color.Red;
            this.lbDigitalMeter1.Format = "0000.00";
            this.lbDigitalMeter1.Location = new System.Drawing.Point(441, 136);
            this.lbDigitalMeter1.Name = "lbDigitalMeter1";
            this.lbDigitalMeter1.Renderer = null;
            this.lbDigitalMeter1.Signed = false;
            this.lbDigitalMeter1.Size = new System.Drawing.Size(233, 66);
            this.lbDigitalMeter1.TabIndex = 15;
            this.lbDigitalMeter1.Value = 0D;
            this.lbDigitalMeter1.Click += new System.EventHandler(this.OnObjectClicked);
            // 
            // lbAnalogMeter2
            // 
            this.lbAnalogMeter2.BackColor = System.Drawing.Color.Transparent;
            this.lbAnalogMeter2.BodyColor = System.Drawing.Color.DodgerBlue;
            this.lbAnalogMeter2.Location = new System.Drawing.Point(10, 30);
            this.lbAnalogMeter2.MaxValue = 100D;
            this.lbAnalogMeter2.MeterStyle = LBSoft.IndustrialCtrls.Meters.LBAnalogMeter.AnalogMeterStyle.Circular;
            this.lbAnalogMeter2.MinValue = 0D;
            this.lbAnalogMeter2.Name = "lbAnalogMeter2";
            this.lbAnalogMeter2.NeedleColor = System.Drawing.Color.Yellow;
            this.lbAnalogMeter2.Renderer = null;
            this.lbAnalogMeter2.ScaleColor = System.Drawing.Color.GreenYellow;
            this.lbAnalogMeter2.ScaleDivisions = 11;
            this.lbAnalogMeter2.ScaleSubDivisions = 10;
            this.lbAnalogMeter2.Size = new System.Drawing.Size(211, 186);
            this.lbAnalogMeter2.TabIndex = 9;
            this.lbAnalogMeter2.Value = 0D;
            this.lbAnalogMeter2.ViewGlass = true;
            this.lbAnalogMeter2.Click += new System.EventHandler(this.OnObjectClicked);
            // 
            // lbKnob1
            // 
            this.lbKnob1.BackColor = System.Drawing.Color.Transparent;
            this.lbKnob1.DrawRatio = 0.385F;
            this.lbKnob1.IndicatorColor = System.Drawing.Color.DarkRed;
            this.lbKnob1.IndicatorOffset = 8F;
            this.lbKnob1.KnobCenter = ((System.Drawing.PointF)(resources.GetObject("lbKnob1.KnobCenter")));
            this.lbKnob1.KnobColor = System.Drawing.Color.DarkOrange;
            this.lbKnob1.KnobRect = ((System.Drawing.RectangleF)(resources.GetObject("lbKnob1.KnobRect")));
            this.lbKnob1.Location = new System.Drawing.Point(485, 30);
            this.lbKnob1.MaxValue = 100F;
            this.lbKnob1.MinValue = 0F;
            this.lbKnob1.Name = "lbKnob1";
            this.lbKnob1.Renderer = null;
            this.lbKnob1.ScaleColor = System.Drawing.Color.DimGray;
            this.lbKnob1.Size = new System.Drawing.Size(87, 77);
            this.lbKnob1.StepValue = 0.2F;
            this.lbKnob1.Style = LBSoft.IndustrialCtrls.Knobs.LBKnob.KnobStyle.Circular;
            this.lbKnob1.TabIndex = 8;
            this.lbKnob1.Value = 0F;
            this.lbKnob1.KnobChangeValue += new LBSoft.IndustrialCtrls.Knobs.KnobChangeValue(this.OnKnobChangeValue);
            this.lbKnob1.Click += new System.EventHandler(this.OnObjectClicked);
            // 
            // lbAnalogMeter1
            // 
            this.lbAnalogMeter1.BackColor = System.Drawing.Color.Transparent;
            this.lbAnalogMeter1.BodyColor = System.Drawing.Color.DodgerBlue;
            this.lbAnalogMeter1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAnalogMeter1.ForeColor = System.Drawing.Color.Red;
            this.lbAnalogMeter1.Location = new System.Drawing.Point(228, 30);
            this.lbAnalogMeter1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lbAnalogMeter1.MaxValue = 100D;
            this.lbAnalogMeter1.MeterStyle = LBSoft.IndustrialCtrls.Meters.LBAnalogMeter.AnalogMeterStyle.Circular;
            this.lbAnalogMeter1.MinValue = 0D;
            this.lbAnalogMeter1.Name = "lbAnalogMeter1";
            this.lbAnalogMeter1.NeedleColor = System.Drawing.Color.Yellow;
            this.lbAnalogMeter1.Renderer = null;
            this.lbAnalogMeter1.ScaleColor = System.Drawing.Color.GreenYellow;
            this.lbAnalogMeter1.ScaleDivisions = 11;
            this.lbAnalogMeter1.ScaleSubDivisions = 5;
            this.lbAnalogMeter1.Size = new System.Drawing.Size(206, 186);
            this.lbAnalogMeter1.TabIndex = 2;
            this.lbAnalogMeter1.Value = 0D;
            this.lbAnalogMeter1.ViewGlass = true;
            this.lbAnalogMeter1.Click += new System.EventHandler(this.OnObjectClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkKhaki;
            this.ClientSize = new System.Drawing.Size(688, 560);
            this.Controls.Add(this.lbDigitalMeter1);
            this.Controls.Add(this.labelCurrCtrl);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbAnalogMeter2);
            this.Controls.Add(this.lbKnob1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbAnalogMeter1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "TestApp";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		private System.Windows.Forms.Label labelCurrCtrl;
		private System.Windows.Forms.PropertyGrid propertyGrid1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private LBSoft.IndustrialCtrls.Leds.LBLed lbLed4;
		private LBSoft.IndustrialCtrls.Meters.LBAnalogMeter lbAnalogMeter2;
		private LBSoft.IndustrialCtrls.Knobs.LBKnob lbKnob1;
		private LBSoft.IndustrialCtrls.Buttons.LBButton lbButton1;
		private LBSoft.IndustrialCtrls.Buttons.LBButton lbButton2;
		private LBSoft.IndustrialCtrls.Buttons.LBButton lbButton3;
		private LBSoft.IndustrialCtrls.Leds.LBLed lbLed1;
		private LBSoft.IndustrialCtrls.Leds.LBLed lbLed2;
		private LBSoft.IndustrialCtrls.Leds.LBLed lbLed3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox1;
		private LBSoft.IndustrialCtrls.Meters.LBAnalogMeter lbAnalogMeter1;
		
		void OnWarnStateChanged(object sender, LBSoft.IndustrialCtrls.Buttons.LBButtonEventArgs e)
		{
			if ( e.State == LBSoft.IndustrialCtrls.Buttons.LBButton.ButtonState.Pressed )
				this.lbLed3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Blink;
			else
				this.lbLed3.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;
		}
		
		void OnStartStateChanged(object sender, LBSoft.IndustrialCtrls.Buttons.LBButtonEventArgs e)
		{
			if ( e.State == LBSoft.IndustrialCtrls.Buttons.LBButton.ButtonState.Pressed )
				this.lbLed2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On;
			else
				this.lbLed2.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;
		}
		
		void OnStopStateChanged(object sender, LBSoft.IndustrialCtrls.Buttons.LBButtonEventArgs e)
		{
			if ( e.State == LBSoft.IndustrialCtrls.Buttons.LBButton.ButtonState.Pressed )
			{
				this.lbLed1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On;
				this.lbLed4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;
			}
			else
			{
				this.lbLed1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;
				this.lbLed4.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.On;
			}
		}
		
		void OnKnobChangeValue(object sender, LBSoft.IndustrialCtrls.Knobs.LBKnobEventArgs e)
		{
			this.lbAnalogMeter1.Value = e.Value;
			this.lbAnalogMeter2.Value = e.Value;
            this.lbDigitalMeter1.Value = e.Value * 10;

            int v = (int)(e.Value / 10) - 1;
            if ( v < 0 ) 
                v = 0;
            if ( v > 9 )
                v = 9;
            this.lB7SegmentDisplay1.Value = v;
            this.lB7SegmentDisplay2.Value = v;
        }
		
		void OnObjectClicked(object sender, System.EventArgs e)
		{
			this.propertyGrid1.CollapseAllGridItems();
			this.propertyGrid1.Refresh();
			
			this.propertyGrid1.SelectedObject = sender;
		}

        private LBSoft.IndustrialCtrls.Leds.LB7SegmentDisplay lB7SegmentDisplay1;
        private LBSoft.IndustrialCtrls.Leds.LB7SegmentDisplay lB7SegmentDisplay2;
        private Label label4;
        private LBSoft.IndustrialCtrls.Meters.LBDigitalMeter lbDigitalMeter1;
        private LBSoft.IndustrialCtrls.Leds.LB7SegmentDisplay sdRepeat;
        private LBSoft.IndustrialCtrls.Buttons.LBButton btnRepeat;
	}
}
