using MinutradeApp.Data.EntityConfig;
using MinutradeApp.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MinutradeApp.Data.Context
{
  /// <summary>
  /// SQL DB
  /// </summary>
  public class SqlDbContext : DbContext
  {
    /// <summary>
    /// Contructor
    /// </summary>
    public SqlDbContext()
      : base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MinutradeDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
    {

    }

    /// <summary>
    /// DBSet de cliente
    /// </summary>
    public DbSet<Client> Clients { get; set; }
    /// <summary>
    /// DbSet de endereço
    /// </summary>
    public DbSet<Adress> Adresses { get; set; }
    /// <summary>
    /// DbSet de Telefone
    /// </summary>
    //public DbSet<Phone> Phones { get; set; }

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
      //modelBuilder.Properties().Where(p => p.Name == p.ReflectedType.Name + "Id")
      //  .Configure(p => p.IsKey());
      //Configurando o tamanho máximo dos campos varchar na criação das colunas
      modelBuilder.Properties<string>().Configure(p => p.HasColumnType("Varchar"));
      modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));
      //Adicionando a configuração das entidades referente aos valores de cada coluna
      //modelBuilder.Configurations.Add(new PhoneConfiguration());
      modelBuilder.Configurations.Add(new AdressConfiguration());
      modelBuilder.Configurations.Add(new ClientConfiguration());
    }
  }
}
