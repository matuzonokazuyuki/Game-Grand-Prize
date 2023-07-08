using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yuen.Enemy.DeathWheel;
using static Yuen.Enemy.DeathWheel.DeathWheelMovement;

namespace Yuen.Enemy.DeathWheel
{
    public class StopDeathWheelSystem : MonoBehaviour
    {
        [SerializeField] StopDeathWheelSwitchPlayer player;
        [SerializeField] StopDeathWheelSwitchElephant elephant;

        [SerializeField] DeathWheelMovement[] deathWheelMovement;

        private void Awake()
        {
            ResetSwitch();
        }

        //スイッチのリセット
        public void ResetSwitch()
        {
            player.isPlayer = false;
            elephant.isElephant = false;
        }

        private void Update()
        {
            Switch();
        }

        //全部のDeathWheelを止める
        void Switch()
        {
            if (player.isPlayer == true && elephant.isElephant == true)
            {
                for(int i = 0; i < deathWheelMovement.Length; i++)
                {
                    deathWheelMovement[i].ChangeRotationState(RotationState.StopRotation);
                }
            }
        }
    }
}
