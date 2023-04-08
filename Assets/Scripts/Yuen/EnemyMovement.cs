using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    int moveSpeed;
    [SerializeField]
    Vector3 leftPoint, rightPoint;

    bool movingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        //縦のpositionを固定
        rightPoint.y = transform.position.y;
        leftPoint.y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    //エネミーの動き
    void Move()
    {
        //右判定
        if (transform.position.x >= rightPoint.x)
        {
            movingRight = true;
        }
        if (transform.position.x <= leftPoint.x)
        {
            movingRight = false;
        }
        //右方向か左方向
        if (movingRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, leftPoint, moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, rightPoint, moveSpeed * Time.deltaTime);
        }
    } 
}
