using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Westmister_Hotel_Management_System
{
    public class Room : IComparable<Room>
    {
        private int roomNumber;
        private int floor;
        private Size size;
        private int pricePerNight;


        //constructors
        public Room(int roomNumber, int floor, Size size, int pricePerNight)
        {
            this.roomNumber = roomNumber;
            this.floor = floor;
            this.size = size; // either single, double or triple
            this.pricePerNight = pricePerNight; // per night
        }

        public Room(int roomNumber)
        {
            this.RoomNumber = roomNumber;
        }

        public static int Count { get; internal set; }

        //Getters and setters of each attributes
        public int RoomNumber
        {
            get { return roomNumber; }
            set { roomNumber = value; }
        }

        public int Floor
        {
            get { return floor; }
            set { floor = value; }
        }

        public Size Sizes
        {
            get { return size; }
            set { size = value; }
        }

        public int PricePerNight
        {
            get { return pricePerNight; }
            set { pricePerNight = value; }
        }

        // sort the room list 
        public int CompareTo(Room other)
        {
           return this.PricePerNight.CompareTo(other.PricePerNight);
        }


        //display the description of the room
        public virtual string GetDescription()
        {
            return $"Room No: {RoomNumber}\n" +
                   $"   Floor No: {Floor}\n" +
                   $"   Size of the room: {size}\n" +
                   $"   Price: {PricePerNight:C} per night.";
        }



    }
}
