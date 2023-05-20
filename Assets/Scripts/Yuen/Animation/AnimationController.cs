using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yuen.Animation
{
    public class AnimationController : MonoBehaviour
    {
        [SerializeField] Animator playerAnimator;

        bool move;
        bool hit;
        bool inflate;
        bool goal;
        bool dead;

        private void Awake()
        {
            InitializePlayerAnimator();
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        public void InitializePlayerAnimator() 
        {
             move = false;
             hit = false;
             inflate = false;
             goal = false;
             dead = false;
        }


        // Update is called once per frame
        void Update()
        {
            playerAnimator.SetBool("isMove", move);
            playerAnimator.SetBool("isHit", hit);
            playerAnimator.SetBool("isInflate", inflate);
            playerAnimator.SetBool("isGoal", goal);
            playerAnimator.SetBool("isDead", dead);
        
        }
    }
}
