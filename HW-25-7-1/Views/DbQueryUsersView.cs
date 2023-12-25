using HW_25_7_1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_25_7_1.Views
{
    public class DbQueryUsersView
    {
        UserRepository userRepository;

        public DbQueryUsersView(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void Show()
        {
            Console.WriteLine("Найти пользователя по Id (нажмите 1)");
            Console.WriteLine("Показать всех пользователей (нажмите 2)");
            Console.WriteLine("Поиск книги на руках у пользователя (нажмите 3)");
            Console.WriteLine("Количество книг на руках у пользователя (нажмите 4)");
            

            switch (Console.ReadLine())
            {
                case "1":
                    {
                        userRepository.FindById();
                        break;
                    }
                case "2":
                    {
                        userRepository.FindAll();
                        break;
                    }
                case "3":
                    {
                        userRepository.UserHasBook();
                        break;
                    }
                case "4":
                    {
                        userRepository.UserBooksCount();
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
