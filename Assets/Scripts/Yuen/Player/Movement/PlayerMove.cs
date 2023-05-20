using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Yuen.Item;
using Yuen.Player;
using Yuen_Addressable;

namespace Yuen.Player
{
    public class PlayerMove : MonoBehaviour
    {
        //参照
        PlayerData data;
        PlayerBalloon playerBalloon;
        PlayerTakeItem playerTakeItem;
        ItemGravity itemGravity;
        PlayerSkill PlayerSkill;

        //設定
        Vector2 moveInput;
        Vector3 gravity;
        float moveSpeed;
        int balloonCount;
        float playerGravity;
        float balloonUpwardQuantity;
        float setGravity;
        float itemsGravity;
        float skillTime;
        float newSkillTime;

        int frameCount = 60;
        int frameTimer = 0;

        //判定
        public bool isSkill;
        bool isTakeItem;

        // Start is called before the first frame update
        async void Start()
        {
            playerBalloon = GetComponent<PlayerBalloon>();
            playerTakeItem = GetComponent<PlayerTakeItem>();
            itemGravity = GetComponent<ItemGravity>();
            PlayerSkill = GetComponent<PlayerSkill>();
            data = await AddressableLoder.AddressLoder<PlayerData>(AddressableAssetAddress.PLAYER_DATA);

            InitializePlayer();
        }
        
        // Update is called once per frame
        void Update()
        {
            PlayerGravity();
            Move();
            PlayerUseSkill();
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
                skillTime = data.GetSkillTime();
            }

            balloonCount = 0;
            itemsGravity = 0;
            newSkillTime = skillTime;

            isSkill = false;
            isTakeItem = false;

        }

        //Itemというタグのオブジェクトにあったたら
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Item"))
            {
                //そのオブジェクトに付けているItemGravityの重力を取る
                itemGravity = other.gameObject.GetComponent<ItemGravity>();
            }

        }

        //playerの重力計算
        void PlayerGravity()
        {
            if (!isSkill)
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
        void Move()
        {
            // 移動
            if (!isSkill)
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
        //プレイヤーがスキルを使う
        void PlayerUseSkill()
        {
            if (!isSkill)
            {
                newSkillTime = skillTime;
                return;
            }
            if (newSkillTime >= 0)
            {
                frameTimer++;
                if (frameTimer >= frameCount)
                {
                    newSkillTime -= 1;
                    frameTimer = 0;
                }
            }
            else if (newSkillTime < 0)
            {
                PlayerSkill.skillCount = 0;
                isSkill = false;
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
            }
            else if(callback.performed)
            {
                moveSpeed = data.GetMoveSpeed();
            }
        }
        //バルーン増える入力
        public void OnAddBalloon(InputAction.CallbackContext callback)
        {
            if (callback.performed)
            {
                if(balloonCount < data.GetMaxBalloonLimit())
                {
                    playerBalloon.AddBalloon();
                    balloonCount++;
                }
            }
        }
        //バルーン減らす入力
        public void OnDestoryBalloon(InputAction.CallbackContext callback)
        {
            if (callback.performed)
            {
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
            if (callback.performed)
            {
                if (!isTakeItem && itemGravity != null)
                {
                    playerTakeItem.TakeItem();
                    itemsGravity = itemGravity.GetItemGravity();
                    isTakeItem = true;
                }
                else
                {
                    playerTakeItem.ReleaseItem();
                    itemsGravity = 0;
                    isTakeItem = false;
                }
            }
        }
        //スキル使用入力
        public void OnUseSkill(InputAction.CallbackContext callback)
        {
            if (callback.performed)
            {
                if (PlayerSkill.canSkill)
                {
                    isSkill = true;
                }
            }
        }

        #endregion

    }
}
