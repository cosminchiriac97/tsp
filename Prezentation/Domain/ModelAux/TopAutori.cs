using System.Runtime.Serialization;

namespace Domain.ModelAux
{
    [DataContract]
    public class TopAutori
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nume { get; set; }
        [DataMember]
        public string Prenume { get; set; }
        [DataMember]
        public int Scor { get; set; }
    }
}
