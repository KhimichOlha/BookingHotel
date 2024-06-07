using BusinessLogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace BusinessLogicLayer.Services
{
    public class EmailNotificationService : INotificationService
    {
        public void Send(string to, string subject, string body)
        {
            var fromAddress = new MailAddress("olgahimic682@gmail.com");
            var toAddress = new MailAddress(to);
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("olgahimic682@gmail.com", "Olha2005")
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject, 
                Body = body
            })
            {
                //smtp.Send(message);
            }

        }
    }
}
