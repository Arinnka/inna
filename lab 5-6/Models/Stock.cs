//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace lab_5_6.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Stock
    {
        public Stock()
        {
            this.Order = new HashSet<Order>();
            this.Table = new HashSet<Table>();
        }
    
        public int Id { get; set; }
        public string address { get; set; }
        public Nullable<int> volume { get; set; }
    
        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<Table> Table { get; set; }
    }
}
