using SisMedico.InfraData.ORM;
using SisMedico.Mvc.Extensions.ViewComponents.Helpers;

namespace SisMedico.Mvc.Extensions.ViewComponents.EstadoPaciente;

[ViewComponent(Name = "EstadoPaciente")]
public class EstadoPacienteViewComponents : ViewComponent
{
    private readonly ITDeveloperDbContext _context;
    public EstadoPacienteViewComponents(ITDeveloperDbContext context)
    {
        _context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync(string status, string titulo)
    {
        var totalGeral = Util.TotReg(_context);
        decimal totalEstado = Util.GetNumRegEstado(_context, status);

        var classContainer = string.Empty;
        var iconeLg = string.Empty;
        var iconeSm = string.Empty;

        switch (status.ToUpper())
        {
            case "CRÍTICO":
                classContainer = "panel panel-info tile panelClose panelRefresh";
                iconeLg = "l-basic-geolocalize-05";
                iconeSm = "fa fa-arrow-circle-o-up s20 mr5 pull-left";
                break;
            case "ESTÁVEL":
                classContainer = "panel panel-success tile panelClose panelRefresh";
                iconeLg = "l-ecommerce-cart-content";
                iconeSm = "fa fa-arrow-circle-o-up s20 mr5 pull-left";
                break;
            case "GRAVE":
                classContainer = "panel panel-danger tile panelClose panelRefresh";
                iconeLg = "l-basic-life-buoy";
                iconeSm = "fa fa-arrow-circle-o-down s20 mr5 pull-left";
                break;
            case "OBSERVAÇÃO":
                classContainer = "panel panel-default tile panelClose panelRefresh";
                iconeLg = "l-banknote";
                iconeSm = "fa fa-arrow-circle-o-down s20 mr5 pull-left";
                break;
            default:
                break;
        }

        decimal progress = totalEstado * 100 / totalGeral;
        var prct = progress.ToString("F1");

        var model = new ContadorEstadoPaciente()
        {
            Titulo = titulo,
            Parcial = (int) totalEstado,
            Percentual = prct,
            ClassContainer = classContainer,
            IconeLg = iconeLg,
            IconeSm = iconeSm,
            Progress = progress
        };

        return await Task.FromResult(View(model));
    }
}
