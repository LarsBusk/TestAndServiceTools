using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThirdLineQs.Model
{
    [Table("Questions")]
    [PrimaryKey("QuestionId")]
    internal class Questions
    {
        public int QuestionId { get; set; }
        [Required]
        public DateTime QuestionTime { get; set; }
        [Required]
        public short Kind { get; set; }
        [Required]
        public short Duration { get; set; }
        public string Comment { get; set; }
    }
}
