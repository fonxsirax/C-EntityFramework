using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MagicTournament.Models
{
    public class UserModel
    {
        public UserModel(string Login, string Senha) {
            this.Login = Login;
            this.Senha = Senha;
        }
        [Key]
        public int ID { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
