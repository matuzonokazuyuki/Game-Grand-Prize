using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yuen.Item
{
    public class ItemGravity : MonoBehaviour
    {
        [SerializeField] int itemGravity;

        BoxCollider itemBox;
        Rigidbody rig;

        //アイテムの重力設定
        public int GetItemGravity()
        {
            return itemGravity;
        }
        private void Start()
        {
            itemBox = GetComponent<BoxCollider>();
            rig = GetComponent<Rigidbody>();
            ItemState(2);
        }

        public void ItemState(int isTake)
        {
            switch (isTake)
            {
                case 0:
                    rig.isKinematic = false;
                    rig.useGravity = true;
                    itemBox.isTrigger = false;
                    break;

                    case 1:
                    rig.useGravity = false;
                    itemBox.isTrigger = false;
                    rig.isKinematic = true;
                    ItemState(2);
                    break;

                    case 2:
                    rig.useGravity = false;
                    itemBox.isTrigger = true;
                    rig.isKinematic = true;
                    break;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Untagged") || collision.gameObject.CompareTag("Cloud"))
            {
                ItemState(1);
            }

        }
    }
}
