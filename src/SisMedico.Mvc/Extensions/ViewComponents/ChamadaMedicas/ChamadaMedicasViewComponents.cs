using Microsoft.EntityFrameworkCore;
using SisMedico.Domain.Entities;
using SisMedico.InfraData.ORM;
using SisMedico.Mvc.Extensions.ViewComponents.Helpers;

namespace SisMedico.Mvc.Extensions.ViewComponents.ChamadaMedicos;


[ViewComponent(Name = "ChamadaMedicas")]
public class ChamadaMedicasViewComponents : ViewComponent
{
    private readonly ITDeveloperDbContext _context;

    public ChamadaMedicasViewComponents(ITDeveloperDbContext context)
    {
        _context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        ViewBag.Total = Util.TotChamadaMedico(_context);
        var notificacoes = await _context.Set<ChamadaMedica>().AsNoTracking().OrderBy(x => x.ChamadaMedicoId).Take(7).ToListAsync();
       
        return View(await Task.FromResult(notificacoes));
    }
}
