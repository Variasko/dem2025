//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FloorMaster
{
    using System;
    using System.Collections.Generic;
    
    public partial class Material
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Material()
        {
            this.DeliveryHistory = new HashSet<DeliveryHistory>();
            this.MaterialInProduct = new HashSet<MaterialInProduct>();
            this.StorageBase = new HashSet<StorageBase>();
        }
    
        public int id { get; set; }
        public int materialTypeId { get; set; }
        public string name { get; set; }
        public int deliverId { get; set; }
        public int amountPerPack { get; set; }
        public string measerUnit { get; set; }
        public byte[] image { get; set; }
        public decimal cost { get; set; }
    
        public virtual Deliver Deliver { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeliveryHistory> DeliveryHistory { get; set; }
        public virtual MaterialType MaterialType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaterialInProduct> MaterialInProduct { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StorageBase> StorageBase { get; set; }
    }
}