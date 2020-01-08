using MapDiagram.Model;
using NUnit.Framework;

namespace MapDiagramTests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            WeatherForecast wf = new WeatherForecast();
            wf.Summary = "Test";

            Assert.AreEqual("Test", wf.Summary);
        }
    }
}