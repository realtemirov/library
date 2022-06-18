using LibraryManagment.DB;
using LibraryManagment.Interfaces;
using LibraryManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagment.Services
{
    public class LoginServices : ILogin
    {
        public bool SignIn()
        {
            bool result = false;
            
            Console.WriteLine("\t\t\t\t==");
            Console.Write("\t\t\t\t==\tEnter your login or email: ");
            string login = Console.ReadLine();
            Console.Write("\t\t\t\t==\tEnter your password: ");

            StringBuilder pas = new StringBuilder();

            ConsoleKey key;

            do
            {
                var keyInfo = Console.ReadKey(intercept: true);

                key = keyInfo.Key;

                if(key == ConsoleKey.Backspace && pas.Length > 0)
                {
                    Console.Write("\b \b");

                }
                else if(!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    pas.Append(keyInfo.KeyChar);
                }

            } while (key != ConsoleKey.Enter);
            Console.WriteLine();
            int n = 0, a = 0, b = 0; char s = '+';
            do
            {
                SomethingError("Are you human?");

                Random rand = new Random();
                a = rand.Next(1, 10);
                b = rand.Next(1, 10);
                char[] operat = { '+', '-', '*' };
                s = operat[rand.Next(0, 3)];
                Console.WriteLine($"\t\t\t\t==\t{a}{s}{b}=?");
                Console.Write("\t\t\t\t==\tEnter your answer: ");
                string answer = Console.ReadLine();
                
                int.TryParse(answer, out n);

            } while (n != Calc(a,b,s));

            
            Done("You are human !");
            for (int i = 0; i < 3; i++)
            {
                Done("Loggin...");
                Thread.Sleep(100);
            }

            string password = pas.ToString();
            for (int i = 0; i < Database.Accounts.Count; i++)
            {
                if (Database.Accounts[i].Password == password && (Database.Accounts[i].Login == login || Database.Accounts[i].Person.Email == login))
                {
                    Console.WriteLine();
                    Console.WriteLine("\t\t\t\t\t\tWelcome, {0}", Database.Accounts[i].Person.Name);
                    
                    Program.ID = Database.Accounts[i].Id;
                    
                    MenuServices menu = new MenuServices();
                    menu.ShowMenu();
                    return true;
                }
            }
            return result;
        }

        public void Done(string text)
        {
            Console.Write("\t\t\t\t==\t");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n");
        }

        public int Calc(int a, int b, char c)
        {
            int res = 0;
            switch (c)
            {
                case '+':
                    {
                        res = a + b;
                        break;
                    }
                case '-':
                    {
                        res = a - b;
                        break;
                    }
                case '*':
                    {
                        res = a * b;
                        break;
                    }
                default:
                    break;
            }
            return res;
        }

        public  void SomethingError(string message)
        {
            Console.Write("\t\t\t\t==\t");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n");
            Thread.Sleep(100);
        }

        public void SingUp()
        {
            Console.Write("\t\t\t\t#\tEnter your login: ");
            string login = Console.ReadLine();
            Console.Write("\t\t\t\t#\tEnter your name: ");
            string name = Console.ReadLine();
            Console.Write("\t\t\t\t#\tEnter your email: ");
            string email = Console.ReadLine();
            Console.Write("\t\t\t\t#\tEnter your phone: ");
            string phone = Console.ReadLine();
            Console.Write("\t\t\t\t#\tEnter your street address: ");
            string streetAddress = Console.ReadLine();
            Console.Write("\t\t\t\t#\tEnter your city: ");
            string city = Console.ReadLine();
            Console.Write("\t\t\t\t#\tEnter your state: ");
            string state = Console.ReadLine();
            Console.Write("\t\t\t\t#\tEnter your zip code: ");
            string zipCode = Console.ReadLine();
            Console.Write("\t\t\t\t#\tEnter your country: ");
            string country = Console.ReadLine();
            Console.Write("\t\t\t\t#\tEnter your password: ");
            string password = Console.ReadLine();
            Console.Write("\t\t\t\t#\tEnter your reserve word: ");
            string reserveWord = Console.ReadLine();
            Person person = new Person()
            {
                Name = name,
                Address = new Address()
                {
                    StreetAddress = streetAddress,
                    City = city,
                    State = state,
                    ZipCode = zipCode,
                    Country = country
                },
                Email = email,
                Phone = phone
            };
            Account account = new Account(DateTime.Now.Second.ToString())
            {
                
                Login = login,
                Password = password,
                Person = person,
                ReserveWord = reserveWord
            };
            Database.Accounts.Add(account);
            Program.ID = account.Id;

        }
    }
}