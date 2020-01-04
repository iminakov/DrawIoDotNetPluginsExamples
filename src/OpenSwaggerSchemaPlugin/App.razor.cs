using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using OpenSwaggerSchemaPlugin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSwaggerSchemaPlugin
{
    public class AppBase : ComponentBase
    {
        private static AppBase singleInstance; 

        protected override Task OnInitializedAsync()
        {
            singleInstance = this;
            return base.OnInitializedAsync();
        }

        [Inject]
        public IEditorUiService EditorUiService { get; set; }

        [JSInvokableAttribute("HandleMenuActionOpenSwaggerSchema")]
        public static Task HandleMenuActionOpenSwaggerSchema()
        {
            singleInstance.EditorUiService.OpenAndReadFile(singleInstance.OnLoadFile);
            return Task.CompletedTask;
        }

        public void OnLoadFile(string content)
        {
            EditorUiService.LogContent(content).GetAwaiter().GetResult();
        }
    }
}
