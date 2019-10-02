using System.Runtime.Serialization;

namespace Exame.VO
{
    [DataContract]
    public class Cosif
    {
        [DataMember]
        public int Codigo { get; set; }
        [DataMember]
        public int CodigoProduto { get; set; }
        [DataMember]
        public string Classificacao { get; set; }
        [DataMember]
        public string Status { get; set; }
    }
}
