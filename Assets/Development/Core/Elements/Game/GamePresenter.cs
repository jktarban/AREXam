using Cysharp.Threading.Tasks;
using Development.Public.Managers;
using Development.Public.Mvp;
using Development.Public.Mvp.Messages;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Management;

namespace Development.Core.Elements.Game
{
    public class GamePresenter : BasePresenter<GameView, GameModel, GameEvents>
    {
        protected override async UniTask InitPresenter()
        {
            StartARSession().Forget();
            AudioManager.Instance.PlayBgm(model.ConfigData.GameAudio).Forget();
            view.OnRetryButtonClicked(OnRetryButtonClicked);
            model.StartTimer(OnTimeUpdate, OnTimerEnd, CancellationToken).Forget();
            await UniTask.CompletedTask;
        }

        private void OnRetryButtonClicked()
        {
            StopARSession();
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }

        private async UniTaskVoid StartARSession()
        {
            await XRGeneralSettings.Instance.Manager.InitializeLoader();
            XRGeneralSettings.Instance.Manager.StartSubsystems();
        }

        private void StopARSession()
        {
            XRGeneralSettings.Instance.Manager.StopSubsystems();
            XRGeneralSettings.Instance.Manager.DeinitializeLoader();
        }

        public void AddEnemyKill(BaseMessage message)
        {
            model.AddEnemyKill();
            view.UpdateEnemyKillCount(model.EnemyKillCount);
        }

        private void OnTimerEnd()
        {
            view.ShowTimeUp();
            events?.OnGameOver.Invoke(new BaseMessage(), CancellationToken);
        }

        private void OnTimeUpdate(int time)
        {
            view.UpdateTimer(time);
        }


        public override void Dispose()
        {
        }
    }
}