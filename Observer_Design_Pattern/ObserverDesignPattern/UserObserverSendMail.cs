using MailKit.Net.Smtp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MimeKit;
using Observer_Design_Pattern.DAL;
using System;
using System.Net.Mail;

namespace Observer_Design_Pattern.ObserverDesignPattern
{
    public class UserObserverSendMail:IUserObserver
    {
        private readonly IServiceProvider _serviceProvider;

        public UserObserverSendMail(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void CreateUser(AppUser appUser)
        {
            var logger = _serviceProvider.GetRequiredService<ILogger<UserObserverSendMail>>();



            MimeMessage mimeMessage = new MimeMessage();



            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "ezgi.pkts@hotmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);



            MailboxAddress mailboxAddressTo = new MailboxAddress("User", appUser.Email);
            mimeMessage.To.Add(mailboxAddressTo);



            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = "Observer Design Pattern Dersimizde %25 Oranında İndirim Kazandınız, İndirim Kodunuz GIFT2022";
            mimeMessage.Body = bodyBuilder.ToMessageBody();



            mimeMessage.Subject = "Sistemimize Hoş Geldiniz";

            SmtpClient client= new SmtpClient();         
          
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("ezgi.pkts@hotmail.com", "ekzpnmnofibdjgtr");
            client.Send(mimeMessage);
            client.Disconnect(true);



            logger.LogInformation("Yeni kullanıcımıza indirim kodu mail olarak gönderildi");



        }
    }
    }

