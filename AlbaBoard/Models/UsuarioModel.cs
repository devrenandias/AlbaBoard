using AlbaBoard.Enums;
using System.ComponentModel.DataAnnotations;

namespace AlbaBoard.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do usuario")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Digite o login do usuario")]
        public string Login { get; set; }
      
        [Required(ErrorMessage = "Digite o email do usuario")]
        [EmailAddress(ErrorMessage = "O Email informado não é valido")]
        public string Email { get; set; }
    

        [Required(ErrorMessage = "Digite o Perfil do usuario")]
        public PerfilEnum? Perfil { get; set; }
        public string Senha { get; set; }
        [Required(ErrorMessage = "Digite a senha do usuario")]

        //Para ver quando ele foi criado 
        public DateTime DataCadastro { get; set; }


        //Para ver quando ele foi atualizado (Não obrigatoria)
        public DateTime? DataAlteracao { get; set; }

        public bool SenhaValida(string senha)
        {
            
            return senha == senha;
        }


        public UsuarioModel(string name, string login, string email, string senha, DateTime dataCadastro)
        {
            Name = name;
            Login = login;
            Email = email;
            Perfil = PerfilEnum.Admin;
            Perfil = PerfilEnum.Padrao;
            Senha = senha;
            DataCadastro = dataCadastro;
        }

        public UsuarioModel()
        {
        }

        public class UsuarioDto
        {
            public string Name { get; set; }
            public string Login { get; set; }
            public string Email { get; set; }
            public PerfilEnum Perfil { get; set; }
            public string Senha { get; set; }
            public DateTime DataCadastro { get; set; }
        }

        
    }
}
