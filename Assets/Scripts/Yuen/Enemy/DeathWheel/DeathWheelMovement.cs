using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yuen.Enemy.DeathWheel
{
    public class DeathWheelMovement : MonoBehaviour
    {
        [SerializeField, Header("回転するスピード")] int rotationSpeed;
        [SerializeField, Header("減速するスピード")] float slowdownSpeed = 1f;
        [SerializeField, Header("止まる角度")] float targetZRotation = 90.0f;

        private bool isSlowingDown = false;

        //Rotationの方向状態
        public enum RotationState
        {
            RightRotation = 0,
            LeftRotation = 1,
            StopRotation = 2
        }
        [SerializeField, Header("DeathWheelの状態変更")] RotationState rotationState;

        // Update is called once per frame
        void Update()
        {
            Rotation();
        }

        //DeathWheelの状態変更
        void Rotation()
        {
            switch (rotationState)
            {
                case RotationState.RightRotation:
                    transform.eulerAngles -= new Vector3(0, 0, rotationSpeed * Time.deltaTime);
                    break;
                case RotationState.LeftRotation:
                    transform.eulerAngles += new Vector3(0, 0, rotationSpeed * Time.deltaTime);
                    break;
                case RotationState.StopRotation:
                    isSlowingDown = true;
                    StopRotation();
                    break;
            }
        }
        //回転を指定な角度に止める
        void StopRotation()
        {
            if (isSlowingDown)
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, targetZRotation), slowdownSpeed * Time.deltaTime);

                if (Mathf.Abs(transform.rotation.eulerAngles.z - targetZRotation) < 1.0f)
                {
                    isSlowingDown = false;
                }
            }
        }
        
        public void ChangeRotationState(RotationState rotation)
        {
            rotationState = rotation;
        }
    }
}
