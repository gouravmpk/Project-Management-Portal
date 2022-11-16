using ProjectManagementPortal.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementPortal.DL.Repositories.IRepo
{
    public interface IUserRepo
    {
        Task<bool> RegisterUser(User user);
        bool LoginUser(string email, string password);
        bool LogoutUser();

        List<User> GetAllUsers();
        List<User> GetUserByUserId(int userId);
        List<User> GetUserByUserName(string userName);
        Task<bool> DeleteUser(int userId);
        Task<bool> UpdateUser(User user);
        int LoggedInUserId();
        bool IsUser(string emailId, string password);
        bool IsAdmin(string emailId);

    }
}
