using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using canteensystem.Models;

namespace canteenform
{
    class Webservice
    {
        static public List<Users> getUser()
        {
            string baseUrl = "https://localhost:5001/api/Users";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var task = client.GetStringAsync(baseUrl);
            List<Users> users;
            try
            {
                users = JsonConvert.DeserializeObject<List<Users>>(task.Result);
            }
            catch
            {
                users = null;
            }
            return users;
        }

        static public Users getUserById(string id)
        {
            string baseUrl = $"https://localhost:5001/api/Users/{id}";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var task = client.GetStringAsync(baseUrl);
            Users user;
            try
            {
                user = JsonConvert.DeserializeObject<Users>(task.Result);
            }
            catch
            {
                user = null;
            }
            return user;
        }

        static public Users getUserByName(string name)
        {
            string baseUrl = $"https://localhost:5001/api/Users/name/{name}";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var task = client.GetStringAsync(baseUrl);
            Users user;
            try
            {
                user = JsonConvert.DeserializeObject<Users>(task.Result);
            }
            catch
            {
                user = null;
            }
            return user;
        }

        static public void createUser(Users user)
        {
            string baseUrl = "https://localhost:5001/api/Users";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var task = client.PostAsync(baseUrl, content);
            task.Wait();
        }

        static public void userOrder(Food food, string id)
        {
            string baseUrl = "https://localhost:5001/api/Users/order";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpContent content1 = new StringContent(JsonConvert.SerializeObject(food), Encoding.UTF8, "application/json");
            HttpContent content2 = new StringContent(JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json");
            var task1 = client.PostAsync(baseUrl, content1);
            var task2 = client.PostAsync(baseUrl, content2);
            task1.Wait();
            task2.Wait();
        }

        static public float userBuy(string id)
        {
            string baseUrl = "https://localhost:5001/api/Users/buy/{id}";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var task = client.GetStringAsync(baseUrl);
            float sum;
            try
            {
                sum = JsonConvert.DeserializeObject<float>(task.Result);
            }
            catch
            {
                sum = -1;
            }
            return sum;
        }

        static public int userWaitingnum(string storename)
        {
            string baseUrl = "https://localhost:5001/api/Users/waitingnumbers/{storename}";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var task = client.GetStringAsync(baseUrl);
            int num;
            try
            {
                num = JsonConvert.DeserializeObject<int>(task.Result);
            }
            catch
            {
                num = -1;
            }
            return num;
        }

        static public List<Store> getStore()
        {
            string baseUrl = "https://localhost:5001/api/Stores";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var task = client.GetStringAsync(baseUrl);
            List<Store> stores;
            try
            {
                stores = JsonConvert.DeserializeObject<List<Store>>(task.Result);
            }
            catch
            {
                stores = null;
            }
            return stores;
        }

        static public List<Store> getStoreByName(string name)
        {
            string baseUrl = $"https://localhost:5001/api/Store/name/{name}";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var task = client.GetStringAsync(baseUrl);
            List<Store> stores;
            try
            {
                stores = JsonConvert.DeserializeObject<List<Store>>(task.Result);
            }
            catch
            {
                stores = null;
            }
            return stores;
        }
        static public void createStore(Store store)
        {
            string baseUrl = "https://localhost:5001/api/Stores";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpContent content = new StringContent(JsonConvert.SerializeObject(store), Encoding.UTF8, "application/json");
            var task = client.PostAsync(baseUrl, content);
            task.Wait();
        }
        static public void createManager(Manager manager)
        {
            string baseUrl = "https://localhost:5001/api/Managers";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpContent content = new StringContent(JsonConvert.SerializeObject(manager), Encoding.UTF8, "application/json");
            var task = client.PostAsync(baseUrl, content);
            task.Wait();
        }

        static public Users getManagerByName(string name)
        {
            string baseUrl = $"https://localhost:5001/api/Managers/name/{name}";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var task = client.GetStringAsync(baseUrl);
            Manager manager;
            try
            {
               manager = JsonConvert.DeserializeObject<Manager>(task.Result);
            }
            catch
            {
                manager = null;
            }
            return manager;
        }
        static public void createFood(Food food)
        {
            string baseUrl = "https://localhost:5001/api/Food";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpContent content = new StringContent(JsonConvert.SerializeObject(food), Encoding.UTF8, "application/json");
            var task = client.PostAsync(baseUrl, content);
            task.Wait();
        }
    }
}
