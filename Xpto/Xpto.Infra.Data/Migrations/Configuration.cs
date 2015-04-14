namespace Xpto.Infra.Data.Migrations
{
  using Xpto.Infra.Data.Context;
  using System;
  using System.Data.Entity;
  using System.Data.Entity.Migrations;
  using System.Linq;
  using Xpto.Domain.Entities;
  using System.Collections;
  using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<XptoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(XptoContext context)
        {
          //Simulando os dados de outra base de dados sendo importado
          Cliente cliente = new Cliente();          
          cliente.Email = "joao@xpto.com";
          cliente.Nome = "João";
          cliente.Cpf = "123.456.789-12";
          Destino destino = new Destino();
          destino.Nome = "Belo Horizonte";
          destino.Descricao = "Capital de Minas Gerais, oferece diversos pontos turísticos.";
          Viagem viagem = new Viagem();          
          viagem.DataInicio = DateTime.Now.AddDays(-30).Date;
          viagem.DataFim = DateTime.Now.Date;          
          viagem.IdCliente = cliente.ClienteId;
          viagem.IdDestino = destino.IdDestino;          
          viagem.Avaliacao = AvaliacaoViagemEnum.Pendente;

          context.Clientes.AddOrUpdate(cliente);
          context.Destinos.AddOrUpdate(destino);          
          context.Viagens.AddOrUpdate(viagem);

          viagem = new Viagem();
          viagem.DataInicio = DateTime.Now.AddDays(-100).Date;
          viagem.DataFim = DateTime.Now.Date.AddDays(-70);
          viagem.IdCliente = cliente.ClienteId;
          viagem.IdDestino = destino.IdDestino;
          viagem.Avaliacao = AvaliacaoViagemEnum.Regular;
          context.Viagens.AddOrUpdate(viagem);

          destino = new Destino();
          destino.IdDestino = 2;
          destino.Descricao = "Capital do Rio de janeiro";
          destino.Nome = "Rio de Janeiro";
          context.Destinos.AddOrUpdate(destino);
          viagem = new Viagem();
          viagem.DataInicio = DateTime.Now.Date.AddDays(-50);
          viagem.DataFim = DateTime.Now.Date.AddDays(-20);
          viagem.IdCliente = cliente.ClienteId;
          viagem.IdDestino = destino.IdDestino;
          viagem.Avaliacao = AvaliacaoViagemEnum.Muitobom;
          context.Viagens.AddOrUpdate(viagem);
          viagem = new Viagem();
          viagem.DataInicio = DateTime.Now.Date.AddDays(-200);
          viagem.DataFim = DateTime.Now.Date.AddDays(-170);
          viagem.IdCliente = cliente.ClienteId;
          viagem.IdDestino = destino.IdDestino;
          viagem.Avaliacao = AvaliacaoViagemEnum.Excelente;
          context.Viagens.AddOrUpdate(viagem);
          viagem = new Viagem();
          viagem.DataInicio = DateTime.Now.Date.AddDays(-300);
          viagem.DataFim = DateTime.Now.Date.AddDays(-270);
          viagem.IdCliente = cliente.ClienteId;
          viagem.IdDestino = destino.IdDestino;
          viagem.Avaliacao = AvaliacaoViagemEnum.Excelente;
          context.Viagens.AddOrUpdate(viagem);

        }
    }
}
