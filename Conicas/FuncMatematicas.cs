using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Complex;

namespace Conicas
{
    class FuncMatematicas
    {
        private string Name;
        private Matrix<double> matrizG;

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
            var A = Matrix<double>.Build.DenseOfArray(new double[,]
            {
                { a, b/2, d/2 },
                { b/2, c, e/2 },
                { d/2, e/2, f },
            });
            var B = Matrix<double>.Build.DenseOfArray(new double[,]
            {
                { a, b/2, d/2 },
                { b/2, c, e/2 },
                { d/2, e/2, f },
            });
        }

    }
}
