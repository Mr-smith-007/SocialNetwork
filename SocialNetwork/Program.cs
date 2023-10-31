using SocialNetwork.BLL.Servises;
using SocialNetwork.BLL.Models;
using System;


namespace SocialNetwork
{
    class Program
    {
        public static UserService userServise = new UserService();
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в социальную сеть.");

            while (true)
            {
                Console.Write("Для регистрации введите имя пользователя:");
                string firstName = Console.ReadLine();

                Console.Write("Фамилия:");
                string lastName = Console.ReadLine();

                Console.Write("Пароль:");
                string password = Console.ReadLine();

                Console.Write("Адрес Email:");
                string email = Console.ReadLine();

                var userRegistrationData = new UserRegistrationData()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Password = password,
                    Email = email
                };

                try
                {
                    userServise.Register(userRegistrationData);
                    Console.WriteLine("Регистрация прошла успешно");
                }
                catch (ArgumentNullException)
                {
                    Console.Write("Введите корректное значение");
                }
                catch (Exception)
                {
                    Console.Write("Произошла ошибка при регистрации");
                }

                Console.ReadLine();
            }
        }
    }
}