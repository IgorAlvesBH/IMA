using Xpto.Domain.Entities;
using Xpto.Infra.Data.EntityConfig;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Xpto.Infra.Data.EntityConfig;

namespace Xpto.Infra.Data.Context
{
  /// <summary>
  /// Xpto Context
  /// </summary>
  public class XptoContext : DbContext   
  {
    public XptoContext()
      : base("XptoDb")
    {

    }
    /// <summary>
    /// DBSet Cliente
    /// </summary>
    public DbSet<Cliente> Clientes { get; set; }

    /// <summary>
    /// DbSetViagem
    /// </summary>
    public DbSet<Viagem> Viagens { get; set; }
    /// <summary>
    /// DbSetDestino
    /// </summary>
    public DbSet<Destino> Destinos { get; set; }

    /// <summary>
    /// Convenções que serão consideradas na criação da base
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      //Motivo: Ao criar uma tabela "Produtos" por exemplo, seria migrado para
      //"Produtoes" pelo fato de não ter o idioma portugues no EF
      modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
      //Não remover em cascata
      modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
      //Não remover todas relações com o item que está sendo removido
      modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
      //Caso a classe não tenha apenas a propriedade ID, seja por exemplo "ClienteId" e deve ser o campo
      //chave da tabela, estamos incluindo ao modelBuilder essa inteligência
      modelBuilder.Properties().Where(p => p.Name == p.ReflectedType.Name + "Id")
        .Configure(p => p.IsKey());
      //Configurando o tamanho máximo dos campos varchar na criação das colunas
      modelBuilder.Properties<string>().Configure(p => p.HasColumnType("Varchar"));
      modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));  
   
      //Adicionando a configuração do cliente referente aos valores de cada coluna
      modelBuilder.Configurations.Add(new ClienteConfiguration());
      modelBuilder.Configurations.Add(new ViagemConfiguration());
      modelBuilder.Configurations.Add(new DestinoConfiguration());

    }

    public override int SaveChanges()
    {
      //Define a data de cadastro por padrão e se o registro foi ou não modificado
      foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
      {
        if (entry.State == EntityState.Added)
        {
          entry.Property("DataCadastro").CurrentValue = DateTime.Now;
        }

        if (entry.State == EntityState.Modified)
        {
          entry.Property("DataCadastro").IsModified = false;
        }        
      }
      return base.SaveChanges();
    }
  }
}
