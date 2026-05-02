using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace misto
{
    internal class EventService
    {
        public List<Event> Events = new List<Event>(); 
        public List<Event> SortByDistance(double lat, double lon)
        {
            return Events
                .OrderBy(e => GeoHelper.Distance(lat, lon, e.Latitude, e.Longitude))
                .ToList();
        }
        public List<Event> SortByDate()
        {
            return Events
                .OrderBy(e => e.Date)
                .ToList();
        }
        public List<Event> Search(string query)
        {
            query = query.ToLower();

            return Events
                .Where(e => e.Title.ToLower().Contains(query))
                .ToList();
        }
        // Права доступу
        public bool CanEdit(Event e, Guid userId)
        {
            return e.OwnerId == userId;
        }
    }
}
