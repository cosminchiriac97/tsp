using System.Runtime.Serialization;

namespace Domain.ModelAux
{
    [DataContract]
    public class TopGenuri
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Scor { get; set; }
    }
}
