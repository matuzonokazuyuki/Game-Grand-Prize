using UnityEngine;
using UniRx;
using System;
using Sora_Result;

namespace Sora_Player
{
    public class PlayerController : MonoBehaviour
    {
        private float screenOutTime = 5f;

        private Subject<Unit> gameOver = new Subject<Unit>();

        private CharacterMovement movement;

        public void Init(CharacterMovement _movement)
        {
            movement = _movement;
        }

        /// <summary>
        /// 画面外に出れる時間
        /// </summary>
        /// <returns>出れる時間</returns>
        public float GetScreenOutTime()
        {
            return screenOutTime;
        }

        /// <summary>
        /// ゲームオーバー処理
        /// </summary>
        public void GameOver()
        {
            gameOver.OnNext(Unit.Default);
            ResultViewPresenter.GameOver();
            // TODO : 風船の処理  
        }

        public IObservable<Unit> GetGameOver()
        {
            return gameOver;
        }
    }
}