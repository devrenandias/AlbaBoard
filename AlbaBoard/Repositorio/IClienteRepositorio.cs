using AlbaBoard.Models;

namespace AlbaBoard.Repositorio
{
    public interface IClienteRepositorio
    {

        //Buscar por ID
        ClienteModel ListarPorId(int id);


        //Listando dados do banco 
        List<ClienteModel> BuscarTodos();


        //Para Adicionar um novo cliente
        ClienteModel Adicionar(ClienteModel cliente);

        //Atualizar
        ClienteModel Atualizar(ClienteModel cliente);


        //Apagar Cliente
        bool Apagar(int Id);
    }
}
