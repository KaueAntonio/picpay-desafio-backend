using PicPay.Infrasctructure.Database.Models;

namespace PicPay.Core.Transfers.Models.Input
{
    public class InTransfer
    {
        public decimal Value { get; set; }
        public string Payer { get; set; }
        public string Payee { get; set; }
        public static implicit operator Transaction(InTransfer transfer)
        {
            var result = new Transaction()
            {
                Amount = transfer.Value,
                DestinationUserId = transfer.Payee,
                SourceUserId = transfer.Payer,
                TransactionDate = DateTime.UtcNow
            };

            return result;
        }
    }
}
