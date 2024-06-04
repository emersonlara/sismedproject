namespace SisMedico.Domain.ValueObjects;

public class RG : ValueObject
{

    public RG(){}
    public RG(string numero, 
              string orgaoExpedidor,
              string dataExpedicao)
    {
        Numero = numero;
        OrgaoExpedidor = orgaoExpedidor;
        DataExpedicao = dataExpedicao;
    }
    public string Numero { get; private set; }
    public string OrgaoExpedidor { get; private set; }
    public string DataExpedicao { get; private set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {            
        yield return Numero;
        yield return OrgaoExpedidor;
        yield return DataExpedicao;
    }
}
