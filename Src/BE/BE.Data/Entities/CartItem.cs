using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE.Data.Entities
{
    public class CartItem
{
        [Key]
        public int CartId { get; set; }

        [Required]
        public int Qty { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4")]
        public decimal Price { get; set; }

        [Required]
        public string OrderNr { get; set; }

        [Required]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
