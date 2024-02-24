# JwtAuthExtension Class Library

## Overview
The `JwtAuthExtension` class library provides a straightforward and efficient way to integrate JWT (JSON Web Token) authentication into ASP.NET Core applications. It simplifies the process of configuring authentication and authorization mechanisms, focusing on token validation, issuer, and audience verification.

## Features
- Easy integration with ASP.NET Core services.
- Configures JWT authentication with minimal setup.
- Supports token validation parameters including issuer signing key, issuer, audience, and token lifetime.
- Facilitates authorization policy definitions for different user roles.

## Getting Started

### Prerequisites
- .NET Core SDK (version 3.1 or later)
- An ASP.NET Core project

### Installation
1. Ensure your project file (.csproj) is properly configured to generate a NuGet package.
2. Use the `dotnet pack` command to create a NuGet package from your class library.
3. Add the generated NuGet package to your ASP.NET Core project.

### Usage
To use the `JwtAuthExtension` in your project, follow these steps:

1. In your `Startup.cs`, import the namespace:

```csharp
   using YourNamespace.JwtAuthExtension;
````
Call the AddJwtAuthentication extension method within the ConfigureServices method of your Startup.cs, passing the necessary parameters:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddJwtAuthentication(secretKey: "YourSecretKey", issuer: "YourIssuer", audience: "YourAudience");
}
```

### Configuration
Customize your JWT authentication by modifying the parameters passed to AddJwtAuthentication:

- `secretKey`: Your secret key for signing tokens.
- `issuer`: The issuer of the token.
- `audience`: The audience of the token.

### Contributing
Contributions to the JwtAuthExtension library are welcome. Please follow the standard fork-and-pull request workflow.

License
Specify your license here. Common licenses for open-source projects include MIT, GPL, and Apache 2.0.

Contact
For support or to contact the maintainers, please provide contact details or link to the project's issues page.

### Pack the library like this
```sh
dotnet pack -c Release -o ./nuget
```

Remember to replace placeholder texts like "YourNamespace", "YourSecretKey", "YourIssuer", and "YourAudience" with the actual values specific to your project. Also, decide on a license that fits your project's needs and include it in the README.
