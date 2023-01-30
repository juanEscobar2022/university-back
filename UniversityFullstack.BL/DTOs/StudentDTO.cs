﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityFullstack.BL.DTOs
{
    public class StudentDTO
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]

        public string FirstMidName { get; set; }
        [Required]
        public string EnrollmentDate { get; set; }

        public string FullName
        {
            get { return string.Format("{0} {1}", LastName, FirstMidName); }
        }
    }
}
