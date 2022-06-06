using BE.Data.Entities;

namespace BE.Data.Dtos
{
    public class NewCartItem
    {
        public int Qty { get; set; }

        public decimal Price { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
