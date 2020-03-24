namespace PaymentService.Domain.Entities
{
    public class OrderModel
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public long created_at { get; set; }
        public long updated_at { get; set; }

        public UsersModel user { get; set; }
    }
}
