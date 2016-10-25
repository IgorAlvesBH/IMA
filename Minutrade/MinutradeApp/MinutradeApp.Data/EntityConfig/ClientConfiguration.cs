using MinutradeApp.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace MinutradeApp.Data.EntityConfig
{
  /// <summary>
  /// Definição das colunas da entidade Client
  /// </summary>
  public class ClientConfiguration : EntityTypeConfiguration<Client>
  {
    /// <summary>
    /// Constructor
    /// </summary>
    public ClientConfiguration()
    {
      HasKey(a => new { a.Cpf });
      Property(a => a.Cpf)
      .HasMaxLength(11);
      Property(a => a.Phone)
        .HasMaxLength(12);
      Property(a => a.CellPhone)
        .HasMaxLength(12);
    }
  }
}
