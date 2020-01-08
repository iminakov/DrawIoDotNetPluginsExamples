using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BaseDrawIoPlugin
{
    public interface IJsContractInteropService
    {
        Task SetReferenceInJsContext(IDotNetInteropContract service);

        Task RunJsAction<TJsContract>(Expression<Func<TJsContract, Action>> expression, params object[] args);

        Task RunJsAction<TJsContract>(string methodName, params object[] args);
    }
}
