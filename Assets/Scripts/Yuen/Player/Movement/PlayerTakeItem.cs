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
        private bool isItemAttached = false;
        private GameObject attachedItem;

        //ItemにあったたらそRigidbodyを取る
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Item") && !isItemAttached)
            {
                // 衝突したアイテムを子オブジェクトに追加する
                collision.transform.SetParent(transform);
                attachedItem = collision.gameObject;
                isItemAttached = true;
            }
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isItemAttached)
                {
                    // 子オブジェクトとして追加されたアイテムを解除する
                    attachedItem.transform.SetParent(null);
                    attachedItem = null;
                    isItemAttached = false;
                }
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

