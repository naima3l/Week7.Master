using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Week7.Master.Core.Entities;

namespace Week7.Master.RepositoryEF
{
    internal class StudenteConfiguration : IEntityTypeConfiguration<Studente>
    {
        public void Configure(EntityTypeBuilder<Studente> modelBuilder)
        {
            modelBuilder.ToTable("Studente");
            modelBuilder.HasKey(s => s.Id);
            modelBuilder.Property(s => s.Nome).IsRequired();
            modelBuilder.Property(s => s.TitoloStudio).IsRequired();
            modelBuilder.Property(s => s.DataNascita).IsRequired();
            modelBuilder.Property(s => s.Cognome).IsRequired();
            modelBuilder.Property(s => s.Email).IsRequired();

            //Relazione Corso 1 ->Studenti n
            modelBuilder.HasOne(s => s.Corso).WithMany(c => c.Studenti).HasForeignKey(c => c.CorsoCodice);
        }
    }
}