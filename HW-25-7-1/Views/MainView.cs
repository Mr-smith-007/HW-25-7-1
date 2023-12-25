using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_25_7_1.Views
{
    public class MainView
    {
        public void Show()
        {
            Console.WriteLine("Редактировать данные (нажмите 1)");
            Console.WriteLine("Произвести запрос (нажмите 2)");

            switch (Console.ReadLine())
            {
                case "1":
                    {
                        Program.EditDbView.Show();
                        break;
                    }
                case "2":
                    {
                        Program.DbQueryView.Show();
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
