﻿using System;
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
        public InfoConica(int idConica, double[] coeficientes)
        {
            InitializeComponent();
            elementos = new ElementosGeometricos(idConica, coeficientes);
            ShowDetails(idConica, coeficientes);
        }

        void ShowDetails(int idConica, double[] coeficientes)
        {
            lblDetalhes.Text = elementos.DetalhesConicas(idConica,coeficientes);
        }

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
    }
}
