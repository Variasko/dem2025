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
    
    public partial class CostChangeHistory
    {
        public int id { get; set; }
        public int productId { get; set; }
        public string costBefore { get; set; }
        public string costAfter { get; set; }
        public System.DateTime date { get; set; }
    
        public virtual Product Product { get; set; }
    }
}
