using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conicas
{
    class ElementosGeometricos
    {
        // meu kakaka
        string nomeConica;
        double[] coeficientes;// recebe a,b,c,d,e,f--> avaliemos a eq geral

        public ElementosGeometricos(string nomeConica, double[] coeficientes)
        {
            this.coeficientes = coeficientes;
            this.nomeConica = nomeConica;
            chamaElementos(nomeConica,coeficientes);
        }

        void chamaElementos(string nomeConica,double[] coeficientes)
        {
            if(nomeConica=="conjunto vazio")
            {
                
            }else if(nomeConica=="duas retas identicas")
            {
                
            }else if(nomeConica=="duas retas concorrente")
            {

            }else if(nomeConica=="duas paralelas")
            {

            }else if (nomeConica == "circulo")
            {

            }else if (nomeConica == "elipse")
            {

            }else if (nomeConica == "hiperbole")
            {

            }else if (nomeConica == "parabola")
            {

            }
        }



    }
}
