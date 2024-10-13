using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using MasterNet.Application.Core;
using MasterNet.Application.Interfaces;
using MasterNet.Application.Photographs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace MasterNet.Infrastructure.FileUpload.Cloudinary;


public class CloudinaryService : ICloudinaryService
{
    private readonly CloudinaryDotNet.Cloudinary _cloudinary;

    public CloudinaryService(IOptions<CloudinarySettings> configuration)
    {
        var account = new Account(
            configuration.Value.CloudName, configuration.Value.ApiKey, configuration.Value.ApiSecret);

        _cloudinary = new CloudinaryDotNet.Cloudinary(account);
    }

    public async Task<CloudinaryUploadResult> UploadFileAsync(IFormFile file)
    {
        if (file.Length > 0)
        {
            await using var stream = file.OpenReadStream();
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, stream),
                Transformation = new Transformation().Height(500).Width(500).Crop("file")
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            if (uploadResult.Error is not null)
            {
                throw new Exception(uploadResult.Error.Message);
            }

            return new CloudinaryUploadResult
            {
                PublicId = uploadResult.PublicId,
                Url = uploadResult.SecureUrl.ToString(),
            };
        }

        return null!;
    }

    public async Task<string> DeleteFileAsync(string publicId)
    {
        var deleteParams = new DeletionParams(publicId);
        var result = await _cloudinary.DestroyAsync(deleteParams);
        return result.Result == "ok" ? result.Result! : null!;
    }


}