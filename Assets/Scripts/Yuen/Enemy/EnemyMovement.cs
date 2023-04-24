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
        //�c��position���Œ�
        rightPoint.y = transform.position.y;
        leftPoint.y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    //�G�l�~�[�̓���
    void Move()
    {
        //�E����
        if (transform.position.x >= rightPoint.x)
        {
            movingRight = true;
        }
        if (transform.position.x <= leftPoint.x)
        {
            movingRight = false;
        }
        //�E������������
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
