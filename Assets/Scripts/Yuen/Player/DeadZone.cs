using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Yuen.InGame.GameLoop;
using Yuen.InGame;
using Yuen.Music;

namespace Yuen.Player
{
    public class DeadZone : MonoBehaviour
    {
        [SerializeField] private VoiceManager voiceManager;
        public float playerSurvivalTime;
        bool isDead = false;
        bool a = true;

        private void Update()
        {
            if (a)
            {
                if (isDead)
                {
                    voiceManager.PlayGameOverVoice();
                    isDead = false;
                    a = false;
                }

            }
        }

        private void OnTriggerStay(Collider other)
        {
            //DeadZoneに入た後のカウントダウン
            if (other.gameObject.CompareTag("Player"))
            {
                if (playerSurvivalTime > 0) playerSurvivalTime -= Time.deltaTime;

                if (playerSurvivalTime <= 0)
                {
                    isDead = true;
                    playerSurvivalTime = 0;
                }
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                playerSurvivalTime = 3f;
            }
        }

    }
}
