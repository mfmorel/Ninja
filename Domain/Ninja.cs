//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Domain
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ninja
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ninja()
        {
            this.Ninja_equipment = new HashSet<Ninja_equipment>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int Gold { get; set; }
        public Nullable<int> Head { get; set; }
        public Nullable<int> Shoulder { get; set; }
        public Nullable<int> Chest { get; set; }
        public Nullable<int> Belt { get; set; }
        public Nullable<int> Legs { get; set; }
        public Nullable<int> Boots { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ninja_equipment> Ninja_equipment { get; set; }
    }
}
