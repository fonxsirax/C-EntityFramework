using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagicTournament.Data;
using MagicTournament.Models;
using MagicTournament.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace MagicTournament.Controllers
{
    public class CreateDeckController : Controller
    {
        private readonly UserContext _db;
        private IConfiguration _config;

        public CreateDeckController(UserContext dbContext, IConfiguration config)
        {
            _db = dbContext;
            _config = config;
        }
        public ActionResult CreateDeck()
        {
            string id = TempData["IDUSER"].ToString();
            TempData["IDUSER"] = id;
            return View();
        }

        [HttpPost]
        public ActionResult CreateDeck(CreateDeckVM model)
        {
            string id = TempData["IDUSER"].ToString();
            TempData["IDUSER"] = id;
            Deck deckuser = new Deck() { IdUser = Convert.ToInt32(id), Titulo = model.Deckname, Formato = model.Formato, Cards = model.Cards };
            _db.deck.Add(deckuser);

            try
            {
                _db.SaveChanges();
                ViewData["Message"] = "Deck Cadastrado";
            }
            catch (Exception e)
            {
                ViewData["Message"] = "Ocorreu algum error, tente novamente mais tarde.";
            }

            return View();
        }
    }
}
