using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Files
{
    public static class Common
    {
        public static CloudStorageAccount CreateStorageAccountFromConnectionString()
        {
            CloudStorageAccount storageAccount;
            const string Message = "Invalid storage account information provided. Please confirm the AccountName and AccountKey are valid in the app.config file - then restart the sample.";

            try
            {
                storageAccount = new CloudStorageAccount(new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials("", ""), true);
            }
            catch (FormatException)
            {
                Console.WriteLine(Message);
                Console.ReadLine();
                throw;
            }
            catch (ArgumentException)
            {
                Console.WriteLine(Message);
                Console.ReadLine();
                throw;
            }

            return storageAccount;
        }
    }
}
