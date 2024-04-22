using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yuen.Music;

namespace Yuen.InGame
{
    public class Goal : MonoBehaviour
    {
        [SerializeField] private GameLoop gameLoop;
        [SerializeField] private VoiceManager voiceManager;
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                voiceManager.PlayGameClearVoice();
                gameLoop.SetGameState(GameLoop.GameState.Result);
            }
        }
    }
}
