
using MasterNet.Application.Core;
using MasterNet.Application.Photographs;
using Microsoft.AspNetCore.Http;

namespace MasterNet.Application.Interfaces;


public interface ICloudinaryService
{
    Task<CloudinaryUploadResult> UploadFileAsync(IFormFile file);
    Task<string> DeleteFileAsync(string publicId);

}