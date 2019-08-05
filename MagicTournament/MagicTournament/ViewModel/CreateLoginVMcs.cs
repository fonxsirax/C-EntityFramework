using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MagicTournament.ViewModel
{
    public class CreateLoginVMcs
    {
        [Key]
        public int ID { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string ConfirmarSenha {get;set;}
    }
}
