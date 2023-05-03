using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yuen.Enemy
{
    public class RussiaFlyMovement : MonoBehaviour
    {
        [SerializeField, Header("スタートのポジション")] private Vector3 positionA;
        [SerializeField, Header("エンドのポジション")] private Vector3 positionB;
        [SerializeField, Header("飛ぶ時の高さ")] private float height;
        [SerializeField, Header("移動スピード")] private float speed;

        private void Start()
        {
            StartCoroutine(SwingMotion());
        }

        private IEnumerator SwingMotion()
        {
            while (true)
            {
                // AからBへの放物線移動
                Vector3 startPosition = positionA;
                Vector3 endPosition = positionB;
                float distance = Vector3.Distance(startPosition, endPosition);
                float journeyTime = distance / speed;

                for (float t = 0f; t < journeyTime; t += Time.deltaTime)
                {
                    float fraction = t / journeyTime;
                    fraction = Mathf.Clamp01(fraction);
                    float heightOffset = Mathf.Sin(fraction * Mathf.PI) * -height;
                    transform.position = Vector3.Lerp(startPosition, endPosition, fraction) + Vector3.up * heightOffset;
                    yield return null;
                }

                // BからAへの放物線移動
                startPosition = positionB;
                endPosition = positionA;
                distance = Vector3.Distance(startPosition, endPosition);
                journeyTime = distance / speed;

                for (float t = 0f; t < journeyTime; t += Time.deltaTime)
                {
                    float fraction = t / journeyTime;
                    fraction = Mathf.Clamp01(fraction);
                    float heightOffset = Mathf.Sin(fraction * Mathf.PI) * -height;
                    transform.position = Vector3.Lerp(startPosition, endPosition, fraction) + Vector3.up * heightOffset;
                    yield return null;
                }
            }
        }
    }
}
