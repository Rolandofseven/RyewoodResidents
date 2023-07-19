using System;

using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RyewoodResidents.Models;
using System;
using System.Net;


namespace RyewoodResidents.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public  async void SendMail(string lname, string email, string comment)
    {
        using var message = new MimeMessage();
        message.From.Add(new MailboxAddress(
            "ryewoodsmtpmail", 
                    "ryewoodsmtpmail@gmail.com"
        ));
        message.To.Add(new MailboxAddress(
            "Roland", 
                    "rolandjpiggott@gmail.com"
        ));

        message.ReplyTo.Add (new MailboxAddress (lname, email));

        message.Subject = "Sending with Twilio SendGrid is Fun";
        var bodyBuilder = new BodyBuilder
        {
            TextBody = "and easy to do anywhere, especially with C#",
            HtmlBody = "and easy to do anywhere, <b>especially with C#</b>"
        };
        message.Body = bodyBuilder.ToMessageBody();

        using var client = new SmtpClient();
        // SecureSocketOptions.StartTls force a secure connection over TLS
        await client.ConnectAsync("smtp.sendgrid.net", 587, SecureSocketOptions.StartTls);
        await client.AuthenticateAsync(
            userName: "apikey", // the userName is the exact string "apikey" and not the API key itself.
            password: "" // password is the API key
        );

        Console.WriteLine("Sending email");
        await client.SendAsync(message);
        Console.WriteLine("Email sent");

        await client.DisconnectAsync(true);
    }

    public IActionResult Contact()
    {
        return View();
    }

    public IActionResult News()
    {
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
