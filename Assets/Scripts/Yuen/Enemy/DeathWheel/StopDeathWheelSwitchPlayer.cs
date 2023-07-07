using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yuen.Enemy.DeathWheel
{
    public class StopDeathWheelSwitchPlayer : MonoBehaviour
    {
        public bool isPlayer = false;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                isPlayer = true;
            }
        }

    }
}
