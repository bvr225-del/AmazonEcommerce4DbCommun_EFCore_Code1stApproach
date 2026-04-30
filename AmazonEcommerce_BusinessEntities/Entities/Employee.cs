using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonEcommerce_BusinessEntities.Entities
{
    public class Employee
    {
        [Key]
        public int empid { get; set; }
        public string empname { get; set; }
        public int empsalary { get; set; }

    }
}
