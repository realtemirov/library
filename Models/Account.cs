using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagment.Models
{
    public class Account
    {
        public string Id { get; init; }

        
        public Account(string id)
        {
            Id = id;
            Books = new List<Book>();
            IsAdmin = false;
        }

        public bool IsAdmin { get; set; } = false;

        public string Login { get; set; }

        public string Password { get; set; }

        public Person Person { get; set; }

        public ICollection<Book> Books { get; set; }

        public string ReserveWord { get; set; }


        //public AccountStatus AccountStatus { get; set; }

        public override string ToString()
        {
            return $"\t\t\t\t#\t\n\t\t\t\t#\tLogin: {Login} \n\t\t\t\t#\tPassword: {Password} \n\t\t\t\t#\tID: {Id} {Person.ToString()} \n\t\t\t\t#\tReserveWord: {ReserveWord}";
        }

        public bool ResetPassword(string word)
        {
            
            return word == ReserveWord;
        }

        public bool ChangeDetails(string password)
        {
            bool result = false;
            if(password == this.Password)
            {
                result = true;

                string Menu = "\n\t\t\t\t#################################################" +
                              "\n\t\t\t\t#\t\tChange Menu            " +
                              "\n\t\t\t\t#\tSelect your detail:                    " +
                              "\n\t\t\t\t#\t1. Login                               " +
                              "\n\t\t\t\t#\t2. Name                                " +
                              "\n\t\t\t\t#\t3. Address                             " +
                              "\n\t\t\t\t#\t4. Email                               " +
                              "\n\t\t\t\t#\t5. Phone                               " +
                              "\n\t\t\t\t#\t" +
                              "\n\t\t\t\t################################################\n";
                Console.WriteLine(Menu);
                switch (Select())
                {
                    case 1:
                        {
                            Login = Change(Login);
                            break;
                        }
                    case 2:
                        {
                            Person.Name = Change(Person.Name);
                            break;
                        }
                    case 3:
                        {
                            string address = "\t\t\t\t################################################" +
                             "\n\t\t\t\t#\t\tChange Address                 " +
                             "\n\t\t\t\t#\tSelect your detail:                             " +
                             "\n\t\t\t\t#\t1. Street                                       " +
                             "\n\t\t\t\t#\t2. City                                         " +
                             "\n\t\t\t\t#\t3. State                                        " +
                             "\n\t\t\t\t#\t4. ZipCode                                      " +
                             "\n\t\t\t\t#\t5. Country                                      " +
                             "\n\t\t\t\t#\t                                                       " +
                             "\n\t\t\t\t################################################\n";
                            Console.WriteLine(address);
                            
                            switch (Select())
                            {
                                case 1:
                                    {
                                        Person.Address.StreetAddress = (Person.Address.StreetAddress);
                                        break;
                                    }
                                case 2:
                                    {
                                        Person.Address.City = Change(Person.Address.City);
                                        break;
                                    }
                                case 3:
                                    {
                                        Person.Address.State = Change(Person.Address.State);
                                        break;
                                    }
                                case 4:
                                    {
                                        Person.Address.ZipCode = Change(Person.Address.ZipCode);
                                        break;
                                    }

                                case 5:
                                    {
                                        Person.Address.Country = Change(Person.Address.Country);
                                        break;
                                    }
                                default:
                                    SomethingError();
                                    break;
                            }

                            break;
                            
                        }
                    case 4:
                        {
                            Person.Email = Change(Person.Email);
                            break;
                        }

                    case 5:
                        {
                            Person.Phone = Change(Person.Phone);
                            break;
                        }
                    default:
                        SomethingError();
                        break;
                }
            }

            return result;

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

        public void SomethingError()
        {
            Console.Write("\t\t\t\t#\t");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Something error !");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n");
            Thread.Sleep(100);
        }

        public string Change(string detail)
        {
            
            Console.WriteLine($"\t\t\t\t#\tOld: {detail} ");
            Console.Write($"\t\t\t\t#\tEnter new: ");
            string newWord = Console.ReadLine();                                      
            return newWord;
        }
    }

    
}