using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Yuen.Enemy
{
    public class LockSystem : MonoBehaviour
    {
        [SerializeField] GameObject key;
        bool isOpen = true;

        private void Start()
        {
            if(key == null)
            {
                Debug.Log("鍵のゲームオブジェクトをLockSystemがつけているLockに入れてください");
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (!isOpen) return;
            if (other.gameObject == key)
            {
                OpenDoor();
            }
        }
        //ドアを開ける処理
        void OpenDoor()
        {
            //ドアを開く処理
            Debug.Log("ドアーが開きます");
            isOpen = false;

        }
    }
}
