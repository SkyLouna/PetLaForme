using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace PLFServer.Manager
{
    public class MailManager
    {

        const string SMTPHOST = "smtp.educanet2.ch";                    //Mail server host
        const int SMTPPORT = 25;                                        //Mail server port

        SmtpClient smtpClient;                                          //Mail client


        public MailManager()
        {
            //init smtp client
            smtpClient = new SmtpClient(SMTPHOST, SMTPPORT);
            smtpClient.EnableSsl = true;
            smtpClient.Timeout = 10000;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new System.Net.NetworkCredential("demomot@etml.educanet2.ch", "password :)");
        }

        public Boolean SendMail(String receiver, String subject, String content)
        {
            //create new instance of mailmessage
            MailMessage mailMessage = new MailMessage();
            mailMessage.BodyEncoding = UTF8Encoding.UTF8;
            mailMessage.From = new MailAddress("demomot@etml.educanet2.ch");
            mailMessage.To.Add(new MailAddress(receiver));
            mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            mailMessage.Subject = subject;
            mailMessage.Body = content;

            try
            {
               //send message to server using smtp client
                smtpClient.Send(mailMessage);
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine(e.StackTrace);
                return false;
            }
        }

        public Boolean SendMail(List<String> receivers, String subject, String content)
        {
            //create new instance of mailmessage
            MailMessage mailMessage = new MailMessage(subject, content);
            mailMessage.BodyEncoding = UTF8Encoding.UTF8;
            mailMessage.From = new MailAddress("demomot@etml.educanet2.ch");
            foreach (var mail in receivers)
                mailMessage.To.Add(new MailAddress(mail));
            mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            try
            {
                smtpClient.Send(mailMessage);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
