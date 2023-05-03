using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yuen.Enemy
{
    [RequireComponent(typeof(BoxCollider))]
    public class CameraChange : MonoBehaviour
    {
        [SerializeField, Header("カメラを回転するのテレポートゲートの大きさ調整")] Vector3 colliderSize;
        bool isTurn = true;

        private void Start()
        {
            BoxCollider collider = GetComponent<BoxCollider>();
            if (collider == null) Debug.Log("ExchangeというゲームオブジェクトにBox Colliderを付けてください");
            collider.size = colliderSize;
        }
        //Triggerの範囲に入ったらカメラを回転する
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (isTurn)
                {
                    Camera.main.transform.rotation = Quaternion.Euler(0, 0, 180f);
                    isTurn = false;
                }
                else if (!isTurn)
                {
                    Camera.main.transform.rotation = Quaternion.Euler(0, 0, 0);
                    isTurn = true;

                }
            }

        }
    }
}
