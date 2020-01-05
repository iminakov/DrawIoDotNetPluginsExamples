using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenSwaggerSchemaPlugin.Services
{
    public interface IEditorUiService
    {
        Task OpenAndReadFile();

        Task LogContent(string content);
    }
}
