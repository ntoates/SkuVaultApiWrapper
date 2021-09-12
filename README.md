# SkuVaultApiWrapper
Wrapper for SkuVault's public API.

<h3>SkuVaultAccount</h3>
Initiate a SkuVault Http Client by calling one of the SkuVaultAccount constructors. Validation occurrs during construction. 

With UserCredentials:</br>
<pre><code>			
  var userCredentials = new UserCredentials
  {
    Email = "mySkuVaultEmail",
    Password = "mySkuVaultPassword"
  };
  var account = new SkuVaultAccount(userCredentials); 
</code></pre>

With Account Tokens:</br>
<pre><code>			
  var userTokens = new UserTokens
  {
    TenantToken = "MyTenantOrCompanyToken",
    UserToken = "MyUserToken"
  };
  var account = new SkuVaultAccount(userTokens); 
</code></pre>

</br></br>
<h3>Making Request</h3>
Once you have a validated SkuVaultAccount object, it can be passed into any request method along with additional paramaters for each request, which are included in this libraries classes.

<pre><code>			
  var getWarehouseItemQuantityRequest = new GetWarehouseItemQuantityRequest
  {
    Sku = "TestSku01",
    WarehouseId = 1
  };

  GetWarehouseItemQuantityResponse response = await getWarehouseItemQuantityRequest.GetSinglePage(svAccount);
</code></pre>
