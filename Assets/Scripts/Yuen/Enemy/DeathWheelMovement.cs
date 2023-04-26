using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeathWheelMovement : MonoBehaviour
{
    [SerializeField]
    int rotationSpeed;

    //Rotationの方向状態
    public enum RotationState
    {
        RightRotation,
        LeftRotation
    }
    [SerializeField]
    RotationState rotationState;

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }

    private void OnCollisionEnter(Collision collision)
    {

    }

    //Rotationの方向変更
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
        }
    }
}
