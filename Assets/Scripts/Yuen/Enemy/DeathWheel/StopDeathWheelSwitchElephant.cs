using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yuen.Animation;

namespace Yuen.Enemy.DeathWheel
{
    public class StopDeathWheelSwitchElephant : MonoBehaviour
    {
        public bool isElephant = false;
        [SerializeField] private AnimationController animatoAnimator;


        //象に当たったらスイッチオン
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Elephant"))
            {
                isElephant = true;
                animatoAnimator.OnSwitch002Animation(true);
            }
        }
    }
}
