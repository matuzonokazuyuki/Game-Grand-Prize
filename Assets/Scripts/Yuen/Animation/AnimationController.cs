using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yuen.Animation
{
    public class AnimationController : MonoBehaviour
    {
        [SerializeField] Animator playerAnimator;


        private void Awake()
        {
            InitializePlayerAnimator();
        }
        public void InitializePlayerAnimator() 
        {
            OnMoveAnimation(false);
            OnHitAnimation(false);
            OnInflateAnimation(false);
            OnGoalAnimation(false);
            OnDeadAnimation(false);
        }

        public void OnMoveAnimation(bool move)
        {
            playerAnimator.SetBool("isMove", move);

        }
        public void OnHitAnimation(bool hit)
        {
            playerAnimator.SetBool("isHit", hit);

        }
        public void OnInflateAnimation(bool inflate)
        {
            playerAnimator.SetBool("isInflate", inflate);

        }
        public void OnGoalAnimation(bool goal)
        {
            playerAnimator.SetBool("isGoal", goal);

        }
        public void OnDeadAnimation(bool dead)
        {
            playerAnimator.SetBool("isDead", dead);

        }
    }
}
