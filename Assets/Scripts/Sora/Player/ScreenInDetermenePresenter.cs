using UniRx;
using Sora_System;

namespace Sora_Player
{
    public class ScreenInDetermenePresenter
    {
        private ScreenInDetermine determine;
        private PlayerController player;
        private TimerModel timer = new TimerModel();

        private CompositeDisposable disposables = new CompositeDisposable();

        public ScreenInDetermenePresenter(ScreenInDetermine _determine, PlayerController _player)
        {
            determine = _determine;
            player = _player;

            determine.GetDetermine()
                .Where(x => !x)
                .Subscribe(_ => timer.SetTimer(player.GetScreenOutTime()))
                .AddTo(disposables);

            determine.GetDetermine()
                .Where(x => x)
                .Subscribe(_ => timer.ClearTimer())
                .AddTo(disposables);

            timer.GetEndTimer()
                .Subscribe(_ =>
                {
                    player.GameOver();
                    timer.EndTimer();
                }).AddTo(disposables);
        }

        /// <summary>
        /// ゲーム終了時にタイマーを止める
        /// </summary>
        public void EndGame()
        {
            disposables.Dispose();
        }
    }
}