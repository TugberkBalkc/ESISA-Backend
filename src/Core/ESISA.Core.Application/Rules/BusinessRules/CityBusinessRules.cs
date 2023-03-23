﻿using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Rules.BusinessRules.Common;
using ESISA.Core.Domain.Exceptions.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Rules.BusinessRules
{
    public class CityBusinessRules: BusinessRulesBase
    {
        private readonly String _entityName;

        public CityBusinessRules()
        {
            _entityName = "Şehir";   
        }
        public virtual async Task NullCheck(object entity)
        {
            if (entity is null)
                throw new BusinessLogicException(ResponseTitles.Error, $"{_entityName} {ResponseMessages.NotFound}");
        }

        public virtual async Task NullCheck(object[] entities)
        {
            for (int i = 0; i < entities.Length; i++)
            {
                if (entities[i] is null)
                {
                    throw new BusinessLogicException(ResponseTitles.Error, $"{_entityName} {ResponseMessages.NotFound}");
                }
            }
        }

        public virtual async Task ExistsCheck(object entity)
        {
            if (entity is not null)
                throw new BusinessLogicException(ResponseTitles.Error, $"{_entityName} {ResponseMessages.AlreadyExists}");
        }
    }
}
