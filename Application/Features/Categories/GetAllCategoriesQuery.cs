using Application.Common;
using Application.Features.Shared;
using MediatR;

namespace Application.Features.Categories;

public class GetAllCategoriesQuery : IRequest<Result<List<CategoryDto.Index>>>;
