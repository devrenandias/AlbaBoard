using AlbaBoard.Enums;
using System.ComponentModel.DataAnnotations;

namespace AlbaBoard.Models
{
    public class UsuarioSemSenhaModel
    {
        [Required(ErrorMessage = "O campo Id é obrigatório.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo Login é obrigatório.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo Email deve ser um endereço de email válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Perfil é obrigatório.")]
        public PerfilEnum Perfil { get; set; }

      
    }
}
