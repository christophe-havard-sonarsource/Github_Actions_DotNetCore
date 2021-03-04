using System;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Configuration;

namespace Surfrider {

public static class Helper {
    // https://docs.microsoft.com/en-us/azure/key-vault/secrets/quick-create-net
        private static string GetKeyVaultConnectionString(string secretName)
        {

            string keyVaultName = Environment.GetEnvironmentVariable("KEY_VAULT_NAME");
            var kvUri = "https://" + keyVaultName + ".vault.azure.net";

            var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());

            KeyVaultSecret secret = client.GetSecret(secretName);
            return secret.Value;
        }
        public static string GetConnectionString()
        {
             
                return Environment.GetEnvironmentVariable("postgre_connection");
        }
        // I add another useless code line
        public static void DoNothing(){
            Environment.GetEnvironmentVariable("postgre_connection");
            int i = 0;
            while(i< 100){
                // toto
            }
        }
        public static int ComputeWithSomeRecursion(int num, int inc)
        {
            num = num * ComputeWithSomeRecursion(num, inc-1);
            return 2*num;
        }
}
}
