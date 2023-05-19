using ESISA.Core.Application.Dtos.Security.Authorization;
using ESISA.Core.Application.Interfaces.Repositories.Common;
using ESISA.Core.Domain.Entities;

namespace ESISA.Core.Application.Interfaces.Repositories
{
    public interface IUserQueryRepository : IQueryRepository<User>
    {
        List<Role> GetRolesByUserId(Guid userId);
        List<OperationClaim> GetOperationClaimsByUserId(Guid userId);
        List<OperationClaim> GetOperationClaimsByRoleId(Guid roleId);

        List<OperationClaim> GetOperationClaimsByRoleNames(params String[] roleNames);
    }
}
