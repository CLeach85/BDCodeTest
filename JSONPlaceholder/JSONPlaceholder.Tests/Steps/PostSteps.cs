namespace JSONPlaceholder.Tests.Steps
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using JSONPlaceholder.Tests.API;
    using JSONPlaceholder.Tests.Interfaces;
    using TechTalk.SpecFlow;
    using Xunit;

    [Binding]
    public class PostSteps
    {
        private readonly APIContext apiContext;

        public PostSteps(APIContext apiContext)
        {
            this.apiContext = apiContext;
        }


        [Given(@"I have created a post search request with the post number (.*)")]
        public void GivenIHaveCreatedAPostSearchRequestWithThePostNumber(int numberOfPosts)
        {
            apiContext.path = $"posts/{numberOfPosts}";
        }

        [Given(@"I have created a post search request with an empty post number")]
        public void GivenIHaveCreatedAPostSearchRequestWithAnEmptyPostNumber()
        {
            apiContext.path = "posts/";
        }

        [Then(@"there should be (.*) posts returned")]
        public void ThenThereShouldBePostsReturned(int postCount)
        {
            var response = GetPostResponses();
            Assert.Equal(postCount, response.Count);
        }

        [Then(@"there should be a single post returned")]
        public void ThenThereShouldBeASinglePostReturned()
        {
            var response = GetPostResponse();
            Assert.NotNull(response);
        }

        [Then(@"the title of the post should be '(.*)'")]
        public void ThenTheTitleOfThePostShouldBe(string title)
        {
            var response = GetPostResponse();
            Assert.Equal(title, response.title);
        }

        [Then(@"the body of the post should contain '(.*)'")]
        public void ThenTheBodyOfThePostShouldContain(string body)
        {
            var response = GetPostResponse();
            Assert.Contains(body, response.body);
        }

        [Then(@"the id of the post should be (.*)")]
        public void ThenTheIdOfThePostShouldBe(int id)
        {
            var response = GetPostResponse();
            Assert.Equal(id, response.id);
        }


        private PostResponse GetPostResponse()
        {
            return JsonConvert.DeserializeObject<PostResponse>(apiContext.result);
        }

        private List<PostResponse> GetPostResponses()
        {
            return JsonConvert.DeserializeObject<List<PostResponse>>(apiContext.result);
        }

    }
}
