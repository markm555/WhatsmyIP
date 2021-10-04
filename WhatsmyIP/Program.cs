using System;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace Examples.System.Net
{
    public class WebRequestGetExample
    {
        public static void SendEmail(string response)
        {
            var smtpClient = new SmtpClient("66.90.130.119")
            {
                Port = 25,
                Credentials = new NetworkCredential("markm@moorecasa.com", "Time2run2")
            };
            String From = "markm@moorecasa.com";
            String To = "markm@microsoft.com";
            String subject = "What's my IP'";
            String body = response;
            smtpClient.Send(From, To, subject, body);
        }
        public static void Main()
        {
            // Create a request for the URL.
            WebRequest request = WebRequest.Create(
              "http://bot.whatismyipaddress.com");
            request.Credentials = CredentialCache.DefaultCredentials;

            WebResponse response = request.GetResponse();

            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            using (Stream dataStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                Console.WriteLine(responseFromServer);
                SendEmail(responseFromServer);
            }
            response.Close();
        }
    }
}