using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace SendMail
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create Smpt client
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.Timeout = 10000;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;

            smtpClient.Credentials = new NetworkCredential("onima3145@gmail.com", "QWERTYasdfg");

            string path = System.IO.Directory.GetCurrentDirectory().Replace("\\bin\\Debug", "") + "\\HTML\\index.html";
            //Console.WriteLine(System.IO.Directory.GetCurrentDirectory());
            //Console.WriteLine(path);
            string Body = System.IO.File.ReadAllText(path);
            MailMessage msg = new MailMessage("onima3145@gmail.com", "zablotskachristina@gmail.com", "Subject", Body);
            msg.IsBodyHtml = true;

            Attachment attachment = new Attachment(System.IO.Directory.GetCurrentDirectory().Replace("\\bin\\Debug", "") + "\\Image\\1.jpg");
            attachment.ContentId = "flower";
            msg.Attachments.Add(attachment);

            //Credentials
            msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;


            try
            {
                smtpClient.Send(msg);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
