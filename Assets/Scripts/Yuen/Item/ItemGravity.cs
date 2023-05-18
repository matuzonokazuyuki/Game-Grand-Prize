using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yuen.Item
{
    public class ItemGravity : MonoBehaviour
    {
        [SerializeField] int itemGravity;

        //アイテムの重力設定
        public int GetItemGravity()
        {
            return itemGravity;
        }

    }
}
