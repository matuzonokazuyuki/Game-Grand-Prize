using System;
using UniRx;

namespace Sora_Constans
{
    public interface IReadSkillModel
    {
        void AddSkillGagePoint(int _point);
        void InitLoad();
        void ResetSkillGame();
        void TimerStart();
        void EndGame();
        int GetSkillPower();
        int GetSkillMaxValue();
        IObservable<int> GetSkillGagePoint();
        IObservable<Unit> GetMaxSkillValue();
        IObservable<bool> GetSkillInvocation();
        IObservable<Unit> GetSkillUsingTime();
    }
}