using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicTournament.Models
{
    public class CardModelForApi
    {
        public string name { get; set; }
        public string names { get; set; }
        public string manaCost { get; set; }
        public double cmc { get; set; }
        public string imageUrl { get; set; }

        public static explicit operator CardModelForApi(Task<CardModelForApi> v)
        {
            throw new NotImplementedException();
        }
        //public char colorIdentity { get; set; }
        //public int type { get; set; }
        //public string supertypes { get; set; }  //creature enchantment etc
        //public string types { get; set; } // goblin, elf, legend
        //public string subtypes { get; set; }
        //public string rarity { get; set; } // "SOI"
        //public string set { get; set; }
        //public string text { get; set; }
        //public string artist { get; set; }
        //public string number { get; set; }
        //public string power { get; set; }
        //public string toughness { get; set; }
        //public string layout { get; set; }
        //public int multiverseid { get; set; }



    }
}
