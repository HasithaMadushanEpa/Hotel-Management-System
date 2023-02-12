using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Westmister_Hotel_Management_System
{
    internal interface IHotelCustomer
    {
        void ListAvailableRooms(Booking wantedBooking, Size roomSize);

        void ListAvailableRooms(Booking wantedBooking, Size roomSize, int maxPrice);

        bool checkRoom(Room room, Booking wantedBooking);

        bool BookRoom(int roomNumber, Booking wantedBooking);
    }
}
