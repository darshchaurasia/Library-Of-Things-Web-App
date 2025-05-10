using System;
using System.Security.Cryptography;
using System.Text;

namespace FeeCalcLibrary
{
    public static class FeeCalc
    {
        public static decimal ComputeLateFee(int daysLate)
        {
            return daysLate * 0.25m;
        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }
    }
}
