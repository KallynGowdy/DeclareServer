# Authentication

In Servant, Authentication is the process of determining who the client is. 

In particular, Authentication consists of two distinct steps:

1. Recieving whatever documents of proof of identity that the client has.
2. Validating that recieved documents have been issued by the correct authority.

In the Servant architecture, the first step is implemented by the registered `IAuthenticationProvider`. 
Put simply, the `IAuthenticationProvider` is defined as follows:

```csharp
interface IAuthenticationProvider
{
    Task<AuthenticationInfo> RetrieveAuthInfoAsync(IRequest request);
}
```

When a request is processed, `RetrieveAuthInfoAsync()` is called to pull whatever authentication related information exists in the request.
For example, pulling a bearer token from the Authorization header might look something like this:

```csharp
class BearerAuthenticationProvider : IAuthenticationProvider
{
    public async Task<AuthenticationInfo> RetrieveAuthInfoAsync(IRequest request)
    {
        // Only allow auth info from "Bearer" schemes
        if(request.Authorization.Scheme == "Bearer")
        {
            return AuthenticationInfo.Token(request.Authorization.Token);
        }
        else 
        {
            return AuthenticationInfo.Empty();
        }
    }
}
```

Now for the second step. In Servant, it is implemented by `IAuthenticationValidator`.
It is defined below:

```csharp
interface IAuthenticationValidator
{
    Task<ValidationResult> ValidateAuthInfoAsync(AuthenticationInfo info);
}
```

After the authentication info has been procured via `IAuthenticationProvider.RetrieveAuthInfoAsync()`, 
it is then validated using `IAuthenticationValidator.ValidateAuthInfoAsync()`. The results of the validation can then be used
to make decisions about data and its security.

For example, some authentication info that represents a JSON Web Token might be validated like this:

```csharp
class JwtAuthenticationValidator : IAuthenticationValidator
{
    private const string SecretKey = "mySecretKeyThatShouldBeReallyLongAndMuchLongerAndMoreRandomThanThis";

    public Task<ValidationResult> ValidateAuthInfoAsync(AuthenticationInfo info)
    {
        // info.Validate runs the given validation function
        // on each of the stored documents. The function needs to return
        // a specialized validation result object (TBD) that represents
        // whether the document is valid or not.
        return info.Validate(document =>
        
            // Documents contain info that relate one or more claims to a single issuer.
            // document.ValidateToken attempts to retrieve a token from the document
            // and pass it to yet another validation function that transforms the token
            // into a set of claims. If the function throws or returns null, then the document
            // is considered invalid.
            document.ValidateToken(token => 
                JWT.JsonWebToken.DecodeToObject(token, SecretKey) as IDictionary<string, object>));
    }
}
```

Obviously, this overview is incomplete, but it should provide a basis for authentication in Servant.
