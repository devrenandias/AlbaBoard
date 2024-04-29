using AlbaBoard.Models;
using AlbaBoard.Repositorio;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AlbaBoard.Controllers
{
    
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public LoginController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }



        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Login);



                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.senha))
                        {
                            return RedirectToAction("Index", "Home");

                        }
                        TempData["MensagemErro"] = $"A senha está invalida. Por favor, tente novamente.";

                    }

                }
                return View("Index");
            }
            catch (Exception erro) {
                TempData["MensagemErro"] = $"Não conseguimos realizar seu login, tente novamente {erro.Message} ";
                return View("Index");

            }
        }
    }
}
