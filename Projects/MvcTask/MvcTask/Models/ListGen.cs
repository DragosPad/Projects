using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcTask.Models
{
    public class ListGen
    {
        public int ListGenId { get; set; }

         [Required(ErrorMessage = "Name is required")]
         [StringLength(20)]
        public string Name { get; set; }

         [Required(ErrorMessage = "Description is required")]
         [StringLength(100)]
        public string Description { get; set; }

         public int? TaskId { get; set; }

        public virtual List<Task> Tasks { get; set; }
    }
}