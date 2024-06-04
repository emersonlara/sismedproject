using SisMedico.Domain.Base;

namespace SisMedico.Domain.Entities;

public class Tags : EntityBase
{
    public Tags()
    {

    }

    public string Tag { get; set; }

    /// <summary>
    /// Descrição diversa sobre a anotação, como link, Título, etc.
    /// </summary>
    public string Note { get; set; }

    /// <summary>
    /// Campo reservado para dizer onde 
    /// está ou de onde veio, etc
    /// </summary>
    public string SourceAt { get; set; }

    public virtual Author Author { get; set; }

    public Guid AuthorId { get; set; }


}
