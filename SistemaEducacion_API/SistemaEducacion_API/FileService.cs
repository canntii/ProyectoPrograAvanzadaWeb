using Azure.Storage;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Reflection.Metadata;

namespace SistemaEducacion_API
{
    public class FileService
    {
        private readonly string _storageAccount = "cantiedu";
        private readonly string _key = "7a3ZWLv+pGdLcjMTi1biuqBvcP9E108p5ne/4dOz0O6qh9Tsu0i+ACLKoT9irZBZx31SzXeZmAYs+AStuoW+0g==";
        private readonly BlobContainerClient _filesContainer;

        public FileService()
        {
            var credential = new StorageSharedKeyCredential(_storageAccount, _key);
            var blobUri = $"https://{_storageAccount}.blob.core.windows.net";
            var blobServiceClient = new BlobServiceClient(new Uri(blobUri), credential);
            _filesContainer = blobServiceClient.GetBlobContainerClient("videos-container");
        }


        public async Task<List<BlobDto>> ListAsync()
        {
            List<BlobDto> files = new List<BlobDto>();

            await foreach (var file in _filesContainer.GetBlobsAsync())
            {
                string uri = _filesContainer.Uri.ToString();
                var name = file.Name;
                var fullUri = $"{uri}/{name}";

                files.Add(new BlobDto
                {
                    Uri = fullUri,
                    Name = name,
                    ContentType = file.Properties.ContentType
                });
            }
            return files;
        }

        public async Task<BlobResponseDto> UploadAsync(IFormFile blob)
        {
            BlobResponseDto response = new();
            BlobClient client = _filesContainer.GetBlobClient(blob.FileName);

            await using (Stream? data = blob.OpenReadStream())
            {
                await client.UploadAsync(data);
            }

            response.Status = $"File {blob.FileName} Uploaded successfully";
            response.Error = false;
            response.Blob.Uri = client.Uri.AbsoluteUri;
            response.Blob.Name = client.Name;
            return response;
        }

        public async Task<BlobDto?> DownloadAsync(string blobFileName)
        {
            BlobClient file = _filesContainer.GetBlobClient(blobFileName);

            if (await file.ExistsAsync())
            {
                var data = await file.OpenReadAsync();
                Stream blobContent = data;

                var content = await file.DownloadContentAsync();

                string name = blobFileName;
                string contentType = content.Value.Details.ContentType;

                return new BlobDto { Content = blobContent, Name = name, ContentType = contentType };
            }
            return null;
        }

        public async Task<BlobResponseDto> DeleteAsync(string blobFileName)
        {

            BlobClient file = _filesContainer.GetBlobClient(blobFileName);

            await file.DeleteAsync();

            return new BlobResponseDto { Error = false, Status = $"File: {blobFileName} has been successfully deleted." };
        }

    }
}
