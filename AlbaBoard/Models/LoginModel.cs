﻿using System.ComponentModel.DataAnnotations;

namespace AlbaBoard.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Digite o Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite a senha")]
        public string senha { get; set; }
    }
}
