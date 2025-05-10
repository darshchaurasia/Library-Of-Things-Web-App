using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Web;
using FeeCalcLibrary;
using TinyLibraryWeb_M3.Models;

namespace TinyLibraryWeb_M3.Helpers
{
    // This helper class is responsible for handling user authentication and account management
    public static class AuthHelper
    {
        // Setting up the file path for our user accounts XML file
        private static readonly string _xmlPath =
            HttpContext.Current.Server.MapPath("~/App_Data/Accounts.xml");

        // This method is for registering a new user
        public static bool Register(string user, string plainPwd)
        {
            EnsureFile(); // Ensuring the accounts file exists before proceeding
            // Checking if the user already exists.
            if (UserExists(user)) return false;

            // Loading the accounts XML document and adding the new user data
            var doc = XDocument.Load(_xmlPath);
            doc.Root!.Add(new XElement("User",
                new XAttribute("name", user),
                new XAttribute("pwdHash", FeeCalc.HashPassword(plainPwd)),
                new XAttribute("role", "member"),
                new XAttribute("lastLogin", "")
            ));
            doc.Save(_xmlPath); // Saving the updated XML document
            return true; // Indicating successful registration
        }
        // This method is for validating a user's login credentials
        public static bool Validate(string user, string plainPwd, out string role)
        {
            EnsureFile();
            var doc = XDocument.Load(_xmlPath);
            var node = doc.Root!.Elements("User")
                        .FirstOrDefault(u => (string)u.Attribute("name") == user);
            role = node?.Attribute("role")?.Value ?? "";

            if (node == null) return false;
            string hash = FeeCalc.HashPassword(plainPwd);
            bool ok = hash == (string)node.Attribute("pwdHash");
            // If validation is successful, updating last login time and saving
            if (ok)
            {
                node.SetAttributeValue("lastLogin", DateTime.Now);
                doc.Save(_xmlPath);
            }
            return ok;
        }
        // This method is getting all user accounts for display
        public static List<UserModel> GetAll()  // for Staff page
        {
            EnsureFile();
            var doc = XDocument.Load(_xmlPath);
            return doc.Root!.Elements("User")
                     .Select(u => new UserModel
                     {
                         Name = (string)u.Attribute("name"),
                         Role = (string)u.Attribute("role"),
                         LastLogin = (string)u.Attribute("lastLogin")
                     }).ToList();
        }

        // Methods for setting user roles (promoting/demoting) by calling SetRole
        public static bool Promote(string user) => SetRole(user, "staff");
        public static bool Demote(string user) => SetRole(user, "member");

        // This method is deleting a user account
        public static bool Delete(string user)
        {
            if (user.Equals("TA", StringComparison.OrdinalIgnoreCase)) return false;
            var doc = XDocument.Load(_xmlPath);
            var node = doc.Root!.Elements("User")
                        .FirstOrDefault(u => (string)u.Attribute("name") == user);
            if (node == null) return false;
            node.Remove();
            doc.Save(_xmlPath);
            return true;
        }
        // Private helper to check if a user exists by name
        private static bool UserExists(string user)
        {
            var doc = XDocument.Load(_xmlPath);
            return doc.Root!.Elements("User")
                     .Any(u => (string)u.Attribute("name") == user);
        }
        // Private helper to set a user's role
        private static bool SetRole(string user, string role)
        {
            var doc = XDocument.Load(_xmlPath);
            var node = doc.Root!.Elements("User")
                        .FirstOrDefault(u => (string)u.Attribute("name") == user);
            if (node == null) return false;
            node.SetAttributeValue("role", role);
            doc.Save(_xmlPath);
            return true;
        }
        // This private helper method is ensuring the accounts file and initial staff user exist
        private static void EnsureFile()
        {
            if (!System.IO.File.Exists(_xmlPath))
            {
                new XDocument(new XElement("Users")).Save(_xmlPath);
            }
            // Loading the XML document and ensuring the root exists
            var doc = XDocument.Load(_xmlPath);
            var ta = doc.Root!.Elements("User")
                       .FirstOrDefault(u => (string)u.Attribute("name") == "TA");
            if (ta == null)
            {
                ta = new XElement("User",
                        new XAttribute("name", "TA"),
                        new XAttribute("pwdHash", FeeCalc.HashPassword("Cse445!")),
                        new XAttribute("role", "staff"),
                        new XAttribute("lastLogin", ""));
                doc.Root.Add(ta);
                doc.Save(_xmlPath); // Saving after adding TA
            }
            else if ((string)ta.Attribute("pwdHash") == "PLACEHOLDER")
            {
                ta.SetAttributeValue("pwdHash", FeeCalc.HashPassword("Cse445!"));
                doc.Save(_xmlPath); // Saving after updating TA's password
            }
        }
    }
}