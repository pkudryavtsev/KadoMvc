namespace ProductDb.DataClasses
{
    public class BoxProduct
    {
        public int Id { get; set; }
        public int BoxId { get; set; }
        public Box Box { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}