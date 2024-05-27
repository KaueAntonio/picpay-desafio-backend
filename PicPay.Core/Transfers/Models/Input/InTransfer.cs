namespace PicPay.Core.Transfers.Models.Input
{
    public class InTransfer
    {
        public decimal Value { get; set; }
        public int Payer { get; set; }
        public int Payee { get; set; }
    }
}
