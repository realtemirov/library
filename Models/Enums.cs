using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagment.Models
{
    public enum BookFormat
    {
        HARDCOVER,
        PAPERBACK,
        AUDIO_BOOK,
        EBOOK,
        NEWSPAPER,
        MAGAZINE,
        JOURNAL
    }

    public enum BookSubject
    {
        ART,
        BIOGRAPHY,
        BUSINESS,
        CHILDREN,
        COMPUTER,
        COOKBOOK,
        FANTASY,
        FICTION,
        HISTORY,
        HORROR,
        HUMOR
    }

    public enum BookStatus
    {
        AVAILABLE,
        RESERVED,
        LOANED,
        LOST
    }

    public enum ReservationStatus
    {
        WAITING,
        PENDING,
        CANCELED,
        NONE
    }

    public enum AccountStatus
    {
        ACTIVE,
        CLOSED,
        CANCELED,
        BLACKLISTED,
        NONE
    }

}
