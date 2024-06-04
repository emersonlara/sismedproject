using SisMedico.Domain.Base;

namespace SisMedico.Domain.Entities
{
    public class Medico : EntityBase
    {
        // EF
        public Medico(){}

        public Medico(string nome, string crm, DateTime dataNascimento)
        {
            Nome = nome;
            Crm = crm;
            DataNascimento = dataNascimento;
            MedicoEspecialidade = new List<MedicoEspecialidade>();
        }

        public string Nome { get; private set; }
        public string Crm { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public ICollection<MedicoEspecialidade> MedicoEspecialidade { get; set; }

    }

    public class Especialidade : EntityBase
    {
        // EF
        public Especialidade() { }

        public Especialidade(string descricao)
        {
            Descricao = descricao;
        }

        public string Descricao { get; private set; }
        public ICollection<MedicoEspecialidade> MedicoEspecialidade { get; set; }


    }

    public class MedicoEspecialidade
    {
        public Guid MedicoId { get; set; }
        public Medico Medico { get; set; }
        public Guid EspecialidadeId { get; set; }
        public Especialidade Especialidade { get; set; }
    }

}
