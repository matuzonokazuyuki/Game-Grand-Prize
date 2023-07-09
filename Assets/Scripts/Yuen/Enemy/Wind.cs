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
        public Rigidbody rb;
        private bool isInWind = false;

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
                isInWind = true;
                rb.AddForce(windDirection * windPower * Time.deltaTime, ForceMode.Impulse);
                Debug.Log("in wind");
            }
        }
        private void OnTriggerExit(Collider other)
        {
            isInWind = false;
            //rb.AddForce(0, 0, 0, ForceMode.Impulse);
            Debug.Log("out wind");

        }
        private void FixedUpdate()
        {
            if (!isInWind)
            {
                rb.velocity = Vector3.zero;
            }
        }
    }
}
