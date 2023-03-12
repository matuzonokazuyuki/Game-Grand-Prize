using UniRx;
using Sora_Constans;

namespace Sora_Slill
{
    public class SkillUIPresenter
    {
        private bool skillUsagePossible = false;

        private static IReadSkillModel skillModel;
        private static SkillUIView view;
        private static CharacterMovement movement;

        private CompositeDisposable disposables = new CompositeDisposable();

        public SkillUIPresenter(IReadSkillModel _iReadSkillModel, SkillUIView _view, CharacterMovement _movement)
        {
            skillModel = _iReadSkillModel;
            view = _view;
            movement = _movement;

            skillModel.GetMaxSkillValue()
                .Subscribe(_ => view.Init(skillModel.GetSkillMaxValue(), 0))
                .AddTo(disposables);

            //スキルが使用できるかどうか
            skillModel.GetSkillInvocation()
                .Subscribe(x => skillUsagePossible = x)
                .AddTo(disposables);

            //スキルポイントが追加されたら
            skillModel.GetSkillGagePoint()
                .Subscribe(x => view.SetSkillGage(x))
                .AddTo(disposables);

            //スキルが発動したら
            view.GetSkillButtonClick()
                .Where(_ => skillUsagePossible)
                .Subscribe(_ =>
                {
                    movement.UseSkill(skillModel.GetSkillPower());
                    skillModel.TimerStart();
                    skillModel.ResetSkillGame();
                }).AddTo(disposables);

            skillModel.GetSkillUsingTime()
                .Subscribe(_ => movement.EndSkill(skillModel.GetSkillPower()))
                .AddTo(disposables);
        }

        /// <summary>
        /// スキルアイテムをとったときに実行
        /// </summary>
        /// <param name="_point">追加するポイント</param>
        public static void AddSkillGagePoint(int _point)
        {
            skillModel.AddSkillGagePoint(_point);
        }

        /// <summary>
        /// シーン移動やゲームが終わったときに呼ぶ
        /// </summary>
        public void EndGame()
        {
            disposables.Dispose();
            skillModel.EndGame();
        }
    }
}