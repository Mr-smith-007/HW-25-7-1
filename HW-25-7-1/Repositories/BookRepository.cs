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
            Console.Write("Введите ID книги для поиска: ");
            try
            {
                bool result = int.TryParse(Console.ReadLine(), out int id);
                if (!result)
                    throw new WrongIdException();
                using (var db = new AppContext())
                {
                    var book = db.Books.Where(b => b.Id == id).FirstOrDefault();
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
        public void FindByTitle()
        {
            Console.Write("Введите название книги для поиска: ");
            try
            {
                var title = Console.ReadLine();
                using (var db = new AppContext())
                {
                    var book = db.Books.Where(b => b.Title == title).FirstOrDefault();
                    if (book == null)
                        Console.WriteLine("Книга с таким названием не найдена");
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
            Console.Write("Введите название книги: ");
            var title = Console.ReadLine();

            try
            {
                Console.Write("Введите кол-во книг поступающих на склад: ");
                var quantityResult = int.TryParse(Console.ReadLine(), out int quantity);
                if ((!quantityResult) || (quantity < 0))
                    throw new ArgumentException();

                using (var db = new AppContext())
                {
                    var book = db.Books.Where(b => b.Title == title).FirstOrDefault();
                    if (book != null)
                    {
                        book.Quantity += quantity;
                        db.SaveChanges();
                    }
                    else
                        Console.WriteLine("Книга с таким названием не найдена, добавьте как новую книгу");

                }
            }
            catch(ArgumentException)
            {
                Console.WriteLine("Некорректно введено кол-во книг");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Возникло исключение {ex.Message}");
            }
        }


        public void AddNewBook()
        {
            Console.Write("Введите название новой книги: ");
            var title = Console.ReadLine();

            Console.Write("Введите ФИО автора книги: ");
            var author = Console.ReadLine();

            Console.Write("Введите жанр книги: ");
            var genre = Console.ReadLine();

            try
            {
                Console.Write("Введите год издания новой книги: ");
                var result = int.TryParse(Console.ReadLine(), out int year);
                if ((!result) || (year < 0) || (year > DateTime.Now.Year))
                    throw new WrongYearException();

                Console.Write("Введите кол-во книг поступающих на склад: ");
                var quantityResult = int.TryParse(Console.ReadLine(), out int quantity);
                if ((!quantityResult) || (quantity < 0))
                    throw new ArgumentException();

                using (var db = new AppContext())
                {
                    var book = new Book { Title = title, Author = author, Year = year, Genre = genre, Quantity = quantity };
                    db.Books.Add(book);
                    db.SaveChanges();
                }
            }
            catch (WrongYearException)
            {
                Console.WriteLine("Некорректный год издания");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Некорректно введено кол-во книг");
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
            catch (WrongYearException)
            {
                Console.WriteLine("Введен некорректный год издания");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Возникло исключение {ex.Message}");
            }
        }

        public void GenreYearBookList()
        {
            try
            {
                using (var db = new AppContext())
                {
                    Console.Write("Введите жанр книги: ");
                    var genre = Console.ReadLine();
                    var findGenre = db.Books.Any(b => b.Genre == genre);
                    if (!findGenre)
                        throw new GenreNotFoundException();

                    Console.Write("Введите начальный год диапазона поиска: ");
                    var resultYear1 = int.TryParse(Console.ReadLine(), out int year1);
                    if ((!resultYear1) || (year1 < 0) || (year1 > DateTime.Now.Year))
                        throw new WrongYearException();

                    Console.Write("Введите конечный год диапазона поиска: ");
                    var resultYear2 = int.TryParse(Console.ReadLine(), out int year2);
                    if ((!resultYear2) || (year2 < 0) || (year2 > DateTime.Now.Year) || (year1 > year2))
                        throw new WrongYearException();

                    var books = db.Books.Where(b => b.Genre == genre && (b.Year >= year1 && b.Year <= year2)).ToList();
                }
            }
            catch(GenreNotFoundException)
            {
                Console.WriteLine("Книг с указанным жанром не найдено");
            }
            catch (WrongYearException)
            {
                Console.WriteLine("Некорректно указан год");
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Возникло исключение: {ex.Message}");
            }
        }

        public void AutorsBooksCount()
        {
            try
            {
                Console.Write("Введите ФИО автора для поиска книг: ");
                var author = Console.ReadLine();
                using (var db = new AppContext())
                {
                    var isAuthor = db.Books.Any(b => b.Author == author);
                    if (!isAuthor)
                        throw new AuthorNotFoundException();

                    var result = db.Books.
                        Where(b => b.Author == author).
                        Select(b => new { Author = b.Author, Title = b.Title, Year = b.Year, Quantity = b.Quantity }).
                        OrderBy(b => b.Title).ToList();
                }
            }
            catch (AuthorNotFoundException)
            {
                Console.WriteLine("Автор с таким ФИО не найден");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Возникло исключение: {ex.Message}");
            }
        }


    }
}
