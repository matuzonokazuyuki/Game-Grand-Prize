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

        //初期化
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

        //プレイヤー移動アニメーション
        public void OnMoveAnimation(bool move)
        {
            playerAnimator.SetBool("isMove", move);

        }

        //プレイヤー攻撃受けたアニメーション
        public void OnHitAnimation(bool hit)
        {
            playerAnimator.SetBool("isHit", hit);

        }

        //プレイヤー風船吹くアニメーション
        public void OnInflateAnimation(bool inflate)
        {
            playerAnimator.SetBool("isInflate", inflate);

        }

        //プレイヤーゴールしたアニメーション
        public void OnGoalAnimation(bool goal)
        {
            playerAnimator.SetBool("isGoal", goal);

        }

        //プレイヤー死亡アニメーション
        public void OnDeadAnimation(bool dead)
        {
            playerAnimator.SetBool("isDead", dead);

        }

        //プレイヤーが踏むボタンのアニメーション
        public void OnSwitch001Animation(bool switched)
        {
            if(switch001Animator == null) return;
            switch001Animator.SetBool("isSwitch", switched);
        }

        //象が踏むボタンのアニメーション
        public void OnSwitch002Animation(bool switched)
        {
            if(switch002Animator == null) return;
            switch002Animator.SetBool("isSwitch", switched);
        }
    }
}
