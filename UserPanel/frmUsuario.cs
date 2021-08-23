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
    public partial class frmUsuario : Form
    {
        bool tipo;
        int atual;
        private void Habilita()
        {

            txtCodigo.Enabled = false;
            txtNome.Enabled = true;
            txtNivel.Enabled = true;
            txtLogin.Enabled = true;
            txtSenha.Enabled = true;
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
            txtNivel.Enabled = false;
            txtLogin.Enabled = false;
            txtSenha.Enabled = false;
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
            txtCodigo.Text = frmPrincipal.usuarios[atual].codigo.ToString();
            txtNome.Text = frmPrincipal.usuarios[atual].nome;
            txtNivel.Text = frmPrincipal.usuarios[atual].nivel;
            txtLogin.Text = frmPrincipal.usuarios[atual].login;
            txtSenha.Text = frmPrincipal.usuarios[atual].senha;
        }
        public frmUsuario()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            Desabilita();
            atual = 0;
            Mostra();
            
        }
        private void btnNovo_Click_1(object sender, EventArgs e)
        {
            if (frmPrincipal.cadusu<10)
            {
                Habilita();
                txtCodigo.Text = (frmPrincipal.cadusu + 1).ToString();
                txtNome.Text =  "";
                txtNivel.Clear();
                txtLogin.Clear();
                txtSenha.Clear();
                tipo = true;
            }
            else
            {
                //como temos 10 espaços no método, a partir do 11, os dados não serão salvos/cadastrados.
                MessageBox.Show("Impossível realizar novos cadastros!");
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Desabilita();
            if (tipo) { 
            frmPrincipal.usuarios[frmPrincipal.cadusu].codigo = int.Parse(txtCodigo.Text);
            frmPrincipal.usuarios[frmPrincipal.cadusu].nome = txtNome.Text;
            frmPrincipal.usuarios[frmPrincipal.cadusu].nivel = txtNivel.Text;
            frmPrincipal.usuarios[frmPrincipal.cadusu].login = txtLogin.Text;
            frmPrincipal.usuarios[frmPrincipal.cadusu].senha = txtSenha.Text;
            atual = frmPrincipal.cadusu++;
            }
            else
            {
                frmPrincipal.usuarios[atual].nome = txtNome.Text;
                frmPrincipal.usuarios[atual].nivel = txtNivel.Text;
                frmPrincipal.usuarios[atual].login = txtLogin.Text;
                frmPrincipal.usuarios[atual].senha = txtSenha.Text;
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Habilita();
            tipo = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Desabilita();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (atual > 0)
            {
                atual--;
                Mostra();
            }
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            if (atual < frmPrincipal.cadusu-1)
            {
                atual++;
                Mostra();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma a exclusão do cadastro?","Confirmação",
                MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                frmPrincipal.usuarios[atual].nome = "";
                frmPrincipal.usuarios[atual].nivel = "";
                frmPrincipal.usuarios[atual].login = "";
                frmPrincipal.usuarios[atual].senha = "";
                Mostra();
            }
        }
    }
}
