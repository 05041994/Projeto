using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaApp
{
    public class Aluno
    {
        public int id { get; set; }
        public string Nome { get; set; }

        public int Matricula { get; set; }

        public string Email { get; set; }

        public int Idturma { get; set; }

        public override string ToString()
        {
            return $"{id} - {Nome} - {Matricula} - {Email} - Turma: {Idturma} ";
        }
    }
}
