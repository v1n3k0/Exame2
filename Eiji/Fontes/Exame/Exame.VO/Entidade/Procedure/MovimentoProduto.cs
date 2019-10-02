using System.Runtime.Serialization;

namespace Exame.VO.Entidade.Procedure
{
    [DataContract]
    public class MovimentoProduto
    {
        [DataMember]
        public int Mes { get; set; }
        [DataMember]
        public int Ano { get; set; }
        [DataMember]
        public int CodigoProduto { get; set; }
        [DataMember]
        public string DescricaoProduto { get; set; }
        [DataMember]
        public int NumeroLancamento { get; set; }
        [DataMember]
        public string DescricaoMovimento { get; set; }
        [DataMember]
        public int Valor { get; set; }
    }
}
