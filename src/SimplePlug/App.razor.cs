using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SimplePlug.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplePlug
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

        [JSInvokableAttribute("HandleMenuActionFromCSharp")]
        public static Task HandleMenuActionFromCSharp()
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
