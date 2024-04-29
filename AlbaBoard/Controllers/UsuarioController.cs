using AlbaBoard.Models;
using AlbaBoard.Repositorio;
using Microsoft.AspNetCore.Mvc;
using static AlbaBoard.Models.UsuarioModel;
using static AlbaBoard.Models.UsuarioSemSenhaModel;


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

        public IActionResult Editar(int Id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(Id);
            return View(usuario);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _usuarioRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Usuario Apagado com Sucesso";

                }
                else
                {
                    TempData["MensagemErro"] = $"Ao deletar o usuario ocorreu um erro, tente novamente";

                }
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ao deletar o usuario ocorreu um erro, tente novamente, mais detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        //[HttpPost]
        //public IActionResult Criar(UsuarioModel usuario)
        //{
        //    try
        //    {
        //        // Validação manual
        //        if (!IsValidUsuario(usuario))
        //        {
        //            // Se o usuário não for válido, retorne a view com o modelo inválido
        //            return View(usuario);
        //        }

        //        // Se o usuário for válido, adicione-o ao repositório
        //        usuario = _usuarioRepositorio.Adicionar(usuario);

        //        TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso";
        //        return RedirectToAction("Index");
        //    }
        //    catch (System.Exception erro)
        //    {
        //        TempData["MensagemErro"] = $"O cadastro do usuário falhou. Detalhes do erro: {erro.Message}";
        //        return RedirectToAction("Index");
        //    }
        //}

        private bool IsValidUsuario(UsuarioModel usuario)
        {
            // Aqui você pode implementar suas próprias regras de validação para o objeto UsuarioModel
            // Por exemplo, você pode verificar se os campos obrigatórios foram preenchidos
            // e se os dados estão dentro de faixas aceitáveis.

            if (string.IsNullOrEmpty(usuario.Name) || string.IsNullOrEmpty(usuario.Email))
            {
                // Se o nome ou o email do usuário estiverem vazios, o usuário é inválido
                ModelState.AddModelError("", "O nome e o email do usuário são obrigatórios.");
                return false;
            }

            // Outras regras de validação...

            // Se todas as regras de validação passarem, o usuário é considerado válido
            return true;
        }

        [HttpPost]
        public IActionResult Criar(UsuarioDto usuarioDt)
        {
            try
            {
                var usuario = new UsuarioModel(usuarioDt.Name, usuarioDt.Login, usuarioDt.Email, usuarioDt.Senha, usuarioDt.DataCadastro);
                if (!ModelState.IsValid)
                    return View(usuario);
                usuario = _usuarioRepositorio.Adicionar(usuario);
                TempData["MensagemSucesso"] = "Usuario Cadastrado com Sucesso";
                return Redirect("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] =
                    $"O cadastro do Usuario falhou, tente novamente, detalhe do erro: {erro.Message} ";
                return Redirect("Index");
            }

        }
        [HttpPost]
        public IActionResult Alterar(UsuarioSemSenhaModel UsuarioSemSenhaModel)
        {
            try
            {

                UsuarioModel usuario = null;

                // Crie uma nova instância de UsuarioModel
                usuario = new UsuarioModel()
                {
                    Id = UsuarioSemSenhaModel.Id,
                    Name = UsuarioSemSenhaModel.Name,
                    Login = UsuarioSemSenhaModel.Login,
                    Email = UsuarioSemSenhaModel.Email,
                    // Verifica o valor do perfil e atribui "admin", "padrão" ou "default" conforme necessário
                    Perfil = UsuarioSemSenhaModel.Perfil
                };

                // Tente atualizar o usuário no repositório
                usuario = _usuarioRepositorio.Atualizar(usuario);
                TempData["MensagemSucesso"] = "Usuario foi alterado com Sucesso";

                return RedirectToAction("Index");
            }

            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"A alteração do usuario falhou, tente novamente, detalhe do erro: {erro.Message} ";
                return RedirectToAction("Index");
            }
        }

    }
}