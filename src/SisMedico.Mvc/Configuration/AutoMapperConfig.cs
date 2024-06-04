using AutoMapper;
using SisMedico.Domain.Entities;
using SisMedico.Domain.Farmacia.Entities;
using SisMedico.Domain.ValueObjects;
using SisMedico.Mvc.ViewModels.Farmacia;
using SisMedico.Mvc.ViewModels.Medico;

namespace SisMedico.Mvc.Configuration;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<Paciente, PacienteViewModel>().ReverseMap();

        CreateMap<Medico, MedicoViewModel>()
            .ForMember(dest => dest.EspecialidadesIds, opt => opt.MapFrom(src => src.MedicoEspecialidade.Select(me => me.EspecialidadeId)))
            .ForMember(dest => dest.EspecialidadesDescricoes, opt => opt.MapFrom(src => src.MedicoEspecialidade.Select(me => me.Especialidade.Descricao)))
            .ReverseMap();


        CreateMap<Especialidade, EspecialidadeViewModel>().ReverseMap();


        CreateMap<Tags, TagsViewModel>().ReverseMap();

        CreateMap<Author, AuthorViewModel>()
            .ForMember(rd => rd.Facebook, o => o.MapFrom(s => s.RedesSociais.Facebook))
            .ForMember(rd => rd.Twitter, o => o.MapFrom(s => s.RedesSociais.Twitter))
            .ForMember(rd => rd.Linkedin, o => o.MapFrom(s => s.RedesSociais.Linkedin));

        CreateMap<AuthorViewModel, Author>()
            .ConstructUsing(p =>
                new Author(p.Name, p.LastName,
                    p.EmailAddress, p.WebSite,
                      new RedesSociais(p.Facebook, p.Twitter, p.Linkedin)));

        CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
        CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
        CreateMap<Produto, ProdutoViewModel>().ReverseMap();

        CreateMap<AgendaEventos, CreateEditAgendaEventoViewModel>().ReverseMap();

    }
}
