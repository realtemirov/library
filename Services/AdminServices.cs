using LibraryManagment.DB;
using LibraryManagment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagment.Services
{
    public class AdminServices : IAdmin
    {
        
        public void ShowUsers()
        {
            MyPageServices myPage = new MyPageServices();
            foreach (var item in Database.Accounts.Where(x => x.IsAdmin == false))
            {
                myPage.Show(item);
            }
        }
    }
}
