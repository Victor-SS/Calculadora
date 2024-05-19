using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class frmCalculadora : Form
    {
        public frmCalculadora()
        {
            InitializeComponent();
        }

        private void frmCalculadora_Load(object sender, EventArgs e)
        {
            cboOperacoes.Items.Add("Soma");
            cboOperacoes.Items.Add("Divisão");
            cboOperacoes.Items.Add("Subtração");
            cboOperacoes.Items.Add("Multiplicação");
            cboOperacoes.SelectedIndex = -1;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtValor1.Clear();
            txtValor2.Clear();
            cboOperacoes.SelectedIndex = -1;
            txtResultado.Clear();
            txtValor1.Focus();
        }

        private decimal Somar(decimal v1, decimal v2)
        {
            decimal result = 0;

            result = v1 + v2;

            return result;
        }
        private decimal Dividir(decimal v1, decimal v2)
        {
            decimal result = 0;

            result = v1 / v2;

            return result;
        }
        private decimal Subtrair(decimal v1, decimal v2)
        {
            decimal result = 0;

            result = v1 - v2;

            return result;
        }
        private decimal Multiplicar(decimal v1, decimal v2)
        {
            decimal result = 0;

            result = v1 * v2;

            return result;
        }

        private string ValidarPreenchimento()
        {
            string msgErro = string.Empty;

            if(txtValor1.Text == string.Empty)
            {
                msgErro += "Campo VALOR 1 em Branco!\n";
            }
            if(txtValor2.Text == string.Empty)
            {
                msgErro += "Campo VALOR 2 em Branco!\n";
            }
            if(cboOperacoes.SelectedIndex == -1)
            {
                msgErro += "Campo OPERAÇÕES em Branco!\n";
            }

            return msgErro;
        }

        private void txtValor1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' &&
                !char.IsControl(e.KeyChar) ||
                e.KeyChar == ',' && txtValor1.Text.Contains(','))
            {
                e.Handled = true;
            }
            return;
        }
        private void txtValor2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' &&
               !char.IsControl(e.KeyChar) ||
               e.KeyChar == ',' && txtValor2.Text.Contains(','))
            {
                e.Handled = true;
            }
            return;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            decimal valor1 = 0;
            decimal valor2 = 0;
            decimal resultado = 0;
            string mensagem = ValidarPreenchimento();

            if (mensagem != string.Empty)
            {
                MessageBox.Show(mensagem, "Campo Inválido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            valor1 = Convert.ToDecimal(txtValor1.Text);
            valor2 = Convert.ToDecimal(txtValor2.Text);


            switch (cboOperacoes.SelectedItem.ToString())
            {
                case "Soma":
                    resultado = Somar(valor1, valor2);
                    break;
                case "Divisão":
                    if(valor1 == 0 || valor2 == 0)
                    {
                        MessageBox.Show("Divisão por zero não é permitida!",
                            "Erro na Divisão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    resultado = Dividir(valor1, valor2);
                    break;
                case "Subtração":
                    resultado = Subtrair(valor1, valor2);
                    break;
                case "Multiplicação":
                    resultado = Multiplicar(valor1, valor2);
                    break;
            }
            txtResultado.Text = resultado.ToString();
        }
    }
}
