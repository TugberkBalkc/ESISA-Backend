using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISA.Core.Application.Features.MediatR.Commands.SwapAdverts.AddSwappableCategory
{
    public class AddSwappableCategoryCommandRequest : IRequest<AddSwappableCategoryCommandResponse>
    {
        public Guid SwapAdvertId { get; set; }
        public Guid CategoryId { get; set; }

        public AddSwappableCategoryCommandRequest()
        {

        }

        public AddSwappableCategoryCommandRequest(Guid swapAdvertId, Guid categoryId)
        {
            SwapAdvertId = swapAdvertId;
            CategoryId = categoryId;
        }
    }
}
