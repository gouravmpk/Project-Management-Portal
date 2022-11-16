using Microsoft.EntityFrameworkCore;
using ProjectManagementPortal.DL.Entities;
using ProjectManagementPortal.DL.Repositories.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementPortal.DL.Repositories.Repo
{
    public class UserRepo : IUserRepo
    {
        private static int loggedInUserId = 0;
        private readonly ApplicationDbContext _applicationDbContext;

        public UserRepo(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<bool> RegisterUser(User user)
        {
            await _applicationDbContext.Users.AddAsync(user);
            var status = await _applicationDbContext.SaveChangesAsync();
            if (status == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool LoginUser(string email, string password)
        {
            var user = _applicationDbContext.Users.FirstOrDefault(x => x.EmailId == email);
            if (user != null)
            {
                if (user.Password == password)
                {
                    loggedInUserId = user.UserId;
                    return true;
                }

            }
            return false;
        }
        public bool LogoutUser()
        {
            if (loggedInUserId == 0)
                return false;
            loggedInUserId = 0;
            return true;
        }

        public List<User> GetAllUsers()
        {
            return _applicationDbContext.Users.ToList();
        }

        public List<User> GetUserByUserId(int userId)
        {
            var user = _applicationDbContext.Users.Where(x => x.UserId == userId).ToList();
            return user;
        }

        public List<User> GetUserByUserName(string userName)
        {
            var Name = userName.Split(' ');
            var user = _applicationDbContext.Users.Where(x => x.FirstName == Name[0] && x.LastName == Name[1]).ToList();
            return user;
        }

        public async Task<bool> DeleteUser(int userId)
        {
            var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => x.UserId == userId);
            if (user != null)
            {
                var status = _applicationDbContext.Remove(user);
                if (status != null)
                {
                    await _applicationDbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            return false;
        }
        public async Task<bool> UpdateUser(User user)
        {
            var users = await _applicationDbContext.Users.FirstOrDefaultAsync(x => x.UserId == loggedInUserId);
            if (users != null)
            {
                users.FirstName = user.FirstName;
                users.LastName = user.LastName;
                users.PhoneNumber = user.PhoneNumber;
                users.Location = user.Location;
                users.UpdateDate = DateTime.Now;
            }
            var res = await _applicationDbContext.SaveChangesAsync();
            return (res == 1) ? true : false;
        }
        public int LoggedInUserId()
        {
            return loggedInUserId;
        }
        public bool IsUser(string emailId, string password)
        {
            var status = _applicationDbContext.Users.FirstOrDefault(x => x.EmailId == emailId);
            if (status != null)
            {
                var res = (status.Password == password);
                return res;
            }
            else
                return false;
        }
        public bool IsAdmin(string emailId)
        {
            return _applicationDbContext.Users.Any(x => x.EmailId == emailId && x.Designation.DesignationName == "Manager");
        }
    }
}
