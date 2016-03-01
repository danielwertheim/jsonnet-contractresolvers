# JsonNet.PrivateSetterContractResolvers
First. I have nothing to do with [the awesome official](https://github.com/JamesNK/Newtonsoft.Json/blob/master/Src/Newtonsoft.Json/Serialization/CamelCasePropertyNamesContractResolver.cs) library "Newtonsoft.Json". This is merly a tiny extension to it.

2010 I was writing a NoSQL'ish document oriented provider over Microsoft SQL Server (SisoDB). While doing this I found the need for a custom contract resolver to Newtonsoft JSON.Net. One that supported private setters as well. I blogged about the solutions: http://danielwertheim.se/json-net-private-setters/ and this GitHub repo is the code for the custom contract resolver. One that supports private setters as well.

Since the post is still getting traffic, I thought. Why not provide this as a source NuGet. So, here it is:

```
Install-Package JsonNet.PrivateSetterContractResolvers.Source
```

It **installs a single file:** `PrivateSetterContractResolvers.cs`; into your project of choice. After that, you just consume it.