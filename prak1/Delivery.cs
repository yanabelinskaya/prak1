//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace prak1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Delivery
    {
        public int delivery_id { get; set; }
        public Nullable<System.DateTime> deliveryDate { get; set; }
        public Nullable<int> product_id { get; set; }
        public Nullable<int> quantity { get; set; }
        public string deliveryAddress { get; set; }
    
        public virtual Product Product { get; set; }
    }
}
