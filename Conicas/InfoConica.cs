using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Conicas
{
    /*
        Aqui vamos mostrar as informacoes retornadas pela clase Elementos Geometricos
        
     */
    public partial class InfoConica : MaterialForm
    {
        enum Conicas
        {
            ConjuntoVazio,
            DuasRetasIdenticas,
            DuasRetasConcorrentes,
            DuasParalela,
            DuasParalelas,
            Circulo,
            Elipse,
            Hiperbole,
            Parabola
        }

        ElementosGeometricos elementos;
        public InfoConica(double[] coeficientes)
        {
            int idConica;
            InitializeComponent();

            elementos = new ElementosGeometricos(coeficientes);
            idConica = elementos.whatConica(coeficientes);
            ShowDetails(idConica, coeficientes);
        }

        #region Metodos
        void ShowDetails(int idConica, double[] coeficientes)
        {
           // lblDetalhes.Text = elementos.DetalhesConicas(coeficientes);
            lblClassificacao.Text = ClassConicas(idConica);
        }

        private string ClassConicas(int idConica)
        {
            switch (idConica)
            {
                case 0:
                    return "Conjunto Vazio";
                case 1:
                    return "Ponto";
                case 2:
                    return "Duas Retas Idênticas";
                case 3:
                    return "Duas Retas Paralelas";
                case 4:
                    return "Duas Retas Concorrentes";
                case 5:
                    return "Círculo";
                case 6:
                    return "Elipse";
                case 7:
                    return "Hipérbole";
                case 8:
                    return "Parábola";
            }
            return "Erro";
        }
        #endregion

        #region Eventos
        private void InfoConica_FormClosing(object sender, FormClosingEventArgs e)
        {
            var res = MessageBox.Show(this, "Deseja Realmente Sair?", "Sair",
              MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (res != DialogResult.Yes)
            {
                e.Cancel = true;
                return;
            }
        }
        #endregion

       
    }
}
