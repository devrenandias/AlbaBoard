using AlbaBoard.Data;
using AlbaBoard.Models;

namespace AlbaBoard.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;

        //Injetando itens
        public UsuarioRepositorio(BancoContext bancoContext)
        {
            //Injeção de Dependencia
            _bancoContext = bancoContext;
        }
        public UsuarioModel BuscarPorLogin(string Login)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == Login.ToUpper());
        }


        public UsuarioModel ListarPorId(int id)
        {
            return _bancoContext.Usuarios.FirstOrDefault( x => x.Id == id);
        }
     
        public List<UsuarioModel> BuscarTodos()
        {
            return _bancoContext.Usuarios.ToList();
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            //Inserção do cliente no Banco de Dados de VEZ
            _bancoContext.Usuarios.Add(usuario);

            //Comitando a info
            _bancoContext.SaveChanges();
            return usuario;
        }

        //Atualizando o contato
        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = ListarPorId(usuario.Id);
            if (usuarioDB == null) throw new System.Exception("Houve um erro na atualização do usuario");

            usuarioDB.Name = usuario.Name;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Login = usuario.Login;
            usuarioDB.DataAlteracao = DateTime.Now;
            usuarioDB.Perfil = usuario.Perfil;

            _bancoContext.Usuarios.Update(usuarioDB);
            _bancoContext.SaveChanges();

            return usuarioDB;
        }

        public bool Apagar(int Id)
        {
            UsuarioModel usuarioDB = ListarPorId(Id);
            if (usuarioDB == null) throw new System.Exception("Houve um erro na exclusão do usuario"); 

            _bancoContext.Usuarios.Remove(usuarioDB);

            _bancoContext.SaveChanges();
            return true;
        }

       
    }
}
