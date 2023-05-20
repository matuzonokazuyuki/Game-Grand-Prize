using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Yuen.Item;
using Yuen.Player;
using Yuen.UI;

namespace Yuen.InGame
{
    public class GameLoop : MonoBehaviour
    {
        //参照
        [SerializeField] PlayerMove playerMove;
        [SerializeField] PlayerBalloon playerBalloon;
        [SerializeField] PlayerSkill PlayerSkill;

        [SerializeField] GameObject skillUI;
        [SerializeField] SkillPointSystem point;


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
                .Subscribe(state =>
                {
                    Debug.Log(state);
                    switch(state)
                    {
                        case GameState.Prepare:
                            Prepare();
                            break;
                        case GameState.Main:
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
        }
        //状態内の処理
        private void Prepare()
        {
            playerMove.InitializePlayer();
            playerBalloon.InitializeBalloon();
            PlayerSkill.InitializeSkill();
            point.InitializeSkillPoint();
        }

        private void Main()
        {
            skillUI.SetActive(true);

        }

        private void Result()
        {
            skillUI.SetActive(false);

        }
        private void OnDestroy()
        {
            instance = null;
        }
    }
}
