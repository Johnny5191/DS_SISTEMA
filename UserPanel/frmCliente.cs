using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroArray
{
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }
        bool tipo;
        int atual;
        private void Habilita()
        {

            txtCodigo.Enabled = false;
            txtNome.Enabled = true;
            txtTelefone.Enabled = true;
            txtEmail.Enabled = true;
            txtCPF.Enabled = true;
            btnSalvar.Enabled = true;
            btnCancelar.Enabled = true;
            btnAnterior.Enabled = false;
            btnProximo.Enabled = false;
            btnNovo.Enabled = false;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnPesquisar.Enabled = false;
            btnImprimir.Enabled = false;
            btnSair.Enabled = false;
        }
        private void Desabilita()
        {

            txtCodigo.Enabled = false;
            txtNome.Enabled = false;
            txtTelefone.Enabled = false;
            txtEmail.Enabled = false;
            txtCPF.Enabled = false;
            btnSalvar.Enabled = false;
            btnCancelar.Enabled = false;
            btnAnterior.Enabled = true;
            btnProximo.Enabled = true;
            btnNovo.Enabled = true;
            btnAlterar.Enabled = true;
            btnExcluir.Enabled = true;
            btnPesquisar.Enabled = true;
            btnImprimir.Enabled = true;
            btnSair.Enabled = true;
        }
        private void Mostra()
        {
            txtCodigo.Text = frmPrincipal.clientes[atual].codigo.ToString();
            txtNome.Text = frmPrincipal.clientes[atual].nome;
            txtTelefone.Text = frmPrincipal.clientes[atual].telefone.ToString();
            txtEmail.Text = frmPrincipal.clientes[atual].email;
            txtCPF.Text = frmPrincipal.clientes[atual].cpf.ToString();
        }


        private void frmCliente_Load(object sender, EventArgs e)
        {
            Desabilita();
            atual = 0;
            Mostra();

        }
        

        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (frmPrincipal.cadcli < 10)
            {
                Habilita();
                txtCodigo.Text = (frmPrincipal.cadcli + 1).ToString();
                txtNome.Text = "";
                txtTelefone.Clear();
                txtNome.Clear();
                txtCPF.Clear();
                tipo = true;
            }
            else
            {
                //como temos 10 espaços no método, a partir do 11, os dados não serão salvos/cadastrados.
                MessageBox.Show("Impossível realizar novos cadastros!");
            }
        }
        //texto aqui

        private void btnSalvar_Click_1(object sender, EventArgs e)
        {
            Desabilita();
            if (tipo)
            {
                frmPrincipal.clientes[frmPrincipal.cadcli].codigo = int.Parse(txtCodigo.Text);
                frmPrincipal.clientes[frmPrincipal.cadcli].nome = txtNome.Text;
                frmPrincipal.clientes[frmPrincipal.cadcli].telefone = int.Parse(txtTelefone.Text);
                frmPrincipal.clientes[frmPrincipal.cadcli].nome = txtNome.Text;
                frmPrincipal.clientes[frmPrincipal.cadcli].cpf = int.Parse(txtTelefone.Text);
                atual = frmPrincipal.cadcli++;
            }
            else
            {
                frmPrincipal.clientes[atual].nome = txtNome.Text;
                frmPrincipal.clientes[atual].telefone = int.Parse(txtTelefone.Text);
                frmPrincipal.clientes[atual].nome = txtNome.Text;
                frmPrincipal.clientes[atual].cpf = int.Parse(txtTelefone.Text);
            }
        }

        private void btnAlterar_Click_1(object sender, EventArgs e)
        {
            Habilita();
            tipo = false;
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            Desabilita();
        }

        private void btnAnterior_Click_1(object sender, EventArgs e)
        {
            if (atual > 0)
            {
                atual--;
                Mostra();
            }
        }

        private void btnProximo_Click_1(object sender, EventArgs e)
        {
            if (atual < frmPrincipal.cadusu - 1)
            {
                atual++;
                Mostra();
            }
        }
        private void btnExcluir_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma a exclusão do cadastro?", "Confirmação",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                frmPrincipal.usuarios[atual].nome = "";
                frmPrincipal.usuarios[atual].nivel = "";
                frmPrincipal.usuarios[atual].login = "";
                frmPrincipal.usuarios[atual].senha = "";
                Mostra();
            }
        }

        private void btnSair_Click_1(object sender, EventArgs e)
        {
            Close();
        }

      
    }
}
