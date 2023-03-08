using UniRx;
using System;
using Sora_Constans;

namespace Sora_Slill
{
    public class SkillModel : IReadSkillModel
    {
        private int maxValue = 100;
        private int skillPower = 10;

        private float seconds = 10f;

        private ReactiveProperty<int> skillGagePoint = new ReactiveProperty<int>(0);
        private Subject<bool> skillInvocation = new Subject<bool>();
        private Subject<Unit> skillUsingTime = new Subject<Unit>();

        private CompositeDisposable disposables = new CompositeDisposable();

        /// <summary>
        /// スキルゲージを追加する
        /// </summary>
        /// <param name="_point">追加するポイント</param>
        public void AddSkillGagePoint(int _point)
        {
            skillGagePoint.Value += _point;
            if (skillGagePoint.Value >= maxValue)
            {
                skillInvocation.OnNext(true);
            }
        }

        /// <summary>
        /// スキルゲージをリセットする
        /// </summary>
        public void ResetSkillGame()
        {
            skillGagePoint.Value = 0;
            skillInvocation.OnNext(false);
        }

        /// <summary>
        /// タイマーをスタートさせる
        /// </summary>
        public void TimerStart()
        {
            Observable.Timer(TimeSpan.FromSeconds(seconds))
                .Take(1)
                .Subscribe(_ => skillUsingTime.OnNext(Unit.Default))
                .AddTo(disposables);
        }

        /// <summary>
        /// ゲーム終了時やシーン移動時に購読をやめる
        /// </summary>
        public void EndGame()
        {
            disposables.Dispose();
        }

        /// <summary>
        /// スキル使用時の前に進む力を返す
        /// </summary>
        /// <returns>進む力</returns>
        public int GetSkillPower()
        {
            return skillPower;
        }

        /// <summary>
        /// スキルゲージの最大値を渡す
        /// </summary>
        /// <returns>ゲージの最大値</returns>
        public int GetSkillMaxValue()
        {
            return maxValue;
        }

        /// <summary>
        /// スキルゲージの変更を監視する
        /// </summary>
        public IObservable<int> GetSkillGagePoint()
        {
            return skillGagePoint;
        }

        /// <summary>
        /// スキルが発動できるかの監視
        /// </summary>
        public IObservable<bool> GetSkillInvocation()
        {
            return skillInvocation;
        }

        /// <summary>
        /// スキルの使用時間
        /// </summary>
        public IObservable<Unit> GetSkillUsingTime()
        {
            return skillUsingTime;
        }
    }
}