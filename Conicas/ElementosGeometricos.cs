using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conicas
{
    class ElementosGeometricos
    {
        // meu kakak
        string nomeConica;
        string[] coeficientes;// recebe a,b,c,d,e,f--> avaliemos a eq geral

        public ElementosGeometricos(string nomeConica, string[] coeficientes)
        {
            this.coeficientes = coeficientes;
            this.nomeConica = nomeConica;
            chamaElementos(nomeConica,coeficientes);
        }

        void chamaElementos(string nomeConica,string[] coeficientes)
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

            }else if(nomeConica=="parabola")
        }



    }
}
