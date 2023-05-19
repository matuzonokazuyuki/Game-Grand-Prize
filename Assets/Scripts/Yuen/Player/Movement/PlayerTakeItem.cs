﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yuen.Item;
using Yuen.Player;

namespace Yuen.Player
{
    public class PlayerTakeItem : MonoBehaviour
    {
        FixedJoint fixedJoint;
        Rigidbody rb;

        void Start ()
        {
            fixedJoint = gameObject.GetComponent<FixedJoint>();
        }
        //ItemにあったたらそRigidbodyを取る
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Item"))
            {
                rb = other.gameObject.GetComponent<Rigidbody>();
            }
        }
        //アイテムを取る処理
        public void TakeItem()
        {
            fixedJoint.connectedBody = rb;
        }
        //アイテムを離す処理
        public void ReleaseItem()
        {
            fixedJoint.connectedBody = null;
        }

    }
}
