using Microsoft.JSInterop;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSwaggerSchemaPlugin.Services
{
    public class EditorUiService : BaseAsyncJsInteropService, IEditorUiService
    {
        public EditorUiService(IJSRuntime jSRuntime)
            : base(jSRuntime)
        {
        }

        public async Task LogContent(string content)
        {
            await RunAction<OpenSwaggerSchemaContract>(c => c.log, content);
        }

        public async Task OpenAndReadFile(Action<string> asyncResultCallBack)
        {
            await RunAsyncAction<OpenSwaggerSchemaContract>(c => c.openFile, asyncResultCallBack);
        }
    }
}
