namespace SisMedico.Domain.ValueObjects;

public class RedesSociais : ValueObject
{

    public RedesSociais(){}
    public RedesSociais(string facebook, 
                        string twitter,
                        string linkedin
                        )
    {
        Facebook = facebook;
        Twitter = twitter;
        Linkedin = linkedin;
    }
    public string Facebook { get; private set; }
    public string Twitter { get; private set; }
    public string Linkedin { get; private set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        // Using a yield return statement to return each element one at a time
        yield return Facebook;
        yield return Twitter;
        yield return Linkedin;
    }
}


