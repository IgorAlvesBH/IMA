using MinutradeApp.Domain.Entities;
using MinutradeApp.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinutradeApp.Data.Repositories
{
  public class RepositoryClient : SqlRepository<Client>, IRepositoryClient
  {

  }
}
