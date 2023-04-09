using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;
using HotelBookingApplication.Models.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingApplication.Repositories
{
    public class RoomRepository : IRepository<IRoom>
    {
        private List<IRoom> rooms;

        public RoomRepository()
        {
            rooms = new List<IRoom>();
        }
        public void AddNew(IRoom model)
        {
            IRoom room = null;
            if (model is Apartment)
            {
                room = new Apartment();
            }
            else if (model is Studio)
            {
                room = new Studio();
            }
            else if (model is DoubleBed)
            {
                room = new DoubleBed();
            }
            rooms.Add(room);
        }

        public IRoom Select(string criteria)
        {
            return rooms.FirstOrDefault(t => t.GetType().Name == criteria);
        }

        public IReadOnlyCollection<IRoom> All()
        {
            return rooms.AsReadOnly();
        }
    }
}
