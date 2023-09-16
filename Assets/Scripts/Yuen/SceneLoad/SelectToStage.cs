using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Yuen.SceneLoad.StageSelect
{
    public class SelectToStage : MonoBehaviour
    {
        [SerializeField] private LoadingScene loadingScence;

        /// <summary>
        /// ボタンがクリックされた時の処理を記述
        /// </summary>
        /// <param name="id">シーンのID</param>
        public void OnButtonClick(int id)
        {
            loadingScence.StartLoading(id);
        }
    }
}
