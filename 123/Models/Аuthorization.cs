using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _123.Models
{
    public class Аuthorization
    {
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Ваш Email")]
        [Required(ErrorMessage = "Введите ваш Email ")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Введите пароль")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина пароля должна быть не менее 3 символов")]
        public string Password { get; set; }

    }
}