using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagementPortal.BL.BL;

namespace ProjectManagementPortal.BL.Interface
{
    public interface IUserServices
    {
        Task<bool> RegisterUser(UserBL userBL);
        bool LoginUser(string email,string password);
        bool LogoutUser();
        IQueryable<GetUserBL> GetAllUsers();
        IQueryable<GetUserBL> GetUserByUserId(int userId);
        IQueryable<GetUserBL> GetUserByUserName(string userName);
        Task<bool> DeleteUser(int userId);
        Task<bool> UserUpdateBL(UserUpdateBL userUpdate);
        bool IsUser(string emailId, string password);
        int LoggedInUserId();
        bool IsAdmin(string emailId);
    }
}
