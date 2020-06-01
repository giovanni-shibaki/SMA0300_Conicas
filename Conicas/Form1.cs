using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conicas
{
    public partial class MainMenu : Form
    {
        double a, b, c, d, e, f;

        public MainMenu()
        {
            InitializeComponent();
        }
        private void btnCalcula_Click(object sender, EventArgs eventArgs)
        {
            try
            {
                a = double.Parse(txtA.Text);
                b = double.Parse(txtB.Text);
                c = double.Parse(txtC.Text);
                d = double.Parse(txtD.Text);
                e = double.Parse(txtE.Text);
                f = double.Parse(txtF.Text);
            }
            catch (System.FormatException a)
            {
                MessageBox.Show("Erro ao processar os campos!\nMais detalhes: " + a);
            }
            FuncMatematicas funcmat = new FuncMatematicas();
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
