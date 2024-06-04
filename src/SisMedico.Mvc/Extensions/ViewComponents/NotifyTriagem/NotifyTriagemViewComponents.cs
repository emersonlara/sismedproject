using Microsoft.EntityFrameworkCore;
using SisMedico.Domain.Entities;
using SisMedico.InfraData.ORM;
using SisMedico.Mvc.Extensions.ViewComponents.Helpers;

namespace SisMedico.Mvc.Extensions.ViewComponents.NotifyTriagem;


[ViewComponent(Name = "NotifyTriagem")]
public class NotifyTriagemViewComponents : ViewComponent
{
    private readonly ITDeveloperDbContext _context;

    public NotifyTriagemViewComponents(ITDeveloperDbContext context)
    {
        _context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        ViewBag.Total = Util.TotNotifyEvents(_context);
        var notificacoes = await _context.Set<Triagem>().AsNoTracking().OrderBy(x => x.DataNotificacao).Take(7).ToListAsync();
       
        return View(await Task.FromResult(notificacoes));
    }
}
