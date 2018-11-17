using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Uklon_WebApplication.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter first point route")]
        [StringLength(120, MinimumLength = 5, ErrorMessage = "String length must be between  5 to 120")]
        public string AddressFrom { get; set; }
        [Required(ErrorMessage = "Enter last point route")]
        [StringLength(120, MinimumLength = 5, ErrorMessage = "String length must be between  5 to 120")]
        public string AddressTo { get; set; }
        [Required(ErrorMessage = "Enter phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^([\d.,-]+)$", ErrorMessage = "Only digit is allowed")]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "Number length must be 12 numbers")]
        public string Phone { get; set; }
        [RegularExpression(@"^([\d.,-]+)$", ErrorMessage = "Only digit is allowed")]
        public int Price { get; set; }
        public bool Canceled { get; set; }
    }
}
