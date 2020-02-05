using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;
using System.Net.Mail;
using GospelInnMinistry.Models;
using System.Net;
using System.Configuration;
using GospelInnMinistry.DAL;
using System.IO;

namespace GospelInnMinistry.CommonCode
{
    public  static class EmailCode
    {
        

        public static string AdminEmail = "GospelInn@gmail.com";

        public static void UserSendEmail( this User user , string  Message)
        {
            GmailEmail(user, AdminEmail, Message, "User Request");
        }

        public static void SendNewsLetter( this User user, string email, string Message, string Info)
        {
            GmailEmail(user, email, Message, Info);
        }
 
        private static void GmailEmail(User sender, string ReceiverEmail,  string Message , string Info)
        {
            if ( sender != null && ReceiverEmail != null )
            {
                string Name = "";
                string Subject = "User Request";

                if (sender.Roleid== 2)
                {
                       Name = "GospelInn";
                       Subject = Info;
                }
                else
                {
    Name = sender.FirstName.ToString() + " " + sender.LastName.ToString();
                }
                   
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress(ReceiverEmail));
                 message.From = new MailAddress(sender.Email.ToString());
                  
                message.Subject = Subject ;
                message.Body = string.Format(body, Name, sender.Email.ToString(), Message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    smtp.UseDefaultCredentials = false;

					var credential = new NetworkCredential
					{
						UserName = "gospelinnministry9090@gmail.com" ,  // "ibrahim.ademide@gmail.com", // ,  // (ConfigurationManager.AppSettings.Get("GmailUserName")).ToString(),

						Password = "GOSPELINN9090"   //"xj9,xj10" //   // (ConfigurationManager.AppSettings.Get("GmailPassword")).ToString()
                    };

                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
					smtp.Port = 465; // 587;
					smtp.EnableSsl = true;
					smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
					smtp.UseDefaultCredentials = false;



					smtp.Send(message);

                }
            }
            else
            {
                throw new NullReferenceException("Details is null");
            }
        }

        private static void SaveRequestToDb(Message message)
        {
            MessageRepo messageRepo = new MessageRepo();
            messageRepo.addMessage(message);
        }
    }

    public  class SlideCode
    {
        public string[] getAllImages ()
        {
            string[] filePaths = Directory.GetFiles(@"C:\Users\dell\Source\Repos\ademide94\gospelINN\GospelInnMinistry\images\HomePageSlide").Select(file => Path.GetFileName(file)).ToArray();

            return filePaths;
            //foreach (var item in filePaths)
            //{
               
            //}
        }
       
    }
}