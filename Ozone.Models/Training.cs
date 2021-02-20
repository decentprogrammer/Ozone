using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ozone.Models
{
    [Table(name: "Training", Schema = "Trainings")]
    public class Training
    {
        [Required]
        public int TrainingId { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public ICollection<TraineeTraining> TraineeTrainings { get; set; }
        public ICollection<Trainer> Trainers { get; set; }
    }
}
