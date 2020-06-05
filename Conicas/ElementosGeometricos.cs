using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Complex;
using MathNet.Numerics.Optimization;
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
            funcMat.calculaH_K(coeficientes);
        }

        

        public int whatConica(double[] coeficientes)
        {
            // determinante da matrix de coeficientes 3x3
            double big_det = funcMat.whole_matrix_determinant(coeficientes);
            // determinante da matriz "minor" 2x2 formada por a,b,c
            double det = funcMat.acharSolucoesSistema(coeficientes[0], coeficientes[1], coeficientes[2]);
            
            //  Conica nao degenerada: tem conicas com centro unico
            if (big_det != 0)
            {
                // conjunto vazio nos Reais   --> (A+C)*big_det > 0            
                if ((coeficientes[0] + coeficientes[2]) * big_det > 0) { return 0; }
                // circ
                else if (coeficientes[0] == coeficientes[2] && coeficientes[1] == 0) { return 5; }
                // elipse
                else if (det > 0) { return 6; }
                //Hiperbole
                else if (det < 0) { return 7; }
                // parabola
                else if (det == 0) { return 8; }
            }
            //  Conicas Degeneradas
            else if (big_det == 0)
            {
                // ponto 
                if (det > 0) { return 1; }
                // retas concorrentes
                else if (det < 0) { return 4; }
                // retas paralelas
                else if (det == 0)
                {
                    // D^2 + E^2 > 4(A+C)F
                    // distintas se
                    if ((Math.Pow(coeficientes[3], 2) + Math.Pow(coeficientes[3], 2)) > 4 * (coeficientes[0] + coeficientes[2]) * coeficientes[5])
                    {
                        return 3;
                    }
                    // coincidentes se
                    else if ((Math.Pow(coeficientes[3], 2) + Math.Pow(coeficientes[3], 2)) == 4 * (coeficientes[0] + coeficientes[2]) * coeficientes[5])
                    {
                        return 2;
                    }
                }
            }
            return -1;// ERRO
        }

        #region Auxiliary Methods
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
        #endregion

        #region detalhes de cada conica
        private string DetalhesParabol(double[] coeficientes)
        {
            string detalhes=null;

            // C(X,Y)
            double h = funcMat.getH();
            double k = funcMat.getK();

            double p;
            // vamos verificar onde esta o eixo da parabola

            // se temos coeficiente de x^2, eixo de simetria em y
            if (coeficientes[0] != 0)
            {
                p = -(coeficientes[4]);
                detalhes= "\nFoco: F(" + h + "," + (k+p) + ")\n";
                detalhes += "\nDiretriz r: y=" + (-p);
                detalhes += "\n Parametro: p=" + p;
            }
            // se temos coeficiente de y^2, eixo de simetria em x
            else if (coeficientes[2] != 0)
            {
                p = -(coeficientes[3]);
                detalhes = "\nFoco: F(" + (h+p) + "," + k  + ")\n";
                detalhes += "\nDiretriz r: x=" + (-p);
                detalhes += "\n Parametro: p=" + p;
                //detalhes += "\n Eixo: ";
            }

            return detalhes;
        }

        private string DetalhesHiperbole(double[] coeficientes)
        {
            // C(X,Y)
            double X = funcMat.getH();
            double Y = funcMat.getK();
            double a = 0; // semi-eixo maior
            double b = 0; // semi-eixo menor
            double c = 0; // semi distancia focal
            // Centro
            string detalhes = "\nCentro: C(" + X + "," + Y + ")\n";
            // excentricidade
            double exct;
            // verificando onde esta o eixo maior

            // os focos da hiperbole estarao no eixo X se
            if (Math.Abs(coeficientes[0]) > Math.Abs(coeficientes[2]))
            {
                a = Math.Sqrt(Math.Abs(coeficientes[0]));
                b = Math.Sqrt(Math.Abs(coeficientes[2]));
                c = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));

                // excentricidade
                exct = c / a;
                detalhes += "Excentricidade: " + exct;

                // Focos
                detalhes += "Focos:  F1(" + X + "," + (c + Y) + ") e" + "F2(" + X + ", -" + (c + Y) + ")";

                // Vertices
                detalhes += "Vertices:  V1(" + X + "," + (a + Y) + ") e" + "V2(" + X + ", -" + (a + Y) + ")";

                // Assintotas
                detalhes += "\nAssintotas: y= +" + b + "/" + a + "x ou y= -" + b + "/" + a + "x";
            }
            // os focos da hiperbole estarao no eixo Y se
            if (Math.Abs(coeficientes[0]) < Math.Abs(coeficientes[2]))
            {
                a = Math.Sqrt(Math.Abs(coeficientes[2]));
                b = Math.Sqrt(Math.Abs(coeficientes[0]));
                c = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));

                // excentricidade
                exct = c / a;
                detalhes += "Excentricidade: " + exct;

                // Focos
                detalhes += "\nFocos:  F1(" + (c + X) + "," + Y + ") e " + "F2( -" + (c + X) + ", " + Y + ")";

                // Vertices
                detalhes += "\nVertices:  V1(" + (a + X) + "," + Y + ") e " + "V2( -" + (a + X) + "," + Y + ")";

                // Assintotas
                detalhes += "\nAssintotas: y= +" + b + "/" + a + "x ou y= -" + b + "/" + a + "x";
            }
            return detalhes;
        }

        private string DetalhesElipse(double[] coeficientes)
        {
            // C(X,Y)
            double X = funcMat.getH();
            double Y = funcMat.getK();

            // excentricidade
            double exct; 
            string detalhes ="\nCentro: C(" + X + "," + Y + ")\n";

            // verificando onde esta o eixo maior
            double a = 0; // semi-eixo maior
            double b = 0; // semi-eixo menor
            double c = 0;  // semi distancia focal

            // elipse estara deitada no eixo Y, pois b>a
            if (coeficientes[0] > coeficientes[2])
            {
                a = Math.Sqrt(coeficientes[0]);
                b = Math.Sqrt(coeficientes[2]);
                c = Math.Sqrt(Math.Pow(a, 2) - Math.Pow(b, 2));

                // excentricidade
                exct = c / a;
                detalhes += "Excentricidade: " + exct;
                // Focos
                detalhes += "Focos:  F1(" + X + "," + (c + Y) + ") e" + "F2(" + X + ", -" + (c + Y) + ")";

                // Vertices
                detalhes += "Vertices:  V1(" + X + "," + (a + Y) + ") e" + "V2(" + X + ", -" +(a + Y)  + ")";

            }
            // elipse estara deitada no eixo X, pois a>b
            else if (coeficientes[0] < coeficientes[2])
            {
                a = Math.Sqrt(coeficientes[2]);
                b = Math.Sqrt(coeficientes[0]); 
                c = Math.Sqrt(Math.Pow(a,2)- Math.Pow(b, 2));

                // excentricidade
                exct = c /a;
                detalhes += "Excentricidade: " + exct;
                // Focos
                detalhes += "\nFocos:  F1(" + (c+X) + "," + Y + ") e " + "F2( -" + (c+X) + ", " + Y + ")";

                // Vertices
                detalhes += "\nVertices:  V1(" + (a+X) + "," + Y + ") e " + "V2( -" + (a + X) + "," + Y + ")";
            }
            return detalhes;
        }

        // como extrair raio ??
        private string DetalhesCirc(double[] coeficientes)
        {
            // coordenadas do centro
            double h = funcMat.getH();
            double k = funcMat.getK();
            // coordenadas de dx e ey
            double x = funcMat.getAL();
            double y = funcMat.getCL();

            double raio = Math.Sqrt(Math.Pow(h-x, 2)+Math.Pow(k-y,2));
            double diametro = 2 * raio;
            double comprimento = 2 * Math.PI * raio;
            double area = Math.PI * Math.Pow(raio, 2);
            
            //raio, centro, diametro, comprimento
            string detalhes = "Centro: C(" + h + "," + k + ")\nRaio:  "+raio+"\nDiametro: "+diametro+ "\nComprimento: "+comprimento+"\nArea: "+area;
            return detalhes;
        }
        
        private string DetalhesRetConc(double[] coeficientes)
        {
            double X = funcMat.getH();
            double Y = funcMat.getK();
            string detalhes = "As retas se intersseccionam em apenas um ponto P(" + X + "," + Y + ")";
            return detalhes;
        }

        private string DetalhesRetParal(double[] coeficientes)
        {
            string detalhes = "Não há ponto em comum entre elas.";
            return detalhes;
        }

        private string DetalhesPonto(double[] coeficientes)
        {
            double X = funcMat.getH();
            double Y = funcMat.getK();
            string detalhes = "P(" + X + "," + Y + ")";
            return detalhes;
        }

        private string DetalhesRetIdentica(double[] coeficientes)
        {
            string detalhes = "Temos duas retas identicas, isto é, paralelas e coicidentes";
            return detalhes;
        }

        string DetalhesConjVazio(double[] coeficientes)
        {
            string detalhes = "Nao existe no conjunto dos Numeros Reais pontos no plano que satisfaçam essa equação!";
            return detalhes;
        }
    }
    #endregion

}       
