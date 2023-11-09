using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Yuen.Animation;
using Yuen.InGame;
using Yuen.Item;
using Yuen.Music;
using Yuen.Player;
using Yuen.UI;
using Yuen_Addressable;
using static Yuen.InGame.GameLoop;

namespace Yuen.Player
{
    public class PlayerMove : MonoBehaviour
    {
        //参照
        [SerializeField] private PlayerData data;
        private PlayerBalloon playerBalloon;
        private PlayerTakeItem playerTakeItem;
        private ItemGravity itemGravity;
        private PlayerSkill PlayerSkill;
        private PlayerDead playerDead;
        [SerializeField] private GameLoop gameLoop;
        public GameObject playerObject;
        [SerializeField] private GameObject animationObject;
        private AnimationController animationController;
        [SerializeField] VoiceManager voiceManager;


        //設定
        private Vector2 moveInput;
        private Vector3 gravity;
        private float moveSpeed;
        private int balloonCount;
        private float playerGravity;
        private float balloonUpwardQuantity;
        private float setGravity;
        private float itemsGravity;

        //判定
        private bool isTakeItem;
        public bool inGame;
        public bool inTitle;
        private bool isInflate;

        // Start is called before the first frame update
        private void Awake()
        {
            playerBalloon = GetComponent<PlayerBalloon>();
            playerTakeItem = GetComponent<PlayerTakeItem>();
            itemGravity = GetComponent<ItemGravity>();
            PlayerSkill = GetComponent<PlayerSkill>();
            playerDead = GetComponent<PlayerDead>();
            animationController = animationObject.GetComponent<AnimationController>();

        }

        // Update is called once per frame
        private void Update()
        {
            if (inTitle) return;

            PlayerGravity();
            Move();
        }

        //プレイヤーの初期化
        public void InitializePlayer()
        {
            // dataオブジェクトがnullでないことを確認する
            if (data != null)
            {
                // ここに初期化
                moveSpeed = data.GetMoveSpeed();
                balloonUpwardQuantity = data.GetUpwardQuantity();
                playerGravity = data.GetPlayerGravity();
            }

            balloonCount = 0;
            itemsGravity = 0;

            isTakeItem = false;
            inGame = false;
            isInflate = false;

            for (int i = 0; i < 3; i++)
            {
                playerBalloon.AddBalloon();
                balloonCount++;
            }

        }

        //Itemというタグのオブジェクトにあったたら
        private void OnCollisionEnter(Collision collision)
        {
            if (PlayerSkill.isSkill) return;

            //刺がある壁にあったたら風船が一つ消える
            if (collision.gameObject.CompareTag("DamageWall"))
            {
                if (playerBalloon.balloons != null && balloonCount > 0)
                {
                    animationController.OnHitAnimation(true);
                    playerBalloon.RemoveBalloon();
                    balloonCount--;
                    voiceManager.PlayHitVoice();
                    Invoke(nameof(InvokeHitAnimation), 2f);
                }
                else if(playerBalloon.balloons == null && balloonCount <= 0)
                {
                    animationController.OnDeadAnimation(true);
                    voiceManager.PlayGameOverVoice();
                    gameLoop.SetGameState(GameState.Result);
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Item"))
            {
                //そのオブジェクトに付けているItemGravityの重力を取る
                itemGravity = other.gameObject.GetComponent<ItemGravity>();
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Item")) 
            {
                itemGravity = null;
            }
        }


        //playerの重力計算
        private void PlayerGravity()
        {
            if (!PlayerSkill.isSkill)
            {
                setGravity = balloonUpwardQuantity * balloonCount - playerGravity - itemsGravity;

                gravity = new Vector3(0f, setGravity, 0f);

                transform.Translate(gravity * Time.deltaTime);
            }
            else
            {
                setGravity = 0f;
            }   
        }

        //プレイヤーの移動計算
        private void Move()
        {
            if (!inGame) return;
            if (isInflate) return;

            // 移動
            if (!PlayerSkill.isSkill)
            {
                Vector3 movement = new Vector3(moveInput.x, 0f, 0f);
                transform.Translate(movement * moveSpeed * Time.deltaTime);
            }
            else
            {
                Vector3 movement = new Vector3(moveInput.x, moveInput.y, 0f);
                transform.Translate(movement * moveSpeed * Time.deltaTime);
            }
        }

        //Unity New Input System
        #region New Input System
        //移動入力
        public void OnMove(InputAction.CallbackContext callback)
        {

            moveInput = callback.ReadValue<Vector2>();

            if (callback.canceled)
            {
                moveInput = Vector2.zero;
                moveSpeed = 0;
                animationController.OnMoveAnimation(false);
            }
            else if(callback.performed)
            {
                if (moveInput.x > 0)
                {
                    playerObject.transform.localEulerAngles = new Vector3(0, 90, 0);
                }
                else if (moveInput.x < 0)
                {
                    playerObject.transform.localEulerAngles = new Vector3(0, -90, 0);
                }
                moveSpeed = data.GetMoveSpeed();
                animationController.OnMoveAnimation(true);
            }
        }
        //バルーン増える入力
        public void OnAddBalloon(InputAction.CallbackContext callback)
        {
            if (callback.performed)
            {
                if (!inGame) return;

                if(balloonCount < data.GetMaxBalloonLimit() 
                    && playerBalloon.balloonLimit > 0)
                {
                    animationController.OnInflateAnimation(true);
                    isInflate = true;
                    playerBalloon.AddBalloon();
                    balloonCount++;
                    voiceManager.PlayBalloonVoice();
                    Invoke(nameof(InvokeInflateAnimation), 0.5f);
                }
            }
        }
        //バルーン減らす入力
        public void OnDestoryBalloon(InputAction.CallbackContext callback)
        {
            if (callback.performed)
            {
                if (!inGame) return;

                if (playerBalloon.balloons != null && balloonCount > 0)
                {
                    playerBalloon.RemoveBalloon();
                    balloonCount--;
                }
            }
        }
        //アイテムを取るか離すかの入力
        public void TakeItem(InputAction.CallbackContext callback)
        {
            if (callback.performed && inGame)
            {
                if(itemGravity == null)
                {
                    Debug.LogError("アイテムに当たってないよ");
                }
                else if (!isTakeItem 
                    && itemGravity != null)
                {
                    playerTakeItem.TakeItem();
                    itemGravity.ItemState(2);
                    itemsGravity = itemGravity.GetItemGravity();
                    isTakeItem = true;
                }
                else
                {
                    itemsGravity = 0;
                    itemGravity.ItemState(0);
                    playerTakeItem.ReleaseItem();
                    itemGravity = null;
                    isTakeItem = false;
                }
            }
        }
        //スキル使用入力
        public void OnUseSkill(InputAction.CallbackContext callback)
        {
            if (callback.performed)
            {
                if (inGame 
                    && PlayerSkill.canSkill)
                {
                    voiceManager.PlaySkillVoice();

                    PlayerSkill.isSkill = true;
                }
                else if (inTitle)
                {
                    gameLoop.SetGameState(GameState.Main);
                }

            }
        }

        #endregion

        private async UniTask DelayDead()
        {
            await UniTask.Delay(System.TimeSpan.FromSeconds(0.5f));
            gameLoop.SetGameState(GameState.Result);
        }

        private void InvokeInflateAnimation()
        {
            animationController.OnInflateAnimation(false);
            isInflate =false;
        }
        private void InvokeHitAnimation()
        {
            animationController.OnHitAnimation(false);
        }
    }
}
