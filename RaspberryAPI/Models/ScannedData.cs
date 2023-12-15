using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RaspberryAPI.Models
{
    public class ScannedData
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public string Time { get; set; }

        [Required]
        public string CardId { get; set; }
    }

}