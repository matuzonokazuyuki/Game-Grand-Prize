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
        [SerializeField, Header("プレイヤーがスポーンする場所")] GameObject playerSpawn;
        [SerializeField, Header("プレイヤー")] GameObject playerObject;
        [SerializeField] PlayerMove playerMove;
        [SerializeField] PlayerBalloon playerBalloon;
        [SerializeField] PlayerSkill PlayerSkill;
        [SerializeField] PlayerTakeItem playerTakeItem;
        [SerializeField] PlayerDead playerDead;

        [SerializeField, Header("スキル")] SkillPointSystem skillPointSystem;
        
        [SerializeField, Header("タイマー")] TimerSystem timerSystem;

        [SerializeField, Header("UIのPrefab")] GameObject inGameUI;
        [SerializeField] GameObject titleUI;
        [SerializeField] GameObject resultUI;

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
            //gameState.Value = GameState.Main;
        }
        //状態内の処理
        private void Prepare()
        {
            titleUI.SetActive(true);
            inGameUI.SetActive(false);
            resultUI.SetActive(false);

            playerMove.inTitle = true;
            playerMove.inGame = false;

            playerBalloon.InitializeBalloon();
            playerMove.InitializePlayer();
            PlayerSkill.InitializeSkill();
            playerDead.InitializePlayerDead();
            playerTakeItem.ReleaseItem();
            skillPointSystem.InitializeSkillPoint();
            timerSystem.ResetTimer();
            animationController.InitializePlayerAnimator();

            playerObject.transform.position = playerSpawn.transform.position;
            playerObject.GetComponent<PlayerMove>().playerObject.transform.localEulerAngles = new Vector3(0, 90, 0);
        }

        private void Main()
        {
            titleUI.SetActive(false);
            inGameUI.SetActive(true);
            resultUI.SetActive(false);

            playerMove.inTitle = false;
            playerMove.inGame = true;

            timerSystem.StartTimer();


        }

        private void Result()
        {
            inGameUI.SetActive(false);
            titleUI.SetActive(false);
            resultUI.SetActive(true);

            playerMove.inTitle = true;
            playerMove.inGame = false;

            timerSystem.ResetTimer();



        }
        private void OnDestroy()
        {
            instance = null;
        }
    }
}
