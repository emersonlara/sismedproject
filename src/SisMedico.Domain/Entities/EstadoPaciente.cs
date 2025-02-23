﻿using System.ComponentModel.DataAnnotations;
using SisMedico.Domain.Base;

namespace SisMedico.Domain.Entities
{
    public class EstadoPaciente : EntityBase
    {
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(maximumLength:20, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Descricao { get; set; }

        public virtual ICollection<Paciente> Paciente { get; set; }

    }
}
