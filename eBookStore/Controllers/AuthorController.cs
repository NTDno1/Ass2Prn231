using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using BusinessObject.Models;

namespace eBookStore.Controllers
{
    public class AuthorController : Controller
    {
        public async Task<IActionResult> Index()
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
}
