using BaseDrawIoPlugin.XmlLayout;
using JsonGeoDataSchemaPlugin.Model;
using Newtonsoft.Json;

namespace JsonGeoDataSchemaPlugin.Services
{
    public class JsonGeoDataDiagramBuilder
    {
        private const int EllipseSize = 30;

        private readonly GeoDataCollection _geoData;
        private readonly IDiagramXmlBuilder _diagramXmlBuilder;

        public JsonGeoDataDiagramBuilder(string jsonGeoData, IDiagramXmlBuilder diagramXmlBuilder)
        {
            _geoData = JsonConvert.DeserializeObject<GeoDataCollection>(jsonGeoData);
            _diagramXmlBuilder = diagramXmlBuilder;
        }

        public string BuildDiagram()
        {
            foreach (var geoDataItem in _geoData.Collection)
            {
                _diagramXmlBuilder.AddEllipse((int)geoDataItem.Latitude, (int)geoDataItem.Longitude, EllipseSize, geoDataItem.Name);
            }

            return _diagramXmlBuilder.GetDiagramXml();
        }
    }
}
