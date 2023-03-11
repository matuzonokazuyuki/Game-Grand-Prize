using UnityEngine;
using UniRx;
using System;

namespace Sora_System
{
    public class TimerModel
    {
        private float limit;
        private float count = 0;

        private Subject<Unit> endTimer = new();

        private CompositeDisposable disposables = new();

        /// <summary>
        /// タイマーのスタート
        /// </summary>
        /// <param name="timeLimit"></param>
        public void SetTimer(float timeLimit)
        {
            limit = timeLimit;
            RestertTimer();

            Observable.EveryUpdate()
                .Subscribe(_ =>
                {
                    count += Time.deltaTime;
                    if (count > limit)
                    {
                        endTimer.OnNext(Unit.Default);
                    }
                }).AddTo(disposables);
        }
        /// <summary>
        /// タイマーリセット
        /// </summary>
        public void RestertTimer()
        {
            count = 0;
        }
        /// <summary>
        /// タイマーの削除
        /// </summary>
        public void ClearTimer()
        {
            disposables.Clear();
        }
        /// <summary>
        /// タイマーを終わらせる
        /// </summary>
        public void EndTimer()
        {
            disposables.Dispose();
        }
        public IObservable<Unit> GetEndTimer()
        {
            return endTimer;
        }
    }
}