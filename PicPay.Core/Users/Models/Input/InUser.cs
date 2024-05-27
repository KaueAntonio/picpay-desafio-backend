using PicPay.Infrasctructure.Database.Models;
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

        public static implicit operator User(InUser user)
        {
            User newUser = new()
            {
                CPF = user.CPF,
                Email = user.Email,
                Password = user.Password,
                FullName = user.FullName,
            };

            return newUser;
        }
    }
}
