using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Week7.Master.Core.Entities;

namespace Week7.Master.RepositoryEF
{
    internal class CorsoConfiguration : IEntityTypeConfiguration<Corso>
    {
        public void Configure(EntityTypeBuilder<Corso> modelBuilder)
        {
            modelBuilder.ToTable("Corso"); //specifico il nome della tabella
            modelBuilder.HasKey(c => c.CorsoCodice); //specifico la chiave primaria
            modelBuilder.Property(c => c.Nome).IsRequired();
            modelBuilder.Property(c => c.Descrizione).IsRequired();

            //Relazione Corso 1 ->Studenti n
            modelBuilder.HasMany(c => c.Studenti).WithOne(s=> s.Corso).HasForeignKey(s=> s.CorsoCodice);
            //Relazione Corso 1 ->Lezioni n
            modelBuilder.HasMany(c => c.Lezioni).WithOne(l=> l.Corso).HasForeignKey(l=> l.CorsoCodice);

        }
    }
}