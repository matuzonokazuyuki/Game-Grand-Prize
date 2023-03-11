using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using TMPro;
using Sora_System;

namespace Sora_Result
{
    public class ResultView : MonoBehaviour
    {
        [SerializeField, Header("リザルトテキストを表示する時間")] private float resultTime = 3f;
        [SerializeField, Header("リザルトテキスト")] private TextMeshProUGUI resultText;
        [SerializeField, Header("ゲームクリア画面")] private GameObject ClearPanel;
        [SerializeField, Header("ゲームオーバー画面")] private GameObject GameOverPanel;

        private TimerModel timer = new();

        private CompositeDisposable disposables = new CompositeDisposable();

        private void Start()
        {
            resultText.text = "";
            ClearPanel.SetActive(false);
            GameOverPanel.SetActive(false);
        }

        /// <summary>
        /// クリア時の処理
        /// </summary>
        public void GameClear()
        {
            resultText.text = "GameClear";
            timer.SetTimer(resultTime);
            timer.GetEndTimer()
                .Subscribe(_ => ClearPanel.SetActive(true))
                .AddTo(disposables);
        }

        /// <summary>
        /// ゲームオーバー時の処理
        /// </summary>
        public void GameOver()
        {
            resultText.text = "GameOver";
            timer.SetTimer(resultTime);
            timer.GetEndTimer()
                .Subscribe(_ => GameOverPanel.SetActive(true))
                .AddTo(disposables);
        }

        private void OnDestroy()
        {
            disposables.Dispose();
        }
    }
}