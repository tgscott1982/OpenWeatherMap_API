



using Newtonsoft.Json.Linq;

var client = new HttpClient();
Console.WriteLine("Welcome to the Weather Checker App!");
Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
Console.Write("Please enter your API access key:");
var apiKey = Console.ReadLine();


while (true)
{


    Console.Write("\nOK! Please enter the name of your city: ");
    var userCity = Console.ReadLine().ToUpper();

    var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q={userCity}&appid={apiKey}&units=imperial";
    var urlReturn = client.GetStringAsync(weatherURL).Result;
    var formattedReturn = JObject.Parse(urlReturn).GetValue("main").ToString().ToUpper()
                           .Replace('{', ' ').Replace('}', ' ').Replace('_', ' ');

    Console.WriteLine($"\nThe city of {userCity}'s most current weather details are as follows (temperatures are displayed in Fahrenheit): \n{formattedReturn}");
    Console.Write("\nWould you like make another weather query? y/n : ");

    var exitCue = Console.ReadLine().ToLower();

    if (exitCue == "n" || exitCue == "no")
    {
        break;
    }
}
