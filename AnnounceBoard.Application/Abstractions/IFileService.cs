using Microsoft.AspNetCore.Http;

namespace AnnounceBoard.Application.Abstractions;

public interface IFileService
{
    Task<string> UploadImage(IFormFile file);
}