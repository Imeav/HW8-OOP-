using System;

class Email
{
    public string Theme { get; set; }
    public string From { get; set; }
    public string To { get; set; }
}

interface ILogger
{
    void Log(string message);
}

class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}

class EmailSender
{
    private readonly ILogger logger;

    public EmailSender(ILogger logger)
    {
        if (logger == null)
            throw new ArgumentNullException("logger");

        this.logger = logger;
    }

    public void Send(Email email)
    {
        Console.WriteLine("Sending email: " + email.Theme);

        logger.Log("Email from '" + email.From + "' to '" +
                   email.To + "' was sent.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Email[] emails =
        {
            new Email { From = "Me", To = "Vasya", Theme = "Who are you?" },
            new Email { From = "Vasya", To = "Me", Theme = "Vacuum cleaners!" },
            new Email { From = "Kolya", To = "Vasya", Theme = "No! Thanks!" },
            new Email { From = "Vasya", To = "Me", Theme = "Washing machines!" },
            new Email { From = "Me", To = "Vasya", Theme = "Yes" },
            new Email { From = "Vasya", To = "Petya", Theme = "+2" }
        };

        ILogger logger = new ConsoleLogger();
        EmailSender sender = new EmailSender(logger);

        foreach (Email email in emails)
        {
            sender.Send(email);
        }

    }
}
