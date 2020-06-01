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

        private double aL; // a'
        private double cL; // c'
        // Conforme notas de aula pag 94

        // Constructor that takes one argument:
        public FuncMatematicas()
        {
            
        }

        public string Name1 { get => Name; set => Name = value; }

        public int AddTwoNumbers(int number1, int number2)
        {
            return number1 + number2;
        }

        public void calculaH_K(double a, double b, double c, double d, double e, double f)
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

        public Vector<double> gerarEquacaoG2(double a, double b, double c, double d, double e, double f) // Gera a equação G2 com u e v conforme pag 90 das notas de aula de GA
        {
            var B = Vector<double>.Build.Dense(new double[] { a, b, c, (d*this.h)/2, (e*this.k)/2, f });
            // Função G2 do tipo a.u^2 + b.u.v + c.v^2 + dh/2 + ek/2 + f ---> Conforme Notas de Aula pag 90
            return B;
        }

        public void calculaAlCl(Vector<double> g2)
        {
            var A = Matrix<double>.Build.DenseOfArray(new double[,]
            {
                { 1/* a' */, 1/* c' */ },
                { 1/* a' */, -1/* -c' */ },
            });
            MessageBox.Show(A.ToString());
            var B = Vector<double>.Build.Dense(new double[] { (g2[0]+g2[1]), /* g2[0] = termo a de g2;  g2[2] = termo c de g2*/(g2[1]*Math.Sqrt(1 + Math.Pow( ( (g2[0]-g2[2])/g2[1]),2) ) ) });
            var x = A.Solve(B);
            MessageBox.Show("a'  e  c' : "+x.ToString());
            aL = x[0];
            cL = x[1];
        }

    }
}
