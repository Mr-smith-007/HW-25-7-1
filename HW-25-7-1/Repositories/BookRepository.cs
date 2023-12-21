using HW_25_7_1.Exceptions;
using System;
using System.Collections.Generic;
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
    }
}
