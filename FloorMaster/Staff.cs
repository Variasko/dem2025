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
    
    public partial class Staff
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Staff()
        {
            this.Order = new HashSet<Order>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string patronymic { get; set; }
        public System.DateTime birthday { get; set; }
        public string passportSerial { get; set; }
        public string passportNumber { get; set; }
        public string cardNumber { get; set; }
        public bool isMarried { get; set; }
        public int healthStatusId { get; set; }
        public int roleId { get; set; }
        public string login { get; set; }
        public string password { get; set; }
    
        public virtual HealthStatus HealthStatus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }
        public virtual Role Role { get; set; }
    }
}
