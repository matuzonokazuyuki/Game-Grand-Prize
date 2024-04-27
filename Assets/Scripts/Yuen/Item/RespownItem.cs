using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace Yuen.Item
{
    public class RespownItem : MonoBehaviour
    {
        private Vector3 nowPosition;

        private void Awake()
        {
            nowPosition = transform.position;
        }

        //アイテムのリスポーン
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("DeadZone"))
            {
                DelayRespown().Forget();
            }
        }

        private async UniTask DelayRespown()
        {
            await UniTask.Delay(System.TimeSpan.FromSeconds(0.5f));
            transform.position = nowPosition;
        }
    }
}
