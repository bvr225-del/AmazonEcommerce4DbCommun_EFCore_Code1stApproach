using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonEcommerce_BusinessEntities.Dtos
{
    public class OrderDto
    {
        public int orderid { get; set; }
        public string ordername { get; set; }
        public string orderlocation { get; set; }

    }
}
