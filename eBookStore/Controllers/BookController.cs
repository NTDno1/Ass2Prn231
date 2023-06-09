using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static System.Reflection.Metadata.BlobBuilder;

namespace eBookStore.Controllers
{
    public class BookController : Controller
    {
        public async Task<IActionResult> Index()
        {
            //string name = HttpContext.Session.GetString("Name");
            //if (name == null)
            //{
            //    return Redirect($"/Login");
            //}
            //else
            //{
                List<Book> books = await GetBookFromApi();
                return View(books);
            //}
        }
        public async Task<IActionResult> Search(string title)
        {
            //string name = HttpContext.Session.GetString("Name");
            //if (name == null)
            //{
            //    return Redirect($"/Login");
            //}
            //else
            //{
                List<Book> books = await GetBookFromApi(title);
                ViewBag.String = title;
                return View("Index",books);
            //}
        }
        public async Task<List<Book>> GetBookFromApi()
        {
            List<Book> books = new List<Book>();

            string link = "https://localhost:7263/api/Books";

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(link))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        books = JsonConvert.DeserializeObject<List<Book>>(data);
                    }
                }
            }
            return books;
        }
        public async Task<List<Book>> GetBookFromApi(string title)
        {
            List<Book> books = new List<Book>();

            string link = "https://localhost:7263/api/Books"+"/"+title;

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(link))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        books = JsonConvert.DeserializeObject<List<Book>>(data);
                    }
                }
            }
            return books;
        }
    }
}
