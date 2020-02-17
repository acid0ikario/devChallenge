using ServiceStack.FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models.Validations;

namespace WebApi.Models
{
    [Validator(typeof(ItemsValidations))]
    public class ItemsDTO
    {
        public int sku { get; set; }
        public int qty { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }

    }
}
