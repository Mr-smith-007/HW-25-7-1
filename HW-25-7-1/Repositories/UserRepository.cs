using System.Data;
using HW_25_7_1.Exceptions;
using System.ComponentModel.DataAnnotations;
using HW_25_7_1.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace HW_25_7_1.Repositories
{
    public class UserRepository
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
                    var user = db.Users.Where(user => user.Id == id).FirstOrDefault();
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
                    var users = db.Users.ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Возникло исключение {ex.Message}");
            }
        }

        public void AddUser()
        {
            try
            {
                Console.Write("Введите имя нового пользователя: ");
                var name = Console.ReadLine();

                Console.Write("Введите Email нового пользователя: ");
                var email = Console.ReadLine();

                if (!new EmailAddressAttribute().IsValid(email))
                    throw new WrongEmailException();


                using (var db = new AppContext())
                {
                    var user = new User { Name = name, Email = email };
                    db.Users.Add(user);
                    db.SaveChanges();
                }
            }
            catch (WrongEmailException)
            {
                Console.WriteLine("Некорректный Email");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Возникло исключение {ex.Message}");
            }
        }

        public void DeleteUserById()
        {
            Console.Write($"Введите Id пользователя для удаления");

            try
            {
                bool result = int.TryParse(Console.ReadLine(), out var id);
                if (!result)
                    throw new WrongIdException();

                using (var db = new AppContext())
                {
                    var user = db.Users.Where(user => user.Id == id).FirstOrDefault();
                    if (user == null)
                        throw new UserNotFoundException();
                    db.Users.Remove(user);
                    db.SaveChanges();
                }
            }
            catch (WrongIdException)
            {
                Console.WriteLine("Некорректный Id");
            }
            catch (UserNotFoundException)
            {
                Console.WriteLine("Пользователь с такими данными не найден");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Возникло исключение {ex.Message}");
            }
        }

        public void DeleteUserByEmail()
        {
            Console.Write($"Введите Email пользователя для удаления");

            try
            {
                var email = Console.ReadLine();
                if (!new EmailAddressAttribute().IsValid(email))
                    throw new WrongEmailException();

                using (var db = new AppContext())
                {
                    var user = db.Users.Where(user => user.Email == email).FirstOrDefault();
                    if (user == null)
                        throw new UserNotFoundException();
                    db.Users.Remove(user);
                    db.SaveChanges();
                }
            }
            catch (WrongEmailException)
            {
                Console.WriteLine("Некорректный Email");
            }
            catch (UserNotFoundException)
            {
                Console.WriteLine("Пользователь с такими данными не найден");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Возникло исключение {ex.Message}");
            }
        }

        public void UpdateUserNameById()
        {
            Console.Write("Введите Id пользователя для обновления имени: ");

            try
            {
                bool result = int.TryParse(Console.ReadLine(), out var id);
                if (!result)
                    throw new WrongIdException();

                using (var db = new AppContext())
                {
                    var user = db.Users.Where(user => user.Id == id).FirstOrDefault();
                    if (user == null)
                        throw new UserNotFoundException();

                    Console.Write("Введите новое имя пользователя: ");
                    string newName = Console.ReadLine();

                    user.Name = newName;
                    db.SaveChanges();
                }
            }
            catch (WrongIdException)
            {
                Console.WriteLine("Некорректный Id");
            }
            catch (UserNotFoundException)
            {
                Console.WriteLine("Пользователь с такими данными не найден");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Возникло исключение {ex.Message}");
            }
        }

        public void UserTakeBook()
        {
            try
            {
                Console.Write("Введите Id пользователя, который хочет взять книгу: ");
                bool resultUserId = int.TryParse(Console.ReadLine(), out int userId);
                if (!resultUserId)
                    throw new WrongIdException();

                Console.Write("Введите Id книги, которую хочет взять пользователь");
                bool resultBookId = int.TryParse(Console.ReadLine(), out int bookId);
                if (!resultBookId)
                    throw new WrongIdException();

                using (var db = new AppContext())
                {
                    var user = db.Users.Include(u => u.Books).Where(user => user.Id == userId).FirstOrDefault();
                    if (user == null)
                        throw new UserNotFoundException();

                    var book = db.Books.Where(book => book.Id == bookId).FirstOrDefault();
                    if (book == null)
                        throw new BookNotFoundException();

                    user.Books.Add(book);
                    book.Quantity--;
                    db.SaveChanges();
                }
            }
            catch (WrongIdException)
            {
                Console.WriteLine("Некорректно введен Id");
            }
            catch (UserNotFoundException)
            {
                Console.WriteLine("Пользователь c указанным Id не найден");
            }
            catch (BookNotFoundException)
            {
                Console.WriteLine("Книга с указанным Id не найдена");
            }

        }

        public void UserReturnBook()
        {
            try
            {
                Console.Write("Введите Id пользователя, который хочет вернуть книгу: ");
                bool resultUserId = int.TryParse(Console.ReadLine(), out int userId);
                if (!resultUserId)
                    throw new WrongIdException();

                Console.Write("Введите Id книги, которую хочет вернуть пользователь: ");
                bool resultBookId = int.TryParse(Console.ReadLine(), out int bookId);
                if (!resultBookId)
                    throw new WrongIdException();

                using (var db = new AppContext())
                {
                    var user = db.Users.Include(u => u.Books).Where(user => user.Id == userId).FirstOrDefault();
                    if (user == null)
                        throw new UserNotFoundException();

                    var book = db.Books.Where(book => book.Id == bookId).FirstOrDefault();
                    if (book == null)
                        throw new BookNotFoundException();

                    if (!user.Books.Contains(book))
                        Console.WriteLine("Данному пользователю не выдавалась эта книга");

                    user.Books.Remove(book);
                    book.Quantity++;
                    db.SaveChanges();
                }
            }
            catch (WrongIdException)
            {
                Console.WriteLine("Некорректно введен Id");
            }
            catch (UserNotFoundException)
            {
                Console.WriteLine("Пользователь c указанным Id не найден");
            }
            catch (BookNotFoundException)
            {
                Console.WriteLine("Книга с указанным Id не найдена");
            }

        }

        public bool UserHasBook()
        {
            try
            {
                Console.Write("Введите Id пользователя: ");
                bool resultUserId = int.TryParse(Console.ReadLine(), out int userId);
                if (!resultUserId)
                    throw new WrongIdException();

                Console.Write("Введите Id книги: ");
                bool resultBookId = int.TryParse(Console.ReadLine(), out int bookId);
                if (!resultBookId)
                    throw new WrongIdException();

                using (var db = new AppContext())
                {
                    var book = db.Books.Where(b => b.Id == bookId).FirstOrDefault();
                    if (book == null)
                        throw new BookNotFoundException();
                    var user = db.Users.Include(u => u.Books).Where(u => u.Id == userId).FirstOrDefault();
                    if (user == null)
                        throw new UserNotFoundException();
                    var result = db.Users.Include(us => us.Books).Where(us => us.Id == userId).Any(u => u.Books.Contains(book));
                    return result;
                }
            }
            catch (WrongIdException)
            {
                Console.WriteLine("Некорректно введен Id");
                return false;
            }
            catch (BookNotFoundException)
            {
                Console.WriteLine("Книга с указанным Id не найдена");
                return false;
            }
            catch (UserNotFoundException)
            {
                Console.WriteLine("Пользователь указанным Id не найден");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Возникло исключение: {ex.Message}");
                return false;
            }
        }

        public int UserBooksCount()
        {
            try
            {
                Console.Write("Введите Id пользователя: ");
                bool resultUserId = int.TryParse(Console.ReadLine(), out int userId);
                if (!resultUserId)
                    throw new WrongIdException();

                using (var db = new AppContext())
                {
                    int result = db.Users.Include(us => us.Books).Where(u => u.Id == userId).Select(u => u.Books).Count();
                    return result;
                }
            }
            catch (WrongIdException)
            {
                Console.WriteLine("Некорректно введен Id");
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Возникло исключение: {ex.Message}");
                return 0;
            }
        }
    }
}
