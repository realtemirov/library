using LibraryManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagment.Interfaces
{
    public interface IMyPage
    {
        void SomethingError();

        void Back();

        void Menu();
        
        void Show(Account account);

        void MyBooks();

        void ChangeDetails();

        void ResetPassword();

        void DeleteAccount();

        void ShowBook(ICollection<Book> books);
    }
}
