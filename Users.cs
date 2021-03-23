using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreManagement.Entities
{
    [Table(name: "Users")]
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string UserName { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string EmailId { get; set; }

        [Column(TypeName = "text")]
        public string IsDeleted { get; set; }
    }
}
