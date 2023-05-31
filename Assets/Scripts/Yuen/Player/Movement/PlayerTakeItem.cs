using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Yuen.Item;
using Yuen.Player;

namespace Yuen.Player
{

    public class PlayerTakeItem : MonoBehaviour
    {
        Rigidbody rb;

        //ItemにあったたらそRigidbodyを取る
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Item"))
            {

            }
        }
        //アイテムを取る処理
        public void TakeItem()
        {

        }
        //アイテムを離す処理
        public void ReleaseItem()
        {

        }

    }
}

