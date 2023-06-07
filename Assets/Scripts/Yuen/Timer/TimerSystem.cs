using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yuen.UI;
using static Yuen.InGame.GameLoop;

namespace Yuen.InGame
{
    public class TimerSystem : MonoBehaviour
    {
        [SerializeField] GameLoop gameLoop;
        [SerializeField] private TimeUI timeUI;
        [SerializeField, Header("カウントダウンタイマー(秒数)")] public float resetTimer = 180;
        float timer;
        bool startTimer;

        private void Update()
        {
            if (timeUI == null)
            {
                Debug.Log("TimeUIがnull");
            }
            if (startTimer)
            {
                timer -= Time.deltaTime;
                timeUI.TextUpdate((int)timer);
            }
            if (timer <= 0)
            {
                startTimer = false;
                gameLoop.SetGameState(GameState.Result);
            }
        }
        //タイマーのリセット
        public void ResetTimer()
        {
            startTimer = false;
            timer = resetTimer;

        }
        //タイマーのスタート
        public void StartTimer()
        {
            startTimer = true;
        }
    }
}
