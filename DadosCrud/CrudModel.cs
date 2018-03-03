namespace DadosCrud
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CrudModel : DbContext
    {
        public CrudModel()
            : base("name=CrudModel")
        {
        }

        public virtual DbSet<cidade> cidades { get; set; }
        public virtual DbSet<funcionario> funcionarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<cidade>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<cidade>()
                .HasMany(e => e.funcionarios)
                .WithOptional(e => e.cidade1)
                .HasForeignKey(e => e.cidade);

            modelBuilder.Entity<funcionario>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<funcionario>()
                .Property(e => e.cpf)
                .HasPrecision(11, 0);
        }
    }
}
