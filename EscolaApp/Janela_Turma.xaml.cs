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
    /// Lógica interna para Janela_Turma.xaml
    /// </summary>
    public partial class Janela_Turma : Window
    {
        public Janela_Turma()
        {
            InitializeComponent();
        }

        private void InserirClick(object sender, RoutedEventArgs e)
        {
            Turma t = new Turma();
            t.id = int.Parse(txtid.Text);
            t.Curso = txtCurso.Text;
            t.Descrição = txtTurma.Text;
            t.AnoLetivo = int.Parse(txtAno.Text);
            //InserirClick a turma na lista de turmas

            NTurma.Inserir(t);
            ListarClick(sender, e);
        }

        private void ListarClick(object sender, RoutedEventArgs e)
        {
            listTurmas.ItemsSource = null;
            listTurmas.ItemsSource = NTurma.Listar();

        }

        private void AtualizarClick(object sender, RoutedEventArgs e)
        {
            Turma t = new Turma();
            t.id = int.Parse(txtid.Text);
            t.Curso = txtCurso.Text;
            t.Descrição = txtTurma.Text;
            t.AnoLetivo = int.Parse(txtAno.Text);
            //InserirClick a turma na lista de turmas

            NTurma.Atualizar(t);
            ListarClick(sender, e);


        }

        private void ExcluirClick(object sender, RoutedEventArgs e)
        {
            Turma t = new Turma();
            t.id = int.Parse(txtid.Text);

            NTurma.Excluir(t);
            ListarClick(sender, e);
        }

        private void listTurmas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(listTurmas.SelectedItem != null)
            {
                Turma obj = (Turma)listTurmas.SelectedItem;

                txtid.Text = obj.id.ToString();
                txtCurso.Text = obj.Curso;
                txtTurma.Text = obj.Descrição;
                txtAno.Text = obj.AnoLetivo.ToString();
            }
        }
    }
}
