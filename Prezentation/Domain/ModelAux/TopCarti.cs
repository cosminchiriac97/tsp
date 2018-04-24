using System.Runtime.Serialization;

namespace Domain.ModelAux
{
    [DataContract]
    public class TopCarti
    {
        [DataMember]
        public  string Titlu { get; set; }
        [DataMember]
        public int Count { get; set; }
    }
}
