using System.Net;
using System.Net.Mail;

namespace SCM.Utils
{
    public static class MailUtil
    {

        public static void SendMail(string mailAdress, string title, string message)
        {
            MailMessage message1 = new MailMessage();
            SmtpClient smtpClient = new SmtpClient(/*"smtp.gmail.com", 587*/);
            smtpClient.Credentials = new NetworkCredential("projectreferance@hotmail.com", "11213441Dere");
            smtpClient.Port = 587;
            smtpClient.Host = "smtp.office365.com";
            smtpClient.EnableSsl = true;
            message1.To.Add(mailAdress);
            message1.From = new MailAddress("projectreferance@hotmail.com");
            message1.Subject = title;
            message1.Body = message;
            smtpClient.Send(message1);
        }
    }
}
