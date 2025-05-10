using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Web;
using TinyLibraryWeb_M3.Models;
using TinyLibraryWeb_M3.Services;

namespace TinyLibraryWeb_M3.Models
{
    public static class ItemRepository
    {
        private static readonly string _path =
            HttpContext.Current.Server.MapPath("~/App_Data/Items.xml");

        public static List<Item> GetAll()
        {
            var doc = XDocument.Load(_path);
            return doc.Root.Elements("Item")
                .Select(ToModel).ToList();
        }

        public static Item Get(string id)
        {
            var doc = XDocument.Load(_path);
            var node = doc.Root.Elements("Item")
                        .FirstOrDefault(i => (string)i.Element("Id") == id);
            return node == null ? null : ToModel(node);
        }

        public static void Add(string name)
        {
            var list = GetAll();
            int nextId = list.Select(i => int.Parse(i.Id)).DefaultIfEmpty(0).Max() + 1;

            var doc = XDocument.Load(_path);
            doc.Root.Add(new XElement("Item",
                new XElement("Id", nextId.ToString()),
                new XElement("Name", name),
                new XElement("IsBorrowed", false),
                new XElement("BorrowedBy", ""),
                new XElement("DueDate", "")
            ));
            doc.Save(_path);
        }

        public static void Update(Item item)
        {
            var doc = XDocument.Load(_path);
            var node = doc.Root.Elements("Item")
                .First(i => (string)i.Element("Id") == item.Id);

            node.Element("Name").Value = item.Name;
            node.Element("IsBorrowed").Value = item.IsBorrowed.ToString().ToLower();
            node.Element("BorrowedBy").Value = item.BorrowedBy ?? "";
            node.Element("DueDate").Value = item.DueDate ?? "";
            doc.Save(_path);
        }

        public static void Delete(string id)
        {
            var doc = XDocument.Load(_path);
            var node = doc.Root.Elements("Item")
                       .FirstOrDefault(i => (string)i.Element("Id") == id);
            if (node == null) return;
            node.Remove();
            doc.Save(_path);
        }

        public static List<Item> GetBorrowed() =>
            GetAll().Where(i => i.IsBorrowed).ToList();

        private static Item ToModel(XElement x) => new Item
        {
            Id = (string)x.Element("Id"),
            Name = (string)x.Element("Name"),
            IsBorrowed = (bool)x.Element("IsBorrowed"),
            BorrowedBy = (string)x.Element("BorrowedBy"),
            DueDate = (string)x.Element("DueDate")
        };
    }
}
