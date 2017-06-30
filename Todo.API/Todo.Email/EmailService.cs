using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;

namespace Todo.Email
{
    public class EmailService
    {
        private const string SmtpServer = "smtp.gmail.com";
        private const int SmtpPortNumber = 465;
        private const string FromAdress = ""; //Set username from email adress
        private const string FromAdressTitle = "TestIt";
        private const string Password = ""; //Set password from email adress

        public bool Send(Email email)
        {
            try
            {
                var mimeMessage = new MimeMessage();
                mimeMessage.From.Add(new MailboxAddress(FromAdressTitle, FromAdress));
                mimeMessage.To.Add(new MailboxAddress(email.ToAdressTitle, email.ToAdress));
                mimeMessage.Subject = email.Subject;
                mimeMessage.Body = new TextPart("plain")
                {
                    Text = email.BodyContent

                };

                using (var client = new SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    //client.Connect(SmtpServer, SmtpPortNumber, true);
                    client.Connect("smtp.gmail.com", 465, SecureSocketOptions.SslOnConnect);
                    // Note: only needed if the SMTP server requires authentication
                    // Error 5.5.1 Authentication 
                    //client.Authenticate(FromAdress, Password);
                    //client.Connect(SmtpServer, SmtpPortNumber, SecureSocketOptions.StartTlsWhenAvailable);
                    //client.AuthenticationMechanisms.Remove("XOAUTH2"); // Must be removed for Gmail SMTP
                    //var uri = new Uri("smtps://smtp.gmail.com:465");
                    //client.Connect(uri);
                    client.Authenticate(FromAdress, Password);
                    client.Send(mimeMessage);
                    Console.WriteLine("The mail has been sent successfully !!");
                    Console.ReadLine();
                    client.Disconnect(true);

                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
