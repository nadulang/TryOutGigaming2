namespace PaymentService.Domain.Entities
{
    public class OrderDetailsModel
    {
        public int id { get; set; }
        public int product_id { get; set; }
        public int order_id { get; set; }
        public int count { get; set; }
        public int price { get; set; }
        public long created_at { get; set; }
        public long updated_at { get; set; }

        public ProductModel product { get; set; }
        public OrderModel order { get; set; }
    }
}
