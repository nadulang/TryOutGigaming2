using System;
namespace PaymentService.Domain.Entities
{
    public class PaymentModel
    {
        public int id { get; set; }
        public int order_id { get; set; }
        public int transaction_id { get; set; }
        public string payment_type { get; set; }
        public int gross_amount { get; set; }
        public string bank { get; set; }
        public DateTime transaction_time { get; set; }
        public string transaction_status { get; set; }
        public long created_at { get; set; }
        public long updated_at { get; set; }

        public OrderModel orders { get; set; }
    }
}
