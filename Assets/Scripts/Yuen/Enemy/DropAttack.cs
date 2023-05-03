﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yuen.Enemy
{
    public class DropAttack : MonoBehaviour
    {
        [SerializeField, Header("ドロップするもの")] GameObject DropObject;
        [SerializeField, Header("ドロップする場所")] GameObject spawnPoint;

        [SerializeField, Header("判定するの範囲")] Vector3 colliderSize;

        bool isDrop = false;

        private void Start()
        {
            if(DropObject == null || spawnPoint == null)
            {
                Debug.Log("ドロップするものや場所を付けてください");
            }

            BoxCollider collider = GetComponent<BoxCollider>();
            collider.size = colliderSize;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && isDrop == false)
            {
                Instantiate(DropObject, spawnPoint.transform.position, Quaternion.identity);
                isDrop = true;
            }
        }
    }
}