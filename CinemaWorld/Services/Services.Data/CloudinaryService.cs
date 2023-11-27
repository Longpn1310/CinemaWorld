using CinemaWorld.Helper;
using CinemaWorld.Services.Services.Data.Contracts;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;

namespace CinemaWorld.Services.Services.Data
{
    //Cloudinary la 1 dich vu quan ly tep da phuong tien hinh anh va video
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary cloudinary;
        public CloudinaryService(Cloudinary cloudinary)
        {
            this.cloudinary = cloudinary;
        }
        public async Task<string> UpLoadAsync(IFormFile file, string fileName)
        {
            byte[] destinationImage;

            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            destinationImage = memoryStream.ToArray();

            using var destinationStream = new MemoryStream(destinationImage);

            fileName = fileName.Replace("&", "And");
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(fileName, destinationStream),
                PublicId = fileName,
            };

            var result = await this.cloudinary.UploadAsync(uploadParams);
            return result.Uri.AbsolutePath;
        }

        public async Task DeleteImage(Cloudinary cloudinary, string name)
        {
            var delParams = new DelResParams()
            {
                //Danh sach ten cong khai cac tep can xoa
                PublicIds = new List<string>() { name },
                //true de vo hieu hoa cache cua tep hinh anh duoc xoa
                Invalidate = true,

            };
            await cloudinary.DeleteResourcesAsync(delParams);
        }
    }
}
