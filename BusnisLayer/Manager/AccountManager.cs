using BusinessLayer.Common;
using BusinessLayer.IManager;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoriesLayer;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ViewModelLayer.Account;

namespace BusinessLayer.Manager
{
    public class AccountManager : ManagerBase, IAccountManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _config;
        public AccountManager(IUnitOfWork unitOfWork, IConfiguration config) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _config = config;
        }

        public async Task Register(RegisterModelVm registerModelVm)
        {
            try
            {
                // Check if the username is already taken
                var existingUser = await _unitOfWork.UserRepsitory.GetAll().FirstOrDefaultAsync(u => u.UserName == registerModelVm.UserName);
                if (existingUser != null)
                {


                    throw new Exception("Username is already taken");
                }
                var newUser = new User
                {
                    UserName = registerModelVm.UserName,
                    Email = registerModelVm.Email,
                    Password = registerModelVm.Password,
                    Name = registerModelVm.Name,
                };


                await _unitOfWork.UserRepsitory.AddAsync(newUser);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred during registration");
            }
        }



        public async Task<string> Login(LoginModelVm model)
        {
            try
            {
                // Find the user by username
                var user = await _unitOfWork.UserRepsitory.GetAll().FirstOrDefaultAsync(u => u.UserName == model.UserName);
                if (user == null)
                {
                    return null; // User not found
                }
                var token = await GenerateJwtTokenAsync(user);
                return token;
            }
            catch (Exception ex)
            {
                // Handle exceptions
                return null;
            }
        }


        private async Task<string> GenerateJwtTokenAsync(User user)
        {
            var secretKeyBase64 = _config["JWT:Secret"]; // Get the base64 encoded secret key from configuration
            byte[] keyBytes = Convert.FromBase64String(secretKeyBase64);
            var key = new SymmetricSecurityKey(keyBytes); // Create SymmetricSecurityKey from bytes

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: new[] { new Claim(ClaimTypes.Name, user.UserName) },
                expires: DateTime.Now.AddDays(10),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }


}


