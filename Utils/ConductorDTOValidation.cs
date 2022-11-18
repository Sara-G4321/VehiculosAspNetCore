using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehiculosAspNetC.DTOs;

namespace VehiculosAspNetC.Utils
{
    public class ConductorDTOValidation: AbstractValidator<ConductorDTO>
    {
        public ConductorDTOValidation()
        {
            RuleFor(s => s.Identificacion).NotEmpty()
                .WithMessage("Identificación obligatoria")
                .MaximumLength(15).WithMessage("Excede los 15 caracteres");

            RuleFor(s => s.Nombre).NotEmpty()
                .WithMessage("Nombre obligatorio");

            RuleFor(s => s.Apellido).NotEmpty()
                .WithMessage("Apellido obligatorio");

            RuleFor(s => s.Email)
                .EmailAddress();

            RuleFor(s => s.MatriculaId).NotEmpty()
                .WithMessage("Campo obligatorio");
        }

    }
}
