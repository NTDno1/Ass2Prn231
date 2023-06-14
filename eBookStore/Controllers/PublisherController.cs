using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace eBookStore.Controllers
{
    public class PublisherController : Controller
    {
        public async Task<IActionResult> Index()
        {
            string name = HttpContext.Session.GetString("Name");
            int? roleId = HttpContext.Session.GetInt32("Role");
            if (name == null)
            {
                return Redirect($"/Login");
            }
            else
            {
                if (roleId == 1)
                {
                    List<Publisher> publishers = await GetPublisherFromApi();
                    return View(publishers);
                }
                if (roleId == 2)
                {
                    ViewData["isAdmin"] = name;
                    List<Publisher> publishers = await GetPublisherFromApi();
                    return View(publishers);
                }
                else
                {
                    return Redirect($"/Login");
                }
            }
        }
        public async Task<IActionResult> Edit(int id)
        {
            string name = HttpContext.Session.GetString("Name");
            if (name == null)
            {
                return Redirect($"/Login");
            }
            else
            {
                List<Publisher> publishers = await GetPublisherFromApi();
                Publisher publisher = await GetPublisherIdFromApi(id);
                ViewBag.Publisher = publisher;
                return View("Index", publishers);

            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            string name = HttpContext.Session.GetString("Name");
            if (name == null)
            {
                return Redirect($"/Login");
            }
            else
            {
                string link = "https://localhost:7263/api/Publishers";

                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.DeleteAsync(link + "/" + id))
                    {
                        if (res.IsSuccessStatusCode)
                        {
                            List<Publisher> publishers = await GetPublisherFromApi();
                            return View("Index", publishers);
                        }
                        else
                        {
                            return Redirect($"/Login");
                        }
                    }
                }
            }
        }
        public async Task<IActionResult> Update(int id, string fname, string city)
        {
            string link = "https://localhost:7263/api/Publishers";
            Publisher publisher = await GetPublisherIdFromApi(id);
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.PutAsync
                (link + "?id=" + id + "&name=" + fname + "&city=" + city + "&state=" + publisher.State + "&country=" + publisher.Country, null))
                {
                }
            }
            Publisher publisherss = await GetPublisherIdFromApi(id);
            List<Publisher> publishers = await GetPublisherFromApi();
            ViewBag.Publisher = publisherss;
            return View("Index", publishers);
        }
        public async Task<IActionResult> Insert(string fname, string city)
        {
            string link = "https://localhost:7263/api/Publishers";
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.PostAsync
                (link + "?name=" + fname + "&city=" + city + "&state=single&country=Vietnam", null))
                {
                }
            }
            List<Publisher> publishers = await GetPublisherFromApi();
            return View("Index", publishers);
        }
        public async Task<IActionResult> SearchValue(string name, string city)
        {
            string names = HttpContext.Session.GetString("Name");
            int? roleId = HttpContext.Session.GetInt32("Role");
            if (names == null)
            {
                return Redirect($"/Login");
            }
            else
            {
                List<Publisher> publishers = new List<Publisher>();

                string link = "https://localhost:7263/api/Publishers";
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(link + "/" + name + "/" + city))
                    {
                        using (HttpContent content = res.Content)
                        {
                            string data = await content.ReadAsStringAsync();
                            publishers = JsonConvert.DeserializeObject<List<Publisher>>(data);
                        }
                    }
                }
                if (roleId == 1)
                {
                    ViewData["city"] = city;
                    ViewData["name"] = name;
                    return View("Index", publishers);
                }
                if (roleId == 2)
                {
                    ViewData["isAdmin"] = name;
                    ViewData["city"] = city;
                    ViewData["name"] = name;
                    return View("Index", publishers);
                }
                else
                {
                    return Redirect($"/Login");
                }
            }
        }
        public async Task<List<Publisher>> GetPublisherFromApi()
        {
            List<Publisher> publishers = new List<Publisher>();

            string link = "https://localhost:7263/api/Publishers";

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(link))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        publishers = JsonConvert.DeserializeObject<List<Publisher>>(data);
                    }
                }
            }
            return publishers;
        }
        public async Task<Publisher> GetPublisherIdFromApi(int id)
        {
            Publisher publisher = new Publisher();

            string link = "https://localhost:7263/api/Publishers";

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(link + "/" + id))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        publisher = JsonConvert.DeserializeObject<Publisher>(data);
                    }
                }
            }
            return publisher;
        }
    }
}
