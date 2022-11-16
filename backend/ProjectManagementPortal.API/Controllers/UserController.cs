using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementPortal.API.DTOs.Request;
using ProjectManagementPortal.API.DTOs.Response;
using ProjectManagementPortal.BL.Implementation;
using ProjectManagementPortal.BL.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using ProjectManagementPortal.API.Auth;
using Microsoft.AspNetCore.Authorization;
using ProjectManagementPortal.BL.BL;

namespace ProjectManagementPortal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]


    public class UserController : Controller
    {
        private readonly IUserServices _userServices;
        private readonly IOptions<JwtConfig> _config;
        private readonly IMapper _mapper;

        public UserController(IUserServices userServices, IMapper mapper,IOptions<JwtConfig> config)
        {
            _userServices = userServices;
            _mapper = mapper;
            _config = config;
        }



        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequest registerUserRequest)
        {
            var user = _mapper.Map<UserBL>(registerUserRequest);
            var status = await _userServices.RegisterUser(user);
            if (status)
            {
                return StatusCode(StatusCodes.Status201Created, "User Registered Successfully!!!!");
            }
            else
            {
                return BadRequest("ERROR While Registering User.Please Try Again!!!!");
            }
        }

        private bool IsUser(string emailId,string password)
        {
            return _userServices.IsUser(emailId, password);
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginRequest loginUser)
        {

            try
            {
                if (loginUser.EmailId != null && loginUser.Password != null)
                {
                    if (IsUser(loginUser.EmailId, loginUser.Password))
                    {
                        var status = _userServices.LoginUser(loginUser.EmailId, loginUser.Password);
                        if (status)
                        {
                            var res = GenerateJWt(loginUser.EmailId);
                            var IsAdmin = _userServices.IsAdmin(loginUser.EmailId);
                            res.IsAdmin = IsAdmin;
                            return StatusCode(StatusCodes.Status202Accepted, res);
                        }
                    }
                    else
                    {
                        return BadRequest("Please check the emailId or Password");
                    }
                }
                else
                {
                    return BadRequest();
                }
                return BadRequest();
            }
            catch (Exception)
            {

                throw;
            }
        }
        [Authorize]
        [HttpPost("Logout")]
        public IActionResult LogoutUser()
        {
            var emailClaim = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email);
            var result = _userServices.LogoutUser();
            if(result)
            {
                return StatusCode(StatusCodes.Status202Accepted, "User Logged Out");
            }
            else
            {
                return BadRequest("ERROR!!!! Couldn't Logout.");
            }
        }

        
        [HttpGet]
        public ActionResult<List<UserResponse>> GetAllUsers()
        {
            var dbUsers=_userServices.GetAllUsers();
            return _mapper.Map<List<UserResponse>>(dbUsers);
        }


        [HttpGet("Id")]
        public ActionResult<List<UserResponse>> GetUserByUserId(int userId)
        {
            var dbUsers=_userServices.GetUserByUserId(userId);
            return _mapper.Map<List<UserResponse>>(dbUsers);
        }


        [HttpGet("Name")]
        public ActionResult<List<UserResponse>> GetUserByUserName(string userName)
        {
            var dbUser = _userServices.GetUserByUserName(userName);
            return _mapper.Map<List<UserResponse>>(dbUser);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest userRequest)
        {
            var user = _mapper.Map<UserUpdateBL>(userRequest);
            var status = await _userServices.UserUpdateBL(user);
            if (status)
            {
                return StatusCode(StatusCodes.Status201Created, "User Updated Successfully!!!!");
            }
            else
            {
                return BadRequest("ERROR While Updating User.Please Try Again!!!!");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var status = await _userServices.DeleteUser(userId);
            if (status)
            {
                return StatusCode(StatusCodes.Status200OK, $"User with UserID {userId} is this deleted successfully!");
            }
            else
            {
                return BadRequest($"An error occurred while removing user with USerID {userId}, Please check the ID and try again!!");
            }
        }

        private LoginResponse GenerateJWt(string email)
        {
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,email)
            };

            
            // Form the security key
            var secKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Value.Secret));
            var token = new JwtSecurityToken(
                issuer: _config.Value.ValidIssuer,
                audience: _config.Value.ValidAudience,
                expires: DateTime.Now.AddMinutes(30),
                claims: authClaims,
                signingCredentials: new SigningCredentials(secKey, SecurityAlgorithms.HmacSha256)
                );
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            var expiry = token.ValidTo;
            return new LoginResponse
            {
                Token = jwtToken,
                Expiry = expiry
            };
        }

        [HttpGet("loggedInUserId")]
        public int LoggedInUserId()
        {
            var res = _userServices.LoggedInUserId();
            return res;
        }
    }

}

