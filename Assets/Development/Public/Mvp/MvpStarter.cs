using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Development.Public.Mvp.Messages;
using UnityEngine;

namespace Development.Public.Mvp
{
    public class MvpStarter : MonoBehaviour
    {
        [SerializeField] private Transform mvpContainer;
        [SerializeField] private MVpEvent<BaseMessage> onStart;

        private readonly List<IPresenter> _presenters = new();
        private CancellationTokenSource _cancellationTokenSource;

        private void Start()
        {
            _ = Init();
        }

        private async UniTaskVoid Init()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = _cancellationTokenSource.Token;

            var presenters = mvpContainer.GetComponentsInChildren<IPresenter>();
            foreach (IPresenter presenter in presenters)
            {
                _presenters.Add(presenter);
                await presenter.Init(cancellationToken);
                await UniTask.Yield();
            }

            onStart?.Invoke(new BaseMessage(), cancellationToken);
        }

        private void OnDestroy()
        {
            foreach (var presenter in _presenters)
            {
                presenter.Dispose();
            }

            if (_cancellationTokenSource == null)
            {
                return;
            }

            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
            _cancellationTokenSource = null;
        }
    }
}