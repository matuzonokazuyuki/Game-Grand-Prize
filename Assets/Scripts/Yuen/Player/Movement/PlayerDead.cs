using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yuen.InGame;
using Yuen.Music;
using Yuen_Addressable;
using static Yuen.InGame.GameLoop;

namespace Yuen.Player
{
    public class PlayerDead : MonoBehaviour
    {
        [SerializeField] private PlayerData data;
        [SerializeField] private GameLoop gameLoop;
        [SerializeField] private VoiceManager voiceManager;
        public float playerSurvivalTime;

        public bool used = false;

        public void InitializePlayerDead()
        {
            // ここに初期化
            playerSurvivalTime = data.GetSurvivalTime();
            used = false;
        }

        private void OnTriggerStay(Collider other)
        {
            //DeadZoneに入た後のカウントダウン
            if (other.gameObject.CompareTag("DeadZone"))
            {
                if (playerSurvivalTime > 0) playerSurvivalTime -= Time.deltaTime;

                if (playerSurvivalTime <= 0) 
                {
                    if (!used)
                    {
                        voiceManager.PlayGameOverVoice();
                        used = true;
                    }
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
