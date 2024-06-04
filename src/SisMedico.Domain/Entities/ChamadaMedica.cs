using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisMedico.Domain.Entities;

[Table("ChamadaMedica")]
public class ChamadaMedica
{

    [Key]
    public int ChamadaMedicoId { get; set; }

    [Required(ErrorMessage = "Campo obrigatório.")]
    [MaxLength(150, ErrorMessage = "Máximo de 150 caracteres permitidos.")]
    public string Mensagem { get; set; }


    [Display(Name = "Data da Chamada")]
    [DataType(DataType.Date, ErrorMessage = "Data Inválida.")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime DataChamada { get; set; }


    [Display(Name = "Médico(a)")]
    [Required(ErrorMessage = "Campo obrigatório.")]
    [MaxLength(80, ErrorMessage = "Máximo de 80 caracteres!")]
    public string Medico { get; set; }


    [Required(ErrorMessage = "Campo obrigatório.")]
    [MaxLength(10, ErrorMessage = "Máximo de 10 caracteres!")]
    public String Leito { get; set; }

}
