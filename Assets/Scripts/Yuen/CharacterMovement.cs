using UnityEngine;
using UnityEngine.InputSystem;
using UniRx;
using UniRx.Triggers;
using System;
using Sora_Extemsion;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] Transform balloonSpawn;

    private int balloonInflateCount = 0;

    private float upwardPower = 0f;
    private float gravity;
    //スキル実行時に
    private float spead;

    private GameObject balloonParent;
    private PlayerData data;

    private bool isSlkill = false;
    private bool isBalloon = false;
    private bool isPoolEnd = false;
    private bool isForBalloon = false;
    private bool isFiveBalloon = false;
    private bool isGround = false;

    private List<GameObject> havingBalloonList = new List<GameObject>();
    private List<GameObject> useBalloonList = new List<GameObject>();

    Rigidbody rb;
    Vector2 movementinput;

    private Subject<Unit> deadFlag = new Subject<Unit>();

    private async void Awake()
    {
        rb = GetComponent<Rigidbody>();
        data = await AddressLoader.AddressLoder<PlayerData>(AddressableAssetAddress.PLAYER_DATA);
        balloonParent = GameObject.FindGameObjectWithTag(TagName.BalloonParent);
    }
    private async void Start()
    {
        await UniTask.WaitUntil(() => data != null && balloonParent != null);
        spead = data.GetMoveSpeed();
        gravity = -data.GetPlayerGravity();
        CreateBalloon();

        this.UpdateAsObservable()
            .Subscribe(_ => PlayerMove())
            .AddTo(gameObject);
    }

    //移動処理
    public void Move(InputAction.CallbackContext callback)
    {
        movementinput = callback.ReadValue<Vector2>();
    }

    //風船の追加
    public void AddBall(InputAction.CallbackContext callback)
    {
        if (!callback.performed || !isPoolEnd) return;

        if (balloonInflateCount < data.GetMaxBalloonLimit())
        {
            upwardPower += data.GetUpwardQuantity();
            GameObject balloon = havingBalloonList[0];
            havingBalloonList.RemoveAt(0);
            useBalloonList.Add(balloon);
            balloon.transform.parent = balloonSpawn;
            balloon.SetActive(true);
            if (balloonInflateCount < 6)
            {
                balloon.transform.position = new Vector3(-0.6f + 0.3f * balloonInflateCount, 1.8f, 0);
            }
            else
            {
                balloon.transform.position = new Vector3(-0.1f + 0.3f * (balloonInflateCount - 6), 2.6f, 0);
            }
            balloonInflateCount++;
            if (balloonInflateCount == 4)
            {
                isForBalloon = true;
            }
            else if (balloonInflateCount == 5)
            {
                isFiveBalloon = true;
            }
        }
    }

    /// <summary>
    /// 風船をPoolする
    /// </summary>
    private async void CreateBalloon()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject balloon = await AddressLoader.AddressLoder<GameObject>(AddressableAssetAddress.BALLOON_BLUE);
            havingBalloonList.Add(Instantiate(balloon, balloonParent.transform));

            balloon = await AddressLoader.AddressLoder<GameObject>(AddressableAssetAddress.BALLOON_ORENZI);
            havingBalloonList.Add(Instantiate(balloon, balloonParent.transform));

            balloon = await AddressLoader.AddressLoder<GameObject>(AddressableAssetAddress.BALLOON_RED);
            havingBalloonList.Add(Instantiate(balloon, balloonParent.transform));

            balloon = await AddressLoader.AddressLoder<GameObject>(AddressableAssetAddress.BALLOON_WHITE);
            havingBalloonList.Add(Instantiate(balloon, balloonParent.transform));

            balloon = await AddressLoader.AddressLoder<GameObject>(AddressableAssetAddress.BALLOON_YELLOW);
            havingBalloonList.Add(Instantiate(balloon, balloonParent.transform));

            balloon = await AddressLoader.AddressLoder<GameObject>(AddressableAssetAddress.BALLOON_GREAN);
            havingBalloonList.Add(Instantiate(balloon, balloonParent.transform));
        }

        foreach (GameObject balloon in havingBalloonList)
        {
            balloon.SetActive(false);
        }
        isPoolEnd = true;
    }

    //player reduce balloon
    public void DestoryBall(InputAction.CallbackContext callback)
    {
        if (!callback.started) return;
        BalloonDestroy();
    }

    /// <summary>
    /// 風船をすべて消す
    /// </summary>
    public void BalloonAllDestroy()
    {
        isBalloon = true;
        int currentBallonValue = balloonInflateCount;
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
        balloonInflateCount--;
        upwardPower -= data.GetUpwardQuantity();
        //destory ball object
        if (balloonInflateCount >= 0)
        {
            // 風船をPoolにしまう
            GameObject balloon = useBalloonList[0];
            useBalloonList.RemoveAt(0);
            havingBalloonList.Add(balloon);
            balloon.transform.parent = balloonParent.transform;
            balloon.SetActive(false);
        }
    }

    //player take iteam
    public void TakeIteam(InputAction.CallbackContext callback)
    {
        if (!callback.started) return;

        //take iteam
        Debug.Log("take");

    }

    #region skill
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

    /// <summary>
    /// プレイヤーの移動本体
    /// </summary>
    private void PlayerMove()
    {
        if (isSlkill)
        {
            rb.velocity = new Vector3(movementinput.x * spead, movementinput.y * spead, 0);
        }
        else
        {
            HeightupperLimitr();
            rb.velocity = new Vector3(movementinput.x * spead, gravity + upwardPower, 0);
        }
    }

    /// <summary>
    /// 高さ上限を設定
    /// </summary>
    private void HeightupperLimitr()
    {
        switch (balloonInflateCount)
        {
            case 0:
            case 1:
            case 2:
            case 3:
                if (isGround)
                {
                    upwardPower = 3;
                }
                else
                {
                    upwardPower = data.GetUpwardQuantity() * balloonInflateCount;
                }
                break;
            case 4:
                if (transform.position.y >= data.GetFourBalloonUpwardMax())
                {
                    if (isForBalloon)
                    {
                        upwardPower -= data.GetUpwardQuantity();
                        isForBalloon = false;
                    }
                    else
                    {
                        if (upwardPower >= (data.GetUpwardQuantity() * balloonInflateCount - 1))
                        {
                            upwardPower -= data.GetUpwardQuantity();
                        }
                    }
                }
                else
                {
                    if (!isForBalloon)
                    {
                        upwardPower += data.GetUpwardQuantity();
                        isForBalloon = true;
                    }
                }
                break;
            case 5:
                if (transform.position.y >= data.GetFiveBalloonUpwardMax())
                {
                    if (isFiveBalloon)
                    {
                        upwardPower -= data.GetUpwardQuantity();
                        isFiveBalloon = false;
                    }
                    else
                    {
                        if (upwardPower >= (data.GetUpwardQuantity() * balloonInflateCount - 1))
                        {
                            upwardPower -= data.GetUpwardQuantity();
                        }
                    }
                }
                else
                {
                    if (!isFiveBalloon)
                    {
                        upwardPower += data.GetUpwardQuantity();
                        isFiveBalloon = true;
                    }
                }
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 地面判定
    /// </summary>
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag(TagName.Ground))
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        isGround = false;
    }

    private void IsGround()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, 1f))
        {
            if (hit.collider.CompareTag(TagName.Ground))
            {
                isGround = true;
            }
            else
            {
                isGround = false;
            }
        }
        else
        {
            isGround = false;
        }
    }
}
