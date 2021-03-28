using FluentAssertions;
using JsonNet.ContractResolvers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Xunit;
// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Local
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Local
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global

namespace UnitTests
{
    public interface IModel
    {
        string? SomeStringValue { get; }
        int SomeIntValue { get; }
    }

    public class ModelWithPublicCTor : IModel
    {
        public string? SomeStringValue { get; private set; }
        public int SomeIntValue { get; private set; }
    }

    public class ModelWithPrivateCTorWithoutArgs : IModel
    {
        public string SomeStringValue { get; private set; }
        public int SomeIntValue { get; private set; }

        private ModelWithPrivateCTorWithoutArgs()
        {
            SomeStringValue = "Default value";
            SomeIntValue = -92138674;
        }
    }

    public class ModelWithPrivateCTorWithArgs : IModel
    {
        public string SomeStringValue { get; private set; }
        public int SomeIntValue { get; private set; }

        private ModelWithPrivateCTorWithArgs(string someStringValue, int someIntValue)
        {
            SomeStringValue = someStringValue;
            SomeIntValue = someIntValue;
        }
    }

    public abstract class ContractResolverTests<TModel> where TModel : class, IModel
    {
        private readonly IContractResolver _resolver;

        protected ContractResolverTests(IContractResolver resolver)
        {
            _resolver = resolver;
        }

        protected TModel? Deserialize(string json) =>
            JsonConvert.DeserializeObject<TModel>(json, new JsonSerializerSettings
            {
                ContractResolver = _resolver
            });

        [Fact]
        public void When_proper_case_Should_deserialize_to_private_setters()
        {
            const string json = @"{""SomeStringValue"":""Some value"", ""SomeIntValue"": 42}";

            var model = Deserialize(json)!;

            model.SomeStringValue.Should().Be("Some value");
            model.SomeIntValue.Should().Be(42);
        }

        [Fact]
        public void When_camel_case_Should_deserialize_to_private_setters()
        {
            const string json = @"{""someStringValue"":""Some value"", ""someIntValue"": 42}";

            var model = Deserialize(json)!;

            model.SomeStringValue.Should().Be("Some value");
            model.SomeIntValue.Should().Be(42);
        }
    }

    public class PrivateSetterContractResolver_When_public_cTor : ContractResolverTests<ModelWithPublicCTor>
    {
        public PrivateSetterContractResolver_When_public_cTor()
            : base(new PrivateSetterContractResolver()) { }
    }

    public class PrivateSetterCamelCasePropertyNamesContractResolver_When_public_cTor : ContractResolverTests<ModelWithPublicCTor>
    {
        public PrivateSetterCamelCasePropertyNamesContractResolver_When_public_cTor()
            : base(new PrivateSetterCamelCasePropertyNamesContractResolver()) { }
    }

    public class PrivateSetterAndCtorContractResolver_When_private_cTor_has_no_args : ContractResolverTests<ModelWithPrivateCTorWithoutArgs>
    {
        public PrivateSetterAndCtorContractResolver_When_private_cTor_has_no_args()
            : base(new PrivateSetterAndCtorContractResolver()) { }
    }

    public class PrivateSetterAndCtorContractResolver_When_private_cTor_has_args : ContractResolverTests<ModelWithPrivateCTorWithArgs>
    {
        public PrivateSetterAndCtorContractResolver_When_private_cTor_has_args()
            : base(new PrivateSetterAndCtorContractResolver()) { }
    }

    public class PrivateSetterAndCtorCamelCasePropertyNamesContractResolver_When_private_cTor_has_no_args : ContractResolverTests<ModelWithPrivateCTorWithoutArgs>
    {
        public PrivateSetterAndCtorCamelCasePropertyNamesContractResolver_When_private_cTor_has_no_args()
            : base(new PrivateSetterAndCtorCamelCasePropertyNamesContractResolver()) { }
    }

    public class PrivateSetterAndCtorCamelCasePropertyNamesContractResolver_When_private_cTor_has_args : ContractResolverTests<ModelWithPrivateCTorWithArgs>
    {
        public PrivateSetterAndCtorCamelCasePropertyNamesContractResolver_When_private_cTor_has_args()
            : base(new PrivateSetterAndCtorCamelCasePropertyNamesContractResolver()) { }
    }
}
