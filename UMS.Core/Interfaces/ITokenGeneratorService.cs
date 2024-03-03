using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UMS.Core.DTOs;

namespace UMS.Core.Interfaces
{
    public interface ITokenGeneratorService
    {
        string GenerateToken();
    }
}
