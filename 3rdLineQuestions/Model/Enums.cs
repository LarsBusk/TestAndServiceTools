using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _3rdLineQuestions.Model
{
    [Table("Enums")]
    [PrimaryKey("Id")]
    public class Enums
    {
        public short Id { get; }
        [Required]
        public string Kind { get; set; }
        [Required]
        public short Value { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
