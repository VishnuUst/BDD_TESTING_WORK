using NUnit.Framework;

namespace Sample_Project.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        private int firstnumber,secondnumber,sum,difference;

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
           this.firstnumber = number;
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            this.secondnumber = number;
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            this.sum = this.firstnumber + this.secondnumber;
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            Assert.AreEqual(this.sum, result);
        }
        [When(@"the second number is subtracted from the first number")]
        public void WhenTheSecondNumberIsSubtractedFromTheFirstNumber()
        {
            this.difference = this.firstnumber - this.secondnumber;
        }
        [Then(@"the difference should be (.*)")]
        public void ThenTheDifferenceShouldBe(int result)
        {
            Assert.AreEqual(this.difference, result);
        }


    }
}