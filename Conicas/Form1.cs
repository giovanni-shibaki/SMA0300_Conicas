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
using System.Security.Cryptography;
using System.Diagnostics;
using Microsoft.Win32;

namespace Conicas
{
    public partial class MainMenu : MaterialForm
    {
        double[] coeficientes = new double[6];
        public FuncMatematicas funcmat = new FuncMatematicas();
        public Vector<double> matrizG2;
        public Vector<double> matrizG3;
        public double det;
        public MainMenu()
        {
            InitializeComponent();
        }


        #region Métodos
        private bool translacao()
        {
            funcmat.calculaH_K(coeficientes);
            det = funcmat.acharSolucoesSistema(coeficientes[0], coeficientes[1], coeficientes[2]);
            if (det == 0) // Poder ter infinitas soluções ou ser incompativel
            {
                if (double.IsNaN(funcmat.getH()) || double.IsNaN(funcmat.getK()))
                {
                    // Sistema incompativel
                }
                if (double.IsInfinity(funcmat.getH()) || double.IsInfinity(funcmat.getK()))
                {
                    // Sistema com infinitas soluções
                }

                // Não conseguiu eliminar os termos lineares
                matrizG2 = funcmat.gerarEquacaoG2(coeficientes[0], coeficientes[1], coeficientes[2], coeficientes[3], coeficientes[4], coeficientes[5]);
                return false; // não conseguiu realizar a translação
            }

            matrizG2 = funcmat.gerarEquacaoG2(coeficientes[0], coeficientes[1], coeficientes[2], coeficientes[3], coeficientes[4], coeficientes[5]);
            // Conseguiu realizar a translação, então remover os termos lineares
            funcmat.setDL(0);
            funcmat.setEL(0);
            return true;
        }

        private bool rotacao(bool consegiuTranslacao)
        {
            funcmat.calculaSenCos();
            if (funcmat.getCotg2teta() == 0 || double.IsNaN(funcmat.getCotg2teta()))
            {
                // Se não tem solução não dá para fazer rotação
                return false;
            }
            funcmat.calculaAlCl(matrizG2);
            if (consegiuTranslacao) // Se não tiver D e E não precisa calcular dL e eL
            {

            }
            else
            {
                // Calcula dL e 
                funcmat.calculaDlEl();
            }

            // Se deu certo o termo quadrático misto é removido
            funcmat.setBL(0);
            return true;
        }

        // formatacao de sinal para impressao da equacao inicial no lblEqInicial
        private string sinal(double coeficiente)
        {
            string sinal;
            return sinal = (coeficiente > 0) ? "+" : null;
        }
        // recebe apenas os coeficientes e imprime na tela a equacao com X,Y formatados corretamente
        private string printEqAtual(double[] coeficientes)
        {
            string ret = null;

            if (coeficientes[0] != 0) ret = coeficientes[0].ToString() + "x² ";
            if (coeficientes[1] != 0) ret += sinal(coeficientes[1]) + coeficientes[1].ToString() + "xy";
            if (coeficientes[2] != 0) ret += sinal(coeficientes[2]) + coeficientes[2].ToString() + "y²";
            if (coeficientes[3] != 0) ret += sinal(coeficientes[3]) + coeficientes[3].ToString() + "x";
            if (coeficientes[4] != 0) ret += sinal(coeficientes[4]) + coeficientes[4].ToString() + "y";
            if (coeficientes[5] != 0) ret += sinal(coeficientes[5]) + coeficientes[5].ToString();
            return ret;
        }

        // formata coeficientes de acordo com sintaxe da url do wolframAlpha
        private string wolframFormat(double[] coeficientes, bool simplified)
        {
            string ret = null;
            // formatar para equacao antes de rotacao e translacao
            if (!simplified) {
                if (coeficientes[0] != 0) ret = coeficientes[0].ToString() + "x²+%2B+"; // A
                if (coeficientes[1] != 0) ret += coeficientes[1].ToString() + "xy+%2B+";// B
                if (coeficientes[2] != 0) ret += coeficientes[2].ToString() + "y²+%2B+";// C
                if (coeficientes[3] != 0) ret += coeficientes[3].ToString() + "x+%2B+"; // D
                if (coeficientes[4] != 0) ret += coeficientes[4].ToString() + "y+%2B+"; // E
                if (coeficientes[5] != 0) ret += coeficientes[5].ToString() + "+%3D0";  // F
            }
            // formatar para equacao depois de rotacao e translacao
            else
            {
                if (coeficientes[0] != 0) ret =  funcmat.getAL().ToString() + "u²+%2B+"; // A
                if (coeficientes[1] != 0) ret += funcmat.getBL().ToString() + "uv+%2B+";// B
                if (coeficientes[2] != 0) ret += funcmat.getCL().ToString() + "v²+%2B+";// C
                if (coeficientes[3] != 0) ret += funcmat.getDL().ToString() + "u+%2B+"; // D
                if (coeficientes[4] != 0) ret += funcmat.getEL().ToString() + "v+%2B+"; // E
                if (coeficientes[5] != 0) ret += funcmat.getF().ToString() + "+%3D0";  // F
            }
            return ret;
        }
        #endregion

        #region Events

        private void btnCalcula_Click(object sender, EventArgs eventArgs)
        {
            try
            {
                #region settando os campos
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

                funcmat.setAL(coeficientes[0]);
                funcmat.setBL(coeficientes[1]);
                funcmat.setCL(coeficientes[2]);
                funcmat.setDL(coeficientes[3]);
                funcmat.setEL(coeficientes[4]);
                #endregion

                lblEquacaoAtual.Text = printEqAtual(coeficientes);
                ConicaGraph conica = new ConicaGraph(coeficientes);
                conica.Show();
            }
            catch (System.FormatException a)
            {
                MessageBox.Show("Erro ao processar os campos!\nMais detalhes: " + a);
            }

            //Verifica se os termos lineares são 0, se for, pula para a rotação
            if (funcmat.getD() == 0 && funcmat.getE() == 0)
            {
                // Vai direto pra rotação SE TIVER O TERMO QUADRÁTICO MISTO
                if (funcmat.getB() == 0)
                {
                    //Não da pra fazer rotação também, a equação já está pronta
                }
                else
                {
                    matrizG2 = funcmat.gerarEquacaoG2(coeficientes[0], coeficientes[1], coeficientes[2], coeficientes[3], coeficientes[4], coeficientes[5]);
                    if (this.rotacao(false))
                    {
                        matrizG3 = funcmat.gerarEquacaoG2(funcmat.getAL(), (double)0, funcmat.getCL(), funcmat.getDL(), funcmat.getEL(), funcmat.getF());
                        lblEquacaoReduzida.Text = funcmat.mostraNovaEquacao2();
                    }
                    else
                    {
                        // Não realizou a rotação, então não elimina o termo quadrático misto
                        matrizG3 = funcmat.gerarEquacaoG2(funcmat.getAL(), funcmat.getB(), funcmat.getCL(), funcmat.getDL(), funcmat.getEL(), funcmat.getF());
                        lblEquacaoReduzida.Text = funcmat.mostraNovaEquacao2();
                    }
                }
            }
            else
            {
                // Fazer translação e rotação
                if (this.translacao())
                {
                    // Conseguiu fazer a translação
                    lblEquacaoReduzida.Text = funcmat.mostraNovaEquacao();
                    if (funcmat.getB() != 0) // Se não tiver termo quadrático misto não precisa fazer rotação
                    {
                        this.rotacao(true); // True porque a translação deu certo
                    }
                }
                else
                {
                    MessageBox.Show("Não foi possível realizar a translação e remover os termos lineares!\nO sistema linear encontrado para achar os valores de H e K é incompatível ou tem infinitas soluções!\nIniciando rotação...", "Erro translação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Não conseguiu fazer a translação
                    if (funcmat.getB() != 0) // Se não tiver termo quadrático misto não precisa fazer rotação
                    {
                        if (this.rotacao(false))
                        {
                            matrizG3 = funcmat.gerarEquacaoG2(funcmat.getAL(), (double)0, funcmat.getCL(), funcmat.getDL(), funcmat.getEL(), funcmat.getF());
                            lblEquacaoReduzida.Text = funcmat.mostraNovaEquacao2();
                        }
                        else
                        {
                            // Não realizou a rotação, então não elimina o termo quadrático misto
                            matrizG3 = funcmat.gerarEquacaoG2(funcmat.getAL(), funcmat.getB(), funcmat.getCL(), funcmat.getDL(), funcmat.getEL(), funcmat.getF());
                            lblEquacaoReduzida.Text = funcmat.mostraNovaEquacao2();
                        }
                    }
                }
                lblEquacaoReduzida.Text = funcmat.mostraNovaEquacao();
            }

            //coeficientes = new_coeficientes();
            InfoConica info = new InfoConica(coeficientes);
            info.Show();
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

        // deixa 0 nos campos de entrada dos coeficientes
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

        private void btnInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Trabalho realizado por:\n\nGiovanni Shibaki - 11796444\nPedro Kenzo - 11796451\nBCC 020\n\nMatéria SMA0300 - Geometria Analítica", "Sobre a equipe", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        // clique do webplot
        private void btWebPlot_Click(object sender, EventArgs e)
        {
            // lendo texto das textboxes
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


            //  a url da equacao sera concatenada ao wolfram
            string url;

            // prodecimento de Dialog Box
            var res = MessageBox.Show(this, "O Navegador padrão aberto será aberto para isso, ok?", "Web Plotting",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (res == DialogResult.OK)
            {
                // se so temos a equacao inicial
                MessageBox.Show("Exibindo no browser o gráfico da equação inicial");
                url = "https://www.wolframalpha.com/input/?i=" + wolframFormat(this.coeficientes,false);

                System.Diagnostics.Process.Start("cmd", "/C start" + " " + url);

                // se temos equacao reduzida
                if (lblEquacaoReduzida.Text!="")
                {
                    MessageBox.Show("Exibindo no browser o gráfico da equação reduzida");

                    url = "https://www.wolframalpha.com/input/?i=" + wolframFormat(this.coeficientes,true);
                    System.Diagnostics.Process.Start("cmd", "/C start" + " " + url);
                }

            }
        }
        #endregion
    }
}
