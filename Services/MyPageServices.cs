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
    public class MyPageServices : IMyPage
    {
        private Account _myPage = Database.Accounts.FirstOrDefault(x => x.Id == Program.ID);
        
        public void Done()
        {
            Console.Write("\t\t\t\t#\t");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Done !");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n");
        }

        public void ChangeDetails()
        {
            Console.Write("\t\t\t\t#\tEnter your password: ");
            string password = Console.ReadLine();
            if(_myPage.ChangeDetails(password))
            {
                Done();
            }
            else
            {
                SomethingError();
            }
            Menu();
        }

        public void DeleteAccount()
        {
            Console.Write("\t\t\t\t#\tEnter yout reserve word: ");
            string reserveWord = Console.ReadLine();
            if (_myPage.ResetPassword(reserveWord))
            {
                if(Database.Accounts.Remove(_myPage))
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Console.WriteLine("\t\t\t\t#\tBye");        
                    }
                };
                Program.Main(args: new string[] { });
                
            }
            else
            {
                SomethingError();
            }
            Menu();
        }

        public void Menu()
        {
            Console.WriteLine("\t\t\t\t#                                               ");
            Console.WriteLine("\t\t\t\t#################################################");
            Console.WriteLine("\t\t\t\t#                                               ");
            Console.WriteLine("\t\t\t\t#                     My Page                   ");
            Console.WriteLine("\t\t\t\t#                                               ");
            Console.WriteLine("\t\t\t\t#      1. My details                            ");
            Console.WriteLine("\t\t\t\t#      2. Change details                        ");
            Console.WriteLine("\t\t\t\t#      3. My Books                              ");
            Console.WriteLine("\t\t\t\t#      4. Reset Password                        ");
            Console.WriteLine("\t\t\t\t#      5. Delete Account                        ");
            Console.WriteLine("\t\t\t\t#      ....                                     ");
            Console.WriteLine("\t\t\t\t#      10. Exit                                 ");
            Console.WriteLine("\t\t\t\t#                                               ");
            Console.WriteLine("\t\t\t\t#                                               ");
            Console.WriteLine("\t\t\t\t#################################################");
            Console.WriteLine("\t\t\t\t# ");
            switch (Select())
            {
                case 1:
                    {
                        Show(_myPage);
                        Menu();
                        break;
                    }
                case 2:
                    {
                        ChangeDetails();
                        break;
                    }
                case 3:
                    {
                        MyBooks();
                        break;
                    }
                case 4:
                    {
                        ResetPassword();
                        break;
                    }
                case 5:
                    {
                        DeleteAccount();
                        break;
                    }
                case 10:
                    {
                        Back();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("\t\t\t\t#\tSomething error !");
                        Menu();
                    }
                    break;
            }
        }

        public void MyBooks()
        {
            string t = "\t\t\t\t#\t";
            Console.WriteLine(t + "Count of Books: " + _myPage.Books.Count);
            if(_myPage.Books.Count != 0)
            {
                ShowBook(_myPage.Books);
            }
            Menu();
        }

        public void ResetPassword()
        {
            Console.Write("\t\t\t\t#\tEnter yout reserve word: ");
            string reserveWord = Console.ReadLine();
            if(_myPage.ResetPassword(reserveWord))
            {
                Console.Write("\t\t\t\t#\tEnter new password: ");
                string newPassword = Console.ReadLine();
                _myPage.Password = newPassword;
                Database.Accounts.FirstOrDefault(x => x.Id == Program.ID).Password = newPassword;
                Done();
            }
            else
            {
                SomethingError();
            }
            Menu();
        }

        public void Show(Account account)
        {
            Console.WriteLine(account.ToString());
        }

        public void ShowBook(ICollection<Book> books)
        {
            foreach (var item in books)
            {
                Console.WriteLine(item.ToString());
                Console.WriteLine("\t\t\t\t#\t_______________________________");
            }
            Menu();
        }
        
        public int Select()
        {

        x:
            Console.Write("\t\t\t\t#\tSelect: ");
            int a = 0;

            try
            {
                a = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                SomethingError();
                goto x;
            }
            return a;
        }

        public void Back()
        {
            MenuServices menu = new MenuServices();
            menu.ShowMenu();
        }

        public void SomethingError()
        {
            Console.Write("\t\t\t\t#\t");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Something error !");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n");
            Thread.Sleep(100);
        }
    }
}
