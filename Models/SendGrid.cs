using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class SendGridServ
    {
        public static void Execute( string fromEmail , string toEmail , string toUser, string content ,string htmlcont)
        {
            
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(fromEmail, "Admin");
            var subject = "New mail from Admin";
            var to = new EmailAddress(toEmail, toUser);
            var plainTextContent = $"{content}";
            var htmlContent = $"<strong>{htmlcont}</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = client.SendEmailAsync(msg);
        }
    }
}