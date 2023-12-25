using HW_25_7_1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_25_7_1.Views
{
    public class EditDbUsersView
    {
        UserRepository userRepository;
        public EditDbUsersView(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void Show()
        {
            Console.WriteLine("Добавить нового пользователя (нажмите 1)");
            Console.WriteLine("Удалить пользователя по Id (нажмите 2)");
            Console.WriteLine("Удалить пользователя по Email (нажмите 3)");
            Console.WriteLine("Обновить имя пользователя (нажмите 4)");
            Console.WriteLine("Выдать книгу пользователю (нажмите 5)");
            Console.WriteLine("Возврат книги пользователем (нажмите 6)");

            switch (Console.ReadLine())
            {
                case "1":
                    {
                        userRepository.AddUser();
                        break;
                    }
                case "2":
                    {
                        userRepository.DeleteUserById();
                        break;
                    }
                case "3":
                    {
                        userRepository.DeleteUserByEmail();
                        break;
                    }
                case "4":
                    {
                        userRepository.UpdateUserNameById();
                        break;
                    }
                case "5":
                    {
                        userRepository.UserTakeBook();
                        break;
                    }
                case "6":
                    {
                        userRepository.UserReturnBook();
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
