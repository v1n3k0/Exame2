using AutoMapper;
using Exame.VO.Entidade.Procedure;
using Exame.Web.Models;

namespace Exame.Web.Mappers
{
    public class ValueObjectToViewModelMappingProfile : Profile
    {
        public ValueObjectToViewModelMappingProfile()
        {
            CreateMap<MovimentoProduto, MovimentoProdutoView>();
        }
    }
}