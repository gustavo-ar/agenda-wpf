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




        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ContatoDAO dao = new ContatoDAO();
            int id = Int32.Parse(inputID.Text);
            Contato contato = dao.BuscarContatoPorID(id);

            Console.WriteLine(contato.Nome);
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
           

        private void novoContato(object sender, RoutedEventArgs e)
        {
            ContatoDAO dao = new ContatoDAO();

            Contato contato = new Contato
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

            dao.InserirContato(contato);

            tb_nome.Text = "";
            tb_endereco.Text = "";
            tb_numero.Text = "";
            tb_bairro.Text = "";
            tb_cidade.Text = "";
            tb_cep.Text = "";
            tb_telefone.Text = "";
            tb_celular.Text = "";
            tb_email.Text = "";
            MessageBox.Show("Contato inserido com sucesso");
        }
    }
}
