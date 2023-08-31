namespace GeekShopping.OrderAPI.Messages
{
    public class UpdatePaymentResultVO
    {
        public long OrderId { get; set; }
        public string Status { get; set; }
        public string Email { get; set; }
    }
}
