using System;
using System.Threading.Tasks;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.Users.Commands.Interfaces
{
    public interface IGetUser
    {
        Task<User> GetUserByIdAsync(Guid userId, string jwtToken);
    }
}