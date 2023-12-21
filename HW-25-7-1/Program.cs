


namespace HW_25_7_1
{
    class Program
    {
        public static void Main(string[] args)
        {
            using (var db = new AppContext())
            {
                var user = new User { Name = "Arthur", Email = "example1@gmail.com" };
                var book = new Book { Title = "God of war", Year = 2002 };

                db.Users.Add(user);
                db.Books.Add(book);
                db.SaveChanges();
            }
        }
    }
}