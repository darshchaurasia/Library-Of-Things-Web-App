using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web;
using System.Web.SessionState;

namespace TinyLibraryWeb_M3.Handlers
{
    public class Captcha : IHttpHandler, IRequiresSessionState
    {
        // This method is handling the incoming HTTP request for the CAPTCHA image
        public void ProcessRequest(HttpContext context)
        {
            string code = GenerateRandomCode();
            context.Session["Captcha"] = code;
            // Creating a new bitmap image to draw on, and graphics object to do the drawing
            using (Bitmap bmp = new Bitmap(140, 60))
            using (Graphics g = Graphics.FromImage(bmp))
            using (Font font = new Font("Arial", 18))
            {
                g.Clear(Color.White);
                g.DrawString(code, font, Brushes.Black, new PointF(10, 5));

                context.Response.ContentType = "image/png";
                bmp.Save(context.Response.OutputStream, ImageFormat.Png);
            }
        }
        // This property is indicating whether multiple requests can use the same handler instance.
        public bool IsReusable => false;
        // This private helper method is generating a random string of characters for the CAPTCHA
        private string GenerateRandomCode()
        {
            var rand = new Random(); // Initializing a random number generator
            const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            char[] buffer = new char[5];
            for (int i = 0; i < buffer.Length; i++)
                buffer[i] = chars[rand.Next(chars.Length)];
            return new string(buffer);
        }
    }
}
