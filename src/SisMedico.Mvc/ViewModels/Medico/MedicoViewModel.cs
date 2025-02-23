﻿using System.ComponentModel.DataAnnotations;

namespace SisMedico.Mvc.ViewModels.Medico
{
    public class MedicoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Nome do Médico")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(80, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Nome { get; set; }

        [Display(Name = "CRM")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(10, ErrorMessage = "O campo {0} deve ter, no máximo, {1} caracteres.")]
        public string Crm { get; set; }

        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DataType(DataType.Date, ErrorMessage = "Data inválida.")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }

        // Alterado para armazenar os IDs das especialidades
        public List<Guid> EspecialidadesIds { get; set; }

        public List<string> EspecialidadesDescricoes { get; set; }

    }


    public class EspecialidadeViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Descrição")]
        [StringLength(50, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Descricao { get; set; }


    }

}
