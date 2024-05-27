namespace PicPay.Infrasctructure.Database.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int SourceUserId { get; set; }
        public int DestinationUserId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
