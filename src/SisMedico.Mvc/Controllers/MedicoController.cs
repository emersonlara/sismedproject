using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SisMedico.Domain.Entities;
using SisMedico.Domain.Interfaces.NewRepository;
using SisMedico.InfraData.ORM;
using SisMedico.Mvc.ViewModels.Medico;

namespace SisMedico.Mvc.Controllers
{
    public class MedicoController : Controller
    {
        // TODO: Retirar esta injeção depois
        private readonly ITDeveloperDbContext _context;

        private readonly INewUnitOfWork _unitOfWork;
        private readonly INewMedicoRepository _medicoRepository;
        private readonly IMapper _mapper;

        public MedicoController(INewUnitOfWork unitOfWork,
                                INewMedicoRepository medicoRepository,
                                IMapper mapper,
                                ITDeveloperDbContext context)
        {
            _unitOfWork = unitOfWork;
            _medicoRepository = medicoRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var medicos = await _context.Medico
                                        .Include(m => m.MedicoEspecialidade)
                                        .ThenInclude(me => me.Especialidade)
                                        .ToListAsync();

            var medicoViewModels = _mapper.Map<List<MedicoViewModel>>(medicos);
            return View(medicoViewModels);
            //return View(medicos);
        }

        public IActionResult Create()
        {
            var especialidades = _context.Especialidade.ToList();
            ViewBag.Especialidades = new SelectList(especialidades, "Id", "Descricao");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MedicoViewModel medicoViewModel)
        {
            if (ModelState.IsValid)
            {
                //var medico = _mapper.Map<Medico>(medicoViewModel);

                // Adiciona as especialidades selecionadas ao médico
                //medico.MedicoEspecialidade = especialidadesSelecionadas
                //    .Select(especialidadeId => new MedicoEspecialidade { MedicoId = medico.Id, EspecialidadeId = especialidadeId })
                //    .ToList();

                var medico = new Medico(medicoViewModel.Nome, medicoViewModel.Crm, medicoViewModel.DataNascimento);

                foreach(var item in medicoViewModel.EspecialidadesIds)
                {
                    _context.MedicoEspecialidade.Add(new MedicoEspecialidade
                    {
                        MedicoId = medico.Id, EspecialidadeId = item
                    });
                };

                _context.Add(medico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Se houver erros de validação, recarregar o dropdownlist
            var especialidades = _context.Especialidade.ToList();
            ViewBag.Especialidades = new SelectList(especialidades, "Id", "Nome", medicoViewModel.EspecialidadesIds);

            return View(medicoViewModel);
        }

    }
}
