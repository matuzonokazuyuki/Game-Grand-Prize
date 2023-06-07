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
        [SerializeField] PlayerData data;
        [SerializeField] GameLoop gameLoop;
        public float playerSurvivalTime;


        public void InitializePlayerDead()
        {
            // ここに初期化
            playerSurvivalTime = data.GetSurvivalTime();
        }
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag("DeadZone"))
            {
                if (playerSurvivalTime > 0) playerSurvivalTime -= Time.deltaTime;

                if (playerSurvivalTime <= 0) 
                {
                    gameLoop.SetGameState(GameState.Result);
                    playerSurvivalTime = 0;
                }
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("DeadZone"))
            {
                playerSurvivalTime = data.GetSurvivalTime();
            }
        }
    }
}
