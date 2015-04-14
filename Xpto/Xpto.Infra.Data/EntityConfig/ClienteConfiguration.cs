using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Xpto.Domain.Entities;

namespace Xpto.Infra.Data.EntityConfig
{
  /// <summary>
  /// Configuração da entidade Cliente
  /// </summary>
  public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
  {
    /// <summary>
    /// Constructor
    /// </summary>
    public ClienteConfiguration()
    {
      HasKey(c => c.ClienteId);

      Property(c => c.Nome)
        .IsRequired();

      Property(c => c.Email)
        .IsRequired();

      Property(c => c.Cpf)
        .IsRequired();
    }
  }
}
