﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TANE.Domain.Entities;

namespace TANE.Application.Groups.Kunder.Commands.Interfaces
{
    public interface IDeleteKunde
    {
        Task<bool> DeleteKundeAsync(int kundeId, string jwtToken);
    }
}
