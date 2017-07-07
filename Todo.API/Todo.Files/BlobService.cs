using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.RetryPolicies;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.WindowsAzure.Storage.Auth;

namespace Todo.Files
{
    public class BlobService
    {
    //    public CloudStorageAccount _storageAccount;
    //    public CloudBlobContainer container;
    //    public CloudBlobClient blobClient;

        public async void Init()
        {

            var storageCredentials = new StorageCredentials("ictestit", "XOgu/B04gLo5fZk4MKMImefGy1pLVH7nlEA8Tlpa37H0Wr2zIYKeG/rjMoI7JtcLw7TZB1hgg8VevQWoDIT0iw==");
            var cloudStorageAccount = new CloudStorageAccount(storageCredentials, true);
            var cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();

            var container = cloudBlobClient.GetContainerReference("mycontainer");
            await container.CreateIfNotExistsAsync();
            var blockBlob = container.GetBlockBlobReference("material01");
            await blockBlob.UploadFromFileAsync(@".\..\Todo.Files\teste.pdf");
            var newBlob = container.GetBlockBlobReference("material01");
            await newBlob.DownloadToFileAsync("./../Todo.Files/testeR.pdf", FileMode.Create);
        }

    }
}
