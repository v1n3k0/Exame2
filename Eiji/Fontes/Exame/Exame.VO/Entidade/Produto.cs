using System.Runtime.Serialization;

namespace Exame.VO
{
    [DataContract]
    public class Produto
    {
        [DataMember]
        public int Codigo { get; set; }
        [DataMember]
        public string Descricao { get; set; }
        [DataMember]
        public string Status { get; set; }
    }
}
