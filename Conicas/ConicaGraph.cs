using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Drawing.Drawing2D;
namespace Conicas
{
    public partial class ConicaGraph : MaterialForm
    {
        double[] coeficientes;
        public ConicaGraph(double[] coefientes_1)
        {
            InitializeComponent();
            this.coeficientes = coefientes_1;
        }


        // Draw the graph.
        private void btnGraph_Click(object sender, EventArgs e)
        {
            DrawGraph();
        }

        // Draw the graph.
        private void DrawGraph()
        {
            Bitmap bm = new Bitmap(
                picGraph.ClientSize.Width,
                picGraph.ClientSize.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.Clear(picGraph.BackColor);
                gr.SmoothingMode = SmoothingMode.AntiAlias;

                // Get the parameters.
                float A, B, C, D, E, F;
                try
                {


                    A = (float)-0.002936807;
                    B = (float)-0.001556237;
                    C = (float)0.008451099;
                    D = (float)0.9999999;
                    E = (float)-1.415946;
                    F = (float)-0.3586201;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading parameters.\n" + ex.Message);
                    return;
                }

                DrawConicSection(gr, A, B, C, D, E, F);
            }

            // Display the result.
            picGraph.Image = bm;
        }

        // Draw the conic section.
        private void DrawConicSection(Graphics gr,
            float A, float B, float C, float D, float E, float F)
        {
            // Get the X coordinate bounds.
            float xmin = 0;
            float xmax = xmin + picGraph.ClientSize.Width;

            // Find the smallest X coordinate with a real value.
            for (float x = xmin; x < xmax; x++)
            {
                float y = G1(x, A, B, C, D, E, F, -1f);
                if (IsNumber(y))
                {
                    xmin = x;
                    break;
                }
            }

            // Find the largest X coordinate with a real value.
            for (float x = xmax; x > xmin; x--)
            {
                float y = G1(x, A, B, C, D, E, F, -1f);
                if (IsNumber(y))
                {
                    xmax = x;
                    break;
                }
            }

            // Get points for the negative root on the left.
            List<PointF> ln_points = new List<PointF>();
            float xmid1 = xmax;
            for (float x = xmin; x < xmax; x++)
            {
                float y = G1(x, A, B, C, D, E, F, -1f);
                if (!IsNumber(y))
                {
                    xmid1 = x - 1;
                    break;
                }
                ln_points.Add(new PointF(x, y));
            }

            // Get points for the positive root on the left.
            List<PointF> lp_points = new List<PointF>();
            for (float x = xmid1; x >= xmin; x--)
            {
                float y = G1(x, A, B, C, D, E, F, +1f);
                if (IsNumber(y)) lp_points.Add(new PointF(x, y));
            }

            // Make the curves on the right if needed.
            List<PointF> rp_points = new List<PointF>();
            List<PointF> rn_points = new List<PointF>();
            float xmid2 = xmax;
            if (xmid1 < xmax)
            {
                // Get points for the positive root on the right.
                for (float x = xmax; x > xmid1; x--)
                {
                    float y = G1(x, A, B, C, D, E, F, +1f);
                    if (!IsNumber(y))
                    {
                        xmid2 = x + 1;
                        break;
                    }
                    rp_points.Add(new PointF(x, y));
                }

                // Get points for the negative root on the right.
                for (float x = xmid2; x <= xmax; x++)
                {
                    float y = G1(x, A, B, C, D, E, F, -1f);
                    if (IsNumber(y)) rn_points.Add(new PointF(x, y));
                }
            }

            // Connect curves if appropriate.
            // Connect the left curves on the left.
            if (xmin > 0) lp_points.Add(ln_points[0]);

            // Connect the left curves on the right.
            if (xmid1 < picGraph.ClientSize.Width) ln_points.Add(lp_points[0]);

            // Make sure we have the right curves.
            if (rp_points.Count > 0)
            {
                // Connect the right curves on the left.
                rp_points.Add(rn_points[0]);

                // Connect the right curves on the right.
                if (xmax < picGraph.ClientSize.Width) rn_points.Add(rp_points[0]);
            }

            // Draw the curves.
            using (Pen thick_pen = new Pen(Color.Red, 2))
            {
                thick_pen.Color = Color.Red;
                if (ln_points.Count > 1)
                    gr.DrawLines(thick_pen, ln_points.ToArray());

                thick_pen.Color = Color.Green;
                if (lp_points.Count > 1)
                    gr.DrawLines(thick_pen, lp_points.ToArray());

                thick_pen.Color = Color.Blue;
                if (rp_points.Count > 1)
                    gr.DrawLines(thick_pen, rp_points.ToArray());

                thick_pen.Color = Color.Orange;
                if (rn_points.Count > 1)
                    gr.DrawLines(thick_pen, rn_points.ToArray());
            }
        }

        // Calculate G1(x).
        // root_sign is -1 or 1.
        private float G1(float x, float A, float B, float C, float D, float E, float F, float root_sign)
        {
            float result = B * x + E;
            result = result * result;
            result = result - 4 * C * (A * x * x + D * x + F);
            result = root_sign * (float)Math.Sqrt(result);
            result = -(B * x + E) + result;
            result = result / 2 / C;

            return result;
        }

        // Return true if the number is not infinity or NaN.
        private bool IsNumber(float number)
        {
            return !(float.IsNaN(number) || float.IsInfinity(number));
        }
    }
}
