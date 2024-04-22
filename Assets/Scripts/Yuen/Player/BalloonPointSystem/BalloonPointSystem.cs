using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yuen.Item
{
    public class BalloonPointSystem : MonoBehaviour
    {
        [SerializeField] private GameObject[] BallPointObject;

        private void Awake()
        {
            InitializeBallPoint();
        }

        /// <summary>
        /// リセット
        /// </summary>
        public void InitializeBallPoint()
        {
            if(BallPointObject == null) return;

            for (int i = 0; i < BallPointObject.Length; i++)
            {
                BallPointObject[i].gameObject.SetActive(true);
            }
        }
    }
}
