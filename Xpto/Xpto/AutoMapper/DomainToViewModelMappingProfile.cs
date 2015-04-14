using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xpto.Domain.Entities;
using Xpto.ViewModel;

namespace Xpto.AutoMapper
{
  public class DomainToViewModelMappingProfile : Profile
  {
    public override string ProfileName
    {
      get { return "ViewModelToDomainMappings"; }
    }

    protected override void Configure()
    {
      Mapper.CreateMap<ClienteViewModel, Cliente>();
      Mapper.CreateMap<DestinoViewModel, Destino>();
      Mapper.CreateMap<ViagemViewModel, Viagem>();
    }
  }
}