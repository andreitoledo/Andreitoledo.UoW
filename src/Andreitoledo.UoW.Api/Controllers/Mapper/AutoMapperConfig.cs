using Andreitoledo.UoW.Api.Controllers.Models;
using Andreitoledo.UoW.Domain;
using AutoMapper;

namespace Andreitoledo.UoW.Api.Controllers.Mapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Pessoa, PessoaDTO>().ReverseMap();
        }
    }
}
