using AutoMapper;
using Exame.VO;
using Exame.VO.Argumento.Cosif;
using Exame.VO.Argumento.Movimento;
using Exame.VO.Argumento.Produto;
using Exame.VO.Entidade.Procedure;
using System.Collections.Generic;

namespace Exame.BO.Mappers
{
    public sealed class EntityToArgumentMappingProfile : Profile
    {
        public EntityToArgumentMappingProfile()
        {
            CreateMap<Cosif, CosifResponse>();
            CreateMap<Produto, ProdutoResponse>();
            CreateMap<MovimentoProduto, MovimentoProdutoResponse>();
        }
    }
}
