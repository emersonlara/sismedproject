

using SisMedico.Domain.Entities;

namespace SisMedico.Mvc.Extensions.ViewComponents.Paginacao;

public class PaginacaoViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(IPagedList modeloPaginado)
    {
        return View(modeloPaginado);
    }
}
