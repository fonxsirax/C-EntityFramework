using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MagicTournament.Models;
using MtgApiManager.Lib.Service;
using MagicTournament.ViewModel;
using MtgApiManager.Lib.Model;
using MagicTournament.Data;
using MagicTournament.API;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Web;

namespace MagicTournament.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserContext _db;
        private IConfiguration _config;

        public HomeController(UserContext dbContext, IConfiguration config)
        {
            _db = dbContext;
            _config = config;
        }

        public IActionResult Index()
        {
            return View();
        }
        ///teste
        ///

        public ActionResult Logar()
        {
            //var currentUser = HttpContext.User;
            //if (currentUser.HasClaim(c => c.Type == ClaimTypes.Email))
            //{
            //    string name = currentUser.Claims.FirstOrDefault(c => c.ValueType == "ClaimLogin").Value;
            //    ViewData["Message"] = "Usuario" + name + " logado.";
            //}
            //else
            //{
                ViewData["Message"] = "Nenhum Usuario logado.";
            //}
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Logar(LoginVMcs model)
        {
            ActionResult response = Unauthorized();
            var user = Authenticate(model);

            if (user != null)
            {
                var tokenString = BuildToken(user);
                response = Ok(new { token = tokenString });
                ViewData["Message"] = "Usuario logado, Token = " + tokenString;
                return View();
            }
            else
            {
                ViewData["Message"] = "Usuario ou senha inválidos";
            }
            var userwfe = HttpContext.User;
            return View();
        }
        [HttpGet]
        public ActionResult ExibirDecks()
        {
            string id = TempData["IDUSER"].ToString();
            TempData["IDUSER"] = id;
            LoginVMcs model = new LoginVMcs();

            List<Deck> listadedecks = _db.deck.Where(u => u.IdUser == Convert.ToInt32(id)).ToList();
            model.decks = listadedecks;

            return View(model);
        }

        [HttpPost]
        public ActionResult ExibirDecks(LoginVMcs model)
        {

            return View();
        }
        ///
        //////////////METODOS PARA PERFORMAR LOGIN UTILIZANDO JWT

        private UserModel Authenticate(LoginVMcs login)
        {
            UserModel user = null;
            //verificando se o login e senha estao certos
            var tempUser = _db.usertable.FirstOrDefault(u => u.Login == login.Login && u.Senha == login.Senha);
            if (tempUser != null)
            {
                TempData["IDUSER"] = tempUser.ID;
                user = new UserModel(login.Login, null);

            }
            return user;
        }
        private string BuildToken(UserModel user)
        {
            //Informacoes uteis
            var claims = new[] {
                new Claim("ClaimLogin", user.Login),
                new Claim(JwtRegisteredClaimNames.Email, "abcdef"),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        ////////////////////////////////////////////////////////////////////////////
        [HttpGet]
        public ActionResult Search(string SearchCard)
        {
            return View("Teste", SearchCard);
        }
        [HttpGet]
        public ActionResult Teste()
        {
            IndexVM model = new IndexVM();
            model.CardName = "Ornithopter";

            return View(model);
        }

        [HttpPost]
        public ActionResult Teste(IndexVM model)
        {
            ApiCardLoader api = new ApiCardLoader();
            CardModelForApi card =  api.LoadCardsByName(model.CardName);

            if (card != null)
            {
                TempData["URL"] = card.imageUrl;
            }
            else
            {
                TempData["ERRO"] = "Card não encontrado";

            }

            return View();
        }


        //public async string GetCard() {
        //    ApiCardLoader loader = new ApiCardLoader();

        //    CardModelForApi card = await loader.LoadCardsByNumber("Ornithopter");

        //}


        [Authorize]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Pagina de contato";

            return View();
        }

        public ActionResult CreateLogin() {

            return View();
        }
        [HttpPost]
        public ActionResult CreateLogin(CreateLoginVMcs model)
        {
            if ((model.Senha == model.ConfirmarSenha) && (model.Login.Length > 0 && model.Login.Length < 19) && (model.Senha.Length > 0 && model.Senha.Length < 14))
            {
                //insert a new user.

                UserModel entity = new UserModel(model.Login, model.Senha);
                _db.usertable.Add(entity);

                var query = _db.usertable
                            .Where(s => s.Login == model.Login);

                if (query.Count() == 0)
                {
                    try
                    {
                        _db.SaveChanges();
                        ViewData["Message"] = "Login " + model.Login + " criado com sucesso!";
                        return View();
                    }
                    catch (Exception e)
                    {
                        ViewData["Message"] = "Foi encontrado algum problema.";
                        return View();
                    }
                }
                else {
                    ViewData["Message"] = "Usuario ja existente.";
                    return View();
                }
            }
            else {
                ViewData["Message"] = "Foi encontrado algum problema, verifique o numero de caracteres do seu login";
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
