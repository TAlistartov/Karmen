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
    
    public partial class Pattern
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pattern()
        {
            this.Designe = new HashSet<Designe>();
        }
    
        public int Id { get; set; }
        public bool UseUnuse { get; set; }
        public string CrossReference { get; set; }
        public string AdditionalInformation { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Designe> Designe { get; set; }
    }
}