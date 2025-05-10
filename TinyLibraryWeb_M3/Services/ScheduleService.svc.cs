using System.ServiceModel;
using System;
using TinyLibraryWeb_M3.Models;

namespace TinyLibraryWeb_M3.Services
{
    public class ScheduleService : IScheduleService
    {
        // This method is getting the due date for a specific item
        public DateTime GetDueDate(string itemID)
        {
            // Retrieving the item details using the ItemRepository
            var it = ItemRepository.Get(itemID);
            // Checking if the item wasn't found or if it doesn't have a due date assigned yet
            if (it == null || string.IsNullOrEmpty(it.DueDate))
                // If not found or no due date, returning a default 'empty' DateTime value
                return DateTime.MinValue;
            // Parsing the stored DueDate string from the item into a DateTime object
            return DateTime.Parse(it.DueDate);
            // Returning the parsed DateTime due date
        }
    }
}
