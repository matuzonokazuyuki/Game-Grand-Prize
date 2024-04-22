using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Yuen.Animation;
using Yuen.Enemy;
using Yuen.Enemy.DeathWheel;
using Yuen.Enemy.Elephant;
using Yuen.Item;
using Yuen.Music;
using Yuen.Player;
using Yuen.UI;

namespace Yuen.InGame
{
    public class GameLoop : MonoBehaviour
    {
        [Serializable]
        private class Player
        {
            //参照
            public GameObject playerObject;
            public PlayerMove playerMove;
            public PlayerBalloon playerBalloon;
            public PlayerSkill PlayerSkill;
            public PlayerTakeItem playerTakeItem;
            public PlayerDead playerDead;

        }
        [SerializeField] private Player player;
        [SerializeField, Header("プレイヤーがスポーンする場所")] private GameObject playerSpawn;
        [SerializeField, Header("スキル")] private SkillPointSystem skillPointSystem;
        [SerializeField] private SkillGaugeSystem skillSkillGaugeSystem;
        [SerializeField, Header("バルーンポイント")] private BalloonPointSystem ballBalloonPointSystem;
        [SerializeField, Header("アイテムのポジシリセット")] private ResetItemPosition resetItemPosition;
        [SerializeField] ClownSystem clownSystem;
        [SerializeField, Header("ギミック")] private StopDeathWheelSystem stopDeathWheelSystem;
        [SerializeField] private ElephantMove elephantMove;
        [SerializeField] private TeleportGate teleportGate;

        [SerializeField, Header("タイマー")] private TimerSystem timerSystem;

        [SerializeField, Header("UIのPrefab")] private GameObject inGameUI;
        [SerializeField] private GameObject resultUI;

        [SerializeField, Header("Animation")] private AnimationController animationController;

        [SerializeField, Header("Music & SE")] private VoiceManager voiceManager;

        //ゲームの状態
        public enum GameState
        {
            Prepare = 0,
            Main = 1,
            Result = 2,
        }

        private ReactiveProperty<GameState> gameState = new ReactiveProperty<GameState>(GameState.Prepare);

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
        }
        //状態内の処理
        private void Prepare()
        {
            inGameUI.SetActive(false);
            resultUI.SetActive(false);

            player.playerMove.inTitle = true;
            player.playerMove.inGame = false;

            player.playerBalloon.InitializeBalloon();
            player.playerMove.InitializePlayer();
            player.PlayerSkill.InitializeSkill();
            player.playerDead.InitializePlayerDead();
            player.playerTakeItem.ReleaseItem();
            skillPointSystem.InitializeSkillPoint();
            ballBalloonPointSystem.InitializeBallPoint();
            if(stopDeathWheelSystem != null || elephantMove != null || teleportGate != null)
            {
                stopDeathWheelSystem.ResetSwitch();
                elephantMove.Used(false);
                teleportGate.ResetCamera();
            }
            timerSystem.ResetTimer();
            animationController.InitializeAnimator();

            player.playerObject.transform.position = playerSpawn.transform.position;

            resetItemPosition.ResetPosition();
            clownSystem.ResetClown();

            player.playerObject.GetComponent<PlayerMove>().playerObject.transform.localEulerAngles = new Vector3(0, 90, 0);

            gameState.SetValueAndForceNotify(GameState.Main);
        }

        private void Main()
        {
            inGameUI.SetActive(true);
            skillSkillGaugeSystem.gameObject.SetActive(false);
            resultUI.SetActive(false);

            player.playerMove.inTitle = false;
            player.playerMove.inGame = true;

            voiceManager.StopVoice();
            voiceManager.PlayStartVoice();

            timerSystem.StartTimer();

        }

        private void Result()
        {
            inGameUI.SetActive(false);
            resultUI.SetActive(true);

            player.playerMove.inTitle = true;
            player.playerMove.inGame = false;

            resetItemPosition.ResetPosition();

            timerSystem.ResetTimer();



        }
        private void OnDestroy()
        {
            instance = null;
        }
    }
}
