using AxelWebApi.Models;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace AxelWebApi.Helpers
{
    public static class FileHelper
    {
        public static async Task<string> UploadImage(IFormFile file)
        {
            string connectionString = @"DefaultEndpointsProtocol=https;AccountName=munkystorageaccount;AccountKey=gkdgtNLZBh3bpgN+gSWoRuLwBa5Y2v2nZKChMIhWmZDDZZx4jCmaRbcsbb91IEGSXuQ8KZzKJaS7+AStapifJQ==;EndpointSuffix=core.windows.net";
            string containerName = "restaurantsfiles";

            BlobContainerClient blobContainerClient = new BlobContainerClient(connectionString, containerName);
            BlobClient blobClient = blobContainerClient.GetBlobClient(file.FileName);
            var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            memoryStream.Position = 0;
            await blobClient.UploadAsync(memoryStream);
            return blobClient.Uri.AbsoluteUri;
        }
    }
}
