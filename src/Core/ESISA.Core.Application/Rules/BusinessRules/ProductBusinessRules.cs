﻿using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Domain.Exceptions.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Rules.BusinessRules
{
    public class ProductBusinessRules
    {
        private readonly String _entityName;
        public ProductBusinessRules()
        {
            _entityName = "Ürün";
        }

        public virtual async Task NullCheck(object entity)
        {
            if (entity is null)
                throw new BusinessLogicException(ResponseTitles.Error, $"{_entityName} {ResponseMessages.NotFound}");
        }

        public virtual async Task NullCheck(object[] entities)
        {
            if(entities is null || entities.Count() == 0)
                throw new BusinessLogicException(ResponseTitles.Error, ResponseMessages.NothingFoundAccordingToFilter);
        }

        public virtual async Task ExistsCheck(object entity)
        {
            if (entity is not null)
                throw new BusinessLogicException(ResponseTitles.Error, $"{_entityName} {ResponseMessages.AlreadyExists}");
        }
    }
}
