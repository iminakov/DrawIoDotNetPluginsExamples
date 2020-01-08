using System.Threading.Tasks;

namespace BaseDrawIoPlugin.JsContracts
{
    public abstract class BaseDrawIoJsContract<T>
        where T : IJsInteropContract
    {
        private readonly IJsContractInteropService _jsService;

        public BaseDrawIoJsContract(IJsContractInteropService jsService)
        {
            _jsService = jsService;
        }

        public async Task Log(string content)
        {
            await _jsService.RunJsAction<T>(nameof(Log), content);
        }

        public async Task ShowError(string message)
        {
            await _jsService.RunJsAction<T>(nameof(ShowError), message);
        }

        public async Task LoadXml(string xmlContent)
        {
            await _jsService.RunJsAction<T>(nameof(LoadXml), xmlContent);
        }

        public async Task OpenFile()
        {
            await _jsService.RunJsAction<T>(nameof(OpenFile));
        }
    }
}
