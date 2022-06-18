using LibraryManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagment.DB
{
    public static class Database
    {
        public static List<Account> Accounts { get; set; }

        public static Dictionary<Book,int> Books { get; set; }

        public static string LibraryName { get; set; } = "IlmHub";

        
        public static Address Address { get; set; } = new Address()
        {
            StreetAddress = "123 Main St",
            City = "New York",
            State = "NY",
            ZipCode = "10001",
            Country = "USA"
        };
        
        static Database()
        {

            Accounts = new List<Account>();
            Account account1 = new Account("99");
            account1.Login = "admin";
            account1.Password = "admin";
            account1.Person = new Person();
            account1.Person.Name = "User1";
            account1.Person.Address = new Address();
            account1.Person.Address.StreetAddress = "StreetOfUser";
            account1.Person.Address.City = "CityOfUser";
            account1.Person.Address.State = "StateOfUser";
            account1.Person.Address.ZipCode = "123123";
            account1.Person.Address.Country = "CountryofUser";
            account1.Person.Email = $"user@gmail.com";
            account1.Person.Phone = $"";
            account1.ReserveWord = "1";
            account1.IsAdmin = true;
            Accounts.Add(account1);
            for (int i = 0; i < 10; i++)
            {
                Account account = new Account(i.ToString());
                account.Login = "user" + i.ToString();
                account.Password = "password" + (i * 100 + i * 10 + i).ToString();
                account.Person = new Person();
                account.Person.Name = "User " + i.ToString();
                account.Person.Address = new Address();
                account.Person.Address.StreetAddress = "StreetOfUser" + i.ToString();
                account.Person.Address.City = "CityOfUser" + i.ToString();
                account.Person.Address.State = "StateOfUser" + i.ToString();
                account.Person.Address.ZipCode = (i * 100 + i * 10 + i).ToString() + (i * 100 + i * 10 + i).ToString();
                account.Person.Address.Country = "CountryofUser" + i.ToString();
                account.Person.Email = $"user{i}@gmail.com";
                account.Person.Phone = $"+9989{i}{i}{i + 1}{i + 2}{i + 3}{i + 4}{i + 5}{i + 6}";
                account.ReserveWord = "user" + i.ToString() + "user";
                Accounts.Add(account);
            }


            Books = new Dictionary<Book, int>();
            for (int i = 0; i < 10; i++)
            {
                Book book = new Book();
                book.Id = Guid.NewGuid().ToString();
                book.Title = "Book " + i.ToString();
                book.Author = "Author " + i.ToString();
                book.BookSubject = BookSubject.BIOGRAPHY;
                book.Year = DateTime.Now;
                book.Format = BookFormat.HARDCOVER;
                Books.Add(book, 10);
            }

        }
    }
}
