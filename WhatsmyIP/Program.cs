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
            var smtpClient = new SmtpClient("<SMTP Server>")
            {
                Port = 25,
                Credentials = new NetworkCredential("<Username>", "<Password>")
            };
            String From = "<From Email Address>";
            String To = "<to emial address>";
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
