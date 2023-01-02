using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Observer_Design_Pattern.DAL;
using System;

namespace Observer_Design_Pattern.ObserverDesignPattern
{
    public class UserObserverCreateDiscount : IUserObserver
    {
        private readonly IServiceProvider _serviceProvider;

        public UserObserverCreateDiscount(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void CreateUser(AppUser appUser)
        {
            var logger = _serviceProvider.GetRequiredService<ILogger<UserObserverCreateDiscount>>();
            var scoped = _serviceProvider.CreateScope();
            var context = scoped.ServiceProvider.GetRequiredService<Context>();
            context.Discounts.Add(new Discount
            {
                UserID = appUser.Id,
                Rate = 25
            });
            context.SaveChanges();
            logger.LogInformation("Yeni gelen kullanıcıya indirim kodu tanımlandı");
        }
    }
}
