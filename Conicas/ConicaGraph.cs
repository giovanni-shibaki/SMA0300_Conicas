using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Conicas
{
    public partial class ConicaGraph : MaterialForm
    {
        #region Rod Stephens (the right one)
        double[] coeficientes;
        public ConicaGraph(double[] coefientes_1,string qualgrafico)
        {
            InitializeComponent();
            this.coeficientes = coefientes_1;
            lblTipoDeGrafico.Text = qualgrafico;
        }

        // Plot the equations.
        private void ConicaGraph_Load_1(object sender, EventArgs e)
        {
            // Calculating

            // Make the Bitmap.
            Bitmap bm = new Bitmap(picGraph.ClientSize.Width, picGraph.ClientSize.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                // Clear.
                gr.Clear(Color.White);

                //Rectangle rect = new Rectangle(-10, -10, 20, 20); // function scale
                Rectangle rect = new Rectangle(-5, -5, 10, 10); // function scale

                Point[] pts = new Point[]
                {
                    new Point(0, picGraph.ClientSize.Height),
                    new Point(picGraph.ClientSize.Width, picGraph.ClientSize.Height),
                    new Point(0, 0)
                };
                gr.Transform = new Matrix(rect, pts);

                // Draw axes.
                using (Pen axis_pen = new Pen(Color.Gray, 0))
                {
                    gr.DrawLine(axis_pen, -20, 0, 20, 0);
                    gr.DrawLine(axis_pen, 0, -20, 0, 20);
                    for (int i = -20; i <= 20; i++)// axis bars
                    {
                        gr.DrawLine(axis_pen, i, -0.1f, i, 0.1f);
                        gr.DrawLine(axis_pen, -0.1f, i, 0.1f, i);
                    }
                }

                // Graph the equations.
                // controls pixel density of graph
                // 100f --> less pixels than 10f
                // ATTENTION: slows proccessing down
                float dx = 10f / bm.Width;
                float dy = 10f / bm.Height;
                PlotFunction(gr, ConicSection, dx, dy);
            } // using gr.

            // Display the result.
            picGraph.Image = bm;
        }
        // The function.
        private float HeartFunc(float x, float y)
        {
            double a = x * x;
            double b = y - Math.Pow(x * x, (double)1 / 3);
            return (float)(a + b * b - 1);
        }

        // The function 2.
        private float ConicSection(float x, float y)
        {
            double a, b, c, d, e, f;

            a = coeficientes[0] * Math.Pow(x, 2); // ax^2
            b = coeficientes[1] * x * y;// bxy
            c = coeficientes[2] * Math.Pow(y, 2);
            d = coeficientes[3] * x;
            e = coeficientes[4] * y;
            f = coeficientes[5];

            return (float)(a + b + c + d + e + f);

        }



        private delegate float FofXY(float x, float y);

        // Plot a function.
        private void PlotFunction(Graphics gr, FofXY func, float dx, float dy)
        {
            // Plot the function.
            using (Pen thin_pen = new Pen(Color.Red, 0))
            {
                // Horizontal comparisons.
                for (float x = -20f; x <= 20f; x += dx)
                {
                    float last_y = func(x, -20f);
                    for (float y = -20f + dy; y <= 20f; y += dy)
                    {
                        float next_y = func(x, y);
                        if (
                            ((last_y <= 0f) && (next_y >= 0f)) ||
                            ((last_y >= 0f) && (next_y <= 0f))
                           )
                        {
                            // Plot this point.
                            gr.DrawLine(thin_pen, x, y - dy, x, y);
                        }
                        last_y = next_y;
                    }
                } // Horizontal comparisons.

                // Vertical comparisons.
                for (float y = -20f + dy; y <= 20f; y += dy)
                {
                    float last_x = func(-20f, y);
                    for (float x = -20f; x <= 20f; x += dx)
                    {
                        float next_x = func(x, y);
                        if (
                            ((last_x <= 0f) && (next_x >= 0f)) ||
                            ((last_x >= 0f) && (next_x <= 0f))
                           )
                        {
                            // Plot this point.
                            gr.DrawLine(thin_pen, x - dx, y, x, y);
                        }
                        last_x = next_x;
                    }
                } // Vertical comparisons.
            } // using thin_pen.
        }
        #endregion

      
    }

}
