namespace JSONPlaceholder.Tests.Steps
{
    using JSONPlaceholder.Tests.API;
    using TechTalk.SpecFlow;

    [Binding]
    public class SharedSteps
    {
        private readonly APIContext apiContext;

        public SharedSteps(APIContext apiContext)
        {
            this.apiContext = apiContext;
        }

        [When(@"I call the API")]
        public void WhenICallTheAPI()
        {
            apiContext.result = APICaller.CallAPI(apiContext.path);
        }
    }
}
