using UnityEngine;
using Sora_Slill;
using Sora_Constans;

namespace Sora_System
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField]
        private CharacterMovement movement;
        [SerializeField]
        private SkillUIView skillUI;

        private SkillUIPresenter skillUIPresenter;
        private IReadSkillModel skillModel = new SkillModel();
        void Start()
        {
            skillUIPresenter = new SkillUIPresenter(skillModel, skillUI, movement);
        }

        private void OnDestroy()
        {
            skillUIPresenter.EndGame();
        }
    }
}