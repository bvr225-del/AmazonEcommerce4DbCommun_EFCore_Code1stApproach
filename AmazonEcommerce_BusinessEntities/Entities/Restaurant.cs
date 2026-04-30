using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonEcommerce_BusinessEntities.Entities
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantLocation { get; set; }
        public string CreationDate { get; set; }

    }
}
