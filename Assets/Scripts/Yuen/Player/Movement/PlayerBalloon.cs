using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using UnityEngine;
using UnityEngine.InputSystem;
using Yuen.Player;
using Yuen_Addressable;

namespace Yuen.Player
{
    public class PlayerBalloon : MonoBehaviour
    {       
        [SerializeField] Transform spawnPoint;

        string[] address =
        {
            AddressableAssetAddress.BALLOON_BLUE,
            AddressableAssetAddress.BALLOON_RED,
            AddressableAssetAddress.BALLOON_ORANGE,
            AddressableAssetAddress.BALLOON_YELLOW,
            AddressableAssetAddress.BALLOON_GREEN
        };
        int rad;

        GameObject instance;
        public List<GameObject> balloons = new List<GameObject>();
        int horizontalSpawwnCount = 0;
        float verticalSpawnCount = 0;

        private void Start()
        {
            InitializeBalloon();
        }
        //バルーンの初期化
        public void InitializeBalloon()
        {
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
            balloons.Add(instance);
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

                balloons.Remove(balloon);
                Destroy(balloon);
                if(instance != null)
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
    }
}
