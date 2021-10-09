using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ParsTech.Web.Models
{
    public class ViewProjectVM
    {
        public IEnumerable<SelectListItem> ProjectName { get; set; }
        public int IdEmployee { get; set; }
        [Required(ErrorMessage = "Please select a project name.")]
        [DisplayName("Project Name")]
        public int IdProject { get; set; }

        public int IdEmployeeProject { get; set; }
    }
}
