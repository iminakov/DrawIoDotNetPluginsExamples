using NUnit.Framework;
using OpenSwaggerSchemaPlugin.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenSwaggerSchemaPluginTest
{
    [TestFixture]
    public class DiagramXmlBuilderTests
    {
        [Test]
        public void DiagramXmlBuilderCanCreateXmlDataTest()
        {
            var diagramBuilder = new DiagramXmlBuilder();
            var v1Id = diagramBuilder.AddVertex("v1");
            var v2Id = diagramBuilder.AddVertex("v2");
            var edge1Id = diagramBuilder.AddEdge("edge1", v1Id, v2Id);

            Assert.IsNotNull(diagramBuilder.ToString());
        }
    }
}
