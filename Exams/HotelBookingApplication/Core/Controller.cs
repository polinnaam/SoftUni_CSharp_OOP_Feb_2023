using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using HotelBookingApplication.Models.Bookings;
using HotelBookingApplication.Models.Hotels;
using HotelBookingApplication.Models.Rooms;
using HotelBookingApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingApplication.Core
{
    public class Controller : IController
    {
        private HotelRepository hotels;
        private RoomRepository rooms;
        private BookingRepository bookings;

        public Controller ()
        {
            hotels = new HotelRepository();
            rooms = new RoomRepository();
            bookings = new BookingRepository();
        }
        public string AddHotel(string hotelName, int category)
        {
            if (hotels.Select(hotelName) != null)
            {
                //not created yet
                return string.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
            }
            IHotel hotel = new Hotel(hotelName, category);

            hotels.AddNew(hotel);
            return string.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);            
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            if (hotels.Select(hotelName) == null)
            {
                //doesnt exists;
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }
            IHotel hotel = hotels.Select(hotelName);


            if (hotel.Rooms.Select(roomTypeName) != null)
            {
                return string.Format(OutputMessages.RoomTypeAlreadyCreated);
            }
            IRoom room = null;
            
            if (roomTypeName != "Apartment" && roomTypeName != "DoubleBed" && roomTypeName != "Studio")
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }
            //all data is correct

            if (roomTypeName == "Apartment")
            {
                room = new Apartment();
            }
            else if (roomTypeName == "DoubleBed")
            {
                room = new DoubleBed();
            }
            else if (roomTypeName == "Studio")
            {
                room = new Studio();
            }
            hotel.Rooms.AddNew(room);

            return string.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            if (hotels.Select(hotelName) == null)
            {
                //doesnt exists;
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }
            IHotel hotel = hotels.Select(hotelName);
           
            if (roomTypeName != "Apartment" && roomTypeName != "DoubleBed" && roomTypeName != "Studio")
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            IRoom room = hotel.Rooms.Select(roomTypeName);
            if (room == null)
            {
                return string.Format(OutputMessages.RoomTypeNotCreated);
            }

            if (room != null && room.PricePerNight > 0)
            {
                //price is set yet
                throw new InvalidOperationException(ExceptionMessages.PriceAlreadySet);
            }
            room.SetPrice(price);

            return string.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            if (hotels.All().FirstOrDefault(h => h.Category == category) == null)
            {
                return string.Format(OutputMessages.CategoryInvalid, category);
            }

            IOrderedEnumerable<IHotel> orderedHotels = hotels
                .All()
                .Where(h => h.Category == category)
                .OrderBy(h => h.FullName);

            foreach (var hotel in orderedHotels)
            {
                IRoom room = hotel.Rooms
                    .All()
                    .Where(r => r.PricePerNight > 0)
                    .OrderBy(r => r.BedCapacity)
                    .FirstOrDefault(r => r.BedCapacity >= adults + children);

                if (room != null)
                {
                    int bookingNumber = hotel.Bookings.All().Count() + 1;

                    IBooking booking = new Booking(room, duration, adults, children, bookingNumber);

                    hotel.Bookings.AddNew(booking);

                    return string.Format(OutputMessages.BookingSuccessful, bookingNumber, hotel.FullName);
                }
            }

            return OutputMessages.RoomNotAppropriate;
        }

        public string HotelReport(string hotelName)
        {
            IHotel hotel = hotels.Select(hotelName);

            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName) ;
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Hotel name: {hotel.FullName}");
            sb.AppendLine($"--{hotel.Category} star hotel");
            sb.AppendLine($"--Turnover: {hotel.Turnover:F2} $");
            sb.AppendLine($"--Bookings:");
            sb.AppendLine($"");

            if (hotel.Bookings.All().Count == 0)
            {
                sb.AppendLine($"none");
            }
            else
            {
                foreach (var room in hotel.Bookings.All())
                {
                    sb.AppendLine(room.BookingSummary());
                    //sb.AppendLine($"Booking number: {room.BookingNumber}");
                    //sb.AppendLine($"Room type: {room.GetType().Name");
                    //sb.AppendLine($"Adults: {room.AdultsCount} Children: {room.ChildrenCount}");
                    //sb.AppendLine($"Total amount paid: {hotel.Turnover:f2} $");
                    //sb.AppendLine("");
                }
            }
            return sb.ToString().TrimEnd();
        }

      

        
    }
}
