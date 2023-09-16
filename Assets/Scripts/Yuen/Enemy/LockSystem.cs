using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Yuen.Enemy
{
    public class LockSystem : MonoBehaviour
    {
        [SerializeField] GameObject key;
        [SerializeField] DoorOpen door;
        bool isOpen = true;
        bool openDoor = false;

        private void Start()
        {
            if(key == null)
            {
                Debug.Log("鍵のゲームオブジェクトをLockSystemがつけているLockに入れてください");
            }
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject == key)
            {
                openDoor = true;
            }
        }
        private void FixedUpdate()
        {
            if (openDoor)
            {
                OpenDoor();
            }
        }
        //ドアを開ける処理
        void OpenDoor()
        {
            //ドアを開く処理
            door.Open();
            if (door.transform.position.y >= 15)
            {
                door.Stop();
                openDoor = false;
            }
            Debug.Log("ドアーが開きます");
        }
    }
}
