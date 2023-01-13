using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace EscolaApp
{
    /// <summary>
    /// Lógica interna para Janela_Aluno.xaml
    /// </summary>
    public partial class Janela_Aluno : Window
    {
        public Janela_Aluno()
        {
            InitializeComponent();
        }

        private void InserirClick(object sender, RoutedEventArgs e)
        {
            Aluno A = new Aluno();
            A.id = int.Parse(txtid.Text);
            A.Nome = txtNome.Text;
            A.Matricula = int.Parse(txtMatricula.Text);
            A.Email = txtemail.Text;
            A.Idturma = int.Parse(txtidturma.Text);

            //InserirClick a turma na lista de aluno

            NAluno.Inserir(A);
            ListarClick(sender, e);
        }

        private void ListarClick(object sender, RoutedEventArgs e)
        {
            listAluno.ItemsSource = null;
            listAluno.ItemsSource = NAluno.Listar();
        }

        private void AtualizarClick(object sender, RoutedEventArgs e)
        {
            Aluno t = new Aluno();
            t.id = int.Parse(txtid.Text);
            t.Nome = txtNome.Text;
            t.Email = txtemail.Text;
            t.Matricula = int.Parse(txtMatricula.Text);
            t.Idturma = int.Parse(txtidturma.Text);
            //InserirClick a turma na lista de turmas

            NAluno.Atualizar(t);
            ListarClick(sender, e);
        }

        private void ExcluirClick(object sender, RoutedEventArgs e)
        {
            Aluno t = new Aluno();
            t.id = int.Parse(txtid.Text);

            NAluno.Excluir(t);
            ListarClick(sender, e);
        }
        private void listAluno_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listAluno.SelectedItem != null)
            {
                Aluno obj = (Aluno)listAluno.SelectedItem;

                txtid.Text = obj.id.ToString();
                txtNome.Text = obj.Nome;
                txtMatricula.Text = obj.Matricula.ToString();
                txtidturma.Text = obj.Idturma.ToString();
            }
        }
    }
}
