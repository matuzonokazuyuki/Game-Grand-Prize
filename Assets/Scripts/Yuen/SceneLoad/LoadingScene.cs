using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Yuen.SceneLoad
{
    public class LoadingScene : MonoBehaviour
    {
        [SerializeField] private GameObject loadingUI;
        [SerializeField] private Slider loadingBar;

        private void Awake()
        {
            loadingUI.SetActive(false);
        }

        /// <summary>
        /// 他のスクリプトからシーンをロードする
        /// </summary>
        /// <param name="id">シーンのID</param>
        public void StartLoading(int id)
        {
            loadingUI.SetActive(true);
            StartCoroutine(LoadScene(id));
        }

        /// <summary>
        /// シーンをロードするためのコルーチン
        /// </summary>
        /// <param name="id">シーンのID</param>
        /// <returns>null</returns>
        IEnumerator LoadScene(int id)
        {
            var async = SceneManager.LoadSceneAsync(id);
            while (!async.isDone)
            {
                Debug.Log(async.progress);
                loadingBar.value = async.progress;
                yield return null;
            }
        }
    }
}
