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
    //スキル実行時に
    private float spead;

    private BoxCollider playerCollider;
    Rigidbody rb;
    Vector2 movementinput;

    private void Awake()
    {
        playerCollider = GetComponent<BoxCollider>();
        spead = playerData.GetMoveSpeed();
    }
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
    public void UseSkill(float skillPower)
    {
        playerCollider.enabled = false;
        spead += skillPower;
    }

    /// <summary>
    /// スキル時間が終わったら
    /// </summary>
    public void EndSkill(float skillPower)
    {
        playerCollider.enabled = true;
        spead -= skillPower;
    }

    #endregion

    //upwardPower
    void Floating()
    {
        if (balloonNumber >= 0 && balloonNumber < playerData.BalloonGravity.Length)
        {
            upwardPower = playerData.BalloonGravity[balloonNumber];
        }
    }

    private void FixedUpdate()
    {
        //floating at number of balloon 
        Floating();
        //player movement
        rb.AddForce(movementinput.x * spead * Time.deltaTime, upwardPower * Time.deltaTime, 0, ForceMode.Force);
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
