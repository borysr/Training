namespace Orders.Domain
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int LineNumber { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}