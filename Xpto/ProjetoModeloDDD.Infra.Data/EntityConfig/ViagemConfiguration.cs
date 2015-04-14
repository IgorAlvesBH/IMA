using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xpto.Domain.Entities;

namespace Xpto.Infra.Data.EntityConfig
{
  public class ViagemConfiguration : EntityTypeConfiguration<Viagem>
  {
    public ViagemConfiguration()
    {
      HasKey(v => v.IdViagem);

      Property(v => v.DataInicio)
        .IsRequired();

      Property(v => v.DataFim)
        .IsRequired();

      HasRequired(v => v.Cliente)
        .WithMany()
        .HasForeignKey(v => v.IdCliente);
      HasRequired(v => v.Destino)
        .WithMany()
        .HasForeignKey(v => v.IdDestino);
    }
  }
}
