using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ClownAttack : MonoBehaviour
{
    [SerializeField] float detectionRadius = 10f; //索敵範囲
    float distanceToPlayer;

    [SerializeField] GameObject player;
    bool playerInRange;
    float nextAttackTime;

    [SerializeField] GameObject knifeObject;
    [SerializeField] float knifeSpeed, knifeDestroyTime;

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        playerInRange = distanceToPlayer <= detectionRadius;

        //プレイヤーが攻撃範囲内にいるかどうか
        if (!playerInRange) return;
        nextAttackTime += Time.deltaTime;
        Attack();
    }

    //攻撃する
    void Attack()
    {
        if (nextAttackTime >= 1)
        {
            nextAttackTime = 0;

            //GameObject knife = Instantiate(knifeObject, transform.position, Quaternion.identity);
            //Vector2 direction = (player.transform.position - transform.position).normalized;
            //knife.GetComponent<Rigidbody>().velocity = direction * knifeSpeed;

            GameObject knife = Instantiate(knifeObject, transform.position, Quaternion.identity);

            Vector3 direction = player.transform.position - transform.position;
            float distance = direction.magnitude;
            Vector3 velocity = direction / distance * knifeSpeed;

            knife.GetComponent<Rigidbody>().velocity = velocity;

            //UniRxをのObservable.Timerを使いナイフオブジェクトを消す
            Observable.Timer(System.TimeSpan.FromSeconds(knifeDestroyTime)).Subscribe(_ =>
            {
                if (knife != null)
                {
                    Destroy(knife);
                }
            });
        }
    }

    //エディター上のみ索敵範囲を表示します
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
