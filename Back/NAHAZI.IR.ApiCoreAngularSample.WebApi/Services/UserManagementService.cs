using Microsoft.IdentityModel.Tokens;
using NAHAZI.IR.ApiCoreAngularSample.WebApi.DataLayer;
using NAHAZI.IR.ApiCoreAngularSample.WebApi.Model.DomainClasses;
using NAHAZI.IR.ApiCoreAngularSample.WebApi.Model.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NAHAZI.IR.ApiCoreAngularSample.WebApi.Services
{
    public interface IUserManagementService
    {
        string Login(UserLoginModel userModel);
        void AddUser(User user);
    }
    public class UserManagementService : IUserManagementService
    {
        #region Fields

        private readonly IConfiguration _config;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Ctor

        public UserManagementService(
            IConfiguration config,
            IUnitOfWork unitOfWork)
        {
            _config = config;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Public Methods

        public void AddUser(User user)
        {
            _unitOfWork.User.Add(user);
            _unitOfWork.Save();
        }
        public string Login(UserLoginModel userModel)
        {
            var user = Authenticate(userModel);
            if (user != null)
            {
                return GenerateToken(user);
            }
            return null;
        }



        #endregion

        #region Private Methods

        private string GenerateToken(UserModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName,user.GivenName),
                new Claim(ClaimTypes.Surname,user.Surname),
                new Claim(ClaimTypes.Role,user.Role)
            };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(60),
                Issuer = _config["Jwt:Issuer"],
                Audience = _config["Jwt:Audience"],
                SigningCredentials = credentials
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private UserModel? Authenticate(UserLoginModel userModel)
        {
            var currentUser = GetCurrentUser(userModel);
            if (currentUser != null) return currentUser;
            return null;
        }

        private UserModel? GetCurrentUser(UserLoginModel userModel)
        {
            return UserConstants.Users.FirstOrDefault(x => x.UserName?.ToLower() == userModel.UserName?.ToLower() && x.Password == userModel.Password);
        }

        #endregion

    }
}
