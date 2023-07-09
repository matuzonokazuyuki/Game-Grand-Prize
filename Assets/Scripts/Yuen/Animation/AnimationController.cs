using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yuen.Animation
{
    public class AnimationController : MonoBehaviour
    {
        [SerializeField] Animator playerAnimator;
        [SerializeField] Animator switch001Animator;
        [SerializeField] Animator switch002Animator;
        private void Awake()
        {
            InitializeAnimator();
        }
        public void InitializeAnimator() 
        {
            OnMoveAnimation(false);
            OnHitAnimation(false);
            OnInflateAnimation(false);
            OnGoalAnimation(false);
            OnDeadAnimation(false);
            OnSwitch001Animation(false);
            OnSwitch002Animation(false);
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
        public void OnSwitch001Animation(bool switched)
        {
            switch001Animator.SetBool("isSwitch", switched);
        }
        public void OnSwitch002Animation(bool switched)
        {
            switch002Animator.SetBool("isSwitch", switched);
        }
    }
}
