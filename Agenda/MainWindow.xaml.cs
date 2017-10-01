using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Agenda
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BuscarPorId(object sender, RoutedEventArgs e)
        {
            ContatoDAO dao = new ContatoDAO();
            int id = Int32.Parse(inputID.Text);
            Contato contato = dao.BuscarContatoPorID(id);

            tb_nome.Text = contato.Nome;
            tb_endereco.Text = contato.Endereco;
            tb_numero.Text = contato.Numero.ToString();
            tb_bairro.Text = contato.Bairro;
            tb_cidade.Text = contato.Cidade;
            tb_cep.Text = contato.Cep;
            tb_telefone.Text = contato.Telefone;
            tb_celular.Text = contato.Celular;
            tb_email.Text = contato.Email;
            tb_id.Text = contato.Id.ToString();

            ResetBtns(true);
        }

        private void ResetBtns(bool b)
        {
            btn_alterar.IsEnabled = b;
            btn_excluir.IsEnabled = b;
            btn_novo.IsEnabled = !b;
        }

        private void NovoContato(object sender, RoutedEventArgs e)
        {
            ContatoDAO dao = new ContatoDAO();

            Contato contato = CriarContato();

            dao.InserirContato(contato);
            ResetInputs();
            MessageBox.Show("Contato inserido com sucesso");
        }

        private void ResetInputs()
        {
            tb_nome.Text = "";
            tb_endereco.Text = "";
            tb_numero.Text = "";
            tb_bairro.Text = "";
            tb_cidade.Text = "";
            tb_cep.Text = "";
            tb_id.Text = "";
            tb_telefone.Text = "";
            tb_celular.Text = "";
            tb_email.Text = "";
        }

        private Contato CriarContato()
        {
            return new Contato
            {
                Nome = tb_nome.Text,
                Endereco = tb_endereco.Text,
                Numero = Int32.Parse(tb_numero.Text),
                Bairro = tb_bairro.Text,
                Cidade = tb_cidade.Text,
                Cep = tb_cep.Text,
                Telefone = tb_telefone.Text,
                Celular = tb_celular.Text,
                Email = tb_email.Text               
            };
        }

        private void AlterarContato(object sender, RoutedEventArgs e)
        {
            Contato contato = CriarContato();
            contato.Id = Int32.Parse(tb_id.Text);
            ContatoDAO dao = new ContatoDAO();
            dao.AlterarContato(contato);
            ResetBtns(false);
            ResetInputs();
            MessageBox.Show("Contato alterado com sucesso");
        }

        private void ExcluirContato(object sender, RoutedEventArgs e)
        {
            int id = Int32.Parse( inputID.Text);

            ContatoDAO dao = new ContatoDAO();

            dao.DeletarContato(id);

            ResetInputs();
            ResetBtns(false);

            MessageBox.Show("Contato deletado com sucesso");
        }

        private void CloseApp(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
