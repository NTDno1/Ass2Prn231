using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;

namespace eBookStore.Controllers
{
    public class AuthorController : Controller
    {
        public async Task<IActionResult> Index()
        {
            string name = HttpContext.Session.GetString("Name");
            if (name == null)
            {
                return Redirect($"/Login");
            }
            else
            {
                List<Author> author = new List<Author>();

                string link = "https://localhost:7263/api/Authors";

                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(link))
                    {
                        using (HttpContent content = res.Content)
                        {
                            string data = await content.ReadAsStringAsync();
                            author = JsonConvert.DeserializeObject<List<Author>>(data);

                        }
                    }
                }
                return View(author);
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
                List<Author> authors = new List<Author>();
                Author author = new Author();

                string link = "https://localhost:7263/api/Authors";

                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(link))
                    {
                        using (HttpContent content = res.Content)
                        {
                            string data = await content.ReadAsStringAsync();
                            authors = JsonConvert.DeserializeObject<List<Author>>(data);
                        }
                    }
                    using (HttpResponseMessage res = await client.GetAsync(link+"/"+id))
                    {
                        using (HttpContent content = res.Content)
                        {
                            string data = await content.ReadAsStringAsync();
                            author = JsonConvert.DeserializeObject<Author>(data);
                        }
                    }
                }

                ViewData["Error"] = "Edit";
                ViewBag.Author = author;
                return View("Index",authors);

            }
        }
    }
}
