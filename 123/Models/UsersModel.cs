using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _123.Models
{
    public class UsersModel
    {
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Ваш Email")]
        [Required(ErrorMessage = "Введите ваш Email ")]
        public string Email { get; set; }

        
        [Display(Name = "Ваш номер телефона")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Номер телефона должен состоять из 11 цифр")]
        public string Phone { get; set; }

        [Display(Name = "Ваше имя")]
        [Required(ErrorMessage = "Введите вашe имя ")]
        public string name { get; set; }

        [Display(Name = "Ваша фамилия")]
        [Required(ErrorMessage = "Введите вашу фамилию ")]
        public string surname { get; set; }

        [Display(Name = "Ваш возраст")]
        [Range(18,1000, ErrorMessage ="Вам должно быть больше 18 лет")]
        public int age { get; set; }

        [Display(Name = "Ваш город")]
        [Required(ErrorMessage = "Введите ваш город ")]
        public string city { get; set; }

        [Display(Name = "Ваше объявление")]
        [Required(ErrorMessage = "Введите ваше объявлеине ")]
        public string announcement { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Введите пароль")]
        [StringLength(50, MinimumLength =3, ErrorMessage ="Длина пароля должна быть не менее 3 символов")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Повторите пароль")]
        [Compare("Password", ErrorMessage ="Пароли должны совпадать")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина пароля должна быть не менее 3 символов")]
        public string ConfirmPassword { get; set; }


    }
}