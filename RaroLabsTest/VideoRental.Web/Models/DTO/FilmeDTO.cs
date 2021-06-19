using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoRental.Web.Models.DTO
{
    public class FilmeDTO
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
