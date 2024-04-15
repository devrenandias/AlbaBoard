using AlbaBoard.Models;

namespace AlbaBoard.Repositorio
{
    public interface IUsuarioRepositorio
    {
        //Listando dados do banco 
        List<UsuarioModel> BuscarTodos();

        //Buscar por ID
        UsuarioModel ListarPorId(int id);

        //Para Adicionar um novo cliente
        UsuarioModel Adicionar(UsuarioModel usuario);

        //Atualizar
        UsuarioModel Atualizar(UsuarioModel usuario);


        //Apagar Cliente
        bool Apagar(int Id);
    }
}
