using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    [SerializeField] Transform balloonSpawn;
    [HideInInspector] public int balloonNumber;

    float upwardPower;

    Rigidbody rb;
    Vector2 movementinput;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //reset ball number
        balloonNumber = 0;
    }

    #region new input system
    //Player Movement 
    public void Move(InputAction.CallbackContext callback)
    {
        if (callback.performed) return;
        movementinput = callback.ReadValue<Vector2>();
        //Debug.Log(movementinput);
    }

    //Player add balloon
    public void AddBall(InputAction.CallbackContext callback) 
    {
        if (!callback.started) return;

        //ball spawn
        Instantiate(playerData.balloon[balloonNumber], balloonSpawn);
        //ball counter ++
        balloonNumber++;
    }

    //player reduce balloon
    public void DestoryBall(InputAction.CallbackContext callback) 
    {
        if (!callback.started) return;

        //ball counter --
        balloonNumber--;
        //destory ball object
        Destroy(balloonSpawn.transform.GetChild(balloonNumber).gameObject);
    }

    //player take iteam
    public void TakeIteam(InputAction.CallbackContext callback) 
    {
        if (!callback.started) return;
        
        //take iteam
        Debug.Log("take");
        
    }

    //player use skill
    public void UseSkill()
    {
        
    }

    #endregion

    //upwardPower
    void Floating()
    {
        switch (balloonNumber)
        {
            case 0:
                upwardPower = playerData.BalloonGravity[0];
                break;
            case 1:
                upwardPower = playerData.BalloonGravity[1];
                break;
            case 2:
                upwardPower = playerData.BalloonGravity[2];
                break;
            case 3:
                upwardPower = playerData.BalloonGravity[3];
                break;
            case 4:
                upwardPower = playerData.BalloonGravity[4];
                break;
            case 5:
                upwardPower = playerData.BalloonGravity[5];
                break;
            case 6:
                upwardPower = playerData.BalloonGravity[6];
                break;
        }
    }

    private void FixedUpdate()
    {
        //floating at number of balloon 
        Floating();
        //player movement
        rb.AddForce(movementinput.x * playerData.GetMoveSpeed() * Time.deltaTime, upwardPower * Time.deltaTime, 0, ForceMode.Force);
        //rb.velocity = new Vector3(movementinput.x * playerData.GetMoveSpeed() * Time.deltaTime, playerData.GetWeight() * upwardPower * Time.deltaTime, 0);

        //count balloon not to over or less than 0
        if (balloonNumber >= playerData.balloon.Length)
        {
            balloonNumber = playerData.balloon.Length;
        }
        if (balloonNumber <= 0)
        {
            balloonNumber = 0;
        }
    }
}
