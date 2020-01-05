using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenApiDocumentSchemaPlugin.Model
{
    public interface IDiagramXmlBuilder
    {
        string AddVertex(string value);

        string AddEdge(string value, string sourceId, string targetId);

        string GetDiagramXml();
    }
}
