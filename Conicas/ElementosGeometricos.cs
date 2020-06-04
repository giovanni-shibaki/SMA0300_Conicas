﻿using System;
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

        public int whatConica(double[] coeficientes)
        {
        
            double big_det = funcMat.whole_matrix_determinant(coeficientes);
            double det = funcMat.acharSolucoesSistema(coeficientes[0], coeficientes[1], coeficientes[2]);
            funcMat.calculaH_K(coeficientes);

            this.h = funcMat.getH();
            this.k = funcMat.getK();

            // Conicas com centro unico
            
            if (big_det != 0)
            {
                // conj vazio
                if(coeficientes[0]==coeficientes[1] && coeficientes[5] == coeficientes[0]) { return 0; }
                // ponto
                if (det==0 && coeficientes[0] == coeficientes[1] && coeficientes[5] == 0) { return 1; }

                // circ
                if (coeficientes[0] == coeficientes[2] && coeficientes[1] == 0) { return 5; }
                // elipse
                else if (det > 0) { return 6; }
                //Hiperbole
                else if (det < 0) { return 7; }
                // parabola
                else if (det == 0) { return 8; }
                //Retas Concorrentes: se x^2 e y^2 tem coeficientes opostos,entao temos 
                //else if (coeficientes[0] > 0 && coeficientes[1] < 0 || coeficientes[0] > 0 && coeficientes[1] < 0) { return 4; }
                //Ponto: se x^2 e y^2 sao positivos e nao temos f
                if (coeficientes[5] == 0 && coeficientes[0] > 0 && coeficientes[1] > 0) { return 1; }
            }
            else if (big_det == 0)
            {
                //  Conicas com centros infinitos ou conicas sem centro

                // se o sistema de h e k da SPI
                if (Double.IsInfinity(h) && Double.IsInfinity(k))
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
                }
                else if (Double.IsNaN(h) && Double.IsNaN(k))
                {
                    return 8;
                }
            }
                      
            return -1;// ERRO
        }

        #region detalhes de cada conica
        private string DetalhesParabol(double[] coeficientes)
        {
            //
            throw new NotImplementedException();
        }

        private string DetalhesHiperbole(double[] coeficientes)
        {
            // diretriz, focos, assintotas
            throw new NotImplementedException();
        }

        private string DetalhesElipse(double[] coeficientes)
        {
            // focos, vertices, excentricidade
            throw new NotImplementedException();
        }

        private string DetalhesCirc(double[] coeficientes)
        {
            //raio, centro.
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
            string detalhes = "Temos duas retas identicas, isto é, paralelas e coicidentes";
            return detalhes;
        }

        string DetalhesConjVazio(double[] coeficientes)
        {
            string detalhes="Conjunto Vazio";
            return detalhes;
        }
        #endregion

    }
}
