﻿using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace SisMedico.Mvc.Extensions.IdentityServices;

public class EmailSender : IEmailSender
{
    public AuthMessageSenderOptions Options { get; }
    public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccess)
    {
        Options = optionsAccess.Value;
    }

    public Task SendEmailAsync(string email, string subject, string message)
    {
        return Execute(Options.SendGridKey, subject, message, email);
    }

    public Task Execute(string apiKey, string subject, string message, string email)
    {
        var client = new SendGridClient(apiKey);
        var msg = new SendGridMessage()
        {
            //From = new EmailAddress("carlos.itdeveloper@gmail.com", Options.SendGridUser),
            From = new EmailAddress("carlos.poetarj@gmail.com", Options.SendGridUser),
            Subject = subject,
            PlainTextContent = message,
            HtmlContent = message
        };
        msg.AddTo(new EmailAddress(email));

        msg.SetClickTracking(false, false);

        return client.SendEmailAsync(msg);

    }
}
