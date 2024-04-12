using Application.Common;
using Microsoft.AspNetCore.Http;

namespace Application.Services.Storage;

public interface IStorageService
{
    Task<Result<string>> UploadImageAsync(IFormFile image, CancellationToken cancellationToken = default);
}
