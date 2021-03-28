using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json.Serialization;

namespace JsonNet.ContractResolvers.Internal
{
    internal static class Extensions
    {
        internal static JsonObjectContract SupportPrivateCTors(this JsonObjectContract objectContract, Type objectType, Func<ConstructorInfo, JsonPropertyCollection, IList<JsonProperty>> cTorParamsFactory)
        {
            if (objectContract.DefaultCreator != null || objectContract.OverrideCreator != null)
                return objectContract;

            if (objectContract.CreatorParameters.Any())
                return objectContract;

            var cTor = objectType
                .GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic)
                .OrderByDescending(e => e.GetParameters().Length)
                .FirstOrDefault();

            if (cTor == null)
                return objectContract;

            objectContract.OverrideCreator = args => cTor.Invoke(args);

            foreach (var parameter in cTorParamsFactory(cTor, objectContract.Properties))
                objectContract.CreatorParameters.Add(parameter);

            return objectContract;
        }

        private static bool IsPropertyWithSetter(MemberInfo member)
        {
            var property = member as PropertyInfo;

            return property?.SetMethod != null;
        }

        internal static JsonProperty MakeWriteable(this JsonProperty jProperty, MemberInfo member)
        {
            if (jProperty.Writable)
                return jProperty;

            jProperty.Writable = IsPropertyWithSetter(member);

            return jProperty;
        }
    }
}