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
        private Collider coll;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Item") && !isItemAttached)
            {
                coll = other;
            }
            else
            {
                coll = null;
            }
        }
        //アイテムを取る処理
        public void TakeItem()
        {
            if(!isItemAttached)
            {
                // 衝突したアイテムを子オブジェクトに追加する
                coll.transform.SetParent(transform);
                attachedItem = coll.gameObject;
                isItemAttached = true;
            }
        }
        //アイテムを離す処理
        public void ReleaseItem()
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
}

