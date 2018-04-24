
//--------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Domain
{


    [DataContract]
    public partial class CARTE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CARTE()
        {
            this.Imprumut = new HashSet<IMPRUMUT>();
        }
        [DataMember]
        public int CarteId { get; set; }
        [DataMember]
        public int AutorId { get; set; }
        [DataMember]
        public string Titlu { get; set; }
        [DataMember]
        public int GenId { get; set; }
      
        public virtual AUTOR Autor { get; set; }
 
        public virtual GEN Gen { get; set; }
  
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IMPRUMUT> Imprumut { get; set; }
    }
}
