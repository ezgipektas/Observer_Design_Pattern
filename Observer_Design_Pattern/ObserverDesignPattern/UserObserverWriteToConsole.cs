using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Observer_Design_Pattern.DAL;
using System;

namespace Observer_Design_Pattern.ObserverDesignPattern
{
    public class UserObserverWriteToConsole : IUserObserver
    {
        private readonly IServiceProvider _serviceProvider;

        public UserObserverWriteToConsole(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void CreateUser(AppUser appUser)
        {
            var logger = _serviceProvider.GetRequiredService<ILogger<UserObserverWriteToConsole>>();
            logger.LogInformation($"{appUser.Name + " " + appUser.Surname} isimli kullanıcı sisteme kayıt yaptı");
        }
    }
}
