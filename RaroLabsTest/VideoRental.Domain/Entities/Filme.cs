using System;
using System.Collections.Generic;
using System.Text;

namespace VideoRental.Domain.Entities
{
    public class Filme
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Ano { get; set; }
        public int GeneroId { get; set; }
        public string Genero { get; set; }
        public string Classificacao { get; set; }
        public string Duracao { get; set; }
    }
}
