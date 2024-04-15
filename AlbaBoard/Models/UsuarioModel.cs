using AlbaBoard.Enums;
using System.ComponentModel.DataAnnotations;

namespace AlbaBoard.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        [Required(ErrorMessage = "Digite o nome do usuario")]

        public string Login {  get; set; }
        [Required(ErrorMessage = "Digite o login do usuario")]

        public string Email {  get; set; }
        [Required(ErrorMessage = "Digite o email do usuario")]
        [EmailAddress(ErrorMessage = "O Email informado não é valido")]

        public PerfilEnum Perfil { get; set; }


        public string Senha {  get; set; }
        [Required(ErrorMessage = "Digite a senha do usuario")]

        //Para ver quando ele foi criado 
        public DateTime DataCadastro { get; set; }


        //Para ver quando ele foi atualizado (Não obrigatoria)
        public DateTime? DataAlteracao { get; set; }



    }
}
