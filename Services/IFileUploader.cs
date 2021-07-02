using Crossways.Models;

namespace Crossways.Services
{
    public interface IFileUploader
    {
        string ImageUploader(PhotoUploadModel model);
    }
}