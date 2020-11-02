using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Aggregator.Core.Utility
{
    public static class EmailSender
    {
        public static async Task SendEmailAsync(string userEmail, string subject, string htmlMessage, Stream stream)
        {
            MailAddress from = new MailAddress("aggregators2@gmail.com", "Aggregator proj");
            MailAddress to = new MailAddress(userEmail); //почта адресата
            MailMessage mailMessage = new MailMessage(from, to);
            mailMessage.Subject = subject;
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = htmlMessage;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("aggregators2@gmail.com", "C147852369"); //почта отправителя
            smtp.EnableSsl = true;
            mailMessage.Attachments.Add(new Attachment(stream, "Tickets", "application/pdf")); //инициализация PDF файла
            await smtp.SendMailAsync(mailMessage);
        }
    }
}
