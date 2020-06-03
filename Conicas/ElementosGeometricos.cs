using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Complex;
using MathNet.Symbolics;
using Expr = MathNet.Symbolics.SymbolicExpression;
namespace Conicas
{
    class ElementosGeometricos
    {
        enum Conicas
        {
            ConjuntoVazio,
            Ponto,
            DuasRetasIdenticas,
            DuasRetasParalela,
            DuasRetasConcorrentes,
            Circulo,
            Elipse,
            Hiperbole,
            Parabola
        }
        // meu kakaka
        int idConica;
        double h, k;
        double[] coeficientes;// recebe a,b,c,d,e,f--> avaliemos a eq geral
        FuncMatematicas funcMat;
        public ElementosGeometricos(double[] coeficientes)
        {
            this.coeficientes = coeficientes;
            funcMat = new FuncMatematicas();
        }

        public int whatConica(double[] coeficientes)
        {
            double det = funcMat.acharSolucoesSistema(coeficientes[0], coeficientes[1], coeficientes[2]);
            funcMat.calculaH_K(coeficientes[0],coeficientes[1],coeficientes[2],coeficientes[3],coeficientes[4],coeficientes[5]);

            this.h = funcMat.getH();
            this.k = funcMat.getK();

            // Conicas com centro unico
            if (det != 0)
            {
                // se nao tem termo independente
                // se f = 1: hiperbole ou elipse
                if (coeficientes[5] == 1)
                {
                    // se x^2 e x^2 sao positivos, temos elipse
                    if(coeficientes[0]>0 && coeficientes[1] > 0) { return 6; }
                    // se x^2 e y^2 tem sinais contrarios, temos hiperbole
                    if(coeficientes[0]>0 && coeficientes[1]<0 || coeficientes[0] > 0 && coeficientes[1] < 0) { return 7; }
                }
                // se f<0 e x^2>0 e y^2>0, pode ser uma circunferencia
                if (coeficientes[5] < 0 && coeficientes[0]>0 && coeficientes[1] > 0)
                {
                    return 5;
                }
                // se x^2 e y^2 tem coeficientes opostos,entao temos retas concorrentes
                if(coeficientes[0] > 0 && coeficientes[1] < 0 || coeficientes[0] > 0 && coeficientes[1] < 0) { return 4; }
                
                // se x^2 e y^2 sao positivos e nao temos f, temos um ponto  
                if (coeficientes[5] == 0 && coeficientes[0] > 0 && coeficientes[1] > 0) { }

                // Conicas com centros infinitos ou conicas sem centro
            }
            else if (det == 0)
            {   
                // se o sistema de h e k da SPI
                if(Double.IsInfinity(h) && Double.IsInfinity(k))
                {
                    // se temos um f, ele 'e o coeficiente linear da reta: retas paralelas
                    if (coeficientes[5] != 0)
                    {
                        return 3;
                    }
                    // senao, sao retas identicas
                    else
                    {
                        return 2;
                    }
                }else if(Double.IsNaN(h) && Double.IsNaN(k))
                {
                    return 8;
                }
            }
            return -1;
        }

        public string DetalhesConicas(double[] coeficientes)
        {
            idConica = whatConica(coeficientes);
            Conicas selection = (Conicas)idConica;

            switch (selection)
            {
                case Conicas.ConjuntoVazio:
                    return DetalhesConjVazio(coeficientes);

                case Conicas.Ponto:
                    return DetalhesPonto(coeficientes);

                case Conicas.DuasRetasIdenticas:
                    return DetalhesRetIdentica(coeficientes);

                case Conicas.DuasRetasParalela:
                    return DetalhesRetParal(coeficientes);

                case Conicas.DuasRetasConcorrentes:
                    return DetalhesRetConc(coeficientes);

                case Conicas.Circulo:
                    return DetalhesCirc(coeficientes);

                case Conicas.Elipse:
                    return DetalhesElipse(coeficientes);

                case Conicas.Hiperbole:
                    return DetalhesHiperbole(coeficientes);

                case Conicas.Parabola:
                    return DetalhesParabol(coeficientes);

            }
            return "Erro";
        }

        #region detalhes de cada conica
        private string DetalhesParabol(double[] coeficientes)
        {
            throw new NotImplementedException();
        }

        private string DetalhesHiperbole(double[] coeficientes)
        {
            throw new NotImplementedException();
        }

        private string DetalhesElipse(double[] coeficientes)
        {
            throw new NotImplementedException();
        }

        private string DetalhesCirc(double[] coeficientes)
        {
            throw new NotImplementedException();
        }

        private string DetalhesRetConc(double[] coeficientes)
        {
            throw new NotImplementedException();
        }

        private string DetalhesRetParal(double[] coeficientes)
        {
            throw new NotImplementedException();
        }

        private string DetalhesPonto(double[] coeficientes)
        {
            int X=0,Y=0;
            string detalhes = "P("+X+","+Y+")";
            return detalhes;
        }

        private string DetalhesRetIdentica(double[] coeficientes)
        {
            throw new NotImplementedException();
        }

        string DetalhesConjVazio(double[] coeficientes)
        {
            string detalhes="Conjunto Vazio";
            return detalhes;
        }
        #endregion

    }
}
