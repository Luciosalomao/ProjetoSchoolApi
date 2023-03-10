// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectoSchool_API.Data;

#nullable disable

namespace ProjectoSchoolAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("ProjectoSchool_API.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DataNasc")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ProfessorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Alunos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataNasc = "02/03/2003",
                            Nome = "Agatha",
                            ProfessorId = 1,
                            Sobrenome = "Farias"
                        },
                        new
                        {
                            Id = 2,
                            DataNasc = "02/03/2003",
                            Nome = "Edileusa",
                            ProfessorId = 2,
                            Sobrenome = "Farias"
                        },
                        new
                        {
                            Id = 3,
                            DataNasc = "02/03/2003",
                            Nome = "Fábio",
                            ProfessorId = 3,
                            Sobrenome = "Farias"
                        },
                        new
                        {
                            Id = 4,
                            DataNasc = "02/03/2003",
                            Nome = "Camargo",
                            ProfessorId = 3,
                            Sobrenome = "Costa"
                        });
                });

            modelBuilder.Entity("ProjectoSchool_API.Models.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Professores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Mariana Sert"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Marcos Palusa"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Cristiana Ortz"
                        });
                });

            modelBuilder.Entity("ProjectoSchool_API.Models.Aluno", b =>
                {
                    b.HasOne("ProjectoSchool_API.Models.Professor", "Professor")
                        .WithMany("Alunos")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("ProjectoSchool_API.Models.Professor", b =>
                {
                    b.Navigation("Alunos");
                });
#pragma warning restore 612, 618
        }
    }
}
