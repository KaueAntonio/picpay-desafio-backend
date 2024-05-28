namespace PicPay.Infrasctructure.Database.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string SourceUserId { get; set; }
        public string DestinationUserId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
