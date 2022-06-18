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
    public class MenuServices : IMenu
    {
        BookServices bookServices = new BookServices();
        
        public void Book()
        {
            throw new NotImplementedException();
        }

        public void Exit()
        {
            Console.Clear();
            Console.WriteLine("Bye!");
            Thread.Sleep(500);
            Console.WriteLine("Bye!");
            Thread.Sleep(500);
            Console.WriteLine("Bye!");
            Thread.Sleep(1000);
            Console.Clear();
            Program.Main(args: new string[] { });
        }
        
        public void GetBook(Book book)
        {
            Database.Accounts.FirstOrDefault(x => x.Id == Program.ID).Books.Add(book);
            Database.Books[Database.Books.Keys.FirstOrDefault(x => x.Title == book.Title)]--;
        }

        public void MyPage()
        {
            MyPageServices myPage = new MyPageServices();
            myPage.Menu();
            ShowMenu();
        }

        public void SearchBook()
        {
            Console.WriteLine("\t\t\t\t#################################################");
            Console.WriteLine("\t\t\t\t#                                               ");
            Console.WriteLine("\t\t\t\t#                     Search                    ");
            Console.WriteLine("\t\t\t\t#                                               ");
            Console.WriteLine("\t\t\t\t#      1. Title");
            Console.WriteLine("\t\t\t\t#      2. Author");
            Console.WriteLine("\t\t\t\t#      3. Year");
            Console.WriteLine("\t\t\t\t#                                               ");
            Console.WriteLine("\t\t\t\t#                                               ");
            Console.WriteLine("\t\t\t\t#################################################");
            Console.WriteLine("\t\t\t\t#                                               ");
        x:
            int a = 0;
            Console.Write("\t\t\t\t#\tSelect Type:  ");
            try
            {
                a = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("\t\t\t\t#\tSomething error...");
                goto x;
            }

            
            switch (a)
            {
                case 1:
                    {
                        bookServices.SearchByTitle();
                        break;
                    }
                case 2:
                    {
                        bookServices.SearchByAuthor();
                        break;
                    }
                case 3:
                    {
                        bookServices.SearchByYear();
                        break;
                    }
                default:
                    Console.WriteLine("\t\t\t\t#\tSomething error...");
                    break;
            }
            ShowMenu();
        }

        public void SelectMenu()
        {
        
            Console.Write("\t\t\t\t#\tSelect Menu:  ");
            switch (Select())
            {
                case 1:
                    {
                        MyPage();
                        break;
                    }
                case 2:
                    {
                        SearchBook();
                        break;
                    }
                case 3:
                    {
                        ShowBooks();
                        break;
                    }
                case 4:
                    {
                        if(Database.Accounts.FirstOrDefault(x => x.Id == Program.ID).IsAdmin == true)
                        {
                            AdminServices admin = new AdminServices();
                            admin.ShowUsers();
                            ShowMenu();
                        }
                        break;

                    }
                case 10:
                    {
                        Exit();
                        break;
                    }
                default: ShowMenu();
                    break;

            }
            ShowMenu();
        }
        
        public void ShowBooks()
        {
            bookServices.ShowAllBooks();
            ShowMenu();
        }

        public void ShowMenu()
        {
            Console.WriteLine("\t\t\t\t#################################################");
            Console.WriteLine("\t\t\t\t#                                               ");
            Console.WriteLine("\t\t\t\t#                     Welcome                   ");
            Console.WriteLine("\t\t\t\t#                                               ");
            Console.WriteLine("\t\t\t\t#      1. My page                               ");
            Console.WriteLine("\t\t\t\t#      2. Search                                ");
            Console.WriteLine("\t\t\t\t#      3. Books                                 ");
            if (Database.Accounts.FirstOrDefault(x => x.Id == Program.ID).IsAdmin == true)
            {
                Console.WriteLine("\t\t\t\t#      4. Users                                 ");
            }
            Console.WriteLine("\t\t\t\t#      ....                                       ");
            Console.WriteLine("\t\t\t\t#      10. Exit                                  ");
            Console.WriteLine("\t\t\t\t#                                               ");
            Console.WriteLine("\t\t\t\t#                                               ");
            Console.WriteLine("\t\t\t\t#################################################");
            Console.WriteLine("\t\t\t\t#                                               ");
            SelectMenu();
        }

        public void WhoTookBook()
        {
            throw new NotImplementedException();
        }

        public int Select()
        {
        x:
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
