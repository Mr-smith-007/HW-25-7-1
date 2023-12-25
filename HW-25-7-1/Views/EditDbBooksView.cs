using HW_25_7_1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_25_7_1.Views
{
    public class EditDbBooksView
    {
        BookRepository bookRepository;

        public EditDbBooksView(BookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
         
        public void Show()
        {
            Console.WriteLine("Добавить новую книгу (новая позиция на складе) (нажмите 1)");
            Console.WriteLine("Добавить книгу на склад (нажмите 2)");
            Console.WriteLine("Удалить книгу по Id (нажмите 3)");
            Console.WriteLine("Редактировать год издания (нажмите 4)");

            switch (Console.ReadLine())
            {
                case "1":
                    {
                        bookRepository.AddNewBook();
                        break;
                    }
                case "2":
                    {
                        bookRepository.AddBook();
                        break;
                    }
                case "3":
                    {
                        bookRepository.DeleteBookById();
                        break;
                    }
                case "4":
                    {
                        bookRepository.UpdateBookYearById();
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
