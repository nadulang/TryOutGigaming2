namespace PaymentService.Application.Models.Query
{
    public class BaseDto
    {
        public string message { get; set; }
        public bool success { get; set; }
    }
    public class CommandDto<T>
    {
        public Attribute<T> Data { get; set; }
    }

    public class Attribute<T>
    {
        public T Attributes { get; set; }
    }
}
