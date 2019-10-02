using AutoMapper;
using Exame.VO;
using Exame.Web.Models;

namespace Exame.Web.Mappers
{
    public class ViewModelToValueObjectMappingProfile : Profile
    {
        public ViewModelToValueObjectMappingProfile()
        {
            CreateMap<MovimentoView, Movimento>();
        }
    }
}