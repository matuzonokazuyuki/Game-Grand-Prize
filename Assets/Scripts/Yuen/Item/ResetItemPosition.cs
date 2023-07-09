using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Yuen.Item
{
    public class ResetItemPosition : MonoBehaviour
    {
        private Vector3[] originalPositions;
        private Transform[] itemTransforms;

        private void Awake()
        {
            // アイテムの元の位置情報を保持するための配列を初期化
            itemTransforms = new Transform[transform.childCount];
            originalPositions = new Vector3[transform.childCount];

            // アイテムの元の位置情報を取得
            for (int i = 0; i < transform.childCount; i++)
            {
                itemTransforms[i] = transform.GetChild(i);
                originalPositions[i] = itemTransforms[i].position;
            }
            ResetPosition();
        }

        public void ResetPosition()
        {
            // アイテムのポジションを元の位置にリセット
            for (int i = 0; i < itemTransforms.Length; i++)
            {
                itemTransforms[i].position = originalPositions[i];
            }
        }
    }
}
