using System;
using NLog;

namespace DreamHome
{
    public class HomeAdObserver : IObserver<HomeAd>
    {
        private static ILogger _log = LogManager.GetCurrentClassLogger();
        private readonly Func<HomeAd, bool> _filter;
        private readonly IUserNotifier _notifier;

        public HomeAdObserver(IUserNotifier notifier, Func<HomeAd, bool> filter)
        {
            this._filter = filter ?? throw new ArgumentNullException(nameof(filter));
            this._notifier = notifier ?? throw new ArgumentNullException(nameof(notifier));
        }

        public void OnCompleted()
        {
            _log.Debug("OnCompleted");
        }

        public void OnError(Exception error)
        {
            _log.Error(error.Message);
        }

        public void OnNext(HomeAd value)
        {
            if (_filter(value))
            {
                _notifier.NotifyUser(value);
            }
        }
    }
}