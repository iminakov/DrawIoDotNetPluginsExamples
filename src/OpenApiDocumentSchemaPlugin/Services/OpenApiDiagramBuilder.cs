using BaseDrawIoPlugin.XmlLayout;
using NJsonSchema;
using NSwag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenApiDocumentSchemaPlugin.Services
{
    public class OpenApiDiagramBuilder
    {
        private readonly OpenApiDocument _openApiDocument;
        private readonly IDiagramXmlBuilder _diagramXmlBuilder;

        public OpenApiDiagramBuilder(OpenApiDocument openApiDocument, IDiagramXmlBuilder diagramXmlBuilder)
        {
            _openApiDocument = openApiDocument;
            _diagramXmlBuilder = diagramXmlBuilder;
        }

        public string BuildDiagram()
        {
            var definitionCellIds = AddDefinitions();
            AddDefinitionsRelations(definitionCellIds);
            AddPathAndOperations(definitionCellIds);

            return _diagramXmlBuilder.GetDiagramXml();
        }

        private void AddDefinitionsRelations(Dictionary<NJsonSchema.JsonSchema, string> definitionCellIds)
        {
            foreach (var definition in _openApiDocument.Definitions)
            {
                foreach (var property in definition.Value.Properties)
                {
                    var sourceId = definitionCellIds[definition.Value];
                    
                    if (property.Value.Reference != null)
                    {
                        var targetId = definitionCellIds[property.Value.Reference];
                        _diagramXmlBuilder.AddEdge(property.Value.Name, sourceId, targetId);
                    }
                    else if (property.Value.Item?.Reference != null)
                    {
                        var targetId = definitionCellIds[property.Value.Item.Reference];
                        _diagramXmlBuilder.AddEdge(property.Value.Name, sourceId, targetId);
                    }
                }
            }
        }

        private Dictionary<NJsonSchema.JsonSchema, string> AddDefinitions()
        {
            var definitionCellIds = new Dictionary<NJsonSchema.JsonSchema, string>();

            foreach (var definition in _openApiDocument.Definitions)
            {
                definitionCellIds.Add(definition.Value, _diagramXmlBuilder.AddVertex(definition.Key));
            }

            return definitionCellIds;
        }

        private void AddPathAndOperations(Dictionary<NJsonSchema.JsonSchema, string> definitionCellIds)
        {
            foreach (var pathItem in _openApiDocument.Paths)
            {
                var pathCellId = _diagramXmlBuilder.AddVertex(pathItem.Key);

                foreach (var pathMethodItem in pathItem.Value)
                {
                    var operationCellId = _diagramXmlBuilder.AddVertex(pathMethodItem.Key);
                    _diagramXmlBuilder.AddEdge(null, pathCellId, operationCellId);
                    
                    AddParametersRelationship(definitionCellIds, pathMethodItem, operationCellId);
                    AddResponseRelationships(definitionCellIds, pathMethodItem, operationCellId);
                }
            }
        }

        private void AddParametersRelationship(Dictionary<JsonSchema, string> definitionCellIds, KeyValuePair<string, OpenApiOperation> pathMethodItem, string operationCellId)
        {
            foreach (var parameter in pathMethodItem.Value.Parameters)
            {
                if (parameter.Schema?.Reference != null)
                {
                    var targetId = definitionCellIds[parameter.Schema.Reference];
                    _diagramXmlBuilder.AddEdge(parameter.Name, operationCellId, targetId);
                }
                else if (parameter.Schema?.Item?.Reference != null)
                {
                    var targetId = definitionCellIds[parameter.Schema.Item.Reference];
                    _diagramXmlBuilder.AddEdge(parameter.Name, operationCellId, targetId);
                }
            }
        }

        private void AddResponseRelationships(Dictionary<JsonSchema, string> definitionCellIds, KeyValuePair<string, OpenApiOperation> pathMethodItem, string operationCellId)
        {
            foreach (var response in pathMethodItem.Value.Responses)
            {
                if (response.Value.Schema?.Reference != null)
                {
                    var targetId = definitionCellIds[response.Value.Schema.Reference];
                    _diagramXmlBuilder.AddEdge($"Response {response.Key}", operationCellId, targetId);
                }
                else if (response.Value.Schema?.Item?.Reference != null)
                {
                    var targetId = definitionCellIds[response.Value.Schema.Item.Reference];
                    _diagramXmlBuilder.AddEdge($"Response {response.Key}", operationCellId, targetId);
                }
            }
        }
    }
}
