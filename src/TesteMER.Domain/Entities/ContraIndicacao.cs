using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cooperchip.MedicalManagement.Domain.Entidade;

public class ContraIndicacao
{

    [Key]
    [Display(Name ="ID")]
    public int ContraIndicacaoId { get; set; }

    [Required]
    [MaxLength(2000)]
    [Display(Name ="DESCRIÇÃO")]
    public string Descricao { get; set; }

    [Required]
    [ForeignKey("Generico")]
    [Display(Name ="GENÉRICO")]
    public int IdGenerico { get; set; }

    public virtual Generico Generico { get; set; }
}
