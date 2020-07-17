using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JeopardyService.Models
{
    [Table("Rounds")]
    public class Round
    {
        [Key]
        public int Id { get; set; }
        public string RoundName { get; set; }
    }
}
