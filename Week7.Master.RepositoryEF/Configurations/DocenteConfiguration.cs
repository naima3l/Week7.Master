using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Week7.Master.Core.Entities;

namespace Week7.Master.RepositoryEF
{
    internal class DocenteConfiguration : IEntityTypeConfiguration<Docente>
    {
        public void Configure(EntityTypeBuilder<Docente> modelBuilder)
        {
            modelBuilder.ToTable("Docente");
            modelBuilder.HasKey(d => d.Id);
            modelBuilder.Property(d => d.Nome).IsRequired();
            modelBuilder.Property(d => d.Cognome).IsRequired();
            modelBuilder.Property(d => d.Email).IsRequired();
            modelBuilder.Property(d => d.Telefono).IsRequired();

            //Relazione Docente 1 ->Lezioni n
            modelBuilder.HasMany(d => d.Lezioni).WithOne(l => l.Docente).HasForeignKey(l => l.DocenteId);
        }
    }
}