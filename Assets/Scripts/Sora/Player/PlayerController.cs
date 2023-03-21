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

        private void Awake()
        {
            movement = GetComponent<CharacterMovement>();
        }

        private void Start()
        {
            movement.GetDeadFlag()
                .Subscribe(_ => GameOver())
                .AddTo(this);
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
            movement.BalloonAllDestroy();
        }

        public IObservable<Unit> GetGameOver()
        {
            return gameOver;
        }
    }
}