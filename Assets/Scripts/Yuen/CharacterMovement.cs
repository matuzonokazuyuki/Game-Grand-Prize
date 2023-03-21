using UnityEngine;
using UnityEngine.InputSystem;
using UniRx;
using System;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    [SerializeField] Transform balloonSpawn;
    [HideInInspector] public int balloonNumber;

    float upwardPower;
    //スキル実行時に
    private float spead;

    private bool isSlkill = false;
    private bool isBalloon = false;

    Rigidbody rb;
    Vector2 movementinput;

    private Subject<Unit> deadFlag = new Subject<Unit>();

    private void Awake()
    {
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
    }

    //Player add balloon
    public void AddBall(InputAction.CallbackContext callback)
    {
        if (!callback.started) return;

        //ball spawn
        if (balloonNumber < playerData.balloon.Length)
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
        if (balloonNumber >= 0)
            Destroy(balloonSpawn.transform.GetChild(balloonNumber).gameObject);
    }

    /// <summary>
    /// 風船をすべて消す
    /// </summary>
    public void BalloonAllDestroy()
    {
        isBalloon = true;
        int currentBallonValue = balloonNumber;
        for (int i = 0; i < currentBallonValue; i++)
        {
            BalloonDestroy();
            if (i == currentBallonValue)
            {
                isBalloon = false;
            }

        }
    }
    /// <summary>
    /// 風船を消す
    /// </summary>
    public void BalloonDestroy()
    {
        balloonNumber--;
        if (balloonNumber >= 0)
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
        isSlkill = true;
        rb.useGravity = false;
        spead += skillPower;
    }

    /// <summary>
    /// スキル時間が終わったら
    /// </summary>
    public void EndSkill(float skillPower)
    {
        isSlkill = false;
        rb.useGravity = true;
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

    /// <summary>
    /// 死んだと通知
    /// </summary>
    public void Dead()
    {
        if (!isBalloon)
        {
            deadFlag.OnNext(Unit.Default);
        }
    }

    public IObservable<Unit> GetDeadFlag()
    {
        return deadFlag;
    }

    private void FixedUpdate()
    {
        //floating at number of balloon
        Floating();
        //player movement
        //スキル使用時
        if (isSlkill)
        {
            rb.velocity = new Vector3(movementinput.x * spead * Time.deltaTime, movementinput.y * spead * Time.deltaTime, 0);
        }
        else
        {
            rb.AddForce(movementinput.x * spead * Time.deltaTime, upwardPower * Time.deltaTime, 0, ForceMode.Force);
            //rb.velocity = new Vector3(movementinput.x * playerData.GetMoveSpeed() * Time.deltaTime, playerData.GetWeight() * upwardPower * Time.deltaTime, 0);
        }
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
