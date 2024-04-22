using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yuen.Enemy
{
    public class ClownSystem : MonoBehaviour
    {
        [SerializeField] private GameObject[] clown;

        private void Awake()
        {
            ResetClown();
        }

        /// <summary>
        /// リセット
        /// </summary>
        public void ResetClown()
        {
            if(clown == null) return;

            for (int i = 0; i < clown.Length; i++)
            {
                clown[i].SetActive(true);
            }
        }
    }
}
