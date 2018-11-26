using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AspNetVS2017.Capitulo01.Frete
{
    public partial class FreteForm : Form
    {
        public FreteForm()
        {
            InitializeComponent();
        }

        private void calcularButton_Click(object sender, EventArgs e)
        {
            var erros = ValidarFormulario();
            // Toda lista utiliza o count 
            if (erros.Count == 0)
            {
                Calcular();
            }
            else
            {
                //separador por linha
                MessageBox.Show(string.Join(Environment.NewLine,erros),
                    "validação", // header
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }




        }
        private void Calcular()
        {
            var percentual = 0m;
            var valor = Convert.ToDecimal(valorTextBox.Text);
            var nordeste = new List<string> {"AL","PE","AL"};

            switch(ufComboBox.Text.ToUpper())
            {
                case "SP":
                    percentual = 0.2m;
                    break;
                case "RJ":
                    percentual = 0.3m;
                    break;

                case "MG":
                    percentual = 0.35m;
                    break;
                case "AM":
                    percentual = 0.6m;
                    break;

                case var uf when nordeste.Contains(uf):
                    percentual = 0.45m;
                    break;

                case null:
                    throw new NullReferenceException("combobox null");

                default:
                    percentual = 0.5m;
                    break;
                   




            }


            freteTextBox.Text = percentual.ToString();
            totalTextBox.Text = (valor * (1 + percentual)).ToString("C2");

        }

        private List<string> ValidarFormulario()
        {
            // estanciando lista de strings 
            var erros = new List<string>();
            //if (clienteTextBox.Text == string.Empty) //""
            if (string.IsNullOrEmpty(clienteTextBox.Text)) 
            {
                //   Console.WriteLine("O campo nao pode ser vazio");
                erros.Add("O campo Cliente é obrigatorio");                    
            }
            // se nao selecioanr ngm indice -1
            if (ufComboBox.SelectedIndex ==-1)
            {
                erros.Add("Selecione um campo UF");
            }

            if (string.IsNullOrEmpty(valorTextBox.Text))
            {
                
                erros.Add("O campo Valor é obrigatorio");
            }
            else 
            {

                if (!decimal.TryParse(valorTextBox.Text, out decimal valor))
                {
                    erros.Add("O campo Valor é invalido");
                }
            }


            return erros;
        }

        private void limparButton_Click(object sender, EventArgs e)
        {
            valorTextBox.Text = "";
            clienteTextBox.Text = "";
            totalTextBox.Text = "";
            freteTextBox.Text = "";
            ufComboBox.Text = "";

            clienteTextBox.Focus();
        }
    }
}
