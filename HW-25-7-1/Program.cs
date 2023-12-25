


using HW_25_7_1.Entities;
using HW_25_7_1.Repositories;
using HW_25_7_1.Views;

namespace HW_25_7_1
{
    class Program
    {
        static UserRepository userRepository;
        static BookRepository bookRepository;

        public static MainView mainView;
        public static EditDbView editDbView;
        public static EditDbUsersView editDbUsersView;
        public static EditDbBooksView editDbBooksView;
        public static DbQueryView dbQueryView;
        public static DbQueryUsersView dbQueryUsersView;
        public static DbQueryBooksView dbQueryBooksView;
        public static void Main(string[] args)
        {
            userRepository = new UserRepository();
            bookRepository = new BookRepository();

            mainView = new MainView();
            editDbView = new EditDbView();
            editDbUsersView = new EditDbUsersView(userRepository);
            editDbBooksView = new EditDbBooksView(bookRepository);
            dbQueryView = new DbQueryView();
            dbQueryUsersView = new DbQueryUsersView(userRepository);
            dbQueryBooksView = new DbQueryBooksView(bookRepository);


            var flag = true;
            while (flag)
            {
                Console.WriteLine("Начать работу (нажмите 1)");
                Console.WriteLine("Завершить работу (нажмите 2)");

                switch (Console.ReadLine())
                {
                    case "1":
                        {
                            mainView.Show();
                            break;
                        }
                    case "2":
                        {
                            flag = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Некорректная команда");
                            break;
                        }
                }
            }

        }
    }
}