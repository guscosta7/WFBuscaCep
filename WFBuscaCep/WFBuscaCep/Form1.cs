using Refit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace WFBuscaCep
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private async Task consomeCep()
        {
            try
            {
                var cepCliente = RestService.For<ICepApiService>("https://viacep.com.br");

                CepResponse endereco = await cepCliente.GetAddressAsync(txtCep.Text);

                txtBairro.Text = endereco.Bairro;
                txtCep.Text = endereco.Cep;
                txtCidade.Text = endereco.Localidade;
                txtLogradouro.Text = endereco.Logradouro;
                txtUF.Text = endereco.Uf;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na requisição: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            consomeCep();
        }
    }
}
