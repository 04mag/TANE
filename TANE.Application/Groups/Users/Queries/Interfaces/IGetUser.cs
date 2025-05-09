using System;
using System.Threading.Tasks;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.Users.Queries.Interfaces
{
    public interface IGetUser
    {
        Task<User> GetUserByIdAsync(Guid userId, string jwtToken);
    }
    public interface IGetUsers
    {
        Task<IReadOnlyList<User>> GetUsersAsync(string jwtToken);
    }
}
