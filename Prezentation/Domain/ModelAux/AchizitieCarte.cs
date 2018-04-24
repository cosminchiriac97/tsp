using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Domain.ModelAux
{
    [DataContract]
    public class AchizitieCarte
    {
        [DataMember]
        [Required]
        [StringLength(50)]
        public string Titlu { set; get; }
        [DataMember]
        [Required]
        [StringLength(20)]
        public string NumeAutor { set; get; }
        [DataMember]
        [Required]
        [StringLength(20)]
        public string PrenumeAutor { set; get; }
        [DataMember]
        [Required]
        [StringLength(50)]
        public string Descriere { get; set; }
        [DataMember]
        [Required]
        public int NumarCarti { get; set; }
    }
}
