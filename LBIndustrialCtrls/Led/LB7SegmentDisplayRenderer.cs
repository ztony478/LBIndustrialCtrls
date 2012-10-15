/*---------------------------------------------------------------------------
 * File: LBLed.cs
 * Utente: lucabonotto
 * Date: 05/04/2009
 *-------------------------------------------------------------------------*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using LBSoft.IndustrialCtrls.Base;

using LBSoft.IndustrialCtrls.Utils;

namespace LBSoft.IndustrialCtrls.Leds
{
	/// <summary>
	/// Description of LB7SegmentDisplayRenderer.
	/// </summary>
	public class LB7SegmentDisplayRenderer : LBRendererBase
    {
        #region (* Constants *)
        public const int WIDTH_PIXEL     = 11;
        public const int HEIGHT_PIXELS   = 18;
        #endregion

        #region (* Variables *)
        /// <summary>
        /// Segments data array
        /// </summary>
        protected SegmentDictionary segments = new SegmentDictionary();
        /// <summary>
        /// Defaults points coordinates
        /// </summary>
        protected PointsList defPoints = new PointsList();
        /// <summary>
        /// List of the points coordinates
        /// </summary>
        protected PointsList points = new PointsList();
        /// <summary>
        /// Segments list of a value
        /// </summary>
        protected SegmentsValueDictionary valuesSegments = new SegmentsValueDictionary();
        /// <summary>
        /// Rectangle of the dp
        /// </summary>
        protected RectangleF rectDP = new RectangleF();
        #endregion

        #region (* Contructor *)
        public LB7SegmentDisplayRenderer()
		{
            this.CreateSegmetsData();
            this.CreateDefPointsCoordinates();
            this.CreateSegmentsValuesList();
            this.UpdatePointsCoordinates();
        }
        #endregion

        #region (* Overrided methods *)
        public override bool Update()
        {
            this.UpdatePointsCoordinates();
            return true;
        }

        public override void Draw(Graphics Gr)
        {
            if (Gr == null)
                throw new ArgumentNullException("Gr");

            LB7SegmentDisplay ctrl = this.Display;
            if (ctrl == null)
                throw new NullReferenceException("Associated control is not valid");

            RectangleF _rc = new RectangleF(0, 0, ctrl.Width, ctrl.Height);
			Gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
		
            this.DrawBackground(Gr, _rc);
            this.DrawOffSegments(Gr, _rc);
            this.DrawValue(Gr, _rc);
        }
        #endregion

        #region (* Properies *)
        [Browsable(false)]
        public LB7SegmentDisplay Display
		{
			set { this.Control = value; }
            get { return this.Control as LB7SegmentDisplay; }
		}

        [Browsable(false)]
        public SegmentDictionary Segments
        {
            get { return this.segments; }
        }
        #endregion

        #region (* Virtual methods *)
        /// <summary>
        /// Creation of the default points list of the
        /// all segments
        /// </summary>
        protected virtual void CreateDefPointsCoordinates()
        {
            PointF pt = new PointF(3F, 1F);
            this.defPoints.Add(pt);
            pt = new PointF(8F, 1F);
            this.defPoints.Add(pt);
            pt = new PointF(9F, 2F);
            this.defPoints.Add(pt);
            pt = new PointF(10F, 3F);
            this.defPoints.Add(pt);
            pt = new PointF(10F, 8F);
            this.defPoints.Add(pt);
            pt = new PointF(9F, 9F);
            this.defPoints.Add(pt);
            pt = new PointF(10F, 10F);
            this.defPoints.Add(pt);
            pt = new PointF(10F, 15F);
            this.defPoints.Add(pt);
            pt = new PointF(9F, 16F);
            this.defPoints.Add(pt);
            pt = new PointF(8F, 17F);
            this.defPoints.Add(pt);
            pt = new PointF(3F, 17F);
            this.defPoints.Add(pt);
            pt = new PointF(2F, 16F);
            this.defPoints.Add(pt);
            pt = new PointF(1F, 15F);
            this.defPoints.Add(pt);
            pt = new PointF(1F, 10F);
            this.defPoints.Add(pt);
            pt = new PointF(2F, 9F);
            this.defPoints.Add(pt);
            pt = new PointF(1F, 8F);
            this.defPoints.Add(pt);
            pt = new PointF(1F, 3F);
            this.defPoints.Add(pt);
            pt = new PointF(2F, 2F);
            this.defPoints.Add(pt);
            pt = new PointF(3F, 3F);
            this.defPoints.Add(pt);
            pt = new PointF(8F, 3F);
            this.defPoints.Add(pt);
            pt = new PointF(8F, 8F);
            this.defPoints.Add(pt);
            pt = new PointF(8F, 10F);
            this.defPoints.Add(pt);
            pt = new PointF(8F, 15F);
            this.defPoints.Add(pt);
            pt = new PointF(3F, 15F);
            this.defPoints.Add(pt);
            pt = new PointF(3F, 10F);
            this.defPoints.Add(pt);
            pt = new PointF(3F, 8F);
            this.defPoints.Add(pt);
        }

        /// <summary>
        /// Create the dictionary of the
        /// segment coordinates
        /// </summary>
        protected virtual void CreateSegmetsData()
        {
            this.Segments.Clear();

            Segment s = new Segment();
            s.PointsIndexs[0] = 0;
            s.PointsIndexs[1] = 1;
            s.PointsIndexs[2] = 2;
            s.PointsIndexs[3] = 19;
            s.PointsIndexs[4] = 18;
            s.PointsIndexs[5] = 17;
            this.Segments.Add('A', s);

            s = new Segment();
            s.PointsIndexs[0] = 2;
            s.PointsIndexs[1] = 3;
            s.PointsIndexs[2] = 4;
            s.PointsIndexs[3] = 5;
            s.PointsIndexs[4] = 20;
            s.PointsIndexs[5] = 19;
            this.Segments.Add('B', s);

            s = new Segment();
            s.PointsIndexs[0] = 6;
            s.PointsIndexs[1] = 7;
            s.PointsIndexs[2] = 8;
            s.PointsIndexs[3] = 22;
            s.PointsIndexs[4] = 21;
            s.PointsIndexs[5] = 5;
            this.Segments.Add('C', s);

            s = new Segment();
            s.PointsIndexs[0] = 9;
            s.PointsIndexs[1] = 10;
            s.PointsIndexs[2] = 11;
            s.PointsIndexs[3] = 23;
            s.PointsIndexs[4] = 22;
            s.PointsIndexs[5] = 8;
            this.Segments.Add('D', s);

            s = new Segment();
            s.PointsIndexs[0] = 12;
            s.PointsIndexs[1] = 13;
            s.PointsIndexs[2] = 14;
            s.PointsIndexs[3] = 24;
            s.PointsIndexs[4] = 23;
            s.PointsIndexs[5] = 11;
            this.Segments.Add('E', s);

            s = new Segment();
            s.PointsIndexs[0] = 15;
            s.PointsIndexs[1] = 16;
            s.PointsIndexs[2] = 17;
            s.PointsIndexs[3] = 18;
            s.PointsIndexs[4] = 25;
            s.PointsIndexs[5] = 14;
            this.Segments.Add('F', s);

            s = new Segment();
            s.PointsIndexs[0] = 25;
            s.PointsIndexs[1] = 20;
            s.PointsIndexs[2] = 5;
            s.PointsIndexs[3] = 21;
            s.PointsIndexs[4] = 24;
            s.PointsIndexs[5] = 14;
            this.Segments.Add('G', s);
        }

        /// <summary>
        /// Create the dictionary of the segments
        /// for the number values
        /// </summary>
        protected virtual void CreateSegmentsValuesList()
        {
            SegmentsList list = new SegmentsList();
            list.Add('A');
            list.Add('B');
            list.Add('C');
            list.Add('D');
            list.Add('E');
            list.Add('F');
            this.valuesSegments.Add(0, list);

            list = new SegmentsList();
            list.Add('B');
            list.Add('C');
            this.valuesSegments.Add(1, list);

            list = new SegmentsList();
            list.Add('A');
            list.Add('B');
            list.Add('G');
            list.Add('E');
            list.Add('D');
            this.valuesSegments.Add(2, list);

            list = new SegmentsList();
            list.Add('A');
            list.Add('B');
            list.Add('G');
            list.Add('C');
            list.Add('D');
            this.valuesSegments.Add(3, list);

            list = new SegmentsList();
            list.Add('F');
            list.Add('G');
            list.Add('B');
            list.Add('C');
            this.valuesSegments.Add(4, list);

            list = new SegmentsList();
            list.Add('A');
            list.Add('F');
            list.Add('G');
            list.Add('C');
            list.Add('D');
            this.valuesSegments.Add(5, list);

            list = new SegmentsList();
            list.Add('A');
            list.Add('F');
            list.Add('G');
            list.Add('C');
            list.Add('D');
            list.Add('E');
            this.valuesSegments.Add(6, list);

            list = new SegmentsList();
            list.Add('A');
            list.Add('B');
            list.Add('C');
            this.valuesSegments.Add(7, list);

            list = new SegmentsList();
            list.Add('A');
            list.Add('B');
            list.Add('C');
            list.Add('D');
            list.Add('E');
            list.Add('F');
            list.Add('G');
            this.valuesSegments.Add(8, list);

            list = new SegmentsList();
            list.Add('A');
            list.Add('B');
            list.Add('C');
            list.Add('D');
            list.Add('F');
            list.Add('G');
            this.valuesSegments.Add(9, list);

            list = new SegmentsList();
            list.Add('G');
            this.valuesSegments.Add((int)'-', list);

            list = new SegmentsList();
            list.Add('A');
            list.Add('D');
            list.Add('E');
            list.Add('F');
            list.Add('G');
            this.valuesSegments.Add((int)'E', list);
        }

        /// <summary>
        /// Calculate the points coordinates for drawing
        /// with the ratio of the control
        /// </summary>
        protected virtual void UpdatePointsCoordinates()
        {
            this.points.Clear();

            double rappW = 1;
            double rappH = 1;

            if (this.Display != null)
            {
                rappW = (double)this.Display.Width / (double)WIDTH_PIXEL;
                rappH = (double)this.Display.Height / (double)HEIGHT_PIXELS;
            }

            for (int idx = 0; idx < this.defPoints.Count; idx++)
            {
                PointF ptDef = this.defPoints[idx];
                PointF pt = new PointF((float)((double)ptDef.X * rappW), (float)((double)ptDef.Y * rappH));
                this.points.Add ( pt );
            }

            this.rectDP.X = this.points[7].X - (float)(0.5 * rappW);
            this.rectDP.Y = this.points[8].Y;
            this.rectDP.Width = (float)rappW;
            this.rectDP.Height = (float)rappH;                 
        }

        /// <summary>
        /// Draw the control background
        /// </summary>
        /// <param name="gr"></param>
        /// <param name="rc"></param>
        /// <returns></returns>
        protected virtual bool DrawBackground(Graphics gr, RectangleF rc)
        {
            if (this.Display == null)
                return false;

            Color c = this.Display.BackColor;
            SolidBrush br = new SolidBrush(c);
            Pen pen = new Pen(c);

            Rectangle _rcTmp = new Rectangle(0, 0, this.Display.Width, this.Display.Height);
            gr.DrawRectangle(pen, _rcTmp);
            gr.FillRectangle(br, rc);

            br.Dispose();
            pen.Dispose();

            return true;
        }

        /// <summary>
        /// Draw all the segments in the off state
        /// </summary>
        /// <param name="gr"></param>
        /// <param name="rc"></param>
        /// <returns></returns>
        protected virtual bool DrawOffSegments(Graphics gr, RectangleF rc)
        {
            if (this.Display == null)
                return false;

//            SolidBrush br = new SolidBrush(LBColorManager.StepColor(this.Display.ForeColor, 30));
            Color clr = Color.FromArgb(70, this.Display.ForeColor);
            SolidBrush br = new SolidBrush(clr);

            foreach (Segment seg in this.Segments.Values)
            {
                GraphicsPath pth = new GraphicsPath();

                for (int idx = 0; idx < seg.PointsIndexs.Length - 1; idx++)
                {
                    PointF pt1 = this.points[seg.PointsIndexs[idx]];
                    PointF pt2 = this.points[seg.PointsIndexs[idx + 1]];
                    pth.AddLine(pt1, pt2);
                }
                pth.CloseFigure();

                gr.FillPath(br, pth);

                pth.Dispose();
            }

            gr.FillEllipse(br, this.rectDP);

            br.Dispose();
            return true;
        }

        /// <summary>
        /// Draw the segments in on state
        /// </summary>
        /// <param name="gr"></param>
        /// <param name="rc"></param>
        /// <returns></returns>
        protected virtual bool DrawValue(Graphics gr, RectangleF rc)
        {
            if (this.Display == null)
                return false;

            if (this.valuesSegments.Contains(this.Display.Value) == false)
                return false;

            SegmentsList list = this.valuesSegments[this.Display.Value];
            if (list == null)
                return false;

            SolidBrush br = new SolidBrush(this.Display.ForeColor);

            foreach (char ch in list)
            {
                Segment seg = this.segments[ch];
                if (seg != null)
                {
                    GraphicsPath pth = new GraphicsPath();

                    for (int idx = 0; idx < seg.PointsIndexs.Length - 1; idx++)
                    {
                        PointF pt1 = this.points[seg.PointsIndexs[idx]];
                        PointF pt2 = this.points[seg.PointsIndexs[idx + 1]];
                        pth.AddLine(pt1, pt2);
                    }
                    pth.CloseFigure();

                    gr.FillPath(br, pth);

                    pth.Dispose();
                }
            }

            if (this.Display.ShowDP != false)
                gr.FillEllipse(br, this.rectDP);

            br.Dispose();

            return true;
        }
        #endregion
    }

    /// <summary>
    /// Dictionary for the segment associated
    /// to the number
    /// </summary>
    public class SegmentDictionary : DictionaryBase
    {
        public Segment this[char ch]
        {
            set
            {
                if (Dictionary.Contains(ch) == false)
                    this.Add(ch, value);
                else
                    Dictionary[ch] = value;
            }
            get
            {
                if (Dictionary.Contains(ch) == false)
                    return null;

                return (Segment)this.Dictionary[ch];
            }
        }

        public void Add(char ch, Segment seg)
        {
            if (this.Contains(ch) == false)
                this.Dictionary.Add(ch, seg);
            else
                this[ch] = seg;
        }

        public bool Contains(char ch)
        {
            return this.Dictionary.Contains(ch);
        }

        public ICollection Values
        {
            get { return this.Dictionary.Values; }
        }

        public ICollection Keys
        {
            get { return this.Dictionary.Keys; }
        }
    }

    /// <summary>
    /// Class for the segment data
    /// </summary>
    public class Segment
    {
        private int[] points = new int[6];
        public Segment()
        {
        }

        public int[] PointsIndexs
        {
            get { return this.points; }
        }
    }

    /// <summary>
    /// Points list
    /// </summary>
    public class PointsList : List<PointF>
    {
        public PointsList()
        {
        }
    }

    /// <summary>
    /// Segments list
    /// </summary>
    public class SegmentsList : List<char>
    {
        public SegmentsList()
        {
        }
    }

    /// <summary>
    /// Dictionary for value to segments
    /// </summary>
    public class SegmentsValueDictionary : DictionaryBase
    {
        public SegmentsList this[int num]
        {
            set
            {
                if (Dictionary.Contains(num) == false)
                    this.Add(num, value);
                else
                    Dictionary[num] = value;
            }
            get
            {
                if (Dictionary.Contains(num) == false)
                    return null;

                return (SegmentsList)this.Dictionary[num];
            }
        }

        public void Add(int num, SegmentsList seg)
        {
            if (this.Contains(num) == false)
                this.Dictionary.Add(num, seg);
            else
                this[num] = seg;
        }

        public bool Contains(int ch)
        {
            return this.Dictionary.Contains(ch);
        }

        public ICollection Values
        {
            get { return this.Dictionary.Values; }
        }

        public ICollection Keys
        {
            get { return this.Dictionary.Keys; }
        }
    }
}
