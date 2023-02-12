using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = Colorful.Console;

namespace Westmister_Hotel_Management_System
{
    internal class Program
    {
        static void Main(string[] args) 
        {
            
            // Customer menu
            DisplayCustomerMenu();
            Console.Write("Enter your choice: ", Color.BlueViolet);
            int customer_booking = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            WestminsterHotel hotel = new WestminsterHotel();

            int manager;

            do
            {
                // booking room
              if (customer_booking == 1) 
                {

                    Console.Clear();
                    BookingRoom();

                    // user inputs
                    Console.Write("Enter the room number: ");
                    int roomNumber = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter your check-in date (MM/DD/YYYY): ");
                    string x = Console.ReadLine();

                    Console.Write("Enter your check-out date (MM/DD/YYYY): ");
                    string y = Console.ReadLine();

                    DateTime.TryParse(x, out DateTime check_in);
                    DateTime.TryParse(y, out DateTime check_out);

                    // HotelSystem 
                    Booking wantedBooking = new Booking(check_in, check_out);
                    //check the room is in the system or not
                    bool CheckRoom = hotel.BookRoom(roomNumber, wantedBooking);
                    Booking booking = new Booking(roomNumber, check_in, check_out);

                    Console.Clear();
                    // check overlaps
                    bool timeoverlap = hotel.Overlaps(booking);

                    // validation part
                    bool time = hotel.Validate(booking);
                    

                    //add booking
                    hotel.BookingRooms(booking, timeoverlap, time, CheckRoom);
        

                    Console.WriteLine();
                    Console.Write("Do you want to add more (y/n): ");
                    string ans = Console.ReadLine();

                    if (ans == "y")
                    {
                        continue;
                    }
                    else if(ans == "n")
                    {
                        // go back to the customer menu
                        DisplayCustomerMenu();
                        Console.Write("Enter your choice: ", Color.BlueViolet);
                        customer_booking = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                    }

                }
                   
                // disply available rooms
                else if (customer_booking == 2)
                {
                    Console.Clear();
                    CheckAvailableRoom();

                    // user inputs
                    Console.Write("Enter your check-in date (MM/DD/YYYY): ");
                    string x = Console.ReadLine();

                    Console.Write("Enter your check-out date (MM/DD/YYYY): ");
                    string y = Console.ReadLine();

                    DateTime.TryParse(x, out DateTime check_in);
                    DateTime.TryParse(y, out DateTime check_out);

                    Console.Write("Enter a size (s, m, or l): ");
                    string input = Console.ReadLine();

                    Size size;

                    switch (input)
                    {
                        case "s":
                            size = Size.Single;
                            break;
                        case "m":
                            size = Size.Double;
                            break;
                        case "l":
                            size = Size.Triple;
                            break;
                        default:
                            Console.WriteLine("Invalid size");
                            return;
                    }

                    Booking wantedBooking = new Booking(check_in, check_out);
                    hotel.ListAvailableRooms(wantedBooking, size);                  

                    Console.WriteLine("*******************************");
                    //back to menu
                    backToCustomerMenu();
                    Console.Write("Enter your choice: ", Color.BlueViolet);
                    int ans = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("*******************************");
                        

                    if (ans == 1)
                    {
                        DisplayCustomerMenu();
                        Console.Write("Enter your choice: ", Color.BlueViolet);
                        customer_booking = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                    }

                }

                // disply available rooms according to the max.price
                else if (customer_booking == 3)
                {
                    Console.Clear();
                    CheckAvailableMaxPriceRoom();

                    // user inputs
                    Console.Write("Enter your check-in date (MM/DD/YYYY): ");
                    string x = Console.ReadLine();

                    Console.Write("Enter your check-out date (MM/DD/YYYY): ");
                    string y = Console.ReadLine();

                    DateTime.TryParse(x, out DateTime check_in);
                    DateTime.TryParse(y, out DateTime check_out);

                    Console.Write("Enter a size (s, m, or l): ");
                    string input = Console.ReadLine();

                    Size size;

                    switch (input)
                    {
                        case "s":
                            size = Size.Single;
                            break;
                        case "m":
                            size = Size.Double;
                            break;
                        case "l":
                            size = Size.Triple;
                            break;
                        default:
                            Console.WriteLine("Invalid size");
                            return;
                    }

                    Console.Write("Enter the maximum price: ");
                    int price = Convert.ToInt32(Console.ReadLine());

                    Booking wantedBooking = new Booking(check_in, check_out);
                    hotel.ListAvailableRooms(wantedBooking, size, price);

                    Console.WriteLine("*******************************");
                    //back to menu
                    backToCustomerMenu();
                    Console.Write("Enter your choice: ", Color.BlueViolet);
                    int ans = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("*******************************");


                    if (ans == 1)
                    {
                        DisplayCustomerMenu();
                        Console.Write("Enter your choice: ", Color.BlueViolet);
                        customer_booking = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                    }

                }

                // Go to the admin menu
                else if (customer_booking == 4)
                {
                    DisplayManagerMenu();
                    Console.Write("Enter your choice: ", Color.BlueViolet);
                    manager = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    if (manager == 1) // add room
                    {

                        while (true)
                        {
                            // disply types of room menu
                            DisplayTypeOfRooms();
                            Console.Write("Enter your choice: ", Color.BlueViolet);
                            int roomType = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();

                            // add Deluxe room
                            if (roomType == 1) 
                            {
                                Console.WriteLine("***********************************************");
                                Console.WriteLine();

                                // user inputs
                                Console.Write("Enter the room number: ");
                                int roomNumber = Convert.ToInt32(Console.ReadLine());

                                Console.Write("Enter the floor: ");
                                int floor = Convert.ToInt32(Console.ReadLine());

                                Console.Write("Enter the room price per night: ");
                                int price = Convert.ToInt32(Console.ReadLine());

                                Console.Write("Enter the balcony size: ");
                                int balconySize = Convert.ToInt32(Console.ReadLine());

                                Console.Write("Enter the view (sea, land, or mount): ");
                                string views = Console.ReadLine();

                                View view;

                                switch (views)
                                {
                                    case "sea":
                                        view = View.Seaview;
                                        break;
                                    case "land":
                                        view = View.Landmark;
                                        break;
                                    case "mount":
                                        view = View.Mountain;
                                        break;
                                    default:
                                        Console.WriteLine("Invalid size");
                                        return;
                                }

                                Console.Write("Enter the size (s, m, or l): ");
                                string input = Console.ReadLine();

                                Size size;

                                switch (input)
                                {
                                    case "s":
                                        size = Size.Single;
                                        break;
                                    case "m":
                                        size = Size.Double;
                                        break;
                                    case "l":
                                        size = Size.Triple;
                                        break;
                                    default:
                                        Console.WriteLine("Invalid size");
                                        return;
                                }

                                // constructor
                                DeluxeRoom room = new DeluxeRoom(roomNumber, floor, size, price, balconySize, view);
                                bool added = hotel.addRoom(room);

                                Console.Clear();
                                Console.WriteLine("*************************************");
                                Console.WriteLine("************* ROOM DETAILS *************");
                                Console.WriteLine("*************************************");
                                Console.WriteLine();
                                Console.WriteLine(room.GetDescription());
                                Console.WriteLine();
                                if (added)
                                {
                                    Console.WriteLine("Room added successfully.");
                                }
                                else
                                {
                                    Console.WriteLine("Room already exists in the system.");
                                }


                                Console.WriteLine();
                                Console.Write("Do you want to add more (y/n): ");
                                string ans = Console.ReadLine();

                                if (ans == "y")
                                {
                                    continue;
                                }
                                else if (ans == "n")
                                {
                                    DisplayManagerMenu();
                                    Console.Write("Enter your choice: ", Color.BlueViolet);
                                    manager = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine();
                                }
                            }

                            // add Standard room
                            else if (roomType == 2)
                            {
                                Console.WriteLine("***********************************************");
                                Console.WriteLine();

                                // user inputs
                                Console.Write("Enter the room number: ");
                                int roomNumber = Convert.ToInt32(Console.ReadLine());

                                Console.Write("Enter the floor: ");
                                int floor = Convert.ToInt32(Console.ReadLine());

                                Console.Write("Enter the room price per night: ");
                                int price = Convert.ToInt32(Console.ReadLine());

                                Console.Write("Enter the no. of windows: ");
                                int windows = Convert.ToInt32(Console.ReadLine());

                                Console.Write("Enter a size (s, m, or l): ");
                                string input = Console.ReadLine();

                                Size size;

                                switch (input)
                                {
                                    case "s":
                                        size = Size.Single;
                                        break;
                                    case "m":
                                        size = Size.Double;
                                        break;
                                    case "l":
                                        size = Size.Triple;
                                        break;
                                    default:
                                        Console.WriteLine("Invalid size");
                                        return;
                                }

                                // constructor
                                StandardRoom room = new StandardRoom(roomNumber, floor, size, price, windows);
                                bool added = hotel.addRoom(room);

                                Console.Clear();
                                Console.WriteLine("*************************************");
                                Console.WriteLine("************* ROOM DETAILS *************");
                                Console.WriteLine("*************************************");
                                Console.WriteLine();
                                Console.WriteLine(room.GetDescription());
                                Console.WriteLine();
                                if (added)
                                {
                                    Console.WriteLine("Room added successfully.");
                                }
                                else
                                {
                                    Console.WriteLine("Room already exists in the system.");
                                }

                                Console.WriteLine();
                                Console.Write("Do you want to add more (y/n): ");
                                string ans = Console.ReadLine();

                                if (ans == "y")
                                {
                                    continue;
                                }
                                else if (ans == "n")
                                {
                                    break;
                                }

                            }
                            // Back to the customer menu
                            else if (roomType == 3)
                            {
                                break;

                            }
                        }

                    }

                    // Delete rooms
                    else if (manager == 2) 
                    {

                        while (true)
                        {
                            deleteRoom();

                            // user input
                            int roomNumber = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();

                            hotel.DeleteRoom(roomNumber);

                            Console.WriteLine();
                            Console.Write("Do you want to delate more (y/n): ");
                            string ans = Console.ReadLine();

                            if (ans == "y")
                            {
                                continue;
                            }
                            else if (ans == "n")
                            {
                                break;
                            }
                        }
                    }

                    // To get the room list in system
                    else if (manager == 3)
                    {
                        Console.Clear();
                        hotel.ListRooms();
                        

                        Console.WriteLine("*******************************");
                        //back to menu
                        backToAdminMenu();
                        Console.Write("Enter your choice: ", Color.BlueViolet);
                        int ans = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("*******************************");

                        if (ans == 1)
                        {
                            DisplayManagerMenu();
                            Console.Write("Enter your choice: ", Color.BlueViolet);
                            manager = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();
                        }

                    }

                    // To get the room list according to the prices
                    else if (manager == 4)
                    {
                        Console.Clear();
                        Console.WriteLine();
                        hotel.listRoomsOrderedByPrice();

                        Console.WriteLine("*******************************");
                        //back to menu
                        backToAdminMenu();
                        Console.Write("Enter your choice: ", Color.BlueViolet);
                        int ans = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("*******************************");

                        if (ans == 1)
                        {
                            DisplayManagerMenu();
                            Console.Write("Enter your choice: ", Color.BlueViolet);
                            manager = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();
                        }

                    }

                    // To print the report
                    else if (manager == 5)
                    {
                        Console.Clear();
                        Console.Write("What is the file name: ");
                        string name = Console.ReadLine();
                        Console.WriteLine();
                        hotel.generateReport(name);

                        Console.WriteLine("*******************************");
                        //back to menu
                        backToAdminMenu();
                        Console.Write("Enter your choice: ", Color.BlueViolet);
                        int ans = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("*******************************");

                        if (ans == 1)
                        {
                            DisplayManagerMenu();
                            Console.Write("Enter your choice: ", Color.BlueViolet);
                            manager = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();
                        }

                    }

                    // Go to the customer menu
                    else if (manager == 6)
                    {
                        DisplayCustomerMenu();
                        Console.Write("Enter your choice: ", Color.BlueViolet);
                        customer_booking = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                    }

                    // Exit
                    else if (manager == 7)
                    {
                        break;
                    }
                }

                // Exit
                else if (customer_booking == 5)
                {
                    break;
                }  

 
            } while (true);

        }


        static void DisplayCustomerMenu()
        {
            Console.Clear();
            Console.WriteLine("***********************************************");
            Console.WriteLine("            Hotel Management System            ");
            Console.WriteLine("               * Customer Menu *               ");
            Console.WriteLine("***********************************************");
            Console.WriteLine();
            Console.WriteLine("1) Booking Room");
            Console.WriteLine("2) Check Available Rooms");
            Console.WriteLine("3) Check Available Rooms with Max.price");
            Console.WriteLine("4) Admin Menu");
            Console.WriteLine("5) Exit");
            Console.WriteLine();
        }

        static void DisplayManagerMenu()
        {
            Console.Clear();
            Console.WriteLine("***********************************************");
            Console.WriteLine("            Hotel Management System            ");
            Console.WriteLine("                * Admin Menu *               ");
            Console.WriteLine("***********************************************");
            Console.WriteLine();
            Console.WriteLine("1) Add Room");
            Console.WriteLine("2) Delete Room");
            Console.WriteLine("3) List Rooms");
            Console.WriteLine("4) List Rooms Ordered By Price");
            Console.WriteLine("5) Room Report");
            Console.WriteLine("6) Customer Menu");
            Console.WriteLine("7) Exit");
            Console.WriteLine();
        }

        static void DisplayTypeOfRooms()
        {
            Console.Clear();
            Console.WriteLine("***********************************************");
            Console.WriteLine("            Hotel Management System            ");
            Console.WriteLine("               * Type Of Rooms *               ");
            Console.WriteLine("***********************************************");
            Console.WriteLine();
            Console.WriteLine("1) DeluxeRoom");
            Console.WriteLine("2) StandardRoom");
            Console.WriteLine("3) Exit");
            Console.WriteLine();
        }


        static void deleteRoom()
        {
            Console.Clear();
            Console.WriteLine("***********************************************");
            Console.WriteLine("            Hotel Management System            ");
            Console.WriteLine("               * DELETE ROOMS *                ");
            Console.WriteLine("***********************************************");
            Console.WriteLine();

            Console.Write("Enter the room number: ");
        }


        static void BookingRoom()
        {
            Console.Clear();
            Console.WriteLine("***********************************************");
            Console.WriteLine("            Hotel Management System            ");
            Console.WriteLine("               * BOOKING ROOMS *               ");
            Console.WriteLine("***********************************************");
            Console.WriteLine();

        }


        static void CheckAvailableRoom()
        {
            Console.Clear();
            Console.WriteLine("***********************************************");
            Console.WriteLine("            Hotel Management System            ");
            Console.WriteLine("           * CHECK AVAILABLE ROOMS *           ");
            Console.WriteLine("***********************************************");
            Console.WriteLine();

        }


        static void CheckAvailableMaxPriceRoom()
        {
            Console.Clear();
            Console.WriteLine("***********************************************");
            Console.WriteLine("            Hotel Management System            ");
            Console.WriteLine("           * CHECK AVAILABLE ROOMS *           ");
            Console.WriteLine("***********************************************");
            Console.WriteLine();

        }

        static void backToCustomerMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1) Back to Customer Menu");
            Console.WriteLine();
        }

        static void backToAdminMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1) Back to Admin Menu");
            Console.WriteLine();
        }
    }
}
