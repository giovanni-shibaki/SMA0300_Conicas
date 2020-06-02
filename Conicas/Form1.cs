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
    public partial class MainMenu : MaterialForm
    {
        double[] coeficientes = new double[6];
        public MainMenu()
        {
            InitializeComponent();
        }
        private void btnCalcula_Click(object sender, EventArgs eventArgs)
        {
            try
            {
                coeficientes[0] = double.Parse(txtA.Text);
                coeficientes[1] = double.Parse(txtB.Text);
                coeficientes[2] = double.Parse(txtC.Text);
                coeficientes[3] = double.Parse(txtD.Text);
                coeficientes[4] = double.Parse(txtE.Text);
                coeficientes[5] = double.Parse(txtF.Text);
            }
            catch (System.FormatException a)
            {
                MessageBox.Show("Erro ao processar os campos!\nMais detalhes: " + a);
            }
            FuncMatematicas funcmat = new FuncMatematicas();
            // InfoConica info = new InfoConica(nomeConica,coeficientes);
            // Infoconica.show();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            DialogResult dr = new DialogResult();
            dr = MessageBox.Show("Deseja mesmo sair?", "Projeto Cônicas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

    }
}
