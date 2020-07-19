namespace JSONPlaceholder.Tests.API
{
    using System;
    using System.Net.Http;

    public static class APICaller
    {
        public static string CallAPI(string path)
        {
            using (var client = new HttpClient { BaseAddress = new Uri("https://jsonplaceholder.typicode.com/") })
            {
                var response = client.GetStringAsync(path);

                try
                {
                    return response.Result;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }
    }
}
