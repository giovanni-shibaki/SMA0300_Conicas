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
        public MainMenu()
        {
            InitializeComponent();

            /*double a = Convert.ToDouble(txtA.Text);
            double b = Convert.ToDouble(txtB.Text);
            double c = Convert.ToDouble(txtC.Text);*/


            FuncMatematicas fmat = new FuncMatematicas();
            lblEquacao.Text =fmat.AddTwoNumbers(3, 3).ToString();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnCalcula_Click(object sender, EventArgs e)
        {
            FuncMatematicas fmat = new FuncMatematicas();
            fmat.gerarMatrizG(Convert.ToDouble(txtA.Text), Convert.ToDouble(txtB.Text), Convert.ToDouble(txtC.Text), Convert.ToDouble(txtD.Text), Convert.ToDouble(txtE.Text), Convert.ToDouble(txtF.Text));
        }
    }
}
