using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    [SerializeField, Header("鳥の移動スピード設定")] int moveSpeed;
    [SerializeField, Header("鳥が迂回するポジション(左)")] Vector3 leftPoint;
    [SerializeField, Header("鳥が迂回するポジション(右)")] Vector3 rightPoint;

    Vector3 startPoisition;
    Vector3 nowPoisition;


    // Start is called before the first frame update
    void Start()
    {
        //上下position固定
        rightPoint.y = transform.position.y;
        leftPoint.y = transform.position.y;

        startPoisition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        nowPoisition = transform.position;
        Move();
    }
    //鳥の移動
    void Move()
    {
        if(nowPoisition == startPoisition + leftPoint)
        {
            transform.position = Vector3.MoveTowards(transform.position, leftPoint, moveSpeed * Time.deltaTime);
        }
        else if (nowPoisition == startPoisition - leftPoint)
        {
            transform.position = Vector3.MoveTowards(transform.position, rightPoint, moveSpeed * Time.deltaTime);
        }



        ////右行くがどうか
        //if (transform.position.x >= startPoisition.x + rightPoint.x)
        //{
        //    movingRight = true;
        //}
        //if (transform.position.x <= startPoisition.x + leftPoint.x)
        //{
        //    movingRight = false;
        //}
        ////方向とスビートの調整
        //if (movingRight)
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, leftPoint, moveSpeed * Time.deltaTime);
        //}
        //else
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, rightPoint, moveSpeed * Time.deltaTime);
        //}
    }
}
