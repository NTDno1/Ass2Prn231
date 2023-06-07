using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace eBookStore.Controllers
{
    public class PublisherController : Controller
    {
        public async Task< IActionResult> Index()
        {
            string name = HttpContext.Session.GetString("Name");
            if (name == null)
            {
                return Redirect($"/Login");
            }
            else
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
                return View(publishers);
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
                List<Publisher> publishers = new List<Publisher>();
                Publisher publisher = new Publisher();

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
                    using (HttpResponseMessage res = await client.GetAsync(link + "/" + id))
                    {
                        using (HttpContent content = res.Content)
                        {
                            string data = await content.ReadAsStringAsync();
                            publisher = JsonConvert.DeserializeObject<Publisher>(data);
                        }
                    }
                }

                ViewData["Error"] = "Edit";
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
                List<Publisher> publishers = new List<Publisher>();

                string link = "https://localhost:7263/api/Publishers";

                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.DeleteAsync(link + "/" + id))
                    {
                        if (res.IsSuccessStatusCode)
                        {
                            using (HttpResponseMessage ress = await client.GetAsync(link))
                            {
                                using (HttpContent content = ress.Content)
                                {
                                    string data = await content.ReadAsStringAsync();
                                    publishers = JsonConvert.DeserializeObject<List<Publisher>>(data);
                                }
                            }
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
    }
}
