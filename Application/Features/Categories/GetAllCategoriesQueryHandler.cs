using Application.Common;
using Application.Features.Shared;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Categories;

public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, Result<List<CategoryDto.Index>>>
{
    private readonly GiggleDbContext _context;

    public GetAllCategoriesQueryHandler(GiggleDbContext context)
    {
        _context = context;
    }

    public async Task<Result<List<CategoryDto.Index>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _context.Categories
            .Select(c => new CategoryDto.Index()
            {
                Id = c.Id,
                Name = c.Name
            }).ToListAsync(cancellationToken);

        return Result<List<CategoryDto.Index>>.Success(categories);
    }
}
