using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace EscolaApp
{
    static class NAluno
    {
        private static List<Aluno> alunos = new List<Aluno>();

        public static void Inserir(Aluno t)
        {
            Abrir();
            alunos.Add(t);
            Salvar();
        }
        public static List<Aluno> Listar()
        {
            return alunos;
        }

        public static void Atualizar(Aluno t)
        {
            Abrir();
            foreach (Aluno obj in alunos)
            {
                if (obj.id == t.id)
                {
                    obj.Nome = t.Nome;
                    obj.Matricula = t.Matricula;
                    obj.Email = t.Email;
                    obj.Idturma = t.Idturma;
                }
            }
            Salvar();
        }
        public static void Excluir(Aluno t)
        {
            Aluno x = null;
            foreach (Aluno obj in alunos)
                if (obj.id == t.id) x = obj;
            if (x != null) alunos.Remove(x);
        }

        public static void Abrir()
        {
            StreamReader f = null;

            try
            {

                //objeto que tranforma o xml em bloco de texto
                XmlSerializer xml = new XmlSerializer(typeof(List<Aluno>));
                // obj que grava um texto em um arquivo
                f = new StreamReader("./alunos.xml", false);

                alunos = (List<Aluno>)xml.Deserialize(f);
            }
            catch
            {
                alunos = new List<Aluno>();
            }

            if (f != null) f.Close();
            //tratamento de eceçoes
        }
        public static void Salvar()
        {
            //objeto que tranforma o xml em bloco de texto
            XmlSerializer xml = new XmlSerializer(typeof(List<Aluno>));
            // obj que grava um texto em um arquivo
            StreamWriter f = new StreamWriter("./alunos.xml", false);

            xml.Serialize(f, alunos);

            f.Close();
        }
    }
}
