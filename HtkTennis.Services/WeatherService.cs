using HtkTennis.Services.Base;

namespace HtkTennis.Services
{

    // <summary>
    /// Class for getting weather information
    /// </summary>
    public class WeatherService: WebServiceBase
    {
        // URI to the endpoint.
        // And of course its smart to include the api key in here.
        // Because this will definitely not end up in a public repository on Github!
        protected const string endpoint = "https://api.openweathermap.org/data/2.5/onecall?lat=55.71&lon=9.54&exclude=hourly,current,minutely&appid=";
    }
}