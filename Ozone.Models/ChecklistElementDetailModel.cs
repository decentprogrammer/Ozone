using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ozone.Models
{
    public class ChecklistElementDetailModel
    {
        [Key]
        public int Id { get; set; }
        public Guid GuidId { get; set; }
        [StringLength(20)]
        public string Status { get; set; }
        [Required]
        [StringLength(100)]
        public string FaultType { get; set; }
        [Required]
        [StringLength(100)]
        public string FaultOther { get; set; }
        [StringLength(100)]
        public string ActionType { get; set; }
        [StringLength(100)]
        public string ActionOther { get; set; }
        [Required]
        public DateTime StartEventDate { get; set; }
        public DateTime? EndEventDate { get; set; }
        [Required]
        public DateTime StartEventHour { get; set; }
        public DateTime? EndEventHour { get; set; }
        public DateTime? LastMINT { get; set; }
        public DateTime? NextMINT { get; set; }
        [Required]
        public string FaultDescription { get; set; }
        public string ResponseDescription { get; set; }
        public string Note { get; set; }
        public string EmployeesInvolved { get; set; }
        [Required]
        public bool PublicVisible { get; set; }
        [StringLength(20)]
        public string FaultRank { get; set; }
        public bool FinalStatus { get; set; }
        public Guid UnitGuid { get; set; }

        public Guid ElementId { get; set; }
        public ChecklistElementModel ChecklistElementModel { get; set; }
    }
}
