using Application.Common;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;

namespace Application.Services.Storage;

public class AzureBlobStorageService : IStorageService
{
    private readonly BlobServiceClient _blobServiceClient;

    public AzureBlobStorageService(string connectionString)
    {
        _blobServiceClient = new BlobServiceClient(connectionString);
    }

    public Task<Result<string>> UploadImageAsync(IFormFile image, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
