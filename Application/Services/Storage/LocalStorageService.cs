using Application.Common;
using Configuration;
using Microsoft.AspNetCore.Http;

namespace Application.Services.Storage
{
    public class LocalStorageService : IStorageService
    {
        private readonly string _uploadsFolder;

        public LocalStorageService()
        {
            _uploadsFolder = "wwwroot/uploads";

        }
        public async Task<Result<string>> UploadImageAsync(IFormFile image, CancellationToken cancellationToken = default)
        {
            try
            {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";
                var filePath = Path.Combine(_uploadsFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
                return Result<string>.Success(filePath);
            }
            catch (Exception ex)
            {
                return Result<string>.Failure(ex.Message);
            }
        }
    }
}
