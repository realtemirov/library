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
    public class BookServices : IBookServices
    {
        public void Add()
        {
            Book book = new Book();
            book.Id = Guid.NewGuid().ToString();
            Console.WriteLine("\t\t\t\t#\tEnter Book title: ");
            book.Title = Console.ReadLine();
            Console.WriteLine("\t\t\t\t#\tEnter Book author: ");
            book.Author = Console.ReadLine();
            book.Year = DateTime.Now;
            book.BookSubject = BookSubject.CHILDREN;
            book.Format = BookFormat.AUDIO_BOOK;
            Console.WriteLine("\t\t\t\t#\tEnter count of book: ");
            int count = int.Parse(Console.ReadLine());

            Database.Books.Add(book, count);
        }

        public Book Get(string id)
        {
            return Database.Books.Keys.FirstOrDefault(x => x.Id == id);
        }
    
        public void Remove(string id)
        {
            Database.Books.Remove(Database.Books.Keys.FirstOrDefault(x => x.Equals(id)));
        }

        public void SearchByAuthor()
        {
            Book book;
            Console.Write("\t\t\t\t#\tEnter Book Author: ");
            string title = Console.ReadLine();
            book = Database.Books.Keys.FirstOrDefault(x => x.Author == title);

            if (book is not null)
            {
                Console.WriteLine(book.ToString());
                Console.WriteLine("\t\t\t\t#\tCount: " + Database.Books[book]);
                Console.Write("\t\t\t\t#\tAre you get this book? Y/N: ");
                string answer = Console.ReadLine();
                if (answer == "Y")
                {
                    Database.Accounts.FirstOrDefault(x => x.Id == Program.ID).Books.Add(book);
                    Database.Books[book]--;
                }
                Done();
                
            }
            else
            {
                Console.WriteLine("Not found");
            }
        }

        public void Done()
        {
            Console.Write("\t\t\t\t#\t");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Done !");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n");
        }

        public void SearchByTitle()
        {
            
            Console.Write("\t\t\t\t#\tEnter Book title: ");
            string title = Console.ReadLine();
            var book = Database.Books.Keys.FirstOrDefault(x => x.Title == title);

            if(book is not null)
            {
                Console.WriteLine(book.ToString());
                Console.WriteLine("\t\t\t\t#\tCount: " + Database.Books[book]);
                Console.Write("\t\t\t\t#\tAre you get this book? Y/N: ");
                string answer = Console.ReadLine();
                if (answer == "Y")
                {
                    Database.Accounts.FirstOrDefault(x => x.Id == Program.ID).Books.Add(book);
                    Database.Books[book]--;
                }
                Done();
                
            }
            else
            {
                Console.WriteLine("\t\t\t\t#\tNot found");
            }
            
        }

        public void SearchByYear()
        {
            Console.Write("\t\t\t\t#\tEnter Book Year: ");
            string title = Console.ReadLine();
            var book = Database.Books.Keys.FirstOrDefault(x => x.Year.Year == int.Parse(title));

            if (book is not null)
            {
                Console.WriteLine(book.ToString());
                Console.WriteLine("\t\t\t\t#\tCount: " + Database.Books[book]);
                Console.Write("\t\t\t\t#\tAre you get this book? Y/N: ");
                string answer = Console.ReadLine();
                if (answer == "Y")
                {
                    Database.Accounts.FirstOrDefault(x => x.Id == Program.ID).Books.Add(book);
                    Database.Books[book]--;
                }
                Done();
            }
            else
            {
                Console.WriteLine("Not found");
            }
        }

        public void Show(string id)
        {
            Console.WriteLine(Database.Books.Keys.FirstOrDefault(x => x.Id == id).ToString());
        }

        public void ShowAllBooks()
        {
            foreach (var item in Database.Books)
            {
                Console.WriteLine(item.Key.ToString());
                Console.WriteLine("\t\t\t\t#\tCount: " + item.Value);
                Console.WriteLine("\t\t\t\t#\t----------------------");;
            }
        }

        public void Update(string id, Book book)
        {
            Database.Books.Keys.Where(x => x.Id == id).FirstOrDefault().Author = book.Author;
            Database.Books.Keys.Where(x => x.Id == id).FirstOrDefault().Title = book.Title;
            Database.Books.Keys.Where(x => x.Id == id).FirstOrDefault().Year = book.Year;
            Database.Books.Keys.Where(x => x.Id == id).FirstOrDefault().BookSubject = book.BookSubject;
            Database.Books.Keys.Where(x => x.Id == id).FirstOrDefault().Format = book.Format;
        }
    }
}
