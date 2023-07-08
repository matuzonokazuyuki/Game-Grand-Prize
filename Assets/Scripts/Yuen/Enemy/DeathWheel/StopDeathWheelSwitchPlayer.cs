using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yuen.Animation;

namespace Yuen.Enemy.DeathWheel
{
    public class StopDeathWheelSwitchPlayer : MonoBehaviour
    {
        public bool isPlayer = false;
        [SerializeField] AnimationController animatoAnimator;

        //プレイヤーに当たったらスイッチオン
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                isPlayer = true;
                animatoAnimator.OnSwitch001Animation(true);
            }
        }

    }
}
