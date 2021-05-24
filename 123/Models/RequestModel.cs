using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _123.Models
{
    public class RequestModel
    {
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email человека котому вы хотите оставить заявку")]
        [Required(ErrorMessage = "Введите ваш Email ")]
        public string annemail { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Ваш Email")]
        [Required(ErrorMessage = "Введите ваш Email ")]
        public string email { get; set; }


        [Display(Name = "Ваш номер телефона")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Номер телефона должен состоять из 11 цифр")]
        public string phone { get; set; }

        [Display(Name = "Ваше имя")]
        [Required(ErrorMessage = "Введите вашe имя ")]
        public string name { get; set; }

        [Display(Name = "Ваша фамилия")]
        [Required(ErrorMessage = "Введите вашу фамилию ")]
        public string surname { get; set; }

        [Display(Name = "Ваш возраст")]
        [Range(18, 1000, ErrorMessage = "Вам должно быть больше 18 лет")]
        public int age { get; set; }

        [Display(Name = "Ваша заявка")]
        [Required(ErrorMessage = "Введите вашу заявку ")]
        public string request { get; set; }
    }
}