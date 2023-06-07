using BusinessObject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace eBookStore.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index(string mess)
        {
            //ViewData["Error"] = "Đăng nhập không thành công. Vui lòng kiểm tra lại thông tin đăng nhập.";
                return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetUser(string email, string pass)
        {
            string link = "https://localhost:7263/api/Users";
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(link + "/" + email + "/" + pass))
                {
                    if (res.IsSuccessStatusCode)
                    {
                        string jsonResult = await res.Content.ReadAsStringAsync();
                        var resoult = JsonConvert.DeserializeObject<User>(jsonResult);
                        int roleId = resoult.RoleId.GetValueOrDefault();
                        string name = resoult.FirstName.ToString();
                        HttpContext.Session.SetString("Name", name);
                        HttpContext.Session.SetInt32("Role", roleId);
                        //return RedirectToRoute(new { action = "Author", id = roleId, name = name });
                        return Redirect($"/Author");
                    }
                    else
                    {
                        ViewData["Error"] = "Đăng nhập không thành công. Vui lòng kiểm tra lại thông tin đăng nhập.";
                        return View("Index");
                    }
                }
            }
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> SignUp(string email, string pass, string repass)
        {
            if (!pass.Equals(repass))
            {
                ViewData["Error"] = "Vui Lòng Kiểm Tra Lại Thông Tin Đăng Nhập";
                return View("SignUp");
            }
            string link = "https://localhost:7263/api/Users";
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage resget = await client.GetAsync(link + "/" + email + "/" + pass))
                {
                    string jsonResult = await resget.Content.ReadAsStringAsync();
                    var resoult = JsonConvert.DeserializeObject<User>(jsonResult);
                        if (resoult!= null)
                        {
                            ViewData["Error"] = "Email Đã Tồn Tại";
                            return View("SignUp");
                        }
                        else
                        {
                            using (HttpResponseMessage res = await client.PostAsJsonAsync(link + "/" + email + "/" + pass, email))
                            {
                                if (res.IsSuccessStatusCode)
                                {
                                    ViewData["SignUp"] = "Đăng Ký Tài Khoản Thành Công";
                                    return View("Index");
                                }
                                else
                                {
                                    ViewData["Error"] = "Vui Lòng Kiểm Tra Lại Thông Tin Đăng Nhập";
                                    return View("SignUp");
                                }
                            }
                        }
                }
            }
        }
    }
}
