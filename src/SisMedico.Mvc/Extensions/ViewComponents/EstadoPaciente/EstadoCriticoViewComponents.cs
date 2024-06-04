using SisMedico.InfraData.ORM;
using SisMedico.Mvc.Extensions.ViewComponents.Helpers;

namespace SisMedico.Mvc.Extensions.ViewComponents.EstadoPaciente;

[ViewComponent(Name = "EstadoCritico")]
public class EstadoCriticoViewComponents : ViewComponent
{
    private readonly ITDeveloperDbContext _context;
    public EstadoCriticoViewComponents(ITDeveloperDbContext context)
    {
        _context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var totalGeral = Util.TotReg(_context);
        decimal totalEstado = Util.GetNumRegEstado(_context, "Crítico");

        decimal progress = totalEstado * 100 / totalGeral;
        var prct = progress.ToString("F1");

        var model = new ContadorEstadoPaciente()
        {
            Titulo = "Pacientes Críticos",
            Parcial = (int) totalEstado,
            Percentual = prct,
            ClassContainer = "panel panel-info tile panelClose panelRefresh",
            IconeLg = "l-basic-geolocalize-05",
            IconeSm = "fa fa-arrow-circle-o-up s20 mr5 pull-left",
            Progress = progress
        };

        return await Task.FromResult(View(model));
    }
}
