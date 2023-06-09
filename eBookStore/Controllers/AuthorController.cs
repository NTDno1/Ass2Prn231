using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;

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
                List<Author> authors = await GetAuthorsFromApi();
                return View(authors);
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
                List<Author> authors = await GetAuthorsFromApi();
                Author author = await GetAuthorFromApi(id);

                //ViewData["Error"] = "Edit";
                ViewBag.Author = author;
                return View("Index",authors);
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
                string link = "https://localhost:7263/api/Authors";
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.DeleteAsync(link+"?id="+id))
                    {
                        if (res.IsSuccessStatusCode)
                        {
                            List<Author> authors = await GetAuthorsFromApi();
                            return View("Index", authors);
                        }
                        else
                        {
                            return Redirect($"/Login");
                        }
                    }
                }
            }
        }
        public async Task<IActionResult> Update(int id, string fname, string lname, string city, string email)
        {
            string link = "https://localhost:7263/api/Authors";
            Author authors = await GetAuthorFromApi(id);
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.PutAsync
                (link + "?id="+ authors.AuthorId+"&lastname=" + lname + "&firstname=" + fname + "&phone=" + authors.Phone + "&address=" + authors.Address + "&city=" + city + "&state=" + authors.State + "&zip=" + authors.Zip + "&email=" + email + "", null))
                {
                }
            }
            Author author = await GetAuthorFromApi(id);
            List<Author> authorss = await GetAuthorsFromApi();
            ViewBag.Author = author;
            return View("Index", authorss);
        }
        public async Task<IActionResult> Insert(string fname, string lname, string city, string email)
        {
            string link = "https://localhost:7263/api/Authors";
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.PostAsync
                (link + "?lastname="+lname+"&firstname="+fname+"&phone=000&address=Hanoi&city="+city+"&state=1&zip=1&email="+email+"", null))
                {
                }
            }
            List<Author> authorss = await GetAuthorsFromApi();
            return View("Index", authorss);
        }
        public async Task<IActionResult> SearchId(string id)
        {
            return View();
        }
        public async Task<IActionResult> SearchValue(string fname, string lname, string city)
        {
            List<Author> authors = new List<Author>();

            string link = "https://localhost:7263/api/Authors";
            List<String> value = new List<string> { fname, lname, city };
            String name = value[1];
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(link+"/"+lname+"/"+fname+"/"+city))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        authors = JsonConvert.DeserializeObject<List<Author>>(data);
                    }
                }
            }
            ViewData["fname"] = fname;
            ViewData["lname"] = lname;
            ViewData["city"] = city;
            return View("Index", authors);
        }
        public async Task<IActionResult> SearchValue(int id)
        {
            List<Author> authors = new List<Author>();

            string link = "https://localhost:7263/api/Authors";
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(link + "/" + id))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        authors = JsonConvert.DeserializeObject<List<Author>>(data);
                    }
                }
            }
            ViewData["fname"] = id ;
            return View("Index", authors);
        }
        public async Task<List<Author>> GetAuthorsFromApi()
        {
            List<Author> authors = new List<Author>();

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
            }
            return authors;
        }
        public async Task<Author> GetAuthorFromApi(int id)
        {
            Author author = new Author();
            string link = "https://localhost:7263/api/Authors";
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(link + "/" + id))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        author = JsonConvert.DeserializeObject<Author>(data);
                    }
                }
            }
            return author;
        }
        public async Task<Author> GetAuthorByValueFromApi(int id)
        {
            Author author = new Author();
            string link = "https://localhost:7263/api/Authors";
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(link + "/" + id))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        author = JsonConvert.DeserializeObject<Author>(data);
                    }
                }
            }
            return author;
        }
    }
}
