using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreManagement.Entities
{
    [Table(name: "Books")]
    public class Books
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string BookName { get; set; }
        
        [Column(TypeName = "text")]
        [Required]
        public string Author { get; set; }
        
        [Column(TypeName = "text")]
        [Required]
        public string Publisher { get; set; }
        
        [Column(TypeName = "int")]
        [Required]
        public int Cost { get; set; }
        
        [Column(TypeName = "text")]
        [Required]
        public string AvilableFor { get; set; }
        
        [Column(TypeName = "int")]
        [Required]
        public int Quantity { get; set; }
    }
}
