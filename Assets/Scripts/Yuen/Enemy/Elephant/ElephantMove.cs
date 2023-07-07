using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Yuen.Enemy.Elephant
{
    public class ElephantMove : MonoBehaviour
    {
        [SerializeField] Vector3 targetPosition;
        [SerializeField] float moveSpeed;

        public bool isMoving = false;
        public bool isUse;
        private float moveStartTime;
        private Vector3 initialPosition;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Boom"))
            {
                MoveToTargetPosition();
            }
        }

        private void Update()
        {
            if (isUse) return;
            if (isMoving && !isUse)
            {
                float elapsedTime = Time.time - moveStartTime;
                float t = Mathf.Clamp01(elapsedTime / moveSpeed);
                transform.position = Vector3.Lerp(initialPosition, targetPosition, t);

                if (t >= 1f)
                {
                    isMoving = false;
                    transform.position = targetPosition;
                    isUse = true;

                }
            }
        }

        private void MoveToTargetPosition()
        {
            initialPosition = transform.position;
            moveStartTime = Time.time;
            isMoving = true;
        }
        public void Used(bool use)
        {
            isUse = use;
        }
    }
}
