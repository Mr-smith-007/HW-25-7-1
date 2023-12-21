using HW_25_7_1.Entities;
using HW_25_7_1.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_25_7_1.Repositories
{
    internal class BookRepository
    {
        public void FindById()
        {
            Console.Write("Введите ID пользователя для поиска: ");
            try
            {
                bool result = int.TryParse(Console.ReadLine(), out int id);
                if (!result)
                    throw new WrongIdException();
                using (var db = new AppContext())
                {
                    var book = db.Books.Where(user => user.Id == id).FirstOrDefault();
                }
            }
            catch (WrongIdException)
            {
                Console.WriteLine("Введен неверный ID");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Возникло исключение {ex.Message}");
            }
        }

        public void FindAll()
        {
            try
            {
                using (var db = new AppContext())
                {
                    var books = db.Books.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Возникло исключение {ex.Message}");
            }
        }

        public void AddBook()
        {
            Console.Write("Введите название новой книги: ");
            var title = Console.ReadLine();

            Console.Write("Введите год издания новой книги: ");
            var result = int.TryParse(Console.ReadLine(), out int year);
            if ((!result) || (year < 0) || (year > DateTime.Now.Year))
                throw new WrongYearException();

            try
            {
                using (var db = new AppContext())
                {
                    var book = new Book { Title = title, Year = year };
                    db.Books.Add(book);
                    db.SaveChanges();
                }
            }
            catch (WrongYearException)
            {
                Console.WriteLine("Некорректный год издания");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Возникло исключение {ex.Message}");
            }
        }

        public void DeleteBookById()
        {
            Console.Write($"Введите Id книги для удаления");

            try
            {
                bool result = int.TryParse(Console.ReadLine(), out var id);
                if (!result)
                    throw new WrongIdException();

                using (var db = new AppContext())
                {
                    var book = db.Books.Where(book => book.Id == id).FirstOrDefault();
                    if (book == null)
                        throw new BookNotFoundException();
                    db.Books.Remove(book);
                    db.SaveChanges();
                }
            }
            catch (WrongIdException)
            {
                Console.WriteLine("Некорректный Id");
            }
            catch (BookNotFoundException)
            {
                Console.WriteLine("Книга с таким Id не найдена");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Возникло исключение {ex.Message}");
            }

        }

        public void UpdateBookYearById()
        {
            Console.Write($"Введите Id книги для обновления года");

            try
            {
                bool result = int.TryParse(Console.ReadLine(), out var id);
                if (!result)
                    throw new WrongIdException();

                using (var db = new AppContext())
                {
                    var book = db.Books.Where(book => book.Id == id).FirstOrDefault();
                    if (book == null)
                        throw new BookNotFoundException();

                    Console.Write("Введите новый год издания");
                    var resultYear = int.TryParse(Console.ReadLine(), out int newYear);
                    if ((!resultYear) || (newYear < 0) || (newYear > DateTime.Now.Year))
                        throw new WrongYearException();
                    
                    book.Year = newYear;
                    db.SaveChanges();
                }
            }
            catch (WrongIdException)
            {
                Console.WriteLine("Некорректный Id");
            }
            catch (BookNotFoundException)
            {
                Console.WriteLine("Книга с таким Id не найдена");
            }
            catch(WrongYearException)
            {
                Console.WriteLine("Введен некорректный год издания");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Возникло исключение {ex.Message}");
            }
        }
    }
}
