using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Yuen.SceneLoad;

namespace Yuen.UI
{
    public class ExitButton : MonoBehaviour
    {
        public void OnButtonClick()
        {
            // ボタンがクリックされた時の処理を記述
            Debug.Log("Exit Game");
            ToTitle();
        }

        // ゲームを終了する
        private void QuitGame()
        {
            Application.Quit();
        }
        //タイトル画面に戻る
        private void ToTitle()
        {
            SceneManager.LoadScene(0);
        }
    }
}
