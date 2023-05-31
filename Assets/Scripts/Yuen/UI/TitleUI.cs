using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Yuen.InGame.GameLoop;
using Yuen.InGame;

namespace Yuen.UI
{
    public class TitleUI : MonoBehaviour
    {
        [SerializeField] GameLoop gameLoop;

        // ボタンがクリックされた時の処理を記述
        public void OnButtonClick()
        {
            Debug.Log("Start");
            ChangeGameState();
        }
        void ChangeGameState()
        {
            gameLoop.SetGameState(GameState.Main);

        }
    }
}
