using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ParsTech.Web.Models
{
    public class EmployeeProject
    {
        [Key]
        public int IdEmployeeProject { get; set; }
        public int IdEmployee { get; set; }
        public int IdProject { get; set; }
    }
}
