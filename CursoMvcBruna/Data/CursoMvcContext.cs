using CursoMvcBruna.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using CursoMvcBruna.ViewModels;

namespace CursoMvcBruna.Context
{
    public class CursoMvcContext : DbContext
    {
        public CursoMvcContext(DbContextOptions<CursoMvcContext> options)
            : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=./;Database=CursoMVC;Trusted_Connection=True;MultipleActiveResultSets=true;Trust Server Certificate=true");
        }

        //Configurando mapeamento Cliente no BD

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .HasKey(p => p.ClienteId);


        modelBuilder.Entity<Cliente>()

                .Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(150);

        modelBuilder.Entity<Cliente>()

                .Property(p => p.Email)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(100);

        modelBuilder.Entity<Cliente>()

                .Property(p => p.CPF)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(11);


        modelBuilder.Entity<Cliente>() // tive que criar outro chamando o index, o de cima é property

                 .HasIndex(c => c.CPF)
                 .IsUnique();


        modelBuilder.Entity<Cliente>()

                .Property(p => p.DataNascimento)
                .IsRequired();

        modelBuilder.Entity<Cliente>()

                .Property(p => p.Ativo)
                .IsRequired();


        modelBuilder.Entity<Cliente>()

                .ToTable("Clientes");

        //Configurando mapeamento Endereço no BD

        modelBuilder.Entity<Endereco>()

                .HasKey(e => e.EnderecoId);

        modelBuilder.Entity<Endereco>()

                .Property(e => e.Logradouro)
                .HasColumnType("varchar")
                .HasMaxLength(150)
                .IsRequired();

        modelBuilder.Entity<Endereco>()

                .Property(e => e.Numero)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(100);

        modelBuilder.Entity<Endereco>()

                .Property(e => e.Bairro)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(50);

        modelBuilder.Entity<Endereco>()

                .Property(e => e.CEP)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(8);

        modelBuilder.Entity<Endereco>()

                .Property(e => e.Complemento)
                .HasColumnType("varchar")
                .HasMaxLength(100);

        modelBuilder.Entity<Endereco>()

                .Property(e => e.Cidade)
                .HasColumnType("varchar")
                .HasMaxLength(100);

        modelBuilder.Entity<Endereco>()

                .Property(e => e.Estado)
                .HasColumnType("varchar")
                .HasMaxLength(100);

        modelBuilder.Entity<Endereco>()

                .HasOne(e => e.Cliente)
                .WithMany(c => c.Enderecos)
                .HasForeignKey(e => e.ClienteId)
                .IsRequired();

        modelBuilder.Entity<Endereco>()

                .ToTable("Enderecos");

            base.OnModelCreating(modelBuilder);
            

    }


        //Configurando mapeamento Cliente no BD

        public DbSet<CursoMvcBruna.ViewModels.ClienteViewModel> ClienteViewModel { get; set; }


        //Configurando mapeamento Cliente no BD

        public DbSet<CursoMvcBruna.ViewModels.ClienteEnderecoViewModel> ClienteEnderecoViewModel { get; set; }
  }
}
