
using SisMedico.Domain.Base;
using SisMedico.Domain.ValueObjects;

namespace SisMedico.Domain.Entities;

public class Author : EntityBase
{
    public Author() { }
    public Author(string name, string lastName, string emailAddres, string website, RedesSociais redesSociais)
    {
        Name = name;
        LastName = lastName;
        EmailAddress = emailAddres;
        RedesSociais = redesSociais;
        WebSite = website;
        // Validar
    }

    public string Name { get; private set; }
    public string LastName { get; private set; }
    public string EmailAddress { get; private set; }
    public string WebSite { get; private set; }

    // VO
    public RedesSociais RedesSociais { get; private set; }

    public virtual ICollection<Tags> Tags { get; set; }


}
