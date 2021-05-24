using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _123.Models
{
    public class PlacesModel
    {
        [Display(Name = "Название города")]
        [Required(ErrorMessage = "Введите название города ")]
        public string city { get; set; }

        [Display(Name = "Интересные места")]
        [Required(ErrorMessage = "Введите название места ")]
        public string place { get; set; }

        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Введите описание ")]
        public string description { get; set; }
    }
}