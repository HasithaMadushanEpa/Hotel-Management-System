using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Westmister_Hotel_Management_System
{
    public interface IOverlappable
    {
        bool Validate(Booking book);
        bool Overlaps(Booking other);

        bool BookingRooms(Booking booking, bool timeOverlap, bool time, bool CheckRoom);

    }
}
