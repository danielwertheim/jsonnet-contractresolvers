using System;
using System.Reflection;
using JsonNet.ContractResolvers.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace JsonNet.ContractResolvers
{
    /// <summary>
    /// Extends <see cref="DefaultContractResolver"/> with support for private setters.
    /// </summary>
    public class PrivateSetterContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            => base.CreateProperty(member, memberSerialization).MakeWriteable(member);
    }

    /// <summary>
    /// Extends <see cref="CamelCasePropertyNamesContractResolver"/> with support for private setters.
    /// </summary>
    public class PrivateSetterCamelCasePropertyNamesContractResolver : CamelCasePropertyNamesContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            => base.CreateProperty(member, memberSerialization).MakeWriteable(member);
    }

    /// <summary>
    /// Extends <see cref="DefaultContractResolver"/> with support for private setters and private constructors.
    /// </summary>
    public class PrivateSetterAndCtorContractResolver : DefaultContractResolver
    {
        protected override JsonObjectContract CreateObjectContract(Type objectType)
            => base.CreateObjectContract(objectType).SupportPrivateCTors(objectType, CreateConstructorParameters);

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            => base.CreateProperty(member, memberSerialization).MakeWriteable(member);
    }

    /// <summary>
    /// Extends <see cref="CamelCasePropertyNamesContractResolver"/> with support for private setters and private constructors.
    /// </summary>
    public class PrivateSetterAndCtorCamelCasePropertyNamesContractResolver : CamelCasePropertyNamesContractResolver
    {
        protected override JsonObjectContract CreateObjectContract(Type objectType)
            => base.CreateObjectContract(objectType).SupportPrivateCTors(objectType, CreateConstructorParameters);

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            => base.CreateProperty(member, memberSerialization).MakeWriteable(member);
    }
}