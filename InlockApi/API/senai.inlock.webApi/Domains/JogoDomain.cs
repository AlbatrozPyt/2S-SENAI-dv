using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    public class JogoDomain
    {
        public int IdJogo { get; set; }
        public int IdEstudio { get; set; }
        public string Nome {get; set;}
        public string Descricao {get; set;}
        public DateTime DataLancamento {get; set;}
        public double Valor {get; set;}
        public EstudioDomain Estudio {get; set;}
    }
}