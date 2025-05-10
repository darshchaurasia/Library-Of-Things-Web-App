using System;
using System.Linq;
using System.ServiceModel;
using System.Xml.Linq;
using TinyLibraryWeb_M3.Models;

namespace TinyLibraryWeb_M3.Services
{
    public class SearchService : ISearchService
    {
        // This method is searching for items based on a provided keyword
        public Item[] ItemSearch(string keyword)
        {
            // Getting the physical file path for the Items XML data file
            string path = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Items.xml");
            var doc = XDocument.Load(path);

            // Querying the XML document to find matching items
            var results = doc
                .Descendants("Item")
                .Select(x => new Item
                {
                    Id = (string)x.Element("Id"), // Getting the Item's Id
                    Name = (string)x.Element("Name"), // Getting the Item's Name
                    IsBorrowed = (bool)x.Element("IsBorrowed") // Getting the Item's borrowed status
                })
                // Filtering the items to include only those whose Name contains the keyword
                .Where(i => i.Name.IndexOf(keyword ?? "", StringComparison.OrdinalIgnoreCase) >= 0)
                .ToArray();

            return results;// Returning the array of found items
        }
    }
}
