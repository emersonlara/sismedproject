using SisMedico.InfraData.ORM;
using SisMedico.Mvc.Extensions.ViewComponents.Helpers;

namespace SisMedico.Mvc.Extensions.ViewComponents.EstadoPaciente;


public class EstadoObservacaoViewComponents : ViewComponent
{
    private readonly ITDeveloperDbContext _context;
    public EstadoObservacaoViewComponents(ITDeveloperDbContext context)
    {
        _context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var totalGeral = Util.TotReg(_context);
        decimal totalEstado = Util.GetNumRegEstado(_context, "Observação");

        decimal progress = totalEstado * 100 / totalGeral;
        var prct = progress.ToString("F1");

        var model = new ContadorEstadoPaciente()
        {
            Titulo = "Pacientes em Observação",
            Parcial = (int)totalEstado,
            Percentual = prct,
            ClassContainer = "panel panel-default tile panelClose panelRefresh",
            IconeLg = "l-banknote",
            IconeSm = "fa fa-arrow-circle-o-down s20 mr5 pull-left",
            Progress = progress
        };

        return View(model);
    }

}
