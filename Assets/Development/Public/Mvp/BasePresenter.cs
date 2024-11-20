using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Development.Public.Mvp
{
    public abstract class
        BasePresenter<TView, TModel, TEvents> : MonoBehaviour, IPresenter
        where TModel : IModel
        where TView : IView
        where TEvents : IEvents
    {
        protected CancellationToken CancellationToken;

        [SerializeField] protected TModel model;
        [SerializeField] protected TView view;
        [SerializeField] protected TEvents events;

        public async UniTask Init(CancellationToken cancellationToken)
        {
            CancellationToken = cancellationToken;
            await InitPresenter();
        }

        protected abstract UniTask InitPresenter();

        public abstract void Dispose();
    }
}