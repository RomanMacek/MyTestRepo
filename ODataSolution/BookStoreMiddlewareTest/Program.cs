using BookStoreMiddleware.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

// Install-Package Microsoft.AspNet.WebApi.Client
// https://www.youtube.com/watch?v=8JQhXCEdOt8


namespace BookStoreMiddlewareTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            GetTest().Wait();
        }

        static async Task GetTest()
        {
            var uri = new Uri("http://localhost:2459/");
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("Contacts/DejmiCustSParametremShort(1)");
                if (response.IsSuccessStatusCode)
                {
                    var concact = await response.Content.ReadAsAsync<Contact>();
                }
            }
        }

        static async Task PostTest()
        {
            var uri = new Uri("http://localhost:2459/");
            //var uri = new Uri("http://127.0.0.1:5984/");
            System.Net.HttpWebRequest webReq = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(uri);
            //webReq.Method = "Post";
            //webReq.ContentType = "application/json";
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //GET
                //HttpResponseMessage response = await client.GetAsync("Contacts/DejmiCustSParametremShort(1)");
                HttpResponseMessage response = await client.GetAsync("DejmiCustSParametremShort(1)");
                if (response.IsSuccessStatusCode)
                {
                    var concact = await response.Content.ReadAsAsync<Contact>();

                    concact.FirstName = "XXX put";
                    var concactPut = await client.PutAsJsonAsync("contacts", concact);
                    var concactPut2 = await client.PutAsJsonAsync("contacts", concact);
                }



                // Get List
                //HttpResponseMessage responseList = await client.GetAsync("Contacts/contacts");
                //if (response.IsSuccessStatusCode)
                //{
                //    var concactList = await response.Content.ReadAsAsync<List<Contact>>();
                //}

                //var contact = new Contact()
                //{
                //    Id = 3,
                //    FirstName = "Tri",
                //    LastName = "Tri tri "
                //};
                //HttpResponseMessage response = await client.PostAsJsonAsync("Contacts/", contact);
                //if (response.IsSuccessStatusCode)
                //{
                //    Uri xx = response.Headers.Location;

                //}
            }
        }

        private string GetJSon()
        {
            return @"{""id "": 1,""firstName"": ""AAA"",""lastName"": ""BBB""}";
        }
    }
}
