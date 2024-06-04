using System.ComponentModel.DataAnnotations;
using SisMedico.Domain.Base;
using SisMedico.Domain.Enums;

namespace SisMedico.Domain.Entities
{
    public class AgendaEventos : EntityBase
    {
        public Guid PacienteId { get; set; }
        public Guid MedicoId { get; set; }
        public Guid ConvenioId { get; set; }

        [Display(Name = "Título")]
        //[Column(name: "Titulo")]
        public string Title { get; set; }


        [Display(Name = "Descrição")]
        //[Column(name: "Descricao")]
        public string Description { get; set; }

        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public string Color { get; set; }
        public Boolean AllDay { get; set; }


        public LocalExame LocalExame { get; set; }
        public TipoExame TipoExame { get; set; }


        public virtual Paciente Paciente { get; set; }
        public virtual Medico Medico { get; set; }
        public virtual Convenio Convenio { get; set; }

    }
}
