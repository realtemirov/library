using LibraryManagment.DB;
using LibraryManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagment.Interfaces
{
    
    public interface IMenu
    {
        
        void ShowMenu();

        void SelectMenu();

        void MyPage();        

        void Exit();

        void SearchBook();

        void ShowBooks();

        void Book();
        
        void WhoTookBook();

        void GetBook(Book book);
        
    }
}
