using Microsoft.VisualStudio.TestTools.UnitTesting;
using RDFSharp.Model;
using RDFSharp.Query;
using System;
using System.Data;
using TechTalk.SpecFlow;

namespace RDFSharp.SpecFlow.Steps
{
    [Binding]
    public class RDFLimitModifierSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private RDFLimitModifierSteps(ScenarioContext scenarioContext)
        {
            this._scenarioContext = scenarioContext;
        }

        [When(@"create a RDFLimitModifier with a limit of (.*)")]
        public void WhenCreateARDFLimitModifierWithALimitOf(int limit)
        {
            try
            {
                _scenarioContext["Modifier"] = new RDFLimitModifier(limit);
                _scenarioContext["Limit"] = limit;
            }
            catch (RDFQueryException e)
            {
                _scenarioContext["Exception"] = e;
            }
        }
        
        [Then(@"the modifier is successfully created")]
        public void ThenTheModifierIsSuccessfullyCreated()
        {
            var modifier = (RDFLimitModifier)_scenarioContext["Modifier"];
            var limit = (int)_scenarioContext["Limit"];
            Assert.IsNotNull(modifier);
            Assert.IsTrue(modifier.Limit == limit);
            Assert.IsTrue(modifier.ToString().Equals("LIMIT " + limit));
        }
        
        [Then(@"the program sould throw an RDFQueryException")]
        public void ThenTheProgramSouldThrowAnRDFQueryException()
        {
            var exception = (RDFQueryException)_scenarioContext["Exception"];
            Assert.IsNotNull(exception);
        }
    }
}
