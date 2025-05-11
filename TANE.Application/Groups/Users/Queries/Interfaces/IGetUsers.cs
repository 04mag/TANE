using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.Users.Queries.Interfaces
{
    
        public interface IGetUsers
        {
            Task<IReadOnlyList<User>> GetUsersAsync(string jwtToken);
        }
    
}
