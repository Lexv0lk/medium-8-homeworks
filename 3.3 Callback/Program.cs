using System;
using System.Net;
using System.IO;

namespace _3._3_Callback
{
    class Program
    {
        static void Main(string[] args)
        {
            SendRequest("https://www.google.ru", str => Console.WriteLine(str));

            Console.ReadKey();
        }

        private static async void SendRequest(string url, Action<string> callback)
        {
            string result;
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);

            using (var response = (HttpWebResponse)await webRequest.GetResponseAsync())
            {
                using (var stream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                        result = reader.ReadToEnd();

                response.Close();
            }

            callback?.Invoke(result);
        }
    }
}
