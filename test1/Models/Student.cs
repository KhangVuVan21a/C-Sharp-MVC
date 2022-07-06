using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace test1.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        [Display(Name = "Name")]
        public String StudentName { get; set; }
        [Range(10,20,ErrorMessage ="age to ????")]
        public int Age { get; set; }
        public Boolean Sex { get; set; }

    }
}