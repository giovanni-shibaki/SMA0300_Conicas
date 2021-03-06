﻿using System;
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
    public class FuncMatematicas
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
        private double bL = (double)0;
        private double cL; // c'

        // Se não conseguir realizar a translação de primeira
        private double dL; // d'
        private double eL; // e'

        private double sen0;
        private double cos0;
        private double cotg2teta;

        // Conforme notas de aula pag 94

        // Constructor that takes one argument:

        private Vector<double> g2;
        public FuncMatematicas()
        {

        }


        #region getters and setters
        public double getSen()
        {
            return this.sen0;
        }
        public void setSen(double x)
        {
            this.sen0 = x;
        }

        public double getCotg2teta()
        {
            return this.cotg2teta;
        }
        public void setCotg2teta(double x)
        {
            this.cotg2teta = x;
        }

        public double getCos()
        {
            return this.cos0;
        }
        public void setCos(double x)
        {
            this.cos0 = x;
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
        public double getBL()
        {
            return this.bL;
        }
        public void setBL(double x)
        {
            this.bL = x;
        }
        #endregion

        public void calculaH_K(double[] coeficientes)
        {
            double a = coeficientes[0];
            double b = coeficientes[1];
            double c = coeficientes[2];
            double d = coeficientes[3];
            double e = coeficientes[4];
            double f = coeficientes[5];

            var A = Matrix<double>.Build.DenseOfArray(new double[,]
            {
                { Convert.ToInt32(a), Convert.ToInt32(b/2) },
                { Convert.ToInt32(b/2), Convert.ToInt32(c) },
            });
            MessageBox.Show("Matriz para calcular H e K: "+A.ToString());
            var B = Vector<double>.Build.Dense(new double[] { -(d/2), -(e/2) });
            var x = A.Solve(B);
            MessageBox.Show("H e K: "+x.ToString());
            h = x[0];
            k = x[1];

            if(!Double.IsInfinity(getH())) // Se o determinante deu diferente de zero foi possível realizar a translação
            {
                // Achar o novo termo independente da equação: (p.96)
                setF((getD() / 2) * getH() + (getE() / 2) * getK() + getF());

                var eq = Infix.ParseOrThrow(getA().ToString() + "*u*u+" + getB().ToString() + "*u*v+" + getC().ToString() + "*v*v+"+ getF().ToString());
                var expanded = Algebraic.Expand(eq);
                MessageBox.Show("Translação realizada!\nNova equação da cônica:\n"+Infix.FormatStrict(expanded)+" ","Translação Concluida",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                MessageBox.Show("Iniciando Rotação para elimianar o termo quadrático misto", "Iniciando Rotação", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }
        public double whole_matrix_determinant(double []coeficientes)
        {
            double a = coeficientes[0];
            double b = coeficientes[1];
            double c = coeficientes[2];
            double d = coeficientes[3];
            double e = coeficientes[4];
            double f = coeficientes[5];

            double det;
            var matriz = Matrix<double>.Build.DenseOfArray(new double[,] {
                { a, b/2, d/2 },
                { b/2, c, e/2 },
                {d/2, e/2, f }
            });
            det = matriz.Determinant();
            return det;
        }

        public double acharSolucoesSistema(double a,double b,double c)
        {
            double det;
            var matriz = Matrix<double>.Build.DenseOfArray(new double[,] {
                { a, b/2 },
                { b/2, c },
            });
            det = matriz.Determinant();
            MessageBox.Show("Valor de determinante encontrado: " + det, "Determinante", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            MessageBox.Show("Matriz para achar aL e cL:\n"+A.ToString());

            //MessageBox.Show((g2[0] + g2[2]).ToString());
            //MessageBox.Show((g2[1] * Math.Sqrt(1 + Math.Pow(((g2[0] - g2[2]) / g2[1]), 2))).ToString());
            
            var B = Vector<double>.Build.Dense(new double[] { Convert.ToDouble(g2[0]+g2[2]), /* g2[0] = termo a de g2;  g2[2] = termo c de g2*/Convert.ToDouble(g2[1]*Math.Sqrt(1 + Math.Pow( ( (g2[0]-g2[2])/g2[1]),2) ) ) });
            var x = A.Solve(B);
            MessageBox.Show("a'  e  c' : "+x.ToString());
            aL = x[0];
            cL = x[1];
        }

        public string mostraNovaEquacao()
        {
            /*var s = Expr.Variable("s");
            var t = Expr.Variable("t");*/


            //MessageBox.Show("Equação geral: " + aL + "s² + " + cL + "t² - " + aL * cL + " = 0");
            double[] num =
            {
                getAL(), getBL(), getCL(), getDL(), getEL(), getF()
            };

            double max = 0;
            for(int i=0;i<6;i++)
            {
                if(num[i]>max)
                {
                    max = num[i];
                }
            }

            long[] num2 = {
                (long)max,(long)max,(long)max,(long)max,(long)max,(long)max
            };
            int j = 0;
            for(int i=0;i<6;i++)
            {
                if(num[i]!=0)
                {
                    num2[j] = (long) num[i];
                    j++;
                }
            }
            double div = (double)Euclid.GreatestCommonDivisor(num2);
            MessageBox.Show("MMC: " + div);
            if (div != null && div != 0)
            {
                setAL(getAL() / div);
                setBL(getBL() / div);
                setCL(getCL() / div);
                setDL(getDL() / div);
                setEL(getEL() / div);
                setF(getF() / div);
            } // Simplifica a equação com o maior divisor entre eles


            var eq = Infix.ParseOrThrow(getAL().ToString() + "*u*u+" + getBL().ToString() + "*u*v+" + getCL().ToString() + "*v*v+" + getDL().ToString() + "*u+" + getEL().ToString() + "*v+"+getF().ToString());
            var expanded = Algebraic.Expand(eq);
            MessageBox.Show("Equação Geral: " + Infix.FormatStrict(expanded), "Equação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                // Agora falta simplificar a equação


            return Infix.FormatStrict(expanded).ToString();
        }

        public void calculaSenCos()
        {
            cotg2teta = (getA()-getC()) / getB();
            MessageBox.Show("Cotg2TETA: " + cotg2teta);
            double sen2teta = Math.Pow(Math.Sqrt(1 + Math.Pow((getA() - getC()) / getB(),2)), -1);
            //MessageBox.Show("Cotg2teta = " + cotg2teta);
            //MessageBox.Show("Sen2teta = " + sen2teta);
            // Calculos retirados da pag 95 das notas de aula
            double cos2teta = sen2teta * cotg2teta;
            // Calculo de cos2teta retirado da pag 99 das notas de aula
            // Portanto cos²TETA - sen²TETA = cos2teta;
            // E cos²TETA + sen²TETA = 1
            // Agora, resolver a equação e encontrar os valores de cosTETA e senTETA
            //
            // { cos²teta + sen²teta = 1
            // { cos²teta - sen²teta = cos2teta
            var A = Matrix<double>.Build.DenseOfArray(new double[,]{
                { 1/* a' */, 1/* c' */ },
                { 1/* a' */, -1/* -c' */ },
            });
            var B = Vector<double>.Build.Dense(new double[] { (double)1,cos2teta });
            var x = A.Solve(B);
            MessageBox.Show("sen²teta  e  cos²teta : " + x.ToString());
            setCos(Math.Sqrt(x[0])); // Os valores estão ao quadrado, então deve ser aplicado raiz para obter senTeta e cosTeta
            setSen(Math.Sqrt(x[1]));
        }

        public void calculaDlEl()
        {
            var A = Matrix<double>.Build.DenseOfArray(new double[,]{
                { getCos()/* a' */, getSen()/* c' */ },
                { -getSen()/* a' */, getCos()/* -c' */ },
            });
            //MessageBox.Show("sen e cos em calculaDlEl: "+A.ToString());
            var B = Vector<double>.Build.Dense(new double[] { getD(), getE() });
            var x = A.Solve(B);
            MessageBox.Show("d'  E  e' : " + x.ToString());
            setDL(getCos() * getD() + getSen() * getE());
            setEL(-getSen() * getD() + getCos() * getE());
        }

        //mostraNovaEquacao2 retorna a equação após fazer a rotação e a translação conforme o caso na pag 99 das notas de aula
        public string mostraNovaEquacao2()
        {
            // O termo independente continua o mesmo pois não foi realizada a translação
            double[] num =
            {
                getAL(), getBL(), getCL(), getDL(), getEL(), getF()
            };

            double max = 0;
            for (int i = 0; i < 6; i++)
            {
                if (num[i] > max)
                {
                    max = num[i];
                }
            }

            long[] num2 = {
                (long)max,(long)max,(long)max,(long)max,(long)max,(long)max
            };
            int j = 0;
            for (int i = 0; i < 6; i++)
            {
                if (num[i] != 0)
                {
                    num2[j] = (long)num[i];
                    j++;
                }
            }
            double div = (double)Euclid.GreatestCommonDivisor(num2);
            MessageBox.Show("MMC: "+div);
            if (div != null && div !=0)
            {
                setAL(getAL() / div);
                setBL(getBL() / div);
                setCL(getCL() / div);
                setDL(getDL() / div);
                setEL(getEL() / div);
                setF(getF() / div);
            } // Simplifica a equação com o maior divisor entre eles

            var eq = Infix.ParseOrThrow(getAL().ToString()+"*u*u+"+getBL().ToString()+"*u*v+"+getCL().ToString()+"*v*v+"+ getDL().ToString()+"*u+"+getEL().ToString()+"*v+"+getF().ToString());
            var expanded = Algebraic.Expand(eq);
            MessageBox.Show("Equação Geral: "+Infix.FormatStrict(expanded), "Equação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


            return Infix.FormatStrict(expanded).ToString();
            // B = 0
            // Agora simplificar a equação
        }

        // Reduz a equação através de um centro dado (H,K)
        // Notas de aula pág 99
        public void simplificarEq()
        {
            // Eq Geral: aV² + 0U.V + cU² + dV + eU + f
            // {v = t + h
            // {u = w + k
            // Substituir V e U na equação geral
            // Através da biblioteca Math.NET
            
            //var h1 = Infix.ParseOrThrow("(1/8)*r*t*w + (1/2)*r*t^2*w");
            //var q2 = Rational.Expand(q1);
            
        }

    }
}
