using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreManagement.Entities
{
    [Table(name: "Transcations")]
    public class Transcations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TranscationId { get; set; }

        [ForeignKey("books")]
        [Column(TypeName ="int")]
        [Required]
        public int TranscationBookId { get; set; }

        [ForeignKey("users")]
        [Column(TypeName ="int")]
        [Required]
        public int TranscationUserId { get; set; }

        [Column(TypeName ="int")]
        [Required]
        public int TranscationQuantity { get; set; }

        [Column(TypeName ="text")]
        [Required]
        public string TranscationAvailedAs { get; set; }

        [Column(TypeName ="Date")]
        [Required]
        public DateTime DateToReturn { get; set; }


        public Books books { get; set; }
        public Users users { get; set; }
    }
}