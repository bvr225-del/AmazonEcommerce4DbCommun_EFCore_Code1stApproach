using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonEcommerce_BusinessEntities.Entities
{
    public class Order
    {
        [Key]//Key attribute is used to apply the primary key and identity value.
        public int orderid { get; set; }
        public string ordername { get; set; }
        public string orderlocation { get; set; }

    }
}
