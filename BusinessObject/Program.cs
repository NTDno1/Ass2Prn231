using BusinessObject.Models;
using System.Net.WebSockets;

namespace BusinessObject
{
    internal class Program
    {
        //private readonly Assignment2Context _db;
        //public Program(Assignment2Context db)
        //{
        //    _db = db;
        //}
        //List<Book> _books = _db.Books.ToList();
        static void Main(string[] args)
        {
            using (Assignment2Context context = new Assignment2Context())
            {
                var data = context.Authors.ToList();
                Console.WriteLine("day la list danh sach book");
                foreach(var book in data)
                {
                    Console.WriteLine(book);
                }
               
            }
        }

    }

}