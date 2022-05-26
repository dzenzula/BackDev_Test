using KeyboardHooker.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace KeyboardHooker.Handlers
{
    public class TransferDataHandler
    {
        public async void TransferJson(List<ButtonKeyboard> buttons)
        {
            string strRest = ConfigurationManager.AppSettings.Get("rest");
            string strName = ConfigurationManager.AppSettings.Get("fileName");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5000");

                string json = JsonSerializer.Serialize(buttons);

                File.WriteAllText(@"D:\MyProjects\BackDev_Test0\Json\" + strName, json);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                await client.PostAsync(strRest, content);
            }
        }
    }
}
