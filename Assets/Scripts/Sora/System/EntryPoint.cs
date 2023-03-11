using UnityEngine;
using Sora_Slill;
using Sora_Constans;
using Sora_Player;

namespace Sora_System
{
    public class EntryPoint : MonoBehaviour
    {
        [Header("参照スクリプト")]
        [SerializeField] private CharacterMovement movement;
        [SerializeField] private SkillUIView skillUI;
        [SerializeField] private PlayerController playerController;
        [SerializeField] private ScreenInDetermine screenInDetermine;

        private SkillUIPresenter skillUIPresenter;
        private ScreenInDetermenePresenter screenInDetermenePresenter;
        private IReadSkillModel skillModel = new SkillModel();

        void Start()
        {
            skillUIPresenter = new SkillUIPresenter(skillModel, skillUI, movement);
            screenInDetermenePresenter = new ScreenInDetermenePresenter(screenInDetermine, playerController);
        }

        private void OnDestroy()
        {
            skillUIPresenter.EndGame();
            screenInDetermenePresenter.EndGame();
        }
    }
}