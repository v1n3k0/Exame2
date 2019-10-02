using System;
using System.Runtime.Serialization;

namespace Exame.VO
{
    [DataContract]
    public class Movimento
    {
        [DataMember]
        public int Mes { get; set; }
        [DataMember]
        public int Ano { get; set; }
        [DataMember]
        public int NumeroLancamento { get; set; }
        [DataMember]
        public int CodigoProduto { get; set; }
        [DataMember]
        public int CodigoCosif { get; set; }
        [DataMember]
        public int Valor { get; set; }
        [DataMember]
        public string Descricao { get; set; }
        [DataMember]
        public DateTime DataMovimento { get; set; }
        [DataMember]
        public string CodigoUsuario { get; set; }
    }
}
