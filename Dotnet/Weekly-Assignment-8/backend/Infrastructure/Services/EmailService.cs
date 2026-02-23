using Backend.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace Backend.Infrastructure.Services;

public class EmailService : IEmailService
{
    private readonly IConfiguration _config;

    public EmailService(IConfiguration config)
    {
        _config = config;
    }

    public async Task SendEmailAsync(string to, string subject, string body)
    {
        var email = _config["EmailSettings:Email"];
        var password = _config["EmailSettings:Password"];
        var host = _config["EmailSettings:Host"];
        var port = int.Parse(_config["EmailSettings:Port"]!);

        var message = new MailMessage();
        message.From = new MailAddress(email!);
        message.To.Add(to);
        message.Subject = subject;
        message.Body = body;
        message.IsBodyHtml = true;

        using var smtp = new SmtpClient(host, port)
        {
            Credentials = new NetworkCredential(email, password),
            EnableSsl = true
        };

        await smtp.SendMailAsync(message);
    }
}