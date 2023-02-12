using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Westmister_Hotel_Management_System
{
    public class WestminsterHotel : Booking, IHotelManager, IHotelCustomer
    {
        // List of rooms in the system
        public Dictionary<int,Room> RoomInfo = new Dictionary<int,Room>();
        
        
        //===================== IHotelManager section =======================//

        // add room
        public bool addRoom(Room room)
         {
               // check whether the user input room number is already exists in the system or not
             if (this.RoomInfo.ContainsKey(room.RoomNumber))
             {
                 // There is already a room with the given number
                 return false;
             }

             else
             {
                 // Add the room to the list of rooms
                 this.RoomInfo.Add(room.RoomNumber, room);
                 return true;
             }

         }



        // delete room from the system
        public bool DeleteRoom(int roomNumber)
        {
            // check whether the user input room number is already exists in the system or not
            if (!RoomInfo.ContainsKey(roomNumber))
            {
                Console.WriteLine($"{roomNumber} is not in the system !!!");
                return false;
            }

            Room room = RoomInfo[roomNumber];
            RoomInfo.Remove(roomNumber);
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("*************************************");
            Console.WriteLine("******* DELETED ROOM DETAILS ********");
            Console.WriteLine("*************************************");
            Console.WriteLine();
            Console.WriteLine($"Deleted room: {room.GetDescription()}");
            return true;
        }


        // disply list of the rooms in the system
        public void ListRooms()
        {
            int count = 1;
            int counts = 1;
            Console.WriteLine();
            Console.WriteLine("*************************************");
            Console.WriteLine("*********** ROOM DETAILS ************");
            Console.WriteLine("*************************************");
            Console.WriteLine();
            foreach (Room room in RoomInfo.Values)
            {
                Console.Write($"{count}. ");
                Console.WriteLine(room.GetDescription());
                Console.WriteLine();
                count++;               

            }

            Console.WriteLine();
            Console.WriteLine("*************************************");
            Console.WriteLine("******** BOOKED ROOM DETAILS ********");
            Console.WriteLine("*************************************");
            Console.WriteLine();

            if (BookingRoom.Count > 0)
            {
                foreach (Booking rooms in BookingRoom)
                {
                    Console.Write($"{counts}. Room Number   : ");
                    Console.WriteLine(rooms.RoomNumber);
                    Console.WriteLine("   Check-In date : " + rooms.CheckIn.Date.ToString());
                    Console.WriteLine("   Check-Out date: " + rooms.CheckOut.Date.ToString());
                    Console.WriteLine();
                    counts++;
                }
            }
            else
            {
                Console.WriteLine("There is no any bookings");
            }
            

        }

        // details of the rooms in the system
        List<Room> RoomList;

        // List rooms according to ther prices to accending order
        public void listRoomsOrderedByPrice()
        {
            RoomList = new List<Room>(RoomInfo.Values);
            RoomList.Sort();
            // sort the room list according to deccending order
            RoomList.Reverse();

            int count = 1;
            Console.WriteLine();
            Console.WriteLine("*************************************");
            Console.WriteLine("************ ROOM DETAILS ***********");
            Console.WriteLine("*************************************");
            Console.WriteLine();
            foreach (Room room in RoomList)
            {
                Console.Write($"{count}. ");
                Console.WriteLine(room.GetDescription());
                Console.WriteLine();
                count++;
            }

        }

        // get a report
        public void generateReport(string fileName)

        {
            if (RoomInfo.Count() > 0)
            {
                using (StreamWriter writer = new StreamWriter($"{fileName}.txt"))
                {
                    int count = 1;
                    // Iterate over the elements in the list and write them to the file
                    writer.WriteLine();
                    writer.WriteLine("*************************************");
                    writer.WriteLine("************ ROOM DETAILS ***********");
                    writer.WriteLine("*************************************");
                    writer.WriteLine();
                    foreach (Room element in RoomInfo.Values)
                    {
                        writer.Write($"{count}. ");
                        writer.WriteLine(element.GetDescription());                      
                        writer.WriteLine();
                        count++;
                    }
                }

                Console.WriteLine("Report is successfully created !!!");
            }
            else
            {
                using (StreamWriter writer = new StreamWriter("output.txt"))
                writer.WriteLine("System has no rooms included !!");
                Console.WriteLine("System has no rooms included !!!");
            }


        }


        //===================== IHotelCustomer section =======================//

        // Disply available rooms
        public void ListAvailableRooms(Booking wantedBooking, Size roomSize)
        {
            int count = 1;
            Console.WriteLine("Available rooms:");
            foreach (Room room in RoomInfo.Values)

             
            {
               
                if (room.Sizes == roomSize && checkRoom(room, wantedBooking))
                {
                    Console.Write($"{count}. ");
                    Console.WriteLine(room.GetDescription());
                    Console.WriteLine();
                    count++;
                }


            }

            
        }

        // available room according to the max.prices
        public void ListAvailableRooms(Booking wantedBooking, Size roomSize, int maxPrice)
        {
            Console.WriteLine();
            Console.WriteLine("Available rooms:");
            RoomList = new List<Room>(RoomInfo.Values);
            RoomList.Sort();
            int count = 1;
            foreach (Room room in RoomList)
            {

                if (room.Sizes == roomSize && checkRoom(room, wantedBooking) && room.PricePerNight < maxPrice)
                {
                    Console.Write($"{count}. ");
                    Console.WriteLine(room.GetDescription());
                    Console.WriteLine();
                    count++;
                }
                

            }

        }


        // booking method
        public bool BookRoom(int roomNumber, Booking wantedBooking)
        {
            if (!RoomInfo.ContainsKey(roomNumber))
            {
                // the room is already booked in the given room number
                return false;
            }

            // Add the booking to the room's list of bookings
            return true;
        }


        public bool checkRoom(Room room, Booking wantedBooking)
        {

            // Check if the room is available for the wanted booking dates
            foreach (Booking booking in BookingRoom)
            {
                Console.WriteLine();
                if (wantedBooking.CheckIn == booking.CheckIn && wantedBooking.CheckOut == booking.CheckOut && room.RoomNumber == booking.RoomNumber)
                {
                    return false;
                }
            }
            return true;

        }

    }
}
