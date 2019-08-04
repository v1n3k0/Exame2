using AutoMapper;
using Exame.VO.Argumento.Movimento;
using Exame.Web.Models;

namespace Exame.Web.Mappers
{
    public sealed class ViewModelToValueObjectMappingProfile : Profile
    {
        public ViewModelToValueObjectMappingProfile()
        {
            CreateMap<MovimentoView, AdicionarMovimentoRequest>();
        }
    }
}