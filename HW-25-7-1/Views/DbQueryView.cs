using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_25_7_1.Views
{
    public class DbQueryView
    {
        public void Show()
        {
            Console.WriteLine("Запрос в БД пользователей (нажмите 1)");
            Console.WriteLine("Запрос в БД книг (нажмите 2)");

            switch (Console.ReadLine())
            {
                case "1":
                    {
                        Program.dbQueryUsersView.Show();
                        break;
                    }
                case "2":
                    {
                        Program.dbQueryBooksView.Show();
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
