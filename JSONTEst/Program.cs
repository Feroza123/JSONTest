using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;


namespace JSONTEst
{
    class Program
    {
        static void Main(string[] args)
        {
            JsonResponse IPAddress = new JsonResponse();
            IPAddress = Get();
            Console.WriteLine("Your IP Address is: {0} ", IPAddress.IP);
            Console.WriteLine("Your about is: {0} ", IPAddress.about);
        }

        public static JsonResponse Get()
        {
            try
            {
                using (var client = new WebClient())
                {
                    var jsonResponse = client.DownloadString("https://jsonip.com/");
                    JsonResponse response = new JsonResponse();
                    response = JsonConvert.DeserializeObject<JsonResponse>(jsonResponse);
                    return response;

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            //https://gearside.com/public-json-feeds/
        }
    }
}
