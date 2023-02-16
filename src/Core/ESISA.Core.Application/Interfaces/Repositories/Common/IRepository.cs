using ESISA.Core.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Interfaces.Repositories.Common
{
    public interface IRepository<TEntity> 
        where TEntity : EntityBase
    {
    }
}
