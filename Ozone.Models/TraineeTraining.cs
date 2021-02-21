using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ozone.Models
{
    [Table(name: "TraineeTraining", Schema = "Trainings")]
    public class TraineeTraining
    {     

        public int TraineeId { get; set; }
        public Trainee Trainee { get; set; }
        public int TrainingId { get; set; }
        public Training Training { get; set; }

    }
}
