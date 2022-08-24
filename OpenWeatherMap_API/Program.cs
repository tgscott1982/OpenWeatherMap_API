

///using openweathermap.org API to check current weather conditions of a user-provided city
///the first user-provided response is to check whether they have an API key before exiting/continuing
///upon continuing, user will enter city, then the app will display the current weather conditions
///in fahrenheit. the app will then ask if the user would like to check another location. if yes, the
///app will lopp back to entering a city name versus doing the API Key check from beginning. If not, the
///app will exit.

using Newtonsoft.Json.Linq;

var client = new HttpClient();
Console.WriteLine("Welcome to the Weather Checker App!\n");
Console.WriteLine("Please be advised you will need an API Key from http://openweathermap.org to use this app. Do you have one?\n");
Console.Write("Yes/No:   ");
var keyCheck = Console.ReadLine().ToLower();
if(keyCheck == "no" || keyCheck == "n")
{
    Console.WriteLine("I'm sorry. Please re-run the app when you have an API Key. Have a great day!");
    return;
}

Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
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
        Console.WriteLine("Thanks for checking me out! Have a great day!");
        break;
    }
}
