using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xpto.Domain.Entities;
using Xpto.ViewModel;

namespace Xpto.AutoMapper
{
  public class ViewModelToDomainMappingProfile : Profile
  {
    public override string ProfileName
    {
      get { return "DomainToViewModelMapping"; }
    }
    protected override void Configure()
    {
      Mapper.CreateMap<Cliente, ClienteViewModel>();
      Mapper.CreateMap<Destino, DestinoViewModel>();
      Mapper.CreateMap<Viagem, ViagemViewModel>();
    }
  }
}