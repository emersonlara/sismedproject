using System.ComponentModel.DataAnnotations;

namespace Cooperchip.MedicalManagement.Domain.Entidade;

public class Alergia
{

    [Key]
    public int AlergiaId { get; set; }

    [Required(ErrorMessage = "Campo {0} requerido.")]
    [Display(Name = "Alergia")]
    [MaxLength(30, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
    public string Descricao { get; set; }

}
