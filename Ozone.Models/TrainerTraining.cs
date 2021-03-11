using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ozone.Models
{
    [Table(name: "TrainerTraining", Schema = "Trainings")]
    public class TrainerTraining
    {     

        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; }
        public int TrainingId { get; set; }
        public Training Training { get; set; }

    }
}
