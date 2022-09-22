using System.ComponentModel.DataAnnotations;

namespace LeaveManagementWeb_Core_6.Models
{
    public class LeaveTypeVM
    {
        public int Id { get; set; }
        [Display(Name = "LeaveType Name")]
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Default number of days")]
        public int DefaultDays { get; set; }
    }
}
