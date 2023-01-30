﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityFullstack.BL.DTOs
{
    public class CourseDTO
    {
        [Required(ErrorMessage ="The field course ID is required")]
        public int CourseID { get; set; }
        [Required(ErrorMessage ="The field Title is required")]
        [StringLength(50)]
        public string Title { get; set; }
        [Required(ErrorMessage ="The field Credits is required")]
        public int Credits { get; set; }
    }
}
