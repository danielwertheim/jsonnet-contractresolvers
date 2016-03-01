# JsonNet.PrivateSetterContractResolvers
First. I have nothing to do with [the awesome official](https://github.com/JamesNK/Newtonsoft.Json) library "Newtonsoft.Json". This is merely a tiny extension to it. In 2010 I was writing a NoSQL'ish document oriented provider over Microsoft SQL Server (SisoDB). While doing this I found the need for a *custom contract resolver* to Newtonsoft JSON.Net. One that supported **private setters** as well. I've [written](http://danielwertheim.se/json-net-private-setters) about the solutions to this problem before. Since it still seems to solve issues for people I have put up this GitHub repository and created a source distribution NuGet for it as well.

```
Install-Package JsonNet.PrivateSettersContractResolvers.Source
```

It **installs a single file:** `PrivateSettersContractResolvers.cs`; into your project of choice. After that, you just consume it by creating an instance of either:

- PrivateSetterContractResolver
- PrivateSetterCamelCasePropertyNamesContractResolver

which you then assign to the `JsonSerializerSettings.ContractResolver`.

```csharp
var settings = new JsonSerializerSettings
{
    ContractResolver = new PrivateSetterContractResolver()
};

var model = JsonConvert.DeserializeObject<Model>(json, settings);
```
