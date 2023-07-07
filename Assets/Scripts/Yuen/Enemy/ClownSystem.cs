using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yuen.Enemy
{
    public class ClownSystem : MonoBehaviour
    {
        [SerializeField] GameObject[] clown;

        private void Awake()
        {
            for (int i = 0; i < clown.Length; i++)
            {
                clown[i].SetActive(true);
            }
        }
        public void ResetClown()
        {
            for (int i = 0; i < clown.Length; i++)
            {
                clown[i].SetActive(true);
            }
        }
    }
}
