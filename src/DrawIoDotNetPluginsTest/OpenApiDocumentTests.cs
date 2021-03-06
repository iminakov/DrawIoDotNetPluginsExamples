﻿using BaseDrawIoPlugin.XmlLayout;
using NSwag;
using NUnit.Framework;
using OpenApiDocumentSchemaPlugin.Services;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace DrawIoDotNetPluginsTest
{
    [TestFixture]
    public class OpenApiDocumentLoadTests
    {
        [Test]
        public async Task OpenApiDocumentCanBeLoadedFromJsonFile()
        {
            string result = LoadResourceData("DrawIoDotNetPluginsTest.examples.test.json");

            OpenApiDocument document = await OpenApiDocument.FromJsonAsync(result);

            Assert.AreEqual(6, document.Definitions.Count);
        }

        [Test]
        public async Task OpenApiDocumentCanCreateXmlDiagram()
        {
            string result = LoadResourceData("DrawIoDotNetPluginsTest.examples.test.json");
            string targetXmlDiagram = LoadResourceData("DrawIoDotNetPluginsTest.examples.targetXml.txt");

            OpenApiDocument document = await OpenApiDocument.FromJsonAsync(result);
            OpenApiDiagramBuilder builder = new OpenApiDiagramBuilder(document, new DiagramXmlBuilder("111"));

            var xmlDiagram = builder.BuildDiagram();

            Assert.AreEqual(targetXmlDiagram, xmlDiagram);
        }

        private string LoadResourceData(string resourceName)
        {
            using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
            using StreamReader reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
    }
}
