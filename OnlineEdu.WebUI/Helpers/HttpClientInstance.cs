namespace OnlineEdu.WebUI.Helpers
{
    public class HttpClientInstance
    {
        public static HttpClient CreateClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44316/api/");
            return client;
        }
    }
}
