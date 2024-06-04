
using SisMedico.Domain.Interfaces;
using SisMedico.Mvc.Models;
using KissLog;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace SisMedico.Mvc.Controllers
{
    //[Authorize]
    [Route("")]
    [Route("gestao-de-paciente")]
    [Route("gestao-de-pacientes")]
    public class HomeController : Controller
    {
        private readonly IEmailSender _emailSender;
        private readonly IKLogger _logger;
        private readonly IUserInContext _user;

        public HomeController(IEmailSender emailSender,
                              IKLogger logger,
                              IUserInContext user)
        {
            _emailSender = emailSender;
            _logger = logger;
            this._user = user;
        }

        [Route("")]
        [Route("pagina-inicial")]
        public IActionResult Index()
        {
            UserModel model = new()
            {
                Nome = _user.Name,
                Apelido = _user.GetUserApelido(),
                imgFoto = _user.GetUserImgProfilePath(),
                NomeCompleto = _user.GetUserNomeCompleto(),
                UserId = _user.GetUserId()
            };
              return View(model);
        }

        public class UserModel
        {
            public string Nome { get; set; }
            public string Apelido { get; set; }
            public string imgFoto { get; set; }
            public string NomeCompleto { get; set; }
            public Guid UserId { get; set; }
        }


        //[Authorize(Roles = "Admin")]
        [Route("dashboard")]
        [Route("pagina-de-estatistica")]
        public IActionResult Dashboard()
        {

            var email = "";

            //if (User.Identity.IsAuthenticated) { }
            // posso fazer assim também, com o Return aqui  
            // e sem o _user (neste projeto)}

            IDictionary<string, string> minhasClaims = new Dictionary<string, string>();

            if (_user.IsAuthenticated())
            {
                // Posso pegar a Claim Com Type Apelido assim, sem método de extensão
                // Esse 'Apelido' em hard-code aqui está totalmente fora de questão
                // Sem contar que se eu NÃO puder usar os mesmos métodos em qualquer lugar
                // fere o princípio DRY (Don't Repeat yourself) - Não se repita.
                var apelido = User.FindFirst(x => x.Type == "Apelido")?.Value;
                email = User.FindFirst(e => e.Type == "Email")?.Value;

                minhasClaims.Add("Apelido", _user.GetUserApelido());
                minhasClaims.Add("Nome Completo", _user.GetUserNomeCompleto());
                minhasClaims.Add("Imagem do Perfil", _user.GetUserImgProfilePath());
                minhasClaims.Add("Id", _user.GetUserId().ToString());
                minhasClaims.Add("Nome", _user.Name);
                minhasClaims.Add("Email", _user.GetUserEmail());
                minhasClaims.Add("E Administrador", _user.IsInRole("Admin") ? "SIM" : "NÃO");

                var testeUserClaims = minhasClaims;

                var nome = minhasClaims["Nome"];
                email = minhasClaims["Email"];
                var EhAdministrador = minhasClaims["E Administrador"];

            }

            return View();
        }

        [AllowAnonymous]
        [Route("box-init")]
        public IActionResult BoxInit()
        {
            return View();
        }



        [Route("quem-somos")]
        [Route("sobre-nos")]
        [Route("sobre/{id:guid}/{paciente}/{categoria?}")]
        public IActionResult Sobre(Guid id, string paciente, string categoria)
        {
            return View();
        }

        [HttpGet("fale-conosco")]
        //[Route("fale-conosco")]
        public IActionResult Contato()
        {
            return View();
        }

        [HttpPost]
        [Route("fale-conosco")]
        public async Task<IActionResult> Contato(ContatoViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _emailSender.SendEmailAsync(model.Email, model.Subject, model.Message);
                    _logger.Log(KissLog.LogLevel.Information, "Email enviado com sucesso!");
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception e)
                {
                    _logger.Log(KissLog.LogLevel.Error, $"Erro tntando enviar emal: {e.Message}");
                    throw;
                }
            }


            return View();
        }


        [Route("privacidade")]
        [Route("politica-de-privacidade")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("erro")]
        [Route("erro-encontrado")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
