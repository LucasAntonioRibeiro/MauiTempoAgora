using MauiTempoAgora.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MauiTempoAgora.Service
{
    public class DataServicejsonNet8
    {
        public static async Task<Tempo?> GetPrevisaoDoTempo(string cidade)
        {
            string appId = "6135072afe7f6cec1537d5cb08a5a1a2";

            string url = $"http://api.openweathermap.org/data/2.5/weather?q={cidade}&units=metric&appid={appId}";

            Tempo? tempo = null;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    Debug.WriteLine("--------------------------------------------------------------------");
                    Debug.WriteLine(json);
                    Debug.WriteLine("--------------------------------------------------------------------");

                    tempo = JsonSerializer.Deserialize<Tempo>(json);
                }
            }

            return tempo;
        }
    }
}
