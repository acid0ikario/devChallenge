using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.Validations
{
    public class ItemsValidations : AbstractValidator<ItemsDTO>
    {
        public ItemsValidations()
        {
            RuleFor(x => x.description)
                .NotEmpty()
                .WithMessage("La descripcion no puede ser nula");

            RuleFor(x => x.price)
                .NotEmpty()
                .WithMessage("El precio no puede quedar en blanco")
                .GreaterThan(0)
                .WithMessage("El precio del producto debe ser mayor a 0");

            RuleFor(x => x.qty)
                .NotEmpty()
                .WithMessage("la cantidad no puede ser vacia");

        }
    }
}
