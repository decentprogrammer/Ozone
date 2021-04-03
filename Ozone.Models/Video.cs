using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ozone.Models
{
    [Table(name: "Video", Schema = "Trainings")]
    public class Video
    {
        [Required]
        public int VideoId { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public string Title { get; set; }
        public string Duration { get; set; }
        public string URL { get; set; }
        public int IsDeleted { get; set; }

    }
}
