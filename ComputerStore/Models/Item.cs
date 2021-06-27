using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerStore.Models
{
    public class Item
    {
        public int Id { get; set; }
        [Display(Name = "Наименование")]
        public string Name { get; set; }
        [Display(Name = "Тип")]
        public string Type { get; set; }
        [Display(Name = "Цена")]
        public int Price { get; set; }
        [Display(Name = "Характеристики")]
        public string Characteristics { get; set; }
        [Display(Name = "Изображение")]
        public string PictureUrl { get; set; }
        public bool Visibility { get; set; } = true;
    }
}
