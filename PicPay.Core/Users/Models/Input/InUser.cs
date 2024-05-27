using PicPay.Infrasctructure.Database.Models;
using PicPay.Infrasctructure.Utils;
using System.ComponentModel.DataAnnotations;

namespace PicPay.Core.Users.Models.Input
{
    public class InUser
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public string UserName { get; set; }

        public static implicit operator User(InUser user)
        {
            User newUser = new()
            {
                CPF = user.CPF,
                Email = user.Email,
                Password = user.Password,
                FullName = user.FullName,
                Role = user.Role,
                UserName = user.UserName
            };

            return newUser;
        }
        public void Validate()
        {
            if (Role != "Default" && Role != "Lojista")
                throw new Exception("Invalid User Role");

            if (!CpfOperations.IsValid(CPF))
                throw new Exception("Invalid CPF");
        }
    }
}
