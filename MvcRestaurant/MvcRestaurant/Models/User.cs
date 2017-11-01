using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;


namespace MvcRestaurant.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        [RegularExpression("[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,4}")]
        public string UserName { get; set; }

        [Required]
        public string passWord { get; set; }

         [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
   
}