using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EscolaApp
{
    static class NTurma
    {
        private static List<Turma> turmas = new List<Turma>();

        public static void Inserir(Turma t)
        {
            Abrir();
            turmas.Add(t);
            Salvar();
        }
        public static List<Turma> Listar()
        {
            return turmas;
        }

        public static void Atualizar(Turma t)
        {
            Abrir();
            foreach (Turma obj in turmas)
            {
                if (obj.id == t.id)
                {
                    obj.Curso = t.Curso;
                    obj.Descrição = t.Descrição;
                    obj.AnoLetivo = t.AnoLetivo;
                }
            }
            Salvar();
        }
        public static void Excluir(Turma t)
        {
            Turma x = null;
            foreach (Turma obj in turmas)
                if (obj.id == t.id) x = obj;
            if (x != null) turmas.Remove(x);
        }

        public static void Abrir()
        {
            StreamReader f = null;

            try
            {

                //objeto que tranforma o xml em bloco de texto
                XmlSerializer xml = new XmlSerializer(typeof(List<Turma>));
                // obj que grava um texto em um arquivo
                f = new StreamReader("./turmas.xml", false);

                turmas = (List<Turma>)xml.Deserialize(f);
            }
            catch
            {
                turmas = new List<Turma>();
            }
            
            if(f != null) f.Close();
            //tratamento de eceçoes
        }
        public static void Salvar()
        {
            //objeto que tranforma o xml em bloco de texto
            XmlSerializer xml = new XmlSerializer(typeof(List<Turma>));
            // obj que grava um texto em um arquivo
            StreamWriter f = new StreamWriter("./turmas.xml", false);

            xml.Serialize(f, turmas);

            f.Close();
        }

    }
}
