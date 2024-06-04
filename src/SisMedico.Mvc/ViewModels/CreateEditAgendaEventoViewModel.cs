using Microsoft.AspNetCore.Mvc.Rendering;
using SisMedico.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SisMedico.Mvc.ViewModels;

public class CreateEditAgendaEventoViewModel
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public Guid PacienteId { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public Guid MedicoId { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public Guid ConvenioId { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Title { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Description { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public DateTime Start { get; set; }

    public DateTime? End { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Color { get; set; }

    public Boolean AllDay { get; set; } = false;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public LocalExame LocalExame { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public TipoExame TipoExame { get; set; }

    public List<SelectListItem> Pacientes { get; set; }
    public List<SelectListItem> Medicos { get; set; }

    public List<SelectListItem> Convenios { get; set; }

    public List<SelectListItem> LocalExameOptions { get; set; }
    public List<SelectListItem> TipoExameOptions { get; set; }


    public string NomePaciente { get; set; }
    public string NomeMedico { get; set; }
    public string NomeConvenio { get; set; }


    public CreateEditAgendaEventoViewModel()
    {
        Pacientes = new List<SelectListItem>();
        Medicos = new List<SelectListItem>();
        Convenios = new List<SelectListItem>();
    }
}
