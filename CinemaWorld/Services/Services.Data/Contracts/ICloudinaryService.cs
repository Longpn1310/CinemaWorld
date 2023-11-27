using CinemaWorld.Helper;
using CloudinaryDotNet;
using Microsoft.Extensions.Options;

namespace CinemaWorld.Services.Services.Data.Contracts
{
    public interface ICloudinaryService
    {
        Task<string> UpLoadAsync(IFormFile file, string fileName);

        Task DeleteImage(Cloudinary cloudinary, string name);
    }
}
