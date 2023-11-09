using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yuen.Enemy
{
    [RequireComponent(typeof(BoxCollider))]
    public class TeleportGate : MonoBehaviour
    {
        [SerializeField] CameraChange cameraChange;
        [SerializeField] CinemachineVirtualCamera cam;
        [SerializeField, Header("カメラを回転するのテレポートゲートの大きさ調整")] Vector3 colliderSize;


        private void Start()
        {
            BoxCollider collider = GetComponent<BoxCollider>();
            if (collider == null) Debug.Log("ExchangeというゲームオブジェクトにBox Colliderを付けてください");
            collider.size = colliderSize;
        }

        //プレイヤーにあったたら
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (cameraChange.Turned)
                {
                    cam.m_Lens.Dutch = 0;
                    cameraChange.Turned = false;
                }
                else if (!cameraChange.Turned)
                {
                    cam.m_Lens.Dutch = 180;
                    cameraChange.Turned = true;

                }
            }
        }

        //リセット
        public void ResetCamera()
        {
            cam.m_Lens.Dutch = 0;
            cameraChange.Turned = false;
        }
    }
}
