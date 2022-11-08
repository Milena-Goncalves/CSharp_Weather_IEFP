

using Newtonsoft.Json;

//Testes

//Alterei

//Vejam está linha
var client = new HttpClient();
var request = new HttpRequestMessage
{
    Method = HttpMethod.Get,
    RequestUri = new Uri("https://covid-193.p.rapidapi.com/statistics?country=Portugal"),
    Headers =
    {
        { "X-RapidAPI-Key", "2c919a96d7msh4b3c8f542ec9108p1b1e5fjsn5c0f938ee222" },
        { "X-RapidAPI-Host", "covid-193.p.rapidapi.com" },
    },
};

using (var response = await client.SendAsync(request))
{
    response.EnsureSuccessStatusCode();
    var body = await response.Content.ReadAsStringAsync();

    dynamic json = JsonConvert.DeserializeObject(body);

    //População
    Console.WriteLine($"População: {json["response"][0]["population"]} habitantes.");

    //Total casos
    Console.WriteLine($"Total casos de covid: {json["response"][0]["cases"]["total"]}.");

}
