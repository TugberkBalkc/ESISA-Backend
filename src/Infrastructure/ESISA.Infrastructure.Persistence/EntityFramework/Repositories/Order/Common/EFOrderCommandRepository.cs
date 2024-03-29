﻿using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Domain.Entities;
using ESISA.Infrastructure.Persistence.EntityFramework.Contexts;
using ESISA.Infrastructure.Persistence.EntityFramework.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Infrastructure.Persistence.EntityFramework.Repositories
{
    public class EFOrderCommandRepository : EfCommandRepositoryBase<Order>, IOrderCommandRepository
    {
        public EFOrderCommandRepository(ESISADbContext dbContext) : base(dbContext)
        {
        }
    }
}
