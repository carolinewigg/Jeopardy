using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JeopardyService.Models
{
    [Table("Questions")]
    public class JeopardyQuestion
    {
        [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public DateTime AirDate { get; set; }
        public string Question { get; set; }
        public int? DollarValue { get; set; }
        public string Answer { get; set; }
        public int RoundId { get; set; }
        public int ShowNumber { get; set; }
    }
}
