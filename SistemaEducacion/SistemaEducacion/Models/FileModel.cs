using Azure.Storage;
using Azure.Storage.Blobs;
using SistemaEducacion.Services;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Sas;
using SistemaEducacion.WebEntities;

namespace SistemaEducacion.Models
{
    public class FileModel : IFileModel
    {
        private readonly string _storageAccount;
        private readonly string _key;
        private readonly BlobContainerClient _filesContainer;

        public FileModel(IConfiguration _configuration)
        {
            _storageAccount = _configuration.GetSection("settings:StorageAccount").Value ?? string.Empty;
            _key = _configuration.GetSection("settings:AzureKey").Value ?? string.Empty;
            var credential = new StorageSharedKeyCredential(_storageAccount, _key);
            var blobUri = $"https://{_storageAccount}.blob.core.windows.net";
            var blobServiceClient = new BlobServiceClient(new Uri(blobUri), credential);
            _filesContainer = blobServiceClient.GetBlobContainerClient("videos-container");
        }

        public static async Task<Uri> CreateServiceSASBlob(BlobClient blobClient, string storedPolicyName = null!)
        {
            // Check if BlobContainerClient object has been authorized with Shared Key
            if (blobClient.CanGenerateSasUri)
            {
                // Create a SAS token that's valid for one day
                BlobSasBuilder sasBuilder = new BlobSasBuilder()
                {
                    BlobContainerName = blobClient.GetParentBlobContainerClient().Name,
                    BlobName = blobClient.Name,
                    Resource = "b"
                };

                if (storedPolicyName == null)
                {
                    sasBuilder.ExpiresOn = DateTimeOffset.UtcNow.AddDays(30);
                    sasBuilder.SetPermissions(BlobContainerSasPermissions.Read);
                }
                else
                {
                    sasBuilder.Identifier = storedPolicyName;
                }

                Uri sasURI = blobClient.GenerateSasUri(sasBuilder);

                return sasURI;
            }
            else
            {
                return null!;
            }
        }

        public async Task<BlobResponseDto> UploadAsync(IFormFile blob)
        {
            BlobResponseDto response = new BlobResponseDto();
            BlobClient client = _filesContainer.GetBlobClient(blob.FileName);

            await using (Stream data = blob.OpenReadStream())
            {
                var result = await client.UploadAsync(data);

                // Obtener el SAS para el blob recién creado
                Uri blobSASURI = await CreateServiceSASBlob(client);

                // Crear un nuevo cliente de blob con autorización SAS
                BlobClient blobClientSAS = new BlobClient(blobSASURI);

                response.Status = $"File {blob.FileName} uploaded successfully";
                response.Error = false;
                response.Blob.Uri = blobClientSAS.Uri.AbsoluteUri;
                response.Blob.Name = client.Name;
            }
            return response;
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
