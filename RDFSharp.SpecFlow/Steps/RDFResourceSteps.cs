using Microsoft.VisualStudio.TestTools.UnitTesting;
using RDFSharp.Model;
using System;
using TechTalk.SpecFlow;

namespace RDFSharp.SpecFlow.Steps
{
    [Binding]
    public class RDFResourceSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private RDFResourceSteps(ScenarioContext scenarioContext)
        {
            this._scenarioContext = scenarioContext;
        }

        [When(@"create resource without parameters")]
        public void WhenCreateResourceWithoutParameters()
        {
            _scenarioContext["Resource"] = new RDFResource();
        }

        [When(@"create resource with parameter ""(.*)""")]
        public void WhenCreateResourceWithParameter(string input)
        {
            try
            {
                _scenarioContext["Resource"] = new RDFResource(input);
            }
            catch (RDFModelException e)
            {
                _scenarioContext["Exception"] = e;
            }
        }


        [Then(@"the resource sould not be null")]
        public void ThenTheResourceSouldNotBeNull()
        {
            var resource = _scenarioContext["Resource"];
            Assert.IsNotNull(resource);
        }

        [Then(@"the resource should be blank")]
        public void ThenTheResourceShouldBeBlank()
        {
            var resource = (RDFResource)_scenarioContext["Resource"];
            Assert.IsTrue(resource.IsBlank);
        }

        [Then(@"the resource should not be blank")]
        public void ThenTheResourceShouldNotBeBlank()
        {
            var resource = (RDFResource)_scenarioContext["Resource"];
            Assert.IsFalse(resource.IsBlank);
        }

        [Then(@"the resources URI should be start with ""(.*)""")]
        public void ThenTheResourcesURIShouldBeStartWith(string input)
        {
            var resource = (RDFResource)_scenarioContext["Resource"];
            Assert.IsTrue(resource.ToString().StartsWith(input));
        }

        [Then(@"the resources URI should be ""(.*)""")]
        public void ThenTheResourcesURIShouldBe(string input)
        {
            var resource = (RDFResource)_scenarioContext["Resource"];
            Assert.IsTrue(resource.ToString().Equals(input));
        }

        [Then(@"the program sould throw RDFModelException")]
        public void ThenTheProgramSouldThrowRDFModelException()
        {
            var exception = (RDFModelException)_scenarioContext["Exception"];
            Assert.IsNotNull(exception);
        }

    }
}
