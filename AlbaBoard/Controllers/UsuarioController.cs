using AlbaBoard.Models;
using AlbaBoard.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace AlbaBoard.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        //Construtor
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarTodos();
            return View(usuarios);
        }

        public IActionResult Criar()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuario= _usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuario Cadastrado com Sucesso";
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"O cadastro do Usuario falhou, tente novamente, detalhe do erro: {erro.Message} ";
                return RedirectToAction("Index");

            }

        }

    }
}
