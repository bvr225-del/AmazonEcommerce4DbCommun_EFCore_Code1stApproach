using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonEcommerce_BusinessEntities.Entities
{
    public class Department
    {
        //if you apply [key]  attrbute to id property in entity classes it will automatically apply the primary key for id column and identity also applied automatically
        [Key]
        public int deptid { get; set; }
        public string deptname { get; set; }
        public string deptlocation { get; set; }

    }
}
