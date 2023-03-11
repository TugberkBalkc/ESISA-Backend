using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Domain.Exceptions.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Rules.BusinessRules
{
    public class RoleBusinessRules
    {
        private readonly IRoleQueryRepository _roleQueryRepository;
        private readonly String _entityName;
        public RoleBusinessRules(IRoleQueryRepository roleQueryRepository)
        {
            _roleQueryRepository = roleQueryRepository;
            _entityName = "Rol";
        }

        public virtual async Task NullCheck(object entity)
        {
            if (entity is null)
                throw new BusinessLogicException(ResponseTitles.Error, $"{_entityName} {ResponseMessages.NotFound}");
        }

        public virtual async Task ExistsCheck(object entity)
        {
            if (entity is not null)
                throw new BusinessLogicException(ResponseTitles.Error, $"{_entityName} {ResponseMessages.AlreadyExists}");
        }

        public async Task ExistsCheckByRoleName(String roleName)
        {
            var role = await _roleQueryRepository.GetSingleAsync(p => p.Name.Trim().ToLower() == roleName.Trim().ToLower());

            if (role is not null)
                throw new BusinessLogicException(ResponseTitles.Error, $"{_entityName} {ResponseMessages.AlreadyExists}");
        }

        public async Task NullCheckByBrandId(Guid roleId)
        {
            var role = await _roleQueryRepository.GetByIdAsync(roleId);

            if (role is null)
                throw new BusinessLogicException(ResponseTitles.Error, $"{_entityName} {ResponseMessages.NotFound}");
        }
    }
}
