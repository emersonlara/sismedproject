using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SisMedico.Domain.Entities;
using SisMedico.Domain.Interfaces.Repository;
using SisMedico.InfraData.ORM;
using SisMedico.Mvc.Extensions;

namespace SisMedico.Mvc.Controllers;

//[Route("[Controller]")]
public class CidController : Controller
{

    // (Query) - Get ==> Fala dreto com a camada de Dados
    private readonly IRepositoryCid _repoCid;

    // Cuida do Mapeamento Model/ViewModel + Reverse,
    // antes de passar para Repositório ou Seviços de Domain
    private readonly IMapper _mapper;

    private readonly ITDeveloperDbContext _context;

    public CidController(ITDeveloperDbContext context,
                         IRepositoryCid repoCid)
    {
        _context = context;
        _repoCid = repoCid;
    }


    [HttpGet("cids-paginada")]
    public async Task<IActionResult> CidsPaginada([FromQuery] int pi = 1,
                                                  [FromQuery] int ps = 5,
                                                  [FromQuery] string q = null)
    {
        var model = await _repoCid.ObterTodosEFramework(pi, ps, q);
        ViewBag.Pesquisa = q;
        model.ReferenceAction = "CidsPaginada";
        return View(model);
    }


    [HttpGet("arquivo-invalido")]
    public IActionResult ArquivoInvalido()
    {
        TempData["ArquivoInvalido"] = "O Arquivo não é válido!";
        return View();
    }


    [HttpPost("importa-cid")]
    public async Task<IActionResult> ImportCid(IFormFile file, [FromServices] IWebHostEnvironment webHostEnvironment)
    {
        // DRY
        if (!ArquivoValido.EhValido(file, "Cid.Csv")) return RedirectToAction("ArquivoInvalido"); // DELEGUEI

        var filePah = $"{webHostEnvironment.WebRootPath}\\importFiles\\{file.FileName}";

        CopiarArquivo.Copiar(file, filePah); // Deleguei

        int k = 0;
        string line;

        List<Cid> cids = new List<Cid>();
        Encoding encodingPage = Encoding.GetEncoding(1252);
        bool detectEncoding = false;

        using (var fs = System.IO.File.OpenRead(filePah))
        using (var stream = new StreamReader(fs, encoding: encodingPage, detectEncoding))
            while ((line = stream.ReadLine()) != null)
            {
                string[] parts = line.Split(";");
                // cidinternalid, codigo, diagnostico  (os campos que vem no cabecalho do .csv)
                if (k > 0) // Pular Cabechalho
                {
                    if (!_context.Cid.Any(e => e.CidInternalId == int.Parse(parts[0])))
                    {
                        cids.Add(new Cid
                        {
                            CidInternalId = int.Parse(parts[0]),
                            Codigo = parts[1],
                            Diagnostico = parts[2]
                        });
                    }
                }
                k++;
            }

        if (cids.Any())
        {
            await _context.AddRangeAsync(cids);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    // CRUD Aqui
    [HttpGet("detalhes-cid")]
    public async Task<IActionResult> Details(Guid id)
    {

        var cid = await _context.Cid.FirstOrDefaultAsync(m => m.Id == id);
        if (cid == null) return NotFound();

        return View(cid);
    }

    [HttpGet("nova-cid")]
    public IActionResult Create()
    {
        return View();
    }


    [HttpPost("nova-cid")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Cid cid)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _context.Add(cid);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return RedirectToAction(nameof(Index));
        }
        return View(cid);
    }

    [HttpGet("view-cid")]
    public async Task<IActionResult> Edit(Guid id)
    {
        var cid = await _context.Cid.FindAsync(id);
        if (cid == null) return NotFound();

        return View(cid);
    }

    [HttpPost("editar-cid")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, Cid cid)
    {
        if (id != cid.Id) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(cid);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CidExists(cid.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(cid);
    }

    [HttpGet("view-delete-cid")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var cid = await _context.Cid.FirstOrDefaultAsync(m => m.Id == id);
        if (cid == null) NotFound();

        return View(cid);
    }

    [HttpPost, ActionName("Delete")]
    [Route("excluir-cid")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        var cid = await _context.Cid.FindAsync(id);
        _context.Cid.Remove(cid);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CidExists(Guid id)
    {
        return _context.Cid.Any(x => x.Id == id);
    }
}
