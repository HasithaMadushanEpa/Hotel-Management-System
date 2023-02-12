using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Westmister_Hotel_Management_System
{
    public class Booking : IOverlappable
    {
        private int roomNumber;
        private DateTime checkIn;
        private DateTime checkOut;


        // constructors
        public Booking(int roomNumber, DateTime checkIn, DateTime checkOut)
        {
            this.roomNumber = roomNumber;
            this.checkIn = checkIn;
            this.checkOut = checkOut;
        }

        public Booking(DateTime checkIn, DateTime checkOut)
        {
            this.checkIn = checkIn;
            this.checkOut = checkOut;
        }

        public Booking()
        {
        }

        public int RoomNumber
        {
            get { return roomNumber; }
            set { roomNumber = value; }
        }

        public DateTime CheckIn
        {
            get { return checkIn; }
            set { checkIn = value; }
        }

        public DateTime CheckOut
        {
            get { return checkOut; }
            set { checkOut = value; }
        }


        // create a List array to store the booking room details
        public List<Booking> BookingRoom = new List<Booking>();


        // Booking rooms add to the List array
        public bool BookingRooms(Booking booking, bool timeOverlap, bool time, bool CheckRoom)
        {
            if (CheckRoom) // check the room that given number is already exist in the system or not
            {
                if (time)
                {
                    if (timeOverlap == false)
                    {
                        Console.WriteLine($"Room no.{booking.RoomNumber} is booked successfully");
                        this.BookingRoom.Add(booking);

                        return true;
                    }

                    else
                    {
                        // There is already a room with the given number, so return false.
                        Console.WriteLine($"Room no.{booking.RoomNumber} is already booked !!!");
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }
            else
            {
                Console.WriteLine($"Room no.{booking.RoomNumber} is not in the system !!!");
                return false;
            }

        }


        // check whether the time overlap
        public bool Overlaps(Booking other)
        {
            foreach (Booking booking in BookingRoom)
            {
                if (other.CheckIn.Date < booking.CheckOut.Date && other.CheckOut.Date > booking.CheckIn.Date && BookingRoom.Any(b => b.RoomNumber == other.RoomNumber))
                {
                    return true;
                }

            }
            return false;
        }


        // check the validation part
        public bool Validate(Booking book)
        {
            // Check if the check-in date is in the future
            if (book.checkIn.Date < DateTime.Now.Date)
            {
                Console.WriteLine("Error: CheckIn date must be in the future.");
                return false;
            }

            // Check if the check-out date is after the check-in date
            if (book.checkOut.Date < book.checkIn.Date)
            {
                Console.WriteLine("Error: CheckOut date must be after the checkIn date.");
                return false;
            }

            return true;
        }
    }
}
