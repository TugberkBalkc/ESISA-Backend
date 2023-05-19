using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Domain.Entities;
using ESISA.Infrastructure.Persistence.EntityFramework.Contexts;
using ESISA.Infrastructure.Persistence.EntityFramework.Repositories.Common;
using System.Linq.Dynamic.Core;

namespace ESISA.Infrastructure.Persistence.EntityFramework.Repositories
{
    public class EFUserQueryRepository : EfQueryRepositoryBase<User>, IUserQueryRepository
    {
        private readonly IUserRoleQueryRepository _userRoleQueryRepository;

        public EFUserQueryRepository(ESISADbContext dbContext, IUserRoleQueryRepository userRoleQueryRepository) : base(dbContext)
        {
            _userRoleQueryRepository = userRoleQueryRepository;
        }

        public List<OperationClaim> GetOperationClaimsByRoleId(Guid roleId)
        {

            var operationClaims = from roleOperatioClaim in _dbContext.Set<RoleOperationClaim>()
                                  join role in _dbContext.Set<Role>()
                                  on roleOperatioClaim.RoleId equals role.Id
                                  join operationClaim in _dbContext.Set<OperationClaim>()
                                  on roleOperatioClaim.OperationClaimId equals operationClaim.Id
                                  where roleOperatioClaim.RoleId == roleId
                                  select new OperationClaim()
                                  {
                                      Id = operationClaim.Id,
                                      CreatedDate = operationClaim.CreatedDate,
                                      ModifiedDate = operationClaim.ModifiedDate,
                                      IsActive = operationClaim.IsActive,
                                      IsDeleted = operationClaim.IsDeleted,
                                      ClaimName = operationClaim.ClaimName
                                  };

            return operationClaims.ToList();
        }

        public List<OperationClaim> GetOperationClaimsByRoleNames(params string[] roleNames)
        {
            var roles = new List<Role>();

            roleNames.ToList().ForEach(roleName =>
            {
                var role = _dbContext.Set<Role>().SingleOrDefault(e => e.Name == roleName);

                roles.Add(role);
            });

            var operationClaims = new List<OperationClaim>();

            roles.ForEach(e =>
            {
                operationClaims.AddRange(this.GetOperationClaimsByRoleId(e.Id));
            });

            return operationClaims;
        }



        public List<OperationClaim> GetOperationClaimsByUserId(Guid userId)
        {
            var usersRoles = this.GetRolesByUserId(userId);
            
            var usersRoleOperationClaims = new List<OperationClaim>();

            usersRoles.ToList().ForEach(e =>
            {
                var operationClaims = from roleOperatioClaim in _dbContext.Set<RoleOperationClaim>()
                                      join role in _dbContext.Set<Role>()
                                      on roleOperatioClaim.RoleId equals role.Id
                                      join operationClaim in _dbContext.Set<OperationClaim>()
                                      on roleOperatioClaim.OperationClaimId equals operationClaim.Id

                                      select new OperationClaim()
                                      {
                                          Id = operationClaim.Id,
                                          CreatedDate = operationClaim.CreatedDate,
                                          ModifiedDate = operationClaim.ModifiedDate,
                                          IsActive = operationClaim.IsActive,
                                          IsDeleted = operationClaim.IsDeleted,
                                          ClaimName = operationClaim.ClaimName
                                      };

                usersRoleOperationClaims.AddRange(operationClaims.ToList());
            });

            return usersRoleOperationClaims;
        }

        public List<Role> GetRolesByUserId(Guid userId)
        {
            var roles = from userRole in _dbContext.Set<UserRole>()
                        join user in _dbContext.Set<User>()
                        on userRole.UserId equals user.Id
                        join role in _dbContext.Set<Role>()
                        on userRole.RoleId equals role.Id
                        where userRole.UserId == userId
                        select new Role()
                        {
                            Id = role.Id,
                            CreatedDate = role.CreatedDate,
                            ModifiedDate = role.ModifiedDate,
                            IsActive = role.IsActive,
                            IsDeleted = role.IsDeleted,
                            Name = role.Name
                        };

            return roles.ToList();
        }
    }
}
