using Microsoft.JSInterop;
using Moq;
using NUnit.Framework;
using OpenSwaggerSchemaPlugin.Services;

namespace OpenSwaggerSchemaPluginTest
{
    [TestFixture]
    public class JsContractInteropServiceTests
    {
        [Test]
        public void AsyncInteropServiceCanGetInterfaceMethodByReflectionTest()
        {
            var jsRuntime = new Mock<IJSRuntime>();
            var fakeInteropService = new JsContractInteropService(jsRuntime.Object);

            var result = fakeInteropService.GetMethodName<OpenSwaggerSchemaPlugin.JsContracts.OpenSwaggerSchemaJsContract>(c => c.OpenFile);

            Assert.AreEqual("OpenFile", result);
        }
    }
}