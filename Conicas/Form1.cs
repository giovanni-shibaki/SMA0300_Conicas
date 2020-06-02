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
using MathNet.Numerics.LinearAlgebra.Complex;
using MathNet.Numerics.LinearAlgebra;

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
            funcmat.calculaH_K(coeficientes[0], coeficientes[1], coeficientes[2], coeficientes[3], coeficientes[4], coeficientes[5]);
            double det = funcmat.acharSolucoesSistema(coeficientes[0], coeficientes[1], coeficientes[2]);
            // Retorna o determinante da matriz 2x2 para ver o número de soluções
            Vector<double> matrizG2 = funcmat.gerarEquacaoG2(coeficientes[0], coeficientes[1], coeficientes[2], coeficientes[3], coeficientes[4], coeficientes[5]);

            funcmat.calculaAlCl(matrizG2);

            funcmat.mostraNovaEquacao();
            // InfoConica info = new InfoConica(nomeConica,coeficientes);
            // Infoconica.show();
        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
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
