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

        public bool isMoving;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Boom"))
            {
                MoveToTargetPosition();
            }
        }
        private void Update()
        {
            if (isMoving)
            {
                float distance = Vector3.Distance(transform.position, targetPosition);
                float journeyTime = distance / moveSpeed;

                for (float t = 0f; t < journeyTime; t += Time.deltaTime)
                {
                    float fraction = t / journeyTime;
                    fraction = Mathf.Clamp01(fraction);
                    transform.position = Vector3.Lerp(transform.position, targetPosition, fraction);
                }

            }
        }

        private void MoveToTargetPosition()
        {
            isMoving = true;
        }
    }
}
