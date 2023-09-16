using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Yuen.SceneLoad.Resule
{
    public class GameoverToSelect : MonoBehaviour
    {
        // ボタンがクリックされた時の処理を記述
        public void OnButtonClick()
        {
            SceneManager.LoadScene(1);
        }
    }
}
