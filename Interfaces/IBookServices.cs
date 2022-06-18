using LibraryManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagment.Interfaces
{
    public interface IBookServices
    {
        void Add();

        Book Get(string id);
        
        void Remove(string id);

        void Update(string id, Book book);

        void SearchByTitle();

        void SearchByAuthor();

        void SearchByYear();

        void Show(string id);

        void ShowAllBooks();

    }
}
