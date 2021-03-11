using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ozone.Models
{
    [Table(name: "Trainer", Schema = "Trainings")]
    public class Trainer
    {
        [Required]
        public int TrainerId { get; set; }

        [Required]
        [StringLength(50)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string PhoneHome { get; set; }

        [Required]
        [StringLength(500)]
        public string PhoneMobile { get; set; }

        [Required]
        public string Specialization { get; set; }        

        [Required]
        [StringLength(250)]
        public string Address1 { get; set; }

        [StringLength(250)]
        public string Address2 { get; set; }
        public int IsDeleted { get; set; }

        public ICollection<TrainerTraining> TrainerTrainings { get; set; }

    }
}
