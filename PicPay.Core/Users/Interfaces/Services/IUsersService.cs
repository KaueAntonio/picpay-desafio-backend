using PicPay.Core.Users.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPay.Core.Users.Interfaces.Services
{
    public interface IUsersService
    {
        Task CreateUser(InUser user);
    }
}
