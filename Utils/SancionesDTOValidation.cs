using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehiculosAspNetC.DTOs;

namespace VehiculosAspNetC.Utils
{
    public class SancionesDTOValidation: AbstractValidator<SancionesDTO>
    {
        public SancionesDTOValidation()
        {
            RuleFor(s => s.ConductorId).NotEmpty()
                .WithMessage("Identificación conductor obligatoria")
                .MaximumLength(15).WithMessage("Excede los 15 caracteres");
        }

    }
}
