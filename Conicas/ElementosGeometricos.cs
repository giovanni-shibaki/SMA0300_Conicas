using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        double[] coeficientes;// recebe a,b,c,d,e,f--> avaliemos a eq geral

        public ElementosGeometricos(int idConica, double[] coeficientes)
        {
            this.coeficientes = coeficientes;
            this.idConica = idConica;
        }

        public string DetalhesConicas(int idConica,double[] coeficientes)
        {
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


    }
}
