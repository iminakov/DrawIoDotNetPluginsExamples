using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseDrawIoPlugin.XmlLayout
{
    public interface IDiagramXmlBuilder
    {
        string AddVertex(string value);

        string AddEllipse(int x, int y, int size, string value);

        string AddEdge(string value, string sourceId, string targetId);

        string GetDiagramXml();
    }
}
