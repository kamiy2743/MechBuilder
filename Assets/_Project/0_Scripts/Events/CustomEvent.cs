using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.Events;

namespace MB
{
    public class CustomEvent : ICustomEvent
    {
        private Subject<string> _subject = new Subject<string>();
        public bool IsListened { get; private set; } = false;

        public void SetIsListened(bool value)
        {
            IsListened = value;
        }

        public void AddListener(UnityAction call)
        {
            _subject
                .Where(_ => IsListened)
                .Subscribe(_ => call.Invoke());
        }

        public void Invoke()
        {
            _subject.OnNext("");
        }
    }

    public class CustomEvent<T> : ICustomEvent<T>
    {
        private Subject<T> _subject = new Subject<T>();
        public bool IsListened { get; private set; } = false;

        public void SetIsListened(bool value)
        {
            IsListened = value;
        }

        public void AddListener(UnityAction<T> call)
        {
            _subject
                .Where(_ => IsListened)
                .Subscribe(arg => call.Invoke(arg));
        }

        public void Invoke(T arg)
        {
            _subject.OnNext(arg);
        }
    }
}
