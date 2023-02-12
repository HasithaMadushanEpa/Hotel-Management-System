using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Westmister_Hotel_Management_System
{
    public class DeluxeRoom:Room
    {
        private int balconySize;
        private View view;

        public DeluxeRoom(int roomNumber, int Floor, Size size, int PricePerNight, int balconySize, View view):base(roomNumber, Floor, size, PricePerNight)
        {
            this.balconySize = balconySize; // of a given size in m2
            this.view = view; // either seaview, landmark view, or mountain view
        }

        public int BalconySize
        {
            get { return balconySize; }
            set { balconySize = value; }
        }

        public View View
        {
            get { return view; }
            set { view = value; }
        }

        //display the description of the room
        public override string GetDescription()
        {
            return $"{base.GetDescription()}\n" + 
                   $"   It has a {balconySize} m2 size balcony\n" + 
                   $"   balcony with a {view} view\n" +
                   $"   Room Type ===> Deluxe Room";
        }

    }
}
