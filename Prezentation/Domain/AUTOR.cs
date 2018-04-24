using System.Runtime.Serialization;

namespace Domain
{
    using System.Collections.Generic;

    [DataContract]
    public partial class AUTOR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AUTOR()
        {
            this.Carti = new HashSet<CARTE>();
        }
        [DataMember]
        public int AutorId { get; set; }
        [DataMember]
        public string Nume { get; set; }
        [DataMember]
        public string Prenume { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CARTE> Carti { get; set; }
    }
}
