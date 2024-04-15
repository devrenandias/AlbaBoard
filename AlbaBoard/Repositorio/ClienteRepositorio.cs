using AlbaBoard.Data;
using AlbaBoard.Models;

namespace AlbaBoard.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly BancoContext _bancoContext;

        //Injetando itens
        public ClienteRepositorio(BancoContext bancoContext)
        {
            //Injeção de Dependencia
            _bancoContext = bancoContext;
        }

        public ClienteModel ListarPorId(int id)
        {
            return _bancoContext.Clientes.FirstOrDefault( x => x.Id == id);
        }

        public List<ClienteModel> BuscarTodos()
        {
            return _bancoContext.Clientes.ToList();
        }

        public ClienteModel Adicionar(ClienteModel cliente)
        {
            //Inserção do cliente no Banco de Dados de VEZ
            _bancoContext.Clientes.Add(cliente);

            //Comitando a info
            _bancoContext.SaveChanges();
            return cliente;
        }

        //Atualizando o contato
        public ClienteModel Atualizar(ClienteModel cliente)
        {
            ClienteModel clienteDB = ListarPorId(cliente.Id);
            if (clienteDB == null) throw new System.Exception("Houve um erro na atualização do cliente");

            clienteDB.Name = cliente.Name;
            clienteDB.Email = cliente.Email;
            clienteDB.Celular = cliente.Celular;

            _bancoContext.Clientes.Update(clienteDB);
            _bancoContext.SaveChanges();

            return clienteDB;
        }

        public bool Apagar(int Id)
        {
            ClienteModel clienteDB = ListarPorId(Id);
            if (clienteDB == null) throw new System.Exception("Houve um erro na exclusão do cliente"); 

            _bancoContext.Clientes.Remove(clienteDB);

            _bancoContext.SaveChanges();
            return true;
        }
    }
}
