using AutoMapper;
using Exame.Web.Mappers;

namespace Exame.Web.App_Start
{
    public static class AutoMapperConfig
    {
        public static IMapper Mapper { get; private set; }

        public static void RegisterMappings()
        {
            var mapper = new MapperConfiguration(map =>
            {
                map.AddProfile<ValueObjectToViewModelMappingProfile>();
                map.AddProfile<ViewModelToValueObjectMappingProfile>();
            });

            Mapper = mapper.CreateMapper();
        }
    }
}