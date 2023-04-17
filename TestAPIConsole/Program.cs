using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace TestAPIConsole
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            CallWebAPIAsync()
            .Wait();
        }

        static async Task CallWebAPIAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("weatherforecast");
                var weather = await response.Content.ReadAsAsync<IEnumerable<WeatherForecast>>();
                foreach (var w in weather)
                {
                    Console.WriteLine(w.Date + "- " + w.TemperatureC + "- " + w.Summary);
                }
                //if (response.IsSuccessStatusCode)
                //{
                //    WeatherForecast weather = await response.Content.ReadAsAsync<WeatherForecast>();
                //    Console.WriteLine("Temperature:{0}\tSummary:{1}", weather.TemperatureC.ToString(), weather.Summary.ToString());
                //}
                //else
                //{
                //    Console.WriteLine("Internal server Error");
                //}
            }
        }
    }
}
