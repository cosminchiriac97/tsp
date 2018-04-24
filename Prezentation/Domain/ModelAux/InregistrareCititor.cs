using System.Runtime.Serialization;

namespace Domain.ModelAux
{
    [DataContract]
    public class InregistrareCititor
    {
        [DataMember]
        public string Nume { get; set; }
        [DataMember]
        public string Prenume { get; set; }
        [DataMember]
        public string Adresa { get; set; }
        [DataMember]
        public string Email { get; set; }
    }
}
