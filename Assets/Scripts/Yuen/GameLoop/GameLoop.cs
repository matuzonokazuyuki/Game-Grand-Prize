using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Yuen.Animation;
using Yuen.Item;
using Yuen.Player;
using Yuen.UI;

namespace Yuen.InGame
{
    public class GameLoop : MonoBehaviour
    {
        //参照
        [SerializeField,Header("プレイヤー")] PlayerMove playerMove;
        [SerializeField] PlayerBalloon playerBalloon;
        [SerializeField] PlayerSkill PlayerSkill;
        [SerializeField] PlayerDead playerDead;

        [SerializeField, Header("スキル")] SkillPointSystem skillPointSystem;
        
        [SerializeField, Header("タイマー")] TimerSystem timerSystem;

        [SerializeField, Header("UIのPrefab")] GameObject inGameUI;

        [SerializeField, Header("Animation")] AnimationController animationController; 

        //ゲームの状態
        public enum GameState
        {
            Prepare = 0,
            Main = 1,
            Result = 2,
        }

        private ReactiveProperty<GameState> gameState = new ReactiveProperty<GameState>(GameState.Prepare);
        //public IReadOnlyReactiveProperty<GameState> GetGameState() => gameState;
        public void SetGameState(GameState state) => gameState.Value = state;

        public static GameLoop instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        private void Start()
        {
            //状態変更している時の処理
            gameState
                .Skip(1)
                .Subscribe(state =>
                {
                    Debug.Log(state);
                    switch(state)
                    {
                        case GameState.Prepare:
                            Prepare();
                            break;
                        case GameState.Main:
                            Debug.Log(state);
                            Main();
                            break;
                        case GameState.Result:
                            Result();
                            break;
                        default:
                            Debug.LogError(state.ToString() + "がおかしいよ");
                            break;
                    }

                })
                .AddTo(this);


            gameState.SetValueAndForceNotify(GameState.Prepare);
            gameState.Value = GameState.Main;
        }
        //状態内の処理
        private void Prepare()
        {
            playerMove.InitializePlayer();
            playerBalloon.InitializeBalloon();
            PlayerSkill.InitializeSkill();
            playerDead.InitializePlayerDead();
            skillPointSystem.InitializeSkillPoint();
            timerSystem.ResetTimer();
            animationController.InitializePlayerAnimator();

            inGameUI.SetActive(false);
        }

        private void Main()
        {
            inGameUI.SetActive(true);

            timerSystem.StartTimer();

        }

        private void Result()
        {
            inGameUI.SetActive(false);

            timerSystem.ResetTimer();



        }
        private void OnDestroy()
        {
            instance = null;
        }
    }
}
