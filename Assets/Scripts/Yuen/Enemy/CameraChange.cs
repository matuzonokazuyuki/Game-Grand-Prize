using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Yuen.Enemy
{
    [RequireComponent(typeof(BoxCollider))]
    public class CameraChange : MonoBehaviour
    {
        [SerializeField, Header("カメラを回転するのテレポートゲートの大きさ調整")] Vector3 colliderSize;
        [SerializeField] CinemachineVirtualCamera cam;
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
                    cam.m_Lens.Dutch = 180;
                    isTurn = false;
                }
                else if (!isTurn)
                {
                    cam.m_Lens.Dutch = 0;
                    isTurn = true;

                }
            }
        }
    }
}
