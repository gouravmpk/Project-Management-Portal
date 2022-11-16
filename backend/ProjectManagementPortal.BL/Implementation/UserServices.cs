using ProjectManagementPortal.BL.BL;
using ProjectManagementPortal.BL.Interface;
using ProjectManagementPortal.DL.Entities;
using ProjectManagementPortal.DL.Repositories.IRepo;
using ProjectManagementPortal.DL.Repositories.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementPortal.BL.Implementation
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepo _userRepo;

        public UserServices(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }
        public async Task<bool> RegisterUser(UserBL user)
        {
            var result = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth,
                EmailId = user.EmailId,
                PhoneNumber = user.PhoneNumber,
                Location = user.Location,
                DesignationId = user.DesignationId,
                DepartmentId = user.DepartmentId,
                Password = user.Password,
                CreateDate = DateTime.Now

            };
            return await _userRepo.RegisterUser(result);
        }
        public bool LoginUser(string email, string password)
        {
            return _userRepo.LoginUser(email, password);
        }
        public bool LogoutUser()
        {
            return _userRepo.LogoutUser();
        }

        public IQueryable<GetUserBL> GetAllUsers()
        {
            var users = _userRepo.GetAllUsers();
            var getUsersList = new List<GetUserBL>();
            foreach (var user in users)
            {
                getUsersList.Add(new GetUserBL
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    EmailId = user.EmailId,
                    PhoneNumber = user.PhoneNumber,
                    Location = user.Location,
                    UserId =user.UserId
                });

            }
            return getUsersList.AsQueryable();
        }

        public IQueryable<GetUserBL> GetUserByUserId(int userId)
        {
            var userQueryable = _userRepo.GetUserByUserId(userId);
            var userList = new List<GetUserBL>();
            foreach (var user in userQueryable)
            {
                userList.Add(new GetUserBL
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    EmailId = user.EmailId,
                    Location = user.Location
                });

            }
            return userList.AsQueryable();
        }

        public IQueryable<GetUserBL> GetUserByUserName(string userName)
        {
            var userQuerable = _userRepo.GetUserByUserName(userName);
            var userList = new List<GetUserBL>();
            foreach (var user in userQuerable)
            {
                userList.Add(new GetUserBL
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    EmailId = user.EmailId,
                    Location = user.Location
                });

            }
            return userList.AsQueryable();

        }

        public async Task<bool> DeleteUser(int userId)
        {
            var result = await _userRepo.DeleteUser(userId);
            return result;
        }
        public async Task<bool> UserUpdateBL(UserUpdateBL userUpdate)
        {
            var result = new User
            {
                FirstName = userUpdate.FirstName,
                LastName = userUpdate.LastName,
                PhoneNumber = userUpdate.PhoneNumber,
                Location = userUpdate.Location,
            };
            return await _userRepo.UpdateUser(result);
        }

        public bool IsUser(string emailId,string password)
        {
            return _userRepo.IsUser(emailId, password);
        }

        public int LoggedInUserId()
        {
            return _userRepo.LoggedInUserId();
        }
        public bool IsAdmin(string emailId)
        {
            return _userRepo.IsAdmin(emailId);
        }
    }
}
