using System.Data.Entity.ModelConfiguration;
using ListaTelefonica.Domain.Entity;

namespace ListaTelefonica.Infrastructure.Mapping
{
    public class ContatoMapping : EntityTypeConfiguration<Contato>
    {
        public ContatoMapping()
        {
            this.ToTable("Contato");
            this.HasKey(c => c.Identificador);
            this.Property(c => c.Identificador).HasColumnName("Identificador");
            this.Property(c => c.Nome).HasColumnName("Nome");
            this.Property(c => c.Cor).HasColumnName("Cor");
            this.Property(c => c.DataInclusao).HasColumnName("DataInclusao");
            this.Property(c => c.Serial).HasColumnName("Serial");
            this.Property(c => c.DataNascimento).HasColumnName("DataNascimento");
            this.Property(c => c.CPF).HasColumnName("CPF");
            this.Property(c => c.CNPJ).HasColumnName("CNPJ");
            this.Property(c => c.CEP).HasColumnName("CEP");            
        }
    }
}
