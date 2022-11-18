using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehiculosAspNetC.DTOs;

namespace VehiculosAspNetC.Utils
{
    public class MatriculasDTOValidation: AbstractValidator<MatriculasDTO>
    {
        public MatriculasDTOValidation()
        {
            RuleFor(s => s.Numero).NotEmpty()
                .WithMessage("Número de matricula Obligatorio")
                .MaximumLength(20).WithMessage("Máximo 20 caracteres");

            RuleFor(s => s.FechaExpedicion).NotEmpty()
                .WithMessage("Fecha expedición Obligatorio");

            RuleFor(s => s.FechaVencimiento).NotEmpty()
                .WithMessage("Fecha vencimiento Obligatorio");

        }
    }
}
