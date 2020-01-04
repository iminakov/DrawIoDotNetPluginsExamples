using OpenSwaggerSchemaPlugin.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenSwaggerSchemaPluginTest
{
    public class FakeAsyncInteropService : BaseAsyncJsInteropService
    {
        public FakeAsyncInteropService(Microsoft.JSInterop.IJSRuntime jSRuntime) 
            : base(jSRuntime)
        {
        }
    }
}
