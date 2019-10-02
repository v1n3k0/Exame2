using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Exame.Web.Models
{
    [DataContract]
    public class ProdutoView
    {
        [DataMember]
        public int Codigo { get; set; }

        [DataMember]
        public string Descricao { get; set; }

        [DataMember]
        public string Status { get; set; }

        [DataMember]
        public List<CosifView> Cosifs { get; set; }
    }
}