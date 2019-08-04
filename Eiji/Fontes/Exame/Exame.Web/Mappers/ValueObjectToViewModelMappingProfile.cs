using AutoMapper;
using Exame.VO.Argumento.Movimento;
using Exame.Web.Models;

namespace Exame.Web.Mappers
{
    public sealed class ValueObjectToViewModelMappingProfile : Profile
    {
        public ValueObjectToViewModelMappingProfile()
        {
            CreateMap<MovimentoProdutoResponse, MovimentoProdutoView>();
        }
    }
}