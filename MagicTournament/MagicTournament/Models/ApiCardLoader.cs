using MagicTournament.API;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MagicTournament.Models
{
    public class ApiCardLoader
    {
        public int MAX { get; set; }
        public CardModelForApi LoadCardsByName(string name) {
            string url = "https://api.magicthegathering.io/v1/cards?name=" + name;

            CardModelForApi card = null;
            
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string responseString = response.Content.ReadAsStringAsync().Result;
                    CardResponseModel model = JsonConvert.DeserializeObject<CardResponseModel>(responseString);
                    card = model.cards.FirstOrDefault();
                }
            }

            return card;
        } 
    }
    public class CardResponseModel
    {
        public List<CardModelForApi> cards { get; set; }
    }
}
