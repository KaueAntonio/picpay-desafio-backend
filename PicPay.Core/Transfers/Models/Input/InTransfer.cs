namespace PicPay.Core.Transfers.Models.Input
{
    public class InTransfer
    {
        public decimal Value { get; set; }
        public string Payer { get; set; }
        public string Payee { get; set; }
    }
}
