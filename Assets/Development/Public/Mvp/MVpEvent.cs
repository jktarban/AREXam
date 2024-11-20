using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Development.Public.Mvp
{
    [Serializable]
    public class MVpEvent<T>
    {
        [SerializeField] MvpEventItem<T>[] eventItems;

        public async UniTaskVoid Invoke(T parameter, CancellationToken cancellationToken)
        {
            foreach (var eventItem in eventItems)
            {
                // Await for the specified delay, checking for cancellation
                await UniTask.WaitForSeconds(eventItem.delay).SuppressCancellationThrow();

                // Check if the token has been cancelled before invoking the event
                cancellationToken.ThrowIfCancellationRequested();

                // Invoke the UnityEvent if it's not null
                eventItem.unityEvent?.Invoke(parameter);
            }
        }
    }
}