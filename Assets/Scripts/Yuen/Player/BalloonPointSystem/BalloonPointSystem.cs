using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yuen.Item
{
    public class BalloonPointSystem : MonoBehaviour
    {
        [SerializeField] GameObject[] BallPointObject;

        private void Awake()
        {
            InitializeBallPoint();
        }
        public void InitializeBallPoint()
        {
            for (int i = 0; i < BallPointObject.Length; i++)
            {
                BallPointObject[i].gameObject.SetActive(true);
            }
        }
    }
}
