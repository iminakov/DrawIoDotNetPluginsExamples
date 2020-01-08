using System.Threading.Tasks;

namespace BaseDrawIoPlugin.JsContracts
{
    public abstract class BaseDrawIoJsContract<T>
    {
        private readonly JsContractInteropService _jsService;

        public BaseDrawIoJsContract(JsContractInteropService jsService)
        {
            _jsService = jsService;
        }

        public async Task Log(string content)
        {
            await _jsService.RunAction<T>(nameof(Log), content);
        }

        public async Task ShowError(string message)
        {
            await _jsService.RunAction<T>(nameof(ShowError), message);
        }

        public async Task LoadXml(string xmlContent)
        {
            await _jsService.RunAction<T>(nameof(LoadXml), xmlContent);
        }

        public async Task OpenFile()
        {
            await _jsService.RunAction<T>(nameof(OpenFile));
        }
    }
}
