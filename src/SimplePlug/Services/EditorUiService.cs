using Microsoft.JSInterop;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplePlug.Services
{
    public class EditorUiService : BaseAsyncJsInteropService, IEditorUiService
    {
        public EditorUiService(IJSRuntime jSRuntime)
            : base(jSRuntime)
        {
        }

        public async Task LogContent(string content)
        {
            await RunAction("SimplePlugJs", "log", content);
        }

        public async Task OpenAndReadFile(Action<string> asyncResultCallBack)
        {
            await RunAsyncAction("SimplePlugJs", "openFile", asyncResultCallBack);
        }
    }
}
