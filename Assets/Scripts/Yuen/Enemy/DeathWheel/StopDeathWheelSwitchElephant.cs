using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yuen.Enemy.DeathWheel
{
    public class StopDeathWheelSwitchElephant : MonoBehaviour
    {
        public bool isElephant = false;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Elephant"))
            {
                isElephant = true;
            }
        }
    }
}
