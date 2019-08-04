using AutoMapper;

namespace Exame.BO.Mappers
{
    public sealed class AutoMapperServiceConfig
    {
        public static IMapper Mapper { get; private set; }

        public static void RegisterMappings()
        {
            var mapper = new MapperConfiguration(map =>
            {
                map.AddProfile<EntityToArgumentMappingProfile>();
            });

            Mapper = mapper.CreateMapper();
        }
    }
}