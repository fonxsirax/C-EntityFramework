using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MagicTournament.Models;

namespace MagicTournament.ViewModel
{
    public class LoginVMcs
    {
        [Key]
        public int ID { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }


        public List<Deck> decks { get; set; }
    }
}
