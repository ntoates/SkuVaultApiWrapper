# SkuVaultApiWrapper
Intended to be a minimalistic wrapper for SkuVaults API.

## Table of contents
* [Basic Example Usage](#basic-example-usage)
* [Injection Example Usage](#injection-example-usage)
* [DEV IN PROGRESS WARNING](#dev-in-progress-warning)
* [Included](#included)
* [Not Included](#not-included)

## Basic Example Usage
View Microsoft's documentation on HttpClient [here](https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=net-6.0). All SkuVault API documentation can be found [here](https://dev.skuvault.com/reference/).

Example usage:
```
public void Run()
{
    using var httpClient = new HttpClient();
    SkuVaultApiClient client = new SkuVaultApiClient(httpClient, new SkuVaultApiClientConfig("TenantToken", "UserToken"));
    var getOnlineSaleRequest = new GetOnlineSaleStatusRequest { OrderIds = new List<string> { "OrderId" } };
    GetOnlineSaleStatusResponse saleRespone = await client.GetOnlineSaleStatus(getOnlineSaleRequest);
}
```

## Injection Example Usage
Inject the wrapper into your application:
```
services.AddSkuVaultApiWrapper(builder.GetSection("SkuVaultApiClientConfig"));
```

Setup DI in your class that needs it:
```
private readonly SkuVaultApiClient _skuVaultApiClient;

public RandomClass(SkuVaultApiClient skuvaultApiClient)
{
    _skuVaultApiClient = skuvaultApiClient;
}
```

Then use the client to interact with the API:
```
public void Run()
{
    var getOnlineSaleRequest = new GetOnlineSaleStatusRequest { OrderIds = new List<string> { "SameOrderId" } };
    GetOnlineSaleStatusResponse saleRespone = await _skuVaultApiClient.GetOnlineSaleStatus(getOnlineSaleRequest);
}
```

View the example project to see a more in depth example.

## DEV IN PROGRESS WARNING:
I am currently adding endpoints to this library, however base funcionality will not change. There is also a generic POST method included in the library which can be used to pass in response/request objects through the library in the case that a specific endpoint has not been implemented or becomes outdated.

## Included
-  Handling of any undocumented behavior or paramteres discovered during testing. 
-  Minimal project references
-  Service Collection extension for convenient injection
-  API Response and Request models

## Not Included
- Logic for getting multiple pages
- Retry logic

This logic is intended to be handled externally to give the user more control.
