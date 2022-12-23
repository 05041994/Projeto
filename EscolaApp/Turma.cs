using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscolaApp
{
    class Turma
    {
        public int id { get; set; }
        public string Curso { get; set; }
        public string Descrição { get; set; }
        public int AnoLetivo { get; set; }

        public override string ToString()
        {
            return $"{id} - {Curso} - {Descrição} - {AnoLetivo}";
        }

    }
}
