namespace Sora_Result
{
    public class ResultViewPresenter
    {
        private static ResultView view;

        public ResultViewPresenter(ResultView _view)
        {
            view = _view;
        }

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