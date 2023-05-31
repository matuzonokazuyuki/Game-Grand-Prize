using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Yuen.UI
{
    public class ExitButton : MonoBehaviour
    {
        public void OnButtonClick()
        {
            // ボタンがクリックされた時の処理を記述
            Debug.Log("Exit Game");
            QuitGame();
        }

        private void QuitGame()
        {
            // ゲームを終了する
            Application.Quit();
        }
    }
}
