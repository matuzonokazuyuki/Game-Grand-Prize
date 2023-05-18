using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using System.Threading;

namespace Yuen.Enemy
{
    public class ClownAttack : MonoBehaviour
    {
        [SerializeField, Header("プレイヤーのオブジェクト")] GameObject player;

        [SerializeField, Header("ピエロの索敵範囲")] float detectionRadius = 10f;

        [SerializeField, Header("投げるオブジェクト")] GameObject knifeObject;
        [SerializeField, Header("次に投げるの間隔")] float nextAttackTime;
        [SerializeField, Header("投げ物の飛ぶスピード")] float knifeSpeed;
        [SerializeField, Header("投げ物が壊れる時間(秒)")] float knifeDestroyTime;

        float attackTime;
        float distanceToPlayer;
        bool playerInRange;

        private void Start()
        {
            if(player == null)
            {
                Debug.Log("プレイヤーのオブジェクトを付けてください");
            }
            if(knifeObject == null)
            {
                Debug.Log("ナイフのオブジェクトを付けてください");
            }
        }

        // Update is called once per frame
        void Update()
        {
            distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            playerInRange = distanceToPlayer <= detectionRadius;

            //プレイヤーが攻撃範囲内にいるかどうか
            if (!playerInRange) return;
            attackTime += Time.deltaTime;
            Attack();
        }

        //攻撃する
        void Attack()
        {
            if (attackTime >= nextAttackTime)
            {
                attackTime = 0;

                GameObject knife = Instantiate(knifeObject, transform.position, Quaternion.identity);

                Vector3 direction = player.transform.position - transform.position;
                float distance = direction.magnitude;
                Vector3 velocity = direction / distance * knifeSpeed;

                knife.GetComponent<Rigidbody>().velocity = velocity;

                Observable.Timer(System.TimeSpan.FromSeconds(knifeDestroyTime)).Subscribe(_ =>
                {
                    if (knife != null)
                    {
                        Destroy(knife);
                    }
                }).AddTo(this);
            }
        }

        //エディター上のみ索敵範囲を表示します
        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, detectionRadius);
        }

        private void OnDestroy()
        {

        }
    }
}
