using Microsoft.EntityFrameworkCore;
using ProjectoSchool_API.Models;

namespace ProjectoSchool_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            /* Método para carregar as tabelas com a primeira carga de dados */
            builder.Entity<Professor>()
                .HasData(
                new List<Professor>() {
                    new Professor()
                    {
                        Id = 1,
                        Nome = "Mariana Sert"                        
                    },
                    new Professor()
                    {
                        Id = 2,
                        Nome = "Marcos Palusa"
                    },
                    new Professor()
                    {
                        Id = 3,
                        Nome = "Cristiana Ortz"
                    }
                }
                );

            builder.Entity<Aluno>()
                 .HasData(
                 new List<Aluno>() {
                    new Aluno()
                    {
                        Id = 1,
                        Nome = "Agatha",
                        Sobrenome = "Farias",
                        DataNasc = "02/03/2003",
                        ProfessorId = 1,
                    },
                    new Aluno()
                    {
                        Id = 2,
                        Nome = "Edileusa",
                        Sobrenome = "Farias",
                        DataNasc = "02/03/2003",
                        ProfessorId = 2,
                    },
                    new Aluno()
                    {
                        Id = 3,
                        Nome = "Fábio",
                        Sobrenome = "Farias",
                        DataNasc = "02/03/2003",
                        ProfessorId = 3,
                    },
                    new Aluno()
                    {
                        Id = 4,
                        Nome = "Camargo",
                        Sobrenome = "Costa",
                        DataNasc = "02/03/2003",
                        ProfessorId = 3,
                    }
                 });
        }

    }
}
