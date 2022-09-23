using DAL;
using System.Net;
using System.Net.Mail;

namespace SamarApp.Models
{
    public class EmailSettings
    {
        public static void SendEmail(Email email)
        {
            var Client = new SmtpClient("smtp.sendgrid.net", 587);
            Client.EnableSsl = true;
            Client.Credentials = new NetworkCredential("apikey", "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");
            Client.Send("minamamdoh150@gmail.com", email.To, email.Title, email.Body);

        }

    }
}
