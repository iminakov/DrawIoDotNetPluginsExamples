using BaseDrawIoPlugin.XmlLayout;
using JsonGeoDataSchemaPlugin.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JsonGeoDataSchemaPlugin.Services
{
    public class JsonGeoDataDiagramBuilder
    {
        private readonly List<GeoData> _geoData;
        private readonly IDiagramXmlBuilder _diagramXmlBuilder;

        public JsonGeoDataDiagramBuilder(string jsonGeoData, IDiagramXmlBuilder diagramXmlBuilder)
        {
            _geoData = JsonConvert.DeserializeObject<List<GeoData>>(jsonGeoData);
            _diagramXmlBuilder = diagramXmlBuilder;
        }

        public string BuildDiagram()
        {
            foreach (var geoDataItem in _geoData)
            {
                _diagramXmlBuilder.AddEllipse((int)geoDataItem.Latitude, (int)geoDataItem.Longitude, 30, geoDataItem.Name);
            }

            return _diagramXmlBuilder.GetDiagramXml();
        }
    }
}
