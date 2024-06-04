using SisMedico.Mvc.Extensions.ViewComponents.Helpers;

namespace SisMedico.Mvc.Extensions.ViewComponents.Cabecalho;

[ViewComponent(Name = "Cabecalho")]
public class CabecalhoViewComponents : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(string titulo, string subtitulo)
    {
        var model = new Modulo()
        {
            Titulo = titulo,
            Subtitulo = subtitulo
        };

        return View(model);
    }
}
