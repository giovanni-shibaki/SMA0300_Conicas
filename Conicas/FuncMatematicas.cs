using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Complex;

namespace Conicas
{
    class FuncMatematicas
    {
        private string Name;
        private Matrix<double> matrizG;
        private double h;
        private double k;

        // Constructor that takes one argument:
        public FuncMatematicas()
        {
            
        }

        public string Name1 { get => Name; set => Name = value; }

        public int AddTwoNumbers(int number1, int number2)
        {
            return number1 + number2;
        }

        public void gerarMatrizG(double a, double b, double c, double d, double e, double f)
        {
            MessageBox.Show((a-b).ToString());
            var A = Matrix<double>.Build.DenseOfArray(new double[,]
            {
                { Convert.ToInt32(a), Convert.ToInt32(b/2) },
                { Convert.ToInt32(b/2), Convert.ToInt32(c) },
            });
            MessageBox.Show(A.ToString());
            var B = Vector<double>.Build.Dense(new double[] { -(d/2), -(e/2) });
            var x = A.Solve(B);
            MessageBox.Show(x.ToString());
            h = x[0];
            k = x[1];
        }

        public double acharSolucoesSistema(double a,double b,double c)
        {
            double det;
            var matriz = Matrix<double>.Build.DenseOfArray(new double[,] {
                { a, b/2 },
                { b/2, c },
            });
            det = matriz.Determinant();
            return det;
        }



    }
}
