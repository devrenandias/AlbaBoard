using System.ComponentModel.DataAnnotations;

namespace AlbaBoard.Models
{
    public class ClienteModel
    {
        //Validação de cadastro
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do cliente")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Digite o email do cliente")]
        [EmailAddress(ErrorMessage ="O Email informado não é valido")]
        public string Email { get; set;}
        [Required(ErrorMessage = "Digite o celular do cliente")]
        [Phone(ErrorMessage ="O Celular informado não é valido")]
        public string Celular { get; set;}

    }
}
