using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yuen.InGame;
using Yuen_Addressable;
using static Yuen.InGame.GameLoop;

namespace Yuen.Player
{
    public class PlayerDead : MonoBehaviour
    {
        PlayerData data;
        [SerializeField] GameLoop gameLoop;
        float playerSurvivalTime;


        // Start is called before the first frame update
        async void Awake()
        {
            data = await AddressableLoder.AddressLoder<PlayerData>(AddressableAssetAddress.PLAYER_DATA);
            InitializePlayerDead();

        }
        public void InitializePlayerDead()
        {
            // dataオブジェクトがnullでないことを確認する
            if (data != null)
            {
                // ここに初期化
                playerSurvivalTime = data.GetSurvivalTime();
                Debug.Log(playerSurvivalTime);
            }
        }
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag("DeadZone"))
            {
                if (playerSurvivalTime > 0) playerSurvivalTime -= Time.deltaTime;
                if (playerSurvivalTime == 0) IsPlayerDead();
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("DeadZone"))
            {
                playerSurvivalTime = data.GetSurvivalTime();
            }
        }

        public void IsPlayerDead()
        {
            gameLoop.SetGameState(GameState.Result);
        }
    }
}
