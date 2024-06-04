using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SisMedico.Domain.Entities;
using SisMedico.Domain.Enums;
using SisMedico.Domain.Extensions;
using SisMedico.InfraData.ORM;

namespace SisMedico.Mvc.Controllers
{
    public class AgendaEventosController : Controller
    {
        private readonly ITDeveloperDbContext _context;
        private readonly IMapper _imapper;
        private readonly ILogger<AgendaEventosController> _logger;
        private readonly INotyfService _notifyService;

        public AgendaEventosController(ITDeveloperDbContext context, IMapper imapper, ILogger<AgendaEventosController> logger, INotyfService notifyService)
        {
            _context = context;
            _imapper = imapper;
            _logger = logger;
            _notifyService = notifyService;
        }

        public IActionResult Index(DateTime? eventDate)
        {
            ViewBag.EventDate = eventDate ?? DateTime.Now;
            if (TempData["SuccessMessage"] != null)
                _notifyService.Success("Evento salvo com sucesso!");

            return View();
        }

        public JsonResult GetEvents()
        {
            var agendaEventos = (from evento in _context.AgendaEventos
                                 join paciente in _context.Paciente on evento.PacienteId equals paciente.Id
                                 join medico in _context.Medico on evento.MedicoId equals medico.Id
                                 join convenio in _context.Convenio on paciente.Id equals convenio.PacienteId into convenios
                                 from subConvenio in convenios.DefaultIfEmpty()
                                 select new
                                 {
                                     Id = evento.Id,
                                     NomePaciente = paciente.Nome,
                                     NomeMedico = medico.Nome,
                                     Title = evento.Title,
                                     Start = evento.Start,
                                     End = evento.End,
                                     Description = evento.Description,
                                     Color = evento.Color,
                                     AllDay = evento.AllDay,
                                     Convenio = subConvenio != null ? subConvenio.Nome : "N/A",
                                     LocalExame = evento.LocalExame.ToString(),
                                     TipoExame = evento.TipoExame.ToString()
                                 }).ToArray();

            return Json(agendaEventos);
        }

        [HttpGet]
        public async Task<IActionResult> AgendaFilter()
        {
            var listAgendaEventos = await _context.Set<AgendaEventos>()
                .Include(e => e.Paciente)
                .Include(e => e.Medico)
                .Include(e => e.Convenio)
                .AsNoTracking().ToListAsync();

            return View(listAgendaEventos);
        }


        [HttpGet]
        public IActionResult GetEventForEdit(Guid id)
        {
            var evento = _context.AgendaEventos.Find(id);
            if (evento == null)
            {
                _notifyService.Error("Evento não encontrado.");
                return NotFound();
            }

            var viewModel = _imapper.Map<CreateEditAgendaEventoViewModel>(evento);
            PrepareDropdownsData(viewModel); // Preenche os dropdowns

            return PartialView("PartialViews/_EventCalendarModal", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(CreateEditAgendaEventoViewModel model)
        {
            if (ModelState.IsValid)
            {
                AgendaEventos evento;
                // Verifica se é uma criação ou edição
                if (model.Id == Guid.Empty)
                {
                    evento = new AgendaEventos
                    {
                        PacienteId = model.PacienteId,
                        MedicoId = model.MedicoId,
                        ConvenioId = model.ConvenioId,
                        Title = model.Title,
                        Description = model.Description,
                        Start = model.Start,
                        End = model.End,
                        Color = model.Color,
                        AllDay = model.AllDay,
                        LocalExame = model.LocalExame,
                        TipoExame = model.TipoExame
                    };

                    _context.AgendaEventos.Add(evento);
                }
                else
                {
                    evento = _context.AgendaEventos.Find(model.Id);
                    if (evento == null)
                    {
                        _notifyService.Error("Evento não encontrado.");
                        return RedirectToAction(nameof(Index));
                    }
                    _imapper.Map(model, evento); // Atualiza o evento com os dados da ViewModel

                }


                try
                {
                    _context.SaveChanges();
                    TempData["SuccessMessage"] = "Evento salvo com sucesso!";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Erro ao salvar evento");
                    _notifyService.Error("Erro ao salvar evento");
                    return RedirectToAction(nameof(Index));
                }
            }

            // Em caso de falha, prepara novamente os dados para os dropdowns antes de reexibir a View
            PrepareDropdownsData(model);
            return View("CreateModal", model); // Ou a view que você usa para mostrar o form
        }



        [HttpGet]
        public IActionResult EventDetails(Guid id)
        {
            var evento = _context.AgendaEventos
                .Include(e => e.Paciente)
                .Include(e => e.Medico)
                .Include(e => e.Convenio) // Ajuste conforme a estrutura do seu modelo
                .FirstOrDefault(e => e.Id == id);

            if (evento == null)
            {
                return NotFound();
            }

            var viewModel = new CreateEditAgendaEventoViewModel
            {
                // Copie as propriedades necessárias de evento para viewModel
                Id = id,
                NomePaciente = evento.Paciente.Nome,
                NomeMedico = evento.Medico.Nome,
                NomeConvenio = evento.Convenio?.Nome, // Use o operador de coalescência nula se Convenio for opcional
                // Preencha outras propriedades conforme necessário:
                Title = evento.Title,
                LocalExame = evento.LocalExame,
                TipoExame = evento.TipoExame,
                Start = evento.Start,
                End = evento.End,
                Description = evento.Description

            };

            return PartialView("PartialViews/_EventDetailsModal", viewModel);
        }


        public IActionResult CreateModal()
        {
            var viewModel = new CreateEditAgendaEventoViewModel();
            // Preencha viewModel.Pacientes, viewModel.Medicos, etc., aqui
            PrepareDropdownsData(viewModel); // Reaproveitando o método sugerido anteriormente
            return PartialView("PartialViews/_EventCalendarModal", viewModel);
        }

        private void PrepareDropdownsData(CreateEditAgendaEventoViewModel model)
        {
            model.Pacientes = _context.Paciente.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Nome
            }).ToList();

            model.Medicos = _context.Medico.Select(m => new SelectListItem
            {
                Value = m.Id.ToString(),
                Text = m.Nome
            }).ToList();

            model.Convenios = _context.Convenio.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Nome
            }).ToList();

            // Utilizando os métodos de extensão para Enums
            model.LocalExameOptions = Enum.GetValues(typeof(LocalExame))
                                          .Cast<LocalExame>()
                                          .Select(e => new SelectListItem
                                          {
                                              Value = ((int)e).ToString(),
                                              Text = e.ObterDescricao()
                                          })
                                          .ToList();

            model.TipoExameOptions = Enum.GetValues(typeof(TipoExame))
                                         .Cast<TipoExame>()
                                         .Select(e => new SelectListItem
                                         {
                                             Value = ((int)e).ToString(),
                                             Text = e.ObterDescricao()
                                         })
                                         .ToList();
        }

    }
}
