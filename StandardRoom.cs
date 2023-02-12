using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Westmister_Hotel_Management_System
{
    public class StandardRoom:Room
    {
        private int numberOfWindows; // at least 1

        //constructor
        public StandardRoom(int roomNumber, int Floor, Size size, int PricePerNight, int numberOfWindows):base(roomNumber, Floor, size, PricePerNight)
        {
            this.numberOfWindows = numberOfWindows;
        }

        public int NumberOfWindows
        {
            get { return numberOfWindows; }
            set { numberOfWindows = value; }
        }

        //display the description of the room
        public override string GetDescription()
        {
            return $"{base.GetDescription()}\n" + 
                   $"   It has {NumberOfWindows} windows\n" +
                   $"   Room Type ===> Standard Room";
        }
    }
}
