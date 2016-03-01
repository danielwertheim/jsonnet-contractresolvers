using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;

namespace JsonNet.PrivateSettersContractResolvers.UnitTests
{
    [TestFixture]
    public class PrivateSetterContractResolversTests
    {
        [Test]
        public void PrivateSetterContractResolver_Should_deserialize_to_private_setters()
        {
            const string json = @"{""value"":""Some value""}";
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new PrivateSetterContractResolver()
            };

            var model = JsonConvert.DeserializeObject<Model>(json, settings);

            model.Value.Should().Be("Some value");
        }

        [Test]
        public void PrivateSetterCamelCasePropertyNamesContractResolver_Should_deserialize_to_private_setters()
        {
            const string json = @"{""value"":""Some value""}";
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new PrivateSetterCamelCasePropertyNamesContractResolver()
            };

            var model = JsonConvert.DeserializeObject<Model>(json, settings);

            model.Value.Should().Be("Some value");
        }

        private class Model
        {
            public string Value { get; private set; }
        }
    }
}