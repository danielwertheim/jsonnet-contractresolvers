# JsonNet.ContractResolvers
[![NuGet](https://img.shields.io/nuget/v/JsonNet.ContractResolvers.svg?cacheSeconds=3600)](https://www.nuget.org/packages/JsonNet.ContractResolvers)
[![License MIT](https://img.shields.io/badge/License-MIT-blue.svg)](https://choosealicense.com/licenses/mit/)

Tiny solution providing pre-made `ContractResolver` implementations for [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json), resolvers that supports private property setters and private constructors.

## Replaces eariler repos and NuGets
Previous repo and NuGet distributions that this repo replaces are:

- https://github.com/danielwertheim/jsonnet-privatesetterscontractresolvers
- https://www.nuget.org/packages/JsonNet.PrivateSettersContractResolvers/
- https://www.nuget.org/packages/JsonNet.PrivateSettersContractResolvers.Source/

## Usage

```
Install-Package JsonNet.ContractResolvers
```

After that, you just consume it by creating an instance of either:

- `PrivateSetterContractResolver` - extends `DefaultContractResolver` with support for private setters.
- `PrivateSetterAndCtorContractResolver`- extends `DefaultContractResolver` with support for private setters and private constructors.
- `PrivateSetterCamelCasePropertyNamesContractResolver` - extends `CamelCasePropertyNamesContractResolver` with support for private setters.
- `PrivateSetterAndCtorCamelCasePropertyNamesContractResolver`- extends `CamelCasePropertyNamesContractResolver` with support for private setters and private constructors.

which you then assign to the `JsonSerializerSettings.ContractResolver`.

```csharp
var settings = new JsonSerializerSettings
{
    ContractResolver = new PrivateSetterContractResolver()
};

var model = JsonConvert.DeserializeObject<Model>(json, settings);
```
