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
            FuncMatematicas funcmat = new FuncMatematicas();
            try
            {
                coeficientes[0] = double.Parse(txtA.Text);
                coeficientes[1] = double.Parse(txtB.Text);
                coeficientes[2] = double.Parse(txtC.Text);
                coeficientes[3] = double.Parse(txtD.Text);
                coeficientes[4] = double.Parse(txtE.Text);
                coeficientes[5] = double.Parse(txtF.Text);
                funcmat.setA(coeficientes[0]);
                funcmat.setB(coeficientes[1]);
                funcmat.setC(coeficientes[2]);
                funcmat.setD(coeficientes[3]);
                funcmat.setE(coeficientes[4]);
                funcmat.setF(coeficientes[5]);

                lblEquacaoAtual.Text = printEqAtual(coeficientes);
                ConicaGraph conica = new ConicaGraph(coeficientes);
                conica.Show();
            }
            catch (System.FormatException a)
            {
                MessageBox.Show("Erro ao processar os campos!\nMais detalhes: " + a);
            }

            bool translacao = true;

            funcmat.calculaH_K(coeficientes);
            double det = funcmat.acharSolucoesSistema(coeficientes[0], coeficientes[1], coeficientes[2]);
            // Retorna o determinante da matriz 2x2 para ver o número de soluções
            // Se det !=0 -> Pode ser um ponto, circulo, elipse, hibérbole ou união de duas retas concorrentes

            // Se det = 0 -> 2 Casos
            //      Se H_K for SPI -> 2 retas idênticas
            //      Se H_K for SI -> Parábola ou conjunto vazio


            // Se det !=0 e H_K é SI não da pra fazer a translação H e K = INFINITO
            // G2 é a equação geral sem os termos lineares (ainda com o misto)
            Vector<double> matrizG2 = funcmat.gerarEquacaoG2(coeficientes[0], coeficientes[1], coeficientes[2], coeficientes[3], coeficientes[4], coeficientes[5]);

            // Com G2 é deve ser feita a rotação para eliminar o termo misto (SE HOUVER -> CHECAR PRIMEIRO)
            funcmat.calculaAlCl(matrizG2);

            if (det==0 && Double.IsInfinity(funcmat.getH()))
            {
                // Não existe uma translação que pode eliminar os termos lineares
                // Mas sempre existe uma rotação que elimina o termo quadrático misto
                translacao = false;
                MessageBox.Show("Não deu pra fazer translação :(");

                // Já achou aL e cL, agora falta dL e eL (Através de seno e cosseno)
                funcmat.calculaSenCos();
                funcmat.calculaDlEl();
                Vector<double> matrizG3 = funcmat.gerarEquacaoG2(funcmat.getAL(),(double) 0, funcmat.getCL(), funcmat.getDL(), funcmat.getEL(), coeficientes[5]);
                funcmat.mostraNovaEquacao2();
                // Agora falta realizar a translação
            }
            else
            {
                funcmat.mostraNovaEquacao();
            }




            //coeficientes = new_coeficientes();
            InfoConica info = new InfoConica(coeficientes);
            info.Show();
        }
        private string sinal(double coeficiente)
        {
            string sinal;
            return sinal = (coeficiente > 0) ? " + " : " ";
        }
        private string printEqAtual(double[] coeficientes)
        {
            string ret=null;

            if (coeficientes[0] != 0) ret = coeficientes[0].ToString() + "x² ";
            if (coeficientes[1] != 0) ret +=sinal(coeficientes[1]) + coeficientes[1].ToString() + "y²";
            if (coeficientes[2] != 0) ret +=sinal(coeficientes[2]) + coeficientes[2].ToString() + "xy";
            if (coeficientes[3] != 0) ret +=sinal(coeficientes[3]) + coeficientes[3].ToString() + "x";
            if (coeficientes[4] != 0) ret +=sinal(coeficientes[4]) + coeficientes[4].ToString() + "y";
            if (coeficientes[5] != 0) ret +=sinal(coeficientes[5]) + coeficientes[5].ToString();
            return ret;
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

        private void btnLimpar(object sender, EventArgs e)
        {
            txtA.Text = "0";
            txtB.Text = "0";
            txtC.Text = "0";
            txtD.Text = "0";
            txtE.Text = "0";
            txtF.Text = "0";
            txtA.Focus();
        }
    }
}
