using Microsoft.VisualStudio.TestTools.UnitTesting;
using RDFSharp.Model;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace RDFSharp.SpecFlow.Steps
{
    [Binding]
    public class RDFGraphFromFileSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private RDFGraphFromFileSteps(ScenarioContext scenarioContext)
        {
            this._scenarioContext = scenarioContext;
        }

        [Given(@"an RDF graph in the file ""(.*)""")]
        public void GivenAnRDFGraphInTheFile(string fileName)
        {
            _scenarioContext["Path"] = Path.Combine(@"TestFiles", fileName);
        }
        
        [When(@"create a graph from the file")]
        public void WhenCreateAGraphFromTheFile()
        {
            var path = (string)_scenarioContext["Path"];
            try
            {
                _scenarioContext["Graph"] = RDFGraph.FromFile(RDFModelEnums.RDFFormats.RdfXml, path);
            }
            catch (Exception e)
            {
                _scenarioContext["Exception"] = e;
            }
        }
        
        [Then(@"the graph sould be succesfully created")]
        public void ThenTheGraphSouldBeSuccesfullyCreated()
        {
            var graph = _scenarioContext["Graph"];
            Assert.IsNotNull(graph);
        }

        [Then(@"the program should throw an Exception, because of invalid file")]
        public void ThenTheProgramShouldThrowAnExceptionBecauseOfInvalidFile()
        {
            var exception = _scenarioContext["Exception"];
            Assert.IsNotNull(exception);
        }
    }
}
