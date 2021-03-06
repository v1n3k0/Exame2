﻿using Exame.VO;
using Exame.VO.Entidade.Procedure;
using System.Collections.Generic;

namespace Exame.BO.Interface.Servico
{
    public interface IMovimentoServico
    {
        ICollection<MovimentoProduto> ListarMovimentosProduto();

        bool Adicionar(Movimento movimento);
    }
}
