using Microsoft.AspNetCore.Identity;

namespace PicPay.Infrasctructure.Database.Models
{
    public class User : IdentityUser<string>
    {
        private string id = Guid.NewGuid().ToString();
        public override string Id { get => id; set => id = value; }
        public string FullName { get; set; }
        public string CPF { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
