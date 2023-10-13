using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yuen.Enemy
{
    public class ClownDead : MonoBehaviour
    {
        [SerializeField] GameObject rock;
        [SerializeField] Animator animator;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject == rock)
            {
                Dead();
            }
        }

        private void Dead()
        {
            animator.SetBool("IsDead", true);
        }
        public void ResetAnimation()
        {
            animator.SetBool("IsDead", false);
        }


    }
}
