using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ozone.Models
{
    [Table(name: "Trainee", Schema = "Trainings")]
    public class Trainee
    {
        [Required]
        public int TraineeId { get; set; }

        [Required]
        [StringLength(50)]
        public string FullName { get; set; }

        [Required]
        public DateTime DoB { get; set; }

        [Required]
        public int GenderId { get; set; }
        public Gender Gender { get; set; }

        [Required]
        [StringLength(250)]
        public string Address1 { get; set; }
        public string Address2 { get; set; }

        public int GradeId { get; set; }
        public Grade Grade { get; set; }

        public ICollection<TraineeTraining> TraineeTrainings { get; set; }


    }
}
