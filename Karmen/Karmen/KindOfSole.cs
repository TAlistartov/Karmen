//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Karmen
{
    using System;
    using System.Collections.Generic;
    
    public partial class KindOfSole
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KindOfSole()
        {
            this.Sole = new HashSet<Sole>();
        }
    
        public int Id { get; set; }
        public int IdMaterialOfSole { get; set; }
        public int IdComponents { get; set; }
    
        public virtual Component Component { get; set; }
        public virtual MaterialOfSole MaterialOfSole { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sole> Sole { get; set; }
    }
}
