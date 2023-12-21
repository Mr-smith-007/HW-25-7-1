using System.Data;
using HW_25_7_1.Exceptions;

namespace HW_25_7_1.Repositories
{
    internal class UserRepository
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
    }
}
