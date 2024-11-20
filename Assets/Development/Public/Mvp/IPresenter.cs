using System.Threading;
using Cysharp.Threading.Tasks;

namespace Development.Public.Mvp
{
    public interface IPresenter
    {
        public UniTask Init(CancellationToken cancellationToken);

        public void Dispose();
    }
}