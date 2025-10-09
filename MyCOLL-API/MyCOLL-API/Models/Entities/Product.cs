namespace MyCOLL_API.Models.Entities
{
    public enum State
    {
        Inactive,
        Active
    }
    public enum Quality
    {
        New, 
        Used
    }
    public class Product
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public double BasePrice { get; set; }
        public double SellTax { get; set; }
        public State State { get; set; }
        public Quality Quality { get; set; }
        public double FinalPrice
        {
            get
            {
                return BasePrice + (BasePrice * SellTax);
            }
        }
    }
}
