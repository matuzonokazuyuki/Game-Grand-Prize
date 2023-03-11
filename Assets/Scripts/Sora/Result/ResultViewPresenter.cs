using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sora_Result
{
    public class ResultViewPresenter
    {
        private static ResultView view;

        /// <summary>
        /// ゲームクリア処理
        /// </summary>
        public static void GameClear()
        {
            view.GameClear();
        }

        /// <summary>
        /// ゲームオーバー処理
        /// </summary>
        public static void GameOver()
        {
            view.GameOver();
        }
    }
}