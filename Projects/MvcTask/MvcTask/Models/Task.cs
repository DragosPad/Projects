using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace MvcTask.Models
{
    public enum Priority 
    { 
        high,
        medium,
        low
    
    };
    public class Task
    {
        public int TaskId { get; set; }

         [Required(ErrorMessage = "Name is required")]
         [StringLength(20)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime Deadline { get; set; }

         [Required(ErrorMessage = "Priority is required")]
        public Priority? Priority { get; set; }
       // ActionList = new List<Select

        public int? ListGenId { get; set; }
        //[Key, ForeignKey("ListGen")]
        //public virtual ListGen ListGen { get; set; }
    }
}