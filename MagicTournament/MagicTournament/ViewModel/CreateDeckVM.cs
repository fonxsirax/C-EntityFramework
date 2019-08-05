using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MagicTournament.ViewModel
{
    public class CreateDeckVM
    {
        [Key]
        public int ID { get; set; }
        public string Deckname { get; set; }
        public string Formato { get; set; }
        public string Cards { get; set; }

        public string ConfirmarLogin { get; set; }

        public string ConfirmarSenhar { get; set; }
    }
}
