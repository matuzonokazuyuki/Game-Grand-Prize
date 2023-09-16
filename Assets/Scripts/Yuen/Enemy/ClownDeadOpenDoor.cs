using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

namespace Yuen.Enemy
{
    public class ClownDeadOpenDoor : MonoBehaviour
    {
        [SerializeField] DoorOpen openDoor;
        [SerializeField] GameObject rock;
        bool isOpen;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject == rock)
            {
                isOpen = true;
            }
        }
        private void FixedUpdate()
        {
            if (isOpen)
            {
                OpenDoor();
            }

        }
        void OpenDoor()
        {
            //ドアを開く処理
            openDoor.Open();
            if (openDoor.transform.position.y >= 15)
            {
                openDoor.Stop();
                isOpen = false;
                Dead();
            }
            Debug.Log("ドアーが開きます");
        }

        void Dead()
        {
            this.gameObject.SetActive(false);
        }
    }
}
