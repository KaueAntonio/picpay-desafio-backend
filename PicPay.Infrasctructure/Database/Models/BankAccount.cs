namespace PicPay.Infrasctructure.Database.Models
{
    public class BankAccount
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Balance { get; set; }
    }
}
