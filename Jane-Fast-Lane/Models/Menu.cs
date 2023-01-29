using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jane_Fast_Lane.Models
{
    public class Menu
    {
        public int Id { get; set; }

        [RegularExpression(@"^[А-Яа-я\s]{2,50}$", ErrorMessage = "От 2 до 50 букви на кирилица с или без интервали.")]
        [Display(Name = "Име на ястието")]
        public string Name { get; set; }

        [Display(Name = "Категория")]
        public string Category { get; set; }
        [Display(Name = "Грамаж")]

        public int Weight { get; set; }
        [Display(Name = "Кратко описание")]

        public string Summary { get; set; }
        [Display(Name = "Линк към изображение на ястието")]

        public string Image { get; set; }
        [Display(Name = "Цена (лв.)")]

        public double Price { get; set; }
    }
}
