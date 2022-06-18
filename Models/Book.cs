using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagment.Models
{
    public class Book
    {

        public string Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public BookSubject BookSubject { get; set; }

        public BookFormat Format { get; set; }

        public DateTime Year { get; set; }

        public override string ToString()
        {
            return $"\n\t\t\t\t#\tTitle: {Title} \n\t\t\t\t#\tAuthor: {Author} \n\t\t\t\t#\tSubject: {BookSubject} \n\t\t\t\t#\tFormat: {Format} \n\t\t\t\t#\tYear: {Year}";
        }

        
    }

    
}
