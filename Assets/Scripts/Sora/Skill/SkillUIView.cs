using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;

namespace Sora_Slill
{
    public class SkillUIView : MonoBehaviour
    {
        [SerializeField, Header("スキルゲージ")]
        private Slider SkillGameSlider;

        [SerializeField, Header("スキル発動ボタン")]
        private Button skillButton;

        private Subject<Unit> skillButtonClick = new Subject<Unit>();

        private CompositeDisposable disposables = new CompositeDisposable();

        private void Start()
        {
            skillButton.OnClickAsObservable()
                .Subscribe(_ => skillButtonClick.OnNext(Unit.Default))
                .AddTo(disposables);
        }

        /// <summary>
        /// スキルゲージスライダーの初期化
        /// </summary>
        /// <param name="_maxValue">最大数</param>
        /// <param name="_nowValue">初期値</param>
        public void Init(int _maxValue, int _nowValue)
        {
            SkillGameSlider.maxValue = _maxValue;
            SkillGameSlider.minValue = 0;
            SkillGameSlider.value = _nowValue;
        }

        /// <summary>
        /// スキルポイントの表示
        /// </summary>
        /// <param name="_gagePoint">現在のスキルポイント</param>
        public void SetSkillGage(int _gagePoint)
        {
            SkillGameSlider.value = _gagePoint;
        }

        public void OnDestroy()
        {
            disposables.Dispose();
        }

        public IObservable<Unit> GetSkillButtonClick()
        {
            return skillButtonClick;
        }
    }
}