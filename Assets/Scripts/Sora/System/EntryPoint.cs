using UnityEngine;
using Sora_Slill;

namespace Sora_System
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField]
        private SkillUIView skillUI;

        private SkillUIPresenter skillUIPresenter;
        private IReadSkillModel skillModel = new SkillModel();
        void Start()
        {
            skillUIPresenter = new SkillUIPresenter(skillModel,skillUI);
        }

        private void OnDestroy() {
            skillUIPresenter.EndGame();
        }
    }
}