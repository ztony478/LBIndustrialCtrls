/*---------------------------------------------------------------------------
 * File: LBIndustrialCtrlBase.cs
 * Utente: lucabonotto
 * Date: 05/04/2009
 * Time: 13.36
 *-------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LBSoft.IndustrialCtrls.Base
{
    /// <summary>
    /// Base class for the IndustrialCtrls
    /// </summary>
    public partial class LBIndustrialCtrlBase : UserControl
    {
        #region (* Constructor *)
        public LBIndustrialCtrlBase()
        {
            InitializeComponent();

            // Set the styles for drawing
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.ResizeRedraw |
                ControlStyles.DoubleBuffer |
                ControlStyles.SupportsTransparentBackColor,
                true);

            // Transparent background
            this.BackColor = Color.Transparent;

            // Creation of the default renderer
            this._defaultRenderer = CreateDefaultRenderer();
            if (this._defaultRenderer != null)
                this._defaultRenderer.Control = this;
        }
        #endregion

        #region (* Properties *)
        /// <summary>
        /// Default renderer of the control
        /// </summary>
        private ILBRenderer _defaultRenderer = null;
        [Browsable(false)]
        public ILBRenderer DefaultRenderer
        {
            get { return this._defaultRenderer; }
        }

        /// <summary>
        /// User defined renderer
        /// </summary>
        private ILBRenderer _renderer = null;
        [Browsable(false)]
        public ILBRenderer Renderer
        {
            set 
            {
                // set the renderer
                this._renderer = value;
                if (this._renderer != null)
                {
                    // Set the control tu the renderer
                    this._renderer.Control = this;
                    // Update the renderer
                    this._renderer.Update();
                }

                // Redraw the renderer
                Invalidate();
            }
            get { return this._renderer; }
        }
        #endregion

        #region (* Events delegates *)
        /// <summary>
        /// Font change event
        /// </summary>
        /// <param name="e"></param>
        [System.ComponentModel.EditorBrowsableAttribute()]
        protected override void OnFontChanged(EventArgs e)
        {
            // Calculate dimensions
            this.CalculateDimensions();
        }
        /// <summary>
        /// SizeChanged event
        /// </summary>
        /// <param name="e"></param>
        [System.ComponentModel.EditorBrowsableAttribute()]
        protected override void OnSizeChanged(EventArgs e)
        {
            // Default
            base.OnSizeChanged(e);
            // Calculate al the data for
            // drawing the control
            this.CalculateDimensions();
            // Redraw
            this.Invalidate();
        }

        /// <summary>
        /// Resize event
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            // Calculate al the data for
            // drawing the control
            this.CalculateDimensions();
            // Redraw
            this.Invalidate();
        }
        /// <summary>
        /// Paint event
        /// </summary>
        /// <param name="e"></param>
        [System.ComponentModel.EditorBrowsableAttribute()]
        protected override void OnPaint(PaintEventArgs e)
        {
            // Rectangle of the control
            RectangleF _rc = new RectangleF(0, 0, this.Width, this.Height);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Call the default renderer if the user
            // rendere is null
            if (this.Renderer == null)
            {
                this.DefaultRenderer.Draw(e.Graphics);
                return;
            }
            
            // Draw with the user renderer
            this.Renderer.Draw(e.Graphics);
        }
        #endregion

        #region (* Virtual method *)
        /// <summary>
        /// Call from the constructor to create the default renderer
        /// </summary>
        /// <returns></returns>
        protected virtual ILBRenderer CreateDefaultRenderer()
        {
            return new LBRendererBase();
        }

        /// <summary>
        /// Calculate the dimensions of the control
        /// </summary>
        protected virtual void CalculateDimensions()
        {
            this.DefaultRenderer.Update();

            // Update the data in the renderer
            if (this.Renderer != null)
                this.Renderer.Update();

            this.Invalidate();
        }
        #endregion
    }

    /// <summary>
    /// Base class for the controls renderer
    /// </summary>
    public class LBRendererBase : ILBRenderer
    {
        #region (* Constructor *)
        public LBRendererBase()
        {
        }
        #endregion

        #region (* IDisposable implementation *)
        public void Dispose()
        {
            this.OnDispose();
        }
        #endregion

        #region (* Properties *)
        /// <summary>
        /// Associated control
        /// </summary>
        protected object _control = null;
        public object Control
        {
            set { this._control = value; }
            get { return this._control; }
        }
        #endregion

        #region (* Virtual methods *)
        /// <summary>
        /// Dispose the resource of the object
        /// </summary>
        public virtual void OnDispose()
        {
        }

        /// <summary>
        /// Update the renderer
        /// </summary>
        /// <returns></returns>
        public virtual bool Update()
        {
            return false;
        }

        /// <summary>
        /// Drawing method
        /// </summary>
        /// <param name="Gr"></param>
        public virtual void Draw(Graphics Gr)
        {
            // Check the graphics
            if (Gr == null)
                throw new ArgumentNullException("Gr");

            // Check the control
            Control ctrl = this.Control as Control;
            if (ctrl == null)
                throw new NullReferenceException("Associated control is not valid");

            // Default drawing
            Rectangle rc = ctrl.Bounds;

            Gr.FillRectangle(Brushes.White, ctrl.Bounds);
            Gr.DrawRectangle(Pens.Black, ctrl.Bounds);

            Gr.DrawLine(Pens.Red,
                          ctrl.Left,
                          ctrl.Top,
                          ctrl.Right,
                          ctrl.Bottom);

            Gr.DrawLine(Pens.Red,
                          ctrl.Right,
                          ctrl.Top,
                          ctrl.Left,
                          ctrl.Bottom);
        }
        #endregion
    }
}
