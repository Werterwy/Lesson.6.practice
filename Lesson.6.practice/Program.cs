using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson._6.practice
{
    class Program
    {
        static void Main(string[] args)
        {
            Bankomat.Bank bank = new Bankomat.Bank();
            Bankomat.Client currentClient = null;

            while (true)
            {
                Console.WriteLine("Добро пожаловать в банк!");
                Console.WriteLine("1. Открыть счет");
                Console.WriteLine("2. Войти в существующий счет");
                Console.WriteLine("3. Выйти из программы");

                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Console.Write("Введите пароль: ");
                    string password = Console.ReadLine();

                    Bankomat.Client newClient = bank.OpenAccount(password);

                    if (newClient != null)
                    {
                        Console.WriteLine($"Ваш идентификатор клиента: {newClient.ClientId}");
                        currentClient = newClient;
                        MainMenu(currentClient);
                    }
                    else
                    {
                        Console.WriteLine("Извините, банк переполнен.");
                    }
                }
                else if (choice == 2)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Console.Write("Введите идентификатор клиента: ");
                        int clientId = int.Parse(Console.ReadLine());
                        Console.Write("Введите пароль: ");
                        string password = Console.ReadLine();

                        Bankomat.Client existingClient = bank.Authenticate(clientId, password);

                        if (existingClient != null)
                        {
                            currentClient = existingClient;
                            MainMenu(currentClient);
                            i = 3;
                        }
                        else
                        {
                            Console.WriteLine("Неверный идентификатор клиента или пароль.");
                        }
                    }
                }
                else if (choice == 3)
                {
                    return; // Завершение программы
                }
                else
                {
                    Console.WriteLine("Неверный выбор.");
                }
            }
        }

        static void MainMenu(Bankomat.Client client)
        {
            while (true)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Вывод баланса");
                Console.WriteLine("2. Пополнение счета");
                Console.WriteLine("3. Снять деньги");
                Console.WriteLine("4. Выйти");
                Console.WriteLine("5. Вернуться в главное меню");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine($"Баланс: {client.Account.Balance}");
                        Console.WriteLine("1. Вернуться в меню");
                        Console.WriteLine("2. Выйти");
                        int subChoice = int.Parse(Console.ReadLine());
                        if (subChoice == 1)
                        {
                            continue; // Возвращаемся в меню
                        }
                        else if (subChoice == 2)
                        {
                            return; // Возвращаемся в главное меню
                        }
                        else
                        {
                            Console.WriteLine("Неверный выбор.");
                        }
                        break;
                    case 2:
                        Console.Write("Введите сумму для пополнения: ");
                        double depositAmount = double.Parse(Console.ReadLine());
                        client.Account.Deposit(depositAmount);
                        Console.WriteLine($"Счет успешно пополнен. Новый баланс: {client.Account.Balance}");
                        Console.WriteLine("1. Вернуться в меню");
                        Console.WriteLine("2. Выйти");
                        int sub = int.Parse(Console.ReadLine());
                        if (sub == 1)
                        {
                            continue; // Возвращаемся в меню
                        }
                        else if (sub == 2)
                        {
                            return; // Возвращаемся в главное меню
                        }
                        else
                        {
                            Console.WriteLine("Неверный выбор.");
                        }
                        break;
                    case 3:
                        Console.Write("Введите сумму для снятия: ");
                        double withdrawAmount = double.Parse(Console.ReadLine());

                        if (withdrawAmount > client.Account.Balance)
                        {
                            Console.WriteLine("Недостаточно средств на счете.");
                        }
                        else
                        {
                            client.Account.Withdraw(withdrawAmount);
                            Console.WriteLine($"Сумма успешно снята. Новый баланс: {client.Account.Balance}");
                        }
                        break;
                    case 4:
                        return;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Неверный выбор.");
                        break;
                }
            }
        }
    }
}
