using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace MailService
{
    public static class Function1
    {
        [FunctionName("MailService")]
        public static async Task Run([QueueTrigger("warsztaty")]string myQueueItem, ILogger log)
        {
            var apiKey = "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";
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress("andrzej.duda@gov.pl", "Andrzej");
                var subject = "Temat";
                var to = new EmailAddress("szymon.pulka@cloud-vision.pl", "Andrzej");
                var plainTextContent = "and easy to do anywhere, even with C#";
                var htmlContent = "To jest mail wysłany z az -> " + myQueueItem;
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg);
            
        }
    }
}
