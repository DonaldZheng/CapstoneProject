using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneOne.Models
{
    public class DateActivity
    {
        [Key]
        public int Id
        {
            get; set;
        }
        //foreign key  point to customer
        public string ActivityName
        {
            get; set;
        }

        //date
    }
}
