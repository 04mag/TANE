using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TANE.Application.RepositoryInterfaces;
using TANE.Domain.Entities;
using TANE.Persistence.Configuration; 

namespace TANE.Persistence.Repositories
{
    internal class UserRepository : IUserRepository
    {
        

        public Task<User> CreateUser(User user, string jwtToken)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUser(User user, string jwtToken)
        {
            throw new NotImplementedException();
        }

        public Task<User> ReadUserById(int id, string jwtToken)
        {
            throw new NotImplementedException();
        }

        public Task<User> ReadAllUser(string jwtToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> DeleteUser(int id, string jwtToken)
        {
            throw new NotImplementedException();
        }

        Task<bool> IUserRepository.DeleteUser(int userId, string jwtToken)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserById(int userId, string jwtToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAllUser(string jwtToken)
        {
            throw new NotImplementedException();
        }
    }
}
