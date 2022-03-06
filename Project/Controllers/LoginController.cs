using Microsoft.AspNetCore.Mvc;
using System;
using Project.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Project.Data;
using Project.Services;
using System.Linq;

namespace Project.Controllers
{
    public class LoginController : Controller
    {
        private readonly UsuarioService _usuarioService;

        public LoginController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        public ActionResult Login(string email, string senha)
        {
            string messager = string.Empty;
            bool is_action = false;
            string url = string.Empty; 

            try
            {
                if (string.IsNullOrWhiteSpace(email))
                    throw new Exception("Informe o E-mail corretamente.");
                if (string.IsNullOrWhiteSpace(senha))
                    throw new Exception("Informe a Senha corretamente.");

                if (_usuarioService.GetLogin(email,senha))
                {

                    var user = _usuarioService.GetUser(email, senha);

                    HttpContext.Session.SetString("SessionUser", JsonConvert.SerializeObject(user));

                    is_action = true;
                    url = Url.Action("Index", "Dashboard");
                    messager = "Login efetuado com sucesso.";
                }
                else
                    throw new Exception("Não foi possivel efetuar o login, verifique o E-mail e Senha.");
            }
            catch (Exception ex)
            {

                messager = ex.Message;
            }

            return Json(new { is_action, messager, url = string.IsNullOrEmpty(url) ? Url.Action("Index", "Login") : url });
        }

        public ActionResult Sair()
        {
            string messager = string.Empty;
            bool is_action = false;
            string url = string.Empty; ;

            try
            {

                HttpContext.Session.SetString("SessionUser", string.Empty);
                is_action = true;
                url = Url.Action("Index", "Login");

            }
            catch (Exception ex)
            {
                messager = ex.Message;
            }

            return Json(new { is_action, messager, url = string.IsNullOrEmpty(url) ? Url.Action("Index", "Login") : url });
        }
    }
}