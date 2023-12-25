using HW_25_7_1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_25_7_1.Views
{
    public class DbQueryBooksView
    {
        BookRepository bookRepository;

        public DbQueryBooksView(BookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public void Show()
        {
            Console.WriteLine("Найти книгу по Id (нажмите 1)");
            Console.WriteLine("Найти книгу по названию (нажмите 2)");
            Console.WriteLine("Показать все книги (нажмите 3)");
            Console.WriteLine("Список книг заданного жанра с годом издания в заданном диапазоне (нажмите 4)");
            Console.WriteLine("Количество книг по автору (нажмите 5)");
            Console.WriteLine("Количество книг по жанру (нажмите 6)");
            Console.WriteLine("Наличие книги на складе по заданным автору и названию (нажмите 7)");
            Console.WriteLine("Все книги по алфавитному порядку (нажмите 8)");
            Console.WriteLine("Все книги по убыванию года издания (нажмите 9)");
            Console.WriteLine("Последняя изданная книга (нажмите 10)");

            switch (Console.ReadLine())
            {
                case "1":
                    {
                        bookRepository.FindById
                        break;
                    }
                case "2":
                    {
                        bookRepository.FindByTitle();
                        break;
                    }
                case "3":
                    {
                        bookRepository.FindAll();
                        break;
                    }
                case "4":
                    {
                        bookRepository.GenreYearBookList();
                        break;
                    }
                case "5":
                    {
                        bookRepository.AutorsBooksCount();
                        break;
                    }
                case "6":
                    {
                        bookRepository.GenreBooksCount();
                        break;
                    }
                case "7":
                    {
                        bookRepository.BoolTitleAuthorBook();
                        break;
                    }
                case "8":
                    {
                        bookRepository.SordedBooksByTitle();
                        break;
                    }
                case "9":
                    {
                        bookRepository.SortedBooksByYearDescending();
                        break;
                    }
                case "10":
                    {
                        bookRepository.LastBook();
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
