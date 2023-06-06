namespace eBookStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
            var app = builder.Build();
            app.UseSession(); // Kích hoạt phiên

            // Định nghĩa các đường dẫn và xử lý yêu cầu

            app.MapGet("/", async context =>
            {
                var session = context.Session;
                session.SetString("Name", "John");
                await context.Response.WriteAsync("Session value has been set.");
            });

            app.MapGet("/get", async context =>
            {
                var session = context.Session;
                var name = session.GetString("Name");
                await context.Response.WriteAsync($"Session value: {name}");
            });

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}