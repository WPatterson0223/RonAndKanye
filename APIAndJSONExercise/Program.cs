using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace APIAndJSONExercise;
class Program
{
    static void Main(string[] args)
    {
        var client = new HttpClient();

        var ronSwanson = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
        var ye = "https://api.kanye.rest/";

        for (int i = 0; i < 5; i++)
        {
            var ronResponse = client.GetStringAsync(ronSwanson).Result;
            var yeResponse = client.GetStringAsync(ye).Result;

            var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
            var yeQuote = JObject.Parse(yeResponse);

            Console.WriteLine($"Ron Swanson: {ronQuote}");
            Console.WriteLine();

            Console.WriteLine($"Kenye West: {yeQuote["quote"]}");
            Console.WriteLine();
        }
    }
}

