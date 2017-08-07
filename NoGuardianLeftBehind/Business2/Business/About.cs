using Business.Library;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Business.Business
{
    public class About
    {
        public About()
        {
            //Init
        }

        public String ContactUs(String name, String email, String body)
        {
            //Variables
            String returnval = "Thanks " + name + "! Someone will contact you soon!";

            try
            {
                //Variables
                SendGridMessage message = new SendGridMessage();

                //From
                message.From = new MailAddress("questions@noguardianleftbehind.com");

                //To
                message.AddTo(email);
                message.AddTo("questions@noguardianleftbehind.com");

                //Subject and Body
                message.Subject = "AUTOMATED RESPONSE - Contact Us - NoGuardianLeftBehind";
                message.Text = "We Have Recieved Your Email! And we will get back to you as soon as possible!";
                message.Html = "<h2>We Recieved Your Message " + name + "! Someone will contact you as soon as possible!</h2>" +
                               "<h3>Name</h3>" +
                               "<p>" + name + "</p>" +
                               "<h3>Message</h3>" +
                               "<p>" + body + "</p>";

                // Create credentials, specifying your user name and password.
                NetworkCredential credentials = new NetworkCredential(COMMON.EMAIL_USERNAME, COMMON.EMAIL_PASSWORD);

                // Create an Web transport for sending email.
                Web transportWeb = new Web(credentials);

                // Send the email, which returns an awaitable task.
                transportWeb.DeliverAsync(message);


                //MailMessage mail = new MailMessage(email, "elliottquick@live.com", "NOGUARDIANLEFTBEHIND - " + name, body + '\n' + "Reply EMAIL: " + email);
                //SmtpClient client = new SmtpClient("smtp.gmail.com");

                //client.DeliveryMethod = SmtpDeliveryMethod.Network;
                //client.Port = 587;
                //client.Credentials = new System.Net.NetworkCredential("noguardianleftbehind@gmail.com", "!F#O)R^D636120");
                //client.EnableSsl = true;

                //client.Send(mail);

            }
            catch (Exception)
            {
                returnval = "Sorry " + name + " there was an issue with your submission.";
            }

            return returnval;
        }
    }
}
