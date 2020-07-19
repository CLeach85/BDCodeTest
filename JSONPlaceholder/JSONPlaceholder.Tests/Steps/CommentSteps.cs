namespace JSONPlaceholder.Tests.Steps
{
    using JSONPlaceholder.Tests.API;
    using JSONPlaceholder.Tests.Interfaces;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using TechTalk.SpecFlow;
    using Xunit;

    [Binding]
    public class CommentSteps
    {
        private readonly APIContext apiContext;

        public CommentSteps(APIContext apiContext)
        {
            this.apiContext = apiContext;
        }

        [Given(@"I have created a comments search request with the post number (.*)")]
        public void GivenIHaveCreatedACommentsSearchRequestWithThePostNumber(int postNumber)
        {
            apiContext.path = $"posts/{postNumber}/comments/";
        }

        [Given(@"I have created a comments search request with text as the post number")]
        public void GivenIHaveCreatedACommentsSearchRequestWithThePostNumberText()
        {
            apiContext.path = $"posts/invalidPostNumber/comments/";
        }

        [Then(@"there should be (.*) comments returned")]
        public void ThenThereShouldBeCommentsReturned(int numberOfComments)
        {
            //var myDeserializedClass = new Root() { ResponseComments = JsonConvert.DeserializeObject<List<ResponseComment>>(apiContext.result) };

            var response = GetCommentResponses();
            Assert.Equal(numberOfComments, response.Count);
        }

        [Then(@"the name of the '(.*)' comment should be '(.*)'")]
        public void ThenTheNameOfTheCommentShouldBe(int commentNumber, string name)
        {
            var response = GetCommentResponses();
            Assert.Equal(name, response[commentNumber].name);
        }

        [Then(@"the email address of the '(.*)' comment should be '(.*)'")]
        public void ThenTheEmailAddressOfTheCommentNumberCommentShouldBeEmail(int commentNumber, string email)
        {
            var response = GetCommentResponses();
            Assert.Equal(email, response[commentNumber].email);
        }

        [Then(@"the email address of '(.*)' should be '(.*)'")]
        public void ThenTheEmailAddressOfShouldBe(int commentNumber, string email)
        {
            var response = GetCommentResponses();
            Assert.Equal(email, response[commentNumber].email);
        }

        [Then(@"the body of the '(.*)' comment should contain '(.*)'")]
        public void ThenTheBodyOfTheCommentShouldContain(int commentNumber, string body)
        {
            var response = GetCommentResponses();
            Assert.Contains(body, response[commentNumber].body);
        }

        [Then(@"the postid of the (.*) comment should be (.*)")]
        public void ThenThePostidOfTheCommentShouldBe(int commentNumber, int postId)
        {
            var response = GetCommentResponses();
            Assert.Equal(postId, response[commentNumber].postId);
        }

        [Then(@"the response should be empty")]
        public void ThenTheResponseShouldBeEmpty()
        {
            var response = apiContext.result;
            Assert.Equal("[]",response);
        }

        private List<CommentResponse> GetCommentResponses()
        {
            return JsonConvert.DeserializeObject<List<CommentResponse>>(apiContext.result);
        }

    }
}
