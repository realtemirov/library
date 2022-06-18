using LibraryManagment.DB;
using LibraryManagment.Services;
using System;

namespace LibraryManagment
{
    public class Program
    {
        public static string ID { get; set; }
        public static void Main(string[] args)
        {
            #region Login
        
            Show();
            LoginServices sign = new LoginServices();
        menu:
            switch (Select())
            {
                case 1:
                    {
                        sign.SingUp();
                        Show();
                        goto menu;
                    }
                case 2:
                    {
                        int k = 0;
                    s:
                        if (!sign.SignIn())
                        {
                            Message("Login or password error. Please try again");

                            goto s;
                        }
                        else
                        {
                            Console.Write("\t\t\t\t#\t");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("You are human !");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("\n");
                        }
                        break;
                    }
                default:
                    Message("Something error !");
                    goto menu;
                    break;
            }
            
            #endregion       
        }

        public static void Message(string message)
        {
            Console.Write("\t\t\t\t==\t");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n");
            Thread.Sleep(100);
        }

        public static void Show()
        {
            string t = "\n\t\t\t\t==";
            Console.WriteLine($"{t}================================================" +
                              $"{t}" +
                              $"{t}\t\tWelcome {Database.LibraryName}" +
                              $"{t}\t" +
                              $"{t}\t1. Sign Up" +
                              $"{t}\t2. Sign In" +
                              $"{t}\t" +
                              $"{t}================================================" +
                              $"\n" +
                              $"{t}================================================" +
                              $"{ t}\t");
        }
    
        public static int Select()
        {
            
            x:
                Console.Write("\t\t\t\t==\tSelect: ");
                int a = 0;
            
            try
            {
                a = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Message("Something error !");
                goto x;
            }
            return a;
        }
    }
}