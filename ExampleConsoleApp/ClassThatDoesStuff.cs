using Microsoft.Extensions.Options;
using SkuVaultApiWrapper;
using SkuVaultApiWrapper.Models;
using SkuVaultApiWrapper.Models.SkuVaultModels;
using SkuVaultApiWrapper.SkuVaultApiClientExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleConsoleApp
{


    public class ClassThatDoesStuff : IClassThatDoesStuff
    {
        private readonly HttpClient _httpClient = null!;
        private readonly IOptions<SkuVaultApiClientConfig> _clientConfig = null!;

        public ClassThatDoesStuff(HttpClient httpClient, IOptions<SkuVaultApiClientConfig> clientConfig)
        {
            _httpClient = httpClient;
            _clientConfig = clientConfig;
        }

        public void Run()
        {
            var client = new SkuVaultApiClient(_httpClient, _clientConfig);
            Console.WriteLine("Successfully got tokens for your user!");
        }
    }
}
