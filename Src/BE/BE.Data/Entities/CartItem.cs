using System.ComponentModel.DataAnnotations;

namespace BE.Data.Entities
{
    public class CartItem
    {
        [Key]
        public int CartId { get; set; }

        public int UserId { get; set; }

        public int Qty { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
