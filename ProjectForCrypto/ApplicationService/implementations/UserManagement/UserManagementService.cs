﻿using ApplicationService.Models.UserModels;
using Contracts;
using Data.Entities;
using System.Security.Cryptography;
using System.Text;

namespace ApplicationService.implementations.UserManagement
{
    public class UserManagementService : IUserManagementService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;
        public UserManagementService(IUnitOfWork unitOfWork, IJwtAuthenticationManager jwtAuthenticationManager)
        {
            _unitOfWork = unitOfWork;
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }


        public async Task<bool> Registration(RegistrationModel registrationModel)
        {
            UserEntity user = _unitOfWork.Users.FindAsync(u => u.Email == registrationModel.Email).FirstOrDefault();
            if (user != null)
                return false;

            string passwordHash = HashPassword(registrationModel.Password);
            user = new UserEntity();
            user.Email = registrationModel.Email;
            user.PasswordHash = passwordHash;

            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SaveAsync();

            return true;
        }

        public async Task<string> Authorization(AuthenticateModel model)
        {
            string passwordHash = HashPassword(model.Password);
            UserEntity user = await _unitOfWork.Users.GetByEmailAndHashPassword(model.Email, passwordHash);
            if (user == null)
                return string.Empty;
            string jwtToken = _jwtAuthenticationManager.GenerateToken(user);
            return jwtToken;
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();

                return hash;
            }
        }
    }
}
