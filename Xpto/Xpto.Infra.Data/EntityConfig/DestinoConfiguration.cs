using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xpto.Domain.Entities;

namespace Xpto.Infra.Data.EntityConfig
{
  public class DestinoConfiguration : EntityTypeConfiguration<Destino>
  {
    public DestinoConfiguration()
    {
      HasKey(d => d.IdDestino);

      Property(d => d.Nome)
      .IsRequired();

      Property(d => d.Descricao)
        .IsRequired()
        .HasMaxLength(150);
    }
  }
}
