using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Exame.Web.Models
{
    [DataContract]
    public class CosifView
    {
        [DataMember]
        public int Codigo { get; set; }

        [DataMember]
        public int CodigoProduto { get; set; }

        [DataMember]
        public string Classificacao { get; set; }

        [DataMember]
        public string Status { get; set; }

        [DataMember]
        public List<MovimentoView> Movimentos { get; set; }
    }
}