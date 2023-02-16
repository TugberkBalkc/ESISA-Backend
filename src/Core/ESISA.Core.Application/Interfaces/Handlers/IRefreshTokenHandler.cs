using ESISA.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Interfaces.Handlers
{
    public interface IRefreshTokenHandler
    {
        Task<RefreshToken> CreateRefreshTokenAsync(Guid userId);
        Task<RefreshToken> UpdateRefreshTokenAsync(Guid userId);
    }
}
