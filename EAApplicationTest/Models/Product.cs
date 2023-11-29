namespace EAApplicationTest.Models
{
    public class Product //We create models to make it easy to transfer data during tests, to know what exactly should be filled etc
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public ProductType ProductType { get; set; }
    }

    public enum ProductType
    {
        CPU,
        MONITOR,
        PERIPHARALS,
        EXTERNAL
    }
}