using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_25_7_1.Views
{
    public class EditDbView
    {
        public void Show()
        {
            Console.WriteLine("Работа с данными пользователей (нажмите 1)");
            Console.WriteLine("Работа с данными книг (нажмите 2)");

            switch(Console.ReadLine())
            {
                case "1":
                    {
                        Program.editDbUsersView.Show();
                        break;
                    }
                    case "2":
                    {
                        Program.editDbBooksView.Show();
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
