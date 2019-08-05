using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MagicTournament.Models
{
    public class Deck
    {
        [Key]
        public int ID { get; set; }
        public int IdUser { get; set; }
        public string Titulo { get; set; }
        public string Formato { get; set; }
        public string Cards { get; set; }
    }
}
