using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerStore.Models
{
    public class Order
    {
        [Display(Name = "Код")]
        public int Id { get; set; }
        [Display(Name = "Заказчик")]
        public string UserId { get; set; }
        public int ItemId { get; set; }
        [Display(Name = "Кол-во")]
        public int Quantity { get; set; }
        [Display(Name = "Адрес доставки")]
        [Required(ErrorMessage = "Необходимо указать адрес доставки")]
        public string Address { get; set; }
        [Display(Name = "Курьер")]
        public string CourierId { get; set; }
        [Display(Name = "Время заказа")]
        public DateTime Datetimeorderplaced { get; set; }
        [Display(Name = "Время доставки")]
        public DateTime Datetimeorderdelivered { get; set; }

        [Display(Name = "Статус")]
        [NotMapped]
        public string Status { get; set; }

        [NotMapped]
        public int Position { get; set; }
        public Item Item { get; set; }
    }
}
