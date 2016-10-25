namespace MinutradeApp.Data.Migrations
{
  using Domain.Entities;
  using System;
  using System.Data.Entity;
  using System.Data.Entity.Migrations;
  using System.Linq;

  internal sealed class Configuration : DbMigrationsConfiguration<MinutradeApp.Data.Context.SqlDbContext>
  {
    public Configuration()
    {
      AutomaticMigrationsEnabled = true;
    }

    protected override void Seed(MinutradeApp.Data.Context.SqlDbContext context)
    {
      //  This method will be called after migrating to the latest version.

      //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
      //  to avoid creating duplicate seed data. E.g.
      //
      //    context.People.AddOrUpdate(
      //      p => p.FullName,
      //      new Person { FullName = "Andrew Peters" },
      //      new Person { FullName = "Brice Lambson" },
      //      new Person { FullName = "Rowan Miller" }
      //    );
      //
      Adress adress = new Adress() { Id = Guid.Parse("461f7d7c-66b2-415c-bfbd-c0447f810afa"), Street = "Rua/Avenida", Number = 100, Complement = "Casa/Apto 111", City = "Cidade", ZipCode = "55325400", Country = "Brasil", State = "MG", District = "Bairro"};
      context.Adresses.AddOrUpdate(ad => ad.Id, adress);

      Client client = new Client() { Id = Guid.Parse("13c7b50c-428e-4ac6-9862-9a590b356785"), Cpf = "33090079879", AdressId = adress.Id, Email = "teste@teste.com", MaritalStatus = "Casado(a)", Name = "Nome completo" , CellPhone = "31988888888", Phone = "3111111111"};
      context.Clients.AddOrUpdate(cl => cl.Cpf, client);
    }
  }
}
