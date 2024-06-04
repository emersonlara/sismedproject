using SisMedico.Mvc.Models;


namespace SisMedico.Mvc.ViewComponents;

public class NavigationViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var items = NavigationModel.Full;

        return View(items);
    }
}
