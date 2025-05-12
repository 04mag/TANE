using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TANE.Domain.Entities;


namespace TANE.Application.RepositoryInterfaces
{
   
    public interface IUserRepository
    {
        Task<User> CreateUser(User user, string jwtToken);
        
        Task<User> UpdateUser(User user, string jwtToken);
     
        Task<bool> DeleteUser(int userId, string jwtToken);
       
        Task<User> GetUserById(int userId, string jwtToken);

        Task<List<User>> GetAllUser(string jwtToken);
    }
}
