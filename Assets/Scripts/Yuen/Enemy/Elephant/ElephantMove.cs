using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Yuen.Enemy.Elephant
{
    public class ElephantMove : MonoBehaviour
    {
        [SerializeField] Transform targetObject;
        [SerializeField, Header("移動スピード")] float moveSpeed;
        [SerializeField] float arrivalThreshold;

        public bool isMoving = false;
        bool isUse;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Boom"))
            {
                MoveToTarget();
            }

        }
        private void Update()
        {
            //移動
            if (isMoving && !isUse)
            {
                Vector3 targetDirection = (targetObject.position - transform.position).normalized;
                transform.position += targetDirection * moveSpeed * Time.deltaTime;

                if (Vector3.Distance(transform.position, targetObject.position) <= arrivalThreshold)
                {
                    StopMoving();
                }
            }
        }
        //移動開始
        private void MoveToTarget()
        {
            isMoving = true;
        }
        //移動を止める
        private void StopMoving()
        {
            isMoving = false;
            Used(true);
        }
        /// <summary>
        /// 一回しか使えないよ
        /// </summary>
        /// <param name="isUsed">使った</param>
        public void Used(bool isUsed)
        {
            isUse = isUsed;
        }
    }
}
