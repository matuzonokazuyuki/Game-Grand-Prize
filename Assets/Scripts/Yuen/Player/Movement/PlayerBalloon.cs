using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using UnityEngine;
using UnityEngine.InputSystem;
using Yuen.Player;
using Yuen.UI;
using Yuen_Addressable;
using Cysharp.Threading.Tasks;

namespace Yuen.Player
{
    public class PlayerBalloon : MonoBehaviour
    {   
        //balloonのspawnのポジション
        [SerializeField] private Transform spawnPoint;
        private int horizontalSpawwnCount = 0;
        private float verticalSpawnCount = 0;

        //balloonのリスト
        private string[] address =
        {
            AddressableAssetAddress.BALLOON_BLUE,
            AddressableAssetAddress.BALLOON_RED,
            AddressableAssetAddress.BALLOON_ORANGE,
            AddressableAssetAddress.BALLOON_YELLOW,
            AddressableAssetAddress.BALLOON_GREEN
        };

        //ランダム生成
        private int rad;
        private GameObject instance;
        public List<GameObject> balloons = new List<GameObject>();

        //balloonのアニメション
        private Animator balloonAnimator;

        //balloonのUI
        [SerializeField] private PlayerData data;
        public int balloonLimit;
        [SerializeField] private BalloonUI balloonUI;

        //バルーンの初期化
        public void InitializeBalloon()
        {
            balloonLimit = data.GetMaxBalloonLimit();
            balloonUI.UpdateBalloonLimit(balloonLimit);

            for (int i = balloons.Count; i > 0; i--)
            {
                RemoveBalloon();
            }

            horizontalSpawwnCount = 0;
            verticalSpawnCount = 0f;
        }
        //バルーン増えるの処理
        public async void AddBalloon()
        {
            rad = Random.Range(0, address.Length);
            GameObject balloon = await AddressableLoder.AddressLoder<GameObject>(address[rad]);
            //ランダム生成
            instance = Instantiate(balloon, spawnPoint);
            //balloonUIの変更
            balloonLimit--;
            balloonUI.UpdateBalloonLimit(balloonLimit);
            //balloonのアニメーションコントローラー
            balloonAnimator = instance.GetComponent<Animator>();
            balloonAnimator.SetBool("MakeBalloon", true);
            balloons.Add(instance);
            balloonAnimator.SetBool("MakeBalloon", false);
            //balloonのspawnのポジション変更
            instance.transform.localPosition = new Vector3(0.3f * horizontalSpawwnCount, verticalSpawnCount, 0f);

            if(horizontalSpawwnCount < 5)
            horizontalSpawwnCount++;

            if (horizontalSpawwnCount == 5)
            {
                horizontalSpawwnCount = 0;
                verticalSpawnCount = 0.5f;
            }
        }
        //バルーンを消す処理
        public void RemoveBalloon()
        {
            if (balloons.Count > 0)
            {
                //バルーンを順番に消す
                GameObject balloon = balloons.Last();
                //balloonのアニメーションコントローラー
                balloonAnimator = balloon.GetComponent<Animator>();
                balloonAnimator.SetBool("BreakBalloon", true);
                balloons.Remove(balloon);
                //バルーンを消す
                DestroyBalloon(balloon).Forget();
                //balloonのspawnのポジション変更
                if (instance != null)
                instance.transform.localPosition = new Vector3(0.3f * horizontalSpawwnCount, verticalSpawnCount, 0f);

                if (horizontalSpawwnCount >= 0)
                horizontalSpawwnCount--;

                if(horizontalSpawwnCount == -1)
                {
                    horizontalSpawwnCount = 4;
                    verticalSpawnCount = 0f;
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("BalloonPoint") &&
                balloonLimit <= data.GetBalloonStricMaxLimit())
            {
                balloonLimit++;
                balloonUI.UpdateBalloonLimit(balloonLimit);
            }
        }
        /// <summary>
        /// objをDestoryする
        /// </summary>
        /// <param name="obj">オブジェクト(Balloon)</param>
        /// <returns></returns>
        private async UniTask DestroyBalloon(GameObject obj)
        {
            await UniTask.Delay(System.TimeSpan.FromSeconds(0.5f));
            Destroy(obj);
        }
    }
}
