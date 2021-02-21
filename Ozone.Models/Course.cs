﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ozone.Models
{
    [Table(name: "Course", Schema = "Trainings")]
    public class Course
    {
        [Required]
        public int CourseId { get; set; }

        [Required]
        [StringLength(250)]
        public string CourseName { get; set; }

        public ICollection<Training> Trainings { get; set; }
    }
}