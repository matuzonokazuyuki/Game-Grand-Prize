using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yuen.InGame
{
    public class Goal : MonoBehaviour
    {
        [SerializeField] private GameLoop gameLoop;
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                gameLoop.SetGameState(GameLoop.GameState.Result);
            }
        }
    }
}
