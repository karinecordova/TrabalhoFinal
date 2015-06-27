using Empresa.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa.Infra.Data
{
    public class FuncionarioContext : DbContext
    {
        public FuncionarioContext() : base("EmpresaDB") { }
        //public FuncionarioContext() : base("EmpresaDB") { }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Dependente> Dependentes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionario>().ToTable("TBFuncionario");
            modelBuilder.Entity<Funcionario>()
                .Property(b => b.Nome)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Dependente>().ToTable("TBDependente");
            modelBuilder.Entity<Dependente>()
                .Property(b => b.Nome)
                .IsRequired()
                .HasMaxLength(255);
            modelBuilder.Entity<Funcionario>()
                 .HasMany(a => a.Dependentes)
                 .WithOptional()
                 .WillCascadeOnDelete(true);

          
           
        }

    }
}
