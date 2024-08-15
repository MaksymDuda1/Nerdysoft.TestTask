using AnnounceBoard.Application.Abstractions;
using AnnounceBoard.Domain.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;

namespace AnnounceBoard.Application.Services;

public class FileService : IFileService
{
    public async Task<string> UploadImage(IFormFile file)
    {
        try
        {
            var folderName = Path.Combine( "Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim().Split(new[] { '.' });
            var newFileName = new string(Guid.NewGuid() + "." + fileName.Last());
            var fullPath = Path.Combine(pathToSave, newFileName);
            var dbPath = Path.Combine(folderName, newFileName);
            await using var stream = new FileStream(fullPath, FileMode.Create);
            await file.CopyToAsync(stream);

            return dbPath;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}