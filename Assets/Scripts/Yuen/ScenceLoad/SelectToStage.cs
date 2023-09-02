using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Yuen.SceneLoad.StageSelect
{
    public class SelectToStage : MonoBehaviour
    {
        // ボタンがクリックされた時の処理を記述
        public void OnButtonClick(int id)
        {
            SceneManager.LoadScene(id);
        }
    }
}
