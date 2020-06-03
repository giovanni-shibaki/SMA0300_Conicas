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
using MathNet.Symbolics;
using Expr = MathNet.Symbolics.SymbolicExpression;

namespace Conicas
{
    class FuncMatematicas
    {
        private double A;
        private double B;
        private double C;
        private double D;
        private double E;
        private double F;


        private double h;
        private double k;

        private double aL; // a'
        private double cL; // c'

        private double dL; // a'
        private double eL; // c'
        // Conforme notas de aula pag 94

        // Constructor that takes one argument:

        private Vector<double> g2;
        public FuncMatematicas()
        {

        }


        public Vector<double> getVectorG2()
        {
            return this.g2;
        }
        public void setVectorG2(Vector<double> x)
        {
            this.g2 = x;
        }

        public double getA()
        {
            return this.A;
        }
        public void setA(double x)
        {
            this.A = x;
        }
        public double getB()
        {
            return this.B;
        }
        public void setB(double x)
        {
            this.B = x;
        }
        public double getC()
        {
            return this.C;
        }
        public void setC(double x)
        {
            this.C = x;
        }
        public double getD()
        {
            return this.D;
        }
        public void setD(double x)
        {
            this.D = x;
        }
        public double getE()
        {
            return this.E;
        }
        public void setE(double x)
        {
            this.E = x;
        }
        public double getF()
        {
            return this.F;
        }
        public void setF(double x)
        {
            this.F = x;
        }

        public void setH(double x)
        {
            this.h = x;
        }
        public void setK(double x)
        {
            this.k = x;
        }
        public double getH()
        {
            return this.h;
        }
        public double getK()
        {
            return this.k;
        }
        public double getAL()
        {
            return this.aL;
        }
        public double getCL()
        {
            return this.cL;
        }
        public void setAL(double x)
        {
            this.aL = x;
        }
        public void setCL(double x)
        {
            this.cL = x;
        }

        public double getDL()
        {
            return this.dL;
        }
        public double getEL()
        {
            return this.eL;
        }
        public void setDL(double x)
        {
            this.dL = x;
        }
        public void setEL(double x)
        {
            this.eL = x;
        }

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
            var A = Matrix<double>.Build.DenseOfArray(new double[,]{
                { 1/* a' */, 1/* c' */ },
                { 1/* a' */, -1/* -c' */ },
            });
            MessageBox.Show(A.ToString());
            MessageBox.Show((g2[0] + g2[2]).ToString());
            MessageBox.Show((g2[1] * Math.Sqrt(1 + Math.Pow(((g2[0] - g2[2]) / g2[1]), 2))).ToString());
            var B = Vector<double>.Build.Dense(new double[] { Convert.ToDouble(g2[0]+g2[2]), /* g2[0] = termo a de g2;  g2[2] = termo c de g2*/Convert.ToDouble(g2[1]*Math.Sqrt(1 + Math.Pow( ( (g2[0]-g2[2])/g2[1]),2) ) ) });
            var x = A.Solve(B);
            MessageBox.Show("a'  e  c' : "+x.ToString());
            aL = x[0];
            cL = x[1];
        }

        public void mostraNovaEquacao()
        {
            var s = Expr.Variable("s");
            var t = Expr.Variable("t");
            MessageBox.Show("Equação geral: " + aL + "s² + " + cL + "t² - " + aL * cL + " = 0");
            // Agora simplificar a equação
        }

    }
}
