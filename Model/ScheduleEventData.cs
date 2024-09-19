using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleSample.Models
{
    public class ScheduleEventData
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        [MaxLength(100)]
        public string Subject { get; set; }

        [MaxLength(200)]
        public string Location { get; set; }

        public string Description { get; set; }

        public bool IsAllDay { get; set; }

        [MaxLength(50)]
        public string StartTimezone { get; set; }

        [MaxLength(50)]
        public string EndTimezone { get; set; }

        public string RecurrenceRule { get; set; }

        public int? RecurrenceID { get; set; }

        public string RecurrenceException { get; set; }
    }
}