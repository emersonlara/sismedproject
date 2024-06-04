using Microsoft.EntityFrameworkCore;
using SisMedico.Domain.Farmacia.Entities;
using SisMedico.Domain.Messaging;

namespace SisMedico.InfraData.ORM
{
    public class ITDeveloperDbContext : DbContext
    {

        public ITDeveloperDbContext(DbContextOptions<ITDeveloperDbContext> options)
            : base(options)
        { }


        public DbSet<AgendaEventos> AgendaEventos { get; set; }
        public DbSet<Convenio> Convenio { get; set; }

        public DbSet<Medico> Medico { get; set; }

        public DbSet<Especialidade> Especialidade { get; set; }

        public DbSet<MedicoEspecialidade> MedicoEspecialidade { get; set; }

        public DbSet<Mural> Mural { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<EstadoPaciente> EstadoPaciente { get; set; }
        public DbSet<Generico> Generico { get; set; }
        public DbSet<Cid> Cid { get; set; }
        public DbSet<Medicamento> Medicamento { get; set; }
        public DbSet<Tags> Tags { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Telefone> Telefone { get; set; }
        public DbSet<Triagem> Triagem { get; set; }
        public DbSet<ChamadaMedica> ChamadaMedica { get; set; }
        public DbSet<PacienteTeste> PacienteTestes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Ignore<Event>();

            // onde não tiver setado varchar e a propriedade for do tipo string fica valendo varchar(valor)
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
            {
                //property.Relational().ColumnType = "varchar(100)";
                property.SetColumnType("varchar(90)");
            }

            //modelBuilder.ApplyConfiguration(new PacienteMap());
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ITDeveloperDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);

        }

    }
}
