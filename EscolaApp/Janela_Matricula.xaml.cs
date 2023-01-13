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
    /// Lógica interna para Janela_Matricula.xaml
    /// </summary>
    public partial class Janela_Matricula : Window
    {
        public Janela_Matricula()
        {
            InitializeComponent();
        }

        private void ListarClick(object sender, RoutedEventArgs e)
        {
            listTurmas.ItemsSource = null;
            listTurmas.ItemsSource = NTurma.Listar();
            listAlunos.ItemsSource = null;
            listAlunos.ItemsSource = NAluno.Listar();

        }

        private void MatriculaClick(object sender, RoutedEventArgs e)
        {
            if (listTurmas.SelectedItem != null && listAlunos.SelectedItem != null)
            {
                Aluno a = (Aluno)listAlunos.SelectedItem;
                Turma t = (Turma)listTurmas.SelectedItem;
                NAluno.Matricular(a, t);
                ListarClick(sender, e);
            }
        }
    }
}
