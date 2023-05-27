using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using UnityEngine;
using UnityEngine.InputSystem;
using Yuen.Player;
using Yuen.UI;
using Yuen_Addressable;

namespace Yuen.Player
{
    public class PlayerBalloon : MonoBehaviour
    {   
        //balloonのspawnのポジション
        [SerializeField] Transform spawnPoint;
        int horizontalSpawwnCount = 0;
        float verticalSpawnCount = 0;

        //balloonのリスト
        string[] address =
        {
            AddressableAssetAddress.BALLOON_BLUE,
            AddressableAssetAddress.BALLOON_RED,
            AddressableAssetAddress.BALLOON_ORANGE,
            AddressableAssetAddress.BALLOON_YELLOW,
            AddressableAssetAddress.BALLOON_GREEN
        };

        //ランダム生成
        int rad;
        GameObject instance;
        public List<GameObject> balloons = new List<GameObject>();

        //balloonのアニメション
        Animator balloonAnimator;

        //balloonのUI
        PlayerData data;
        public int balloonLimit;
        [SerializeField] BalloonUI balloonUI;

        private async void Awake()
        {
            data = await AddressableLoder.AddressLoder<PlayerData>(AddressableAssetAddress.PLAYER_DATA);
            InitializeBalloon();
        }
        //バルーンの初期化
        public void InitializeBalloon()
        {
            if (data != null)
            {
                balloonLimit = data.GetMaxBalloonLimit();
            }

            balloonUI.UpdateBalloonLimit(balloonLimit);
            
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
                balloonAnimator.SetBool("BreakBalloon", false);
                //バルーンを消す
                Destroy(balloon);
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
    }
}
