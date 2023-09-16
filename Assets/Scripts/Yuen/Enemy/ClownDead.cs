using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yuen.Enemy
{
    public class ClownDead : MonoBehaviour
    {
        [SerializeField] GameObject rock;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject == rock)
            {
                Dead();
            }
        }

        void Dead()
        {
           this.gameObject.SetActive(false);
        }


    }
}
