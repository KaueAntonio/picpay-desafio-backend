using System.Security.Cryptography.Xml;

namespace PicPay.Infrasctructure.Database.Models
{
    public class BankAccount
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public decimal Balance { get; private set; }
        public void UpdateBalance(decimal ammount)
        {
            CheckTransferAmmount(ammount);

            Balance += ammount;
        }
        private void CheckTransferAmmount(decimal ammount)
        {
            var newBalance = Balance + ammount;
            if (newBalance < 0)
                throw new Exception("Insuficient Balance");
        }
    }
}
