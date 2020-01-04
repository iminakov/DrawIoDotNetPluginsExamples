using Microsoft.JSInterop;
using Moq;
using NUnit.Framework;

namespace OpenSwaggerSchemaPluginTest
{
    [TestFixture]
    public class BaseAsyncInteropServiceTests
    {
        [Test]
        public void AsyncInteropServiceCanGetInterfaceMethodByReflectionTest()
        {
            var jsRuntime = new Mock<IJSRuntime>();
            var fakeInteropService = new FakeAsyncInteropService(jsRuntime.Object);

            var result = fakeInteropService.GetMethodName<OpenSwaggerSchemaPlugin.Services.OpenSwaggerSchemaContract>(c => c.openFile);

            Assert.AreEqual("openFile", result);
        }
    }
}