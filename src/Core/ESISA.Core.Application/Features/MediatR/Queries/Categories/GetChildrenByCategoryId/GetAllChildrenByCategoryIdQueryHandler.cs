using AutoMapper;
using ESISA.Core.Application.Constants.Response;
using ESISA.Core.Application.Dtos.Category;
using ESISA.Core.Application.Interfaces.Repositories;
using ESISA.Core.Application.Utilities.Paging;
using ESISA.Core.Application.Utilities.Response.ContentResponse;
using ESISA.Core.Domain.Entities;
using MediatR;

namespace ESISA.Core.Application.Features.MediatR.Queries.Categories.GetChildrenByCategoryId
{
    public class GetAllChildrenByCategoryIdQueryHandler : IRequestHandler<GetAllChildrenByCategoryIdQueryRequest, GetAllChildrenByCategoryIdQueryResponse>
    {
        private readonly ICategoryQueryRepository _categoryQueryRepository;
        private readonly IMapper _mapper;

        public GetAllChildrenByCategoryIdQueryHandler(ICategoryQueryRepository categoryQueryRepository, IMapper mapper)
        {
            _categoryQueryRepository = categoryQueryRepository;
            _mapper = mapper;
        }

        public async Task<GetAllChildrenByCategoryIdQueryResponse> Handle(GetAllChildrenByCategoryIdQueryRequest request, CancellationToken cancellationToken)
        {
            bool isParentIdNull = false;
            Guid parentCategoryId = request.CategoryId;
            List<Category> resultCategories = new List<Category>();
            List<Category> childCategories = new List<Category>();
            List<Category> tempCategories = new List<Category>();
            var firstSubCategoriesList = _categoryQueryRepository.GetWhere(e => e.ParentId == parentCategoryId).ToList();

            resultCategories.AddRange(firstSubCategoriesList);

            childCategories.AddRange(resultCategories);
            
            while (!isParentIdNull)
            {
                foreach(var childCategory in childCategories)
                {
                    var subCateogries = _categoryQueryRepository.GetWhere(e => e.ParentId == childCategory.Id).ToList();

                    if (subCateogries.Count == 0) continue;

                    tempCategories.AddRange(subCateogries);

                    foreach (var subsubcategory in subCateogries)
                    {
                        childCategory.Children.Add(subsubcategory);
                    }


                }

                childCategories.Clear();

                childCategories.AddRange(tempCategories);

                tempCategories.Clear();

                if (childCategories.Count == 0)
                {
                    isParentIdNull = true;
                }
            }

            var category = await _categoryQueryRepository.GetByIdAsync(request.CategoryId);

            foreach (var resultCategory in resultCategories)
            {
                category.Children.Add(resultCategory);
            }

            return new GetAllChildrenByCategoryIdQueryResponse(new SuccessfulContentResponse<Category>(category, ResponseTitles.Success, ResponseMessages.CategoryListed, System.Net.HttpStatusCode.OK));
        }

       

    }

}
