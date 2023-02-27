using UniRx;

namespace Sora_Slill
{
    public class SkillUIPresenter
    {
        private bool skillUsagePossible = false;

        private static IReadSkillModel skillModel;
        private static SkillUIView view;

        private CompositeDisposable disposables = new CompositeDisposable();

        public SkillUIPresenter(IReadSkillModel _iReadSkillModel, SkillUIView _view)
        {
            skillModel = _iReadSkillModel;
            view = _view;

            view.Init(skillModel.GetSkillMaxValue(),0);

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
                .Subscribe(_ => skillModel.ResetSkillGame())
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
        }
    }
}