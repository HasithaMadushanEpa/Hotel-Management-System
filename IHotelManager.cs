using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Westmister_Hotel_Management_System
{
    internal interface IHotelManager
    {
        bool addRoom(Room room);

        bool DeleteRoom(int roomNumber);

        void ListRooms();

        void listRoomsOrderedByPrice();

        void generateReport(string fileName);

    }
}
