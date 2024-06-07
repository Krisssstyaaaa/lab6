using System;
using System.Collections.Generic;

// Интерфейс посетителя
public interface IVisitor
{
    void Visit(Mailbox mailbox);
}

// Конкретный класс посетителя
public class MailVisitor : IVisitor
{
    public void Visit(Mailbox mailbox)
    {
        foreach (var message in mailbox.Messages)
        {
            Console.WriteLine($"Mailbox {mailbox.Name}: {message}");
        }
    }
}

// Класс почтового ящика
public class Mailbox
{
    public string Name { get; set; }
    public List<string> Messages { get; private set; }

    public Mailbox(string name)
    {
        Name = name;
        Messages = new List<string>();
    }

    public void AddMessage(string message)
    {
        Messages.Add(message);
    }
}

// Основная программа
class Program
{
    static void Main(string[] args)
    {
        var mailboxes = new List<Mailbox>
        {
            new Mailbox("Inbox"),
            new Mailbox("Spam"),
            new Mailbox("Promotions")
        };

        // Добавляем сообщения в почтовые ящики
        mailboxes[0].AddMessage("Welcome to your inbox!");
        mailboxes[0].AddMessage("Your order has been shipped.");
        mailboxes[1].AddMessage("You won a million dollars!");
        mailboxes[1].AddMessage("Get rich quick scheme.");
        mailboxes[2].AddMessage("50% off on all products.");
        mailboxes[2].AddMessage("New promotions available now.");

        var visitor = new MailVisitor();

        // Обходим все почтовые ящики и показываем сообщения
        foreach (var mailbox in mailboxes)
        {
            visitor.Visit(mailbox);
        }
    }
}