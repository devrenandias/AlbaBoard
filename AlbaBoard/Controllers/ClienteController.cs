using AlbaBoard.Models;
using AlbaBoard.Repositorio;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AlbaBoard.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        //Construtor
        public ClienteController(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }


        public IActionResult Index()
        {
           List<ClienteModel> clientes = _clienteRepositorio.BuscarTodos();
            return View(clientes);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            //buscando o ID certo para editar
            ClienteModel clientes = _clienteRepositorio.ListarPorId(id);
            return View(clientes);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ClienteModel clientes = _clienteRepositorio.ListarPorId(id);
            return View(clientes);
        }

        public IActionResult Apagar(int id) 
        {
            try
            {
                bool apagado = _clienteRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Cliente Apagado com Sucesso";

                }
                else
                {
                    TempData["MensagemErro"] = $"Ao deletar o cliente ocorreu um erro, tente novamente";

                }
                return RedirectToAction("Index");
            }        
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ao deletar o cliente ocorreu um erro, tente novamente, mais detalhes do erro: {erro.Message}";
                return  RedirectToAction("Index");
            }
        }

        //Metodo de Inclusão/Recebendo informações e cadastrando
        [HttpPost]
        public IActionResult Criar(ClienteModel cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clienteRepositorio.Adicionar(cliente);
                    TempData["MensagemSucesso"] = "Cliente Cadastrado com Sucesso";
                    return RedirectToAction("Index");
                }

                return View(cliente);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"O cadastro do Cliente falhou, tente novamente, detalhe do erro: {erro.Message} " ;
                return RedirectToAction("Index");

            }
         
        }

        [HttpPost]
        public IActionResult Alterar(ClienteModel cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _clienteRepositorio.Atualizar(cliente);
                    TempData["MensagemSucesso"] = "Cliente alterado com Sucesso";

                    return RedirectToAction("Index");
                }
                return View("Editar", cliente);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"A alteração do Cliente falhou, tente novamente, detalhe do erro: {erro.Message} ";
                return RedirectToAction("Index");
            }
        }

    }
}
