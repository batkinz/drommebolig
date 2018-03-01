using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace DreamHome
{
    public class HomeAdProvider : IObservable<HomeAd>
    {
        protected readonly object _observersLock = new object();
        private List<IObserver<HomeAd>> _observers;

        public HomeAdProvider()
        {
            _observers = new List<IObserver<HomeAd>>();
        }

        public IDisposable Subscribe(IObserver<HomeAd> observer)
        {
            lock(_observersLock)
            {
                if (!_observers.Contains(observer))
                {
                    _observers.Add(observer);
                }
            }

            return new Unsubscriber(Unsubscribe, observer);
        }

        private void Unsubscribe(IObserver<HomeAd> observer)
        {
            lock(_observersLock)
            {
                _observers.Remove(observer);
            }
        }

        private class Unsubscriber : IDisposable
        {
            private readonly Action<IObserver<HomeAd>> unsubscribe;
            private readonly IObserver<HomeAd> _observer;

            public Unsubscriber(Action<IObserver<HomeAd>> unsubscribe, IObserver<HomeAd> observer)
            {
                if (unsubscribe == null)
                    throw new ArgumentNullException(nameof(unsubscribe));

                this.unsubscribe = unsubscribe;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null)
                {
                    unsubscribe(_observer);
                }
            }
        }
    }
}