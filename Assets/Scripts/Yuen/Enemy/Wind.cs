using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yuen.Enemy
{
    public class Wind : MonoBehaviour
    {
        [SerializeField, Header("判定するの範囲")] Vector3 colliderSize;
        [SerializeField, Header("風の力")] float windPower;
        [SerializeField, Header("飛ぶ方向")] Vector3 windDirection;

        private void Start()
        {
            BoxCollider collider = GetComponent<BoxCollider>();
            collider.size = colliderSize;
        }

        //コライダー内にいる時風のギミックが発動
        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Rigidbody rb = other.GetComponent<Rigidbody>();
                rb.AddForce(windDirection * windPower * Time.deltaTime, ForceMode.Force);
            }
        }
    }
}
