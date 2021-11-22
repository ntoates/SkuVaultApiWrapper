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
        private readonly SkuVaultApiClient _skuVaultApiClient;

        public ClassThatDoesStuff(ISkuVaultApiClient skuvaultApiClient)
        {
            _skuVaultApiClient = (SkuVaultApiClient) skuvaultApiClient;
        }

        public void Run()
        {
            Console.WriteLine("Successfully got tokens for your user!");
        }
    }
}
